using Appccelerate.CommandLineParser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                using (WebClient client = new WebClient())
                {
                    //                    var response = client.UploadString(client.BaseAddress, "{\"params\": [\"WikiStart\"], \"method\": \"wiki.getPage\", \"id\": 123}");
                    //                   HandleHeaders(client);
                    // var response = CallRpc(client, "wiki.getPage", "WikiStart", "123");
                    //var response = CallRpc(client, "ticket.changeLog", "12657", "123");
                    var response = JsonConvert.DeserializeObject(CallRpc(client, "ticket.query", 
                        "status=closed&milestone=3.7.4&keywords=#rn|#RN&order=id", "123"));

                }
            }
        }

        private static void HandleHeaders(WebClient client)
        {
            client.BaseAddress = "***REMOVED***";
            string authInfo = "***REMOVED***";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            client.Headers["Authorization"] = "Basic " + authInfo;
            client.Headers.Add("Content-Type", "application/json");
        }

        private static string CallRpc(WebClient client, string method, string parameters, string id)
        {
            HandleHeaders(client);
            if (String.IsNullOrEmpty(parameters))
                return client.UploadString(client.BaseAddress,
    string.Format(
        "{{ \"method\":\"{1}\", \"id\":\"{2}\" }}",
        parameters, method, id));


            return client.UploadString(client.BaseAddress,
                string.Format(
                    "{{ \"params\": [\"{0}\"], \"method\":\"{1}\", \"id\":\"{2}\" }}",
                    parameters, method, id));
        }
    }
}
