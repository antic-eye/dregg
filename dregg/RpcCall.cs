using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dregg
{
    public class RpcCall
    {
        private string csvFormat= "\"Ticket\";\"TicketAuthor\";\"Summary\";\"Release Note Content\";\"Source\"";
        private string outputFormat = "\"=HYPERLINK(\"\"{0}/ticket/{1}\"\"; \"\"#{1}\"\")\";\"{2}\";\"{3}\";\"{4}\";\"{5}\"";
        public string host { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string milestone { get; set; }
        public bool closedOnly { get; set; }
        public void DoCall()
        {
            if (string.IsNullOrEmpty(host))
                throw new ArgumentException("\"host\" is empty! Set the property to a valid host name.");
            else if (string.IsNullOrEmpty(user))
                throw new ArgumentException("\"user\" is empty! Set the property to a valid host name.");
            else if (string.IsNullOrEmpty(password))
                throw new ArgumentException("\"host\" is empty! Set the property to a valid host name.");

            //strip rpc url
            string server = host.Replace("/login/jsonrpc", string.Empty).Replace("/jsonrpc", string.Empty);

            Api trac = new Api(host, user, password);
            NameValueCollection col = new NameValueCollection();
            if (closedOnly)
                col.Add("status", "closed");
            if (!String.IsNullOrEmpty(this.milestone))
                col.Add("milestone", milestone);
            col.Add("order", "id");

            string sPath = Path.GetTempFileName().Replace(".tmp", ".csv");
            using (TextWriter writer = new StreamWriter(sPath, false, Encoding.Default))
            {
                writer.WriteLine(this.csvFormat);
                for (int i = 1; i < 1000; i++)
                {
                    var query = trac.QueryTickets(col, i);

                    if (null == query || null == query.Result || query.Result.Length == 0)
                        break;

                    Trace.WriteLine("Processing page " + i);
                    foreach (var res in query.Result)
                    {
                        var ticket = trac.GetTicket(res);
                        var changes = trac.GetChanges(res).ChangeList;
                        var r = (from f in changes where f.Action.ToLowerInvariant() == "comment" select f).Distinct();
                        List<int> lHashs = new List<int>();
                        foreach (var o in r)
                        {
                            if (lHashs.Contains(ticket.Data.Summary.GetHashCode()))
                                continue;
                            else
                                lHashs.Add(ticket.Data.Summary.GetHashCode());
                            writer.WriteLine(this.outputFormat,
                                server, res, o.Author, ticket.Data.Summary, o.To, ticket.Data.Source);
                        }
                    }
                }
            }
            Process.Start(sPath);
        }
    }
}
