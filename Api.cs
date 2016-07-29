using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dregg
{
    public class Api
    {
        public class TicketQuery
        {
            public string Id { get; set; }
            public string Error { get; set; }
            public int[] Result { get; set; }
        }
        public class Changes
        {
            private List<Change> changeList = new List<Change>();
            public string Id { get; set; }
            public string Error { get; set; }
            public List<List<object>> Result { get; set; }

            public List<Change> ChangeList
            {
                get
                {
                    return ParseObjects(this.Result);
                }
            }

            private List<Change> ParseObjects(List<List<object>> results)
            {
                if (null != results && this.changeList.Count == 0)//only on the first call
                {
                    foreach (var line in results)
                    {
                        if (!line[4].ToString().ToLowerInvariant().Contains("#rn"))
                            continue;

                        Change c = new Change();
                        //skip 0, we do not know how to handle __jsonclass__ properly                   
                        c.Author = line[1].ToString();
                        c.Action = line[2].ToString();
                        c.From = line[3].ToString();
                        c.To = line[4].ToString();
                        c.Id = Convert.ToInt32(line[5]);

                        this.changeList.Add(c);
                    }
                }
                return this.changeList;
            }
        }
        public class Change
        {
            private string to = string.Empty;
            public DateTime Timestamp { get; set; }
            public string Author { get; set; }
            public string Action { get; set; }
            public string From { get; set; }
            public string To
            {
                get
                {
                    return this.to;
                }
                set
                {
                    this.to = ParseText(value);
                }
            }

            private string ParseText(string value)
            {
                StringBuilder dbText = new StringBuilder();
                bool bIsChangeset = false;
                //Check if changeset or comment
                if (value.ToLowerInvariant().StartsWith("in [changeset:"))
                    bIsChangeset = true;

                using (TextReader reader = new StringReader(value))
                {
                    string line = string.Empty;
                    bool bContent = false;
                    bool bRN = false;
                    while (null != (line = reader.ReadLine()))
                    {
                        string lineLowered = line.ToLowerInvariant();
                        if (bIsChangeset && lineLowered.StartsWith("}}}"))
                            bContent = false;
                        if (bContent && bIsChangeset || !bIsChangeset)
                        {
                            if (lineLowered.Contains("#rn"))
                                bRN = true;
                            if (lineLowered.StartsWith("#!committicketreference") || !bRN)
                                continue;

                            int iRNPos = -1;
                            iRNPos = lineLowered.IndexOf("#rn");
                            if (iRNPos > -1)
                                line = line.Substring(iRNPos);

                            dbText.Append(line).Append(" ");
                        }
                        if (bIsChangeset && lineLowered.StartsWith("{{{"))
                            bContent = true;
                    }
                }
                dbText =
                    dbText.Replace("#rn", string.Empty)
                    .Replace("#RN", string.Empty)
                    .Replace("#Rn", string.Empty)
                    .Replace("#rN", string.Empty)
                    .Replace("\"", "\"\"");

                string sRet = dbText.ToString();
                if (sRet.StartsWith(":"))
                    sRet = sRet.Substring(1);
                return sRet;
            }

            public int Id { get; set; }
        }
        //basic data
        private readonly string baseUri = string.Empty;
        private readonly string user = string.Empty;
        private readonly string password = string.Empty;

        public Api() { }
        public Api(string host, string user, string password)
        {
            this.user = user;
            this.password = password;
            this.baseUri = host;
        }

        public class Ticket
        {
            private TicketData data;
            public string Id { get; set; }
            public List<object> Result { get; set; }
            public TicketData Data
            {
                get { return ParseObjects(Result); }
            }
            private TicketData ParseObjects(List<object> results)
            {
                if (null != results && null == this.data)//only on the first call
                {
                    TicketData d = new TicketData();
                    //skip 0, we do not know how to handle __jsonclass__ properly                   
                    d = JsonConvert.DeserializeObject<TicketData>(results[3].ToString());

                    this.data = d;
                }
                return data;
            }
        }
        public class TicketData
        {
            public string Owner { get; set; }
            public string Reporter { get; set; }
            public string Summary { get; set; }
        }

        public Ticket GetTicket(int ticketId)
        {
            string res = CallRpc("ticket.get", ticketId.ToString(), Guid.NewGuid().ToString());
            var response = JsonConvert.DeserializeObject<Ticket>(res);
            string s = response.Data.ToString();
            return (Ticket)response;
        }
        public TicketQuery QueryTickets(NameValueCollection query)
        {
            string res = CallRpc("ticket.query", Col2Query(query), Guid.NewGuid().ToString());
            var response = JsonConvert.DeserializeObject<TicketQuery>(res);

            return response;
        }
        public Changes GetChanges(int ticketId)
        {
            string res = CallRpc("ticket.changeLog", ticketId.ToString(), Guid.NewGuid().ToString());
            var response = JsonConvert.DeserializeObject<Changes>(res);
            response.Id = ticketId.ToString();
            return response;
        }
        private void AddHeaders(WebClient client)
        {
            client.BaseAddress = this.baseUri;
            if (!String.IsNullOrEmpty(this.user))
            {
                string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(string.Format("{0}:{1}", this.user, this.password)));
                client.Headers["Authorization"] = "Basic " + authInfo;
            }
            client.Headers.Add("Content-Type", "application/json");
        }

        private string CallRpc(string method, string parameters, string id)
        {
            string sRet = string.Empty;
            using (WebClient client = new WebClient())
            {
                AddHeaders(client);
                if (String.IsNullOrEmpty(parameters))
                {
                    sRet = client.UploadString(client.BaseAddress, string.Format(
                        "{{ \"method\":\"{1}\", \"id\":\"{2}\" }}",
                        parameters, method, id));
                }
                else
                {
                    sRet = client.UploadString(client.BaseAddress, string.Format(
                        "{{ \"params\": [\"{0}\"], \"method\":\"{1}\", \"id\":\"{2}\" }}",
                        parameters, method, id));
                }
            }
            return sRet;
        }

        private string Col2Query(NameValueCollection col)
        {
            StringBuilder sbQuery = new StringBuilder();
            foreach (string val in col)
            {
                sbQuery.AppendFormat("{0}={1}&", val, col[val]);
            }
            sbQuery.Remove(sbQuery.Length - 1, 1);
            return sbQuery.ToString();
        }
    }
}
