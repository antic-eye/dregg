using Appccelerate.CommandLineParser;
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
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = CommandLineParserConfigurator
               .Create()
                   //.WithNamed("s", w => src = new FileInfo(w)).Required()
                   //    .HavingLongAlias("source-file")
                   //    .DescribedBy("Source File", "specifies the path to the csv file to be parsed")
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
            var parser = new CommandLineParser(configuration);
            var parseResult = parser.Parse(args);

            if (parseResult.Succeeded)
            {
                Api trac = new Api();
                NameValueCollection col = new NameValueCollection();
                col.Add("status", "closed");
                col.Add("milestone", "3.5");
                col.Add("keywords", "~#rn");
                col.Add("order", "id");

                StringBuilder lines = new StringBuilder();
                foreach(var res in trac.QueryTickets(col).Result)
                {
                    var changes = trac.GetChanges(res).ChangeList;
                    var r = (from f in changes where f.Action.ToLowerInvariant()=="comment" && f.To.ToLowerInvariant().Contains("#rn") select f);
                    foreach (var o in r)
                        lines.AppendFormat("#{0}: {1}; {2}", res, o.Author, o.To);
                }
                Console.ReadLine();
                
            }
        }

       

       
    }
}
