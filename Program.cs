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
            string milestone = string.Empty;
            Boolean bClosedOnly = false;
            var configuration = CommandLineParserConfigurator
               .Create()
                   .WithNamed("m", m => milestone = m).Required()
                       .HavingLongAlias("milestone")
                       .DescribedBy("Milestone", "specifies the milestone (i.e. 3.7.4) to get all entries for 3.7.4")
                    .WithSwitch("c", () => bClosedOnly=true)
                    .HavingLongAlias("closed-only")
                    .DescribedBy("Query only closed tickets")
               //.WithNamed("t", w => tgt = new FileInfo(w)).Required()
               //    .HavingLongAlias("target-file")
               //    .DescribedBy("Target File", "specifies the path to the wxs file to be written")
               //.WithNamed("i", i => installFolder = i)
               //    .HavingLongAlias("install-folder")
               //    .DescribedBy("INSTALLFOLDER", "name of the variable that indicates the root folder on the target system of the user. Default is INSTALLFOLDER")
               //.WithNamed("k", k => keyFile = k)
               //    .HavingLongAlias("key-file")
               //    .DescribedBy("Key File", "string that indicates the file to get the product version from (will be KEYFILE identifier in the output)")
               .BuildConfiguration();
            var usage = new UsageComposer(configuration).Compose();
            var parser = new CommandLineParser(configuration);
            var parseResult = parser.Parse(args);

            if (parseResult.Succeeded)
            {
                Api trac = new Api();
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
