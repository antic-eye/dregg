using Appccelerate.CommandLineParser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dregg
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = string.Empty;
            string password = string.Empty;
            string host = string.Empty;
            string milestone = string.Empty;
            Boolean bClosedOnly = false;
            var configuration = CommandLineParserConfigurator
               .Create()
                   .WithNamed("u", m => user = m)
                       .HavingLongAlias("username")
                       .DescribedBy("Username", "The user name of a user with permission TRAC_XMLRPC. If empty anonymous login is used.")
                   .WithNamed("p", m => password = m)
                       .HavingLongAlias("password")
                       .DescribedBy("Password", "Password of the user given via -u or --username.")
                   .WithNamed("h", m => host = m).Required()
                       .HavingLongAlias("host")
                       .DescribedBy("Host", "XMLRPC url of the trac system; basically https://myhost.mydomain/trac/project1/jsonrpc for anonymous access or https://myhost.mydomain/trac/project1/login/jsonrpc for use with the credentials.")
                   .WithNamed("m", m => milestone = m).Required()
                       .HavingLongAlias("milestone")
                       .DescribedBy("Milestone", "specifies the milestone (i.e. 1.2.3) to get all entries for 1.2.3")
                    .WithSwitch("c", () => bClosedOnly=true)
                    .HavingLongAlias("closed-only")
                    .DescribedBy("Query only closed tickets")
               .BuildConfiguration();
            var usage = new UsageComposer(configuration).Compose();
            var parser = new CommandLineParser(configuration);
            var parseResult = parser.Parse(args);

            if (parseResult.Succeeded)
            {
                Api trac = new Api(host, user, password);
                NameValueCollection col = new NameValueCollection();
                if (bClosedOnly)
                    col.Add("status", "closed");
                col.Add("milestone", milestone);
                col.Add("order", "id");

                string sPath = Path.GetTempFileName().Replace(".tmp", ".csv");
                using (TextWriter writer = new StreamWriter(sPath, false, Encoding.Default))
                {
                    writer.WriteLine("\"Ticket\";\"TicketAuthor\";\"Summary\";\"Release Note Content\"");
                    foreach (var res in trac.QueryTickets(col).Result)
                    {
                        var ticket = trac.GetTicket(res);
                        var changes = trac.GetChanges(res).ChangeList;
                        var r = (from f in changes where f.Action.ToLowerInvariant() == "comment" select f).Distinct();
                        foreach (var o in r)
                            writer.WriteLine("\"#{0}\";\"{1}\";\"{2}\";\"{3}\"", res, o.Author, ticket.Data.Summary, o.To);
                    }
                }
                Process.Start(sPath);
            }
            else
            {
                Console.Error.WriteLine(parseResult.Message);
                Console.Error.WriteLine("usage:" + usage.Arguments);
                Console.Error.WriteLine("options");
                Console.Error.WriteLine(usage.Options.IndentBy(4));
            }
        }
    }
}
