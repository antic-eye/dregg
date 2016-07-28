using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
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
            public DateTime Timestamp { get; set; }
            public string Author { get; set; }
            public string Action { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public int Id { get; set; }
        }
        //basic data
        private readonly string baseUri = "***REMOVED***";
        private readonly string user = "***REMOVED***";
        private readonly string password = "***REMOVED***";

        //

        public Api()
        {

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
            //var res2 = JsonConvert.DeserializeObject<Change>(response.Result[0].ToString());
            return response;
        }
        private void AddHeaders(WebClient client)
        {
            client.BaseAddress = this.baseUri;
            string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(string.Format("{0}:{1}", this.user, this.password)));
            client.Headers["Authorization"] = "Basic " + authInfo;
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
