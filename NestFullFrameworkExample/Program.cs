using System;
using System.Diagnostics;
using Elastic.Managed.Ephemeral;
using Nest;

namespace NestFullFrameworkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var version = "7.3.0";

            var settings = new ConnectionSettings()
                .DisableDirectStreaming()
                .PrettyJson();
            var client = new ElasticClient(settings);

            using (var cluster = new EphemeralCluster(version, 1))
            {
                cluster.Start();
                var rootNodeInfoResponse = client.RootNodeInfo();
                Console.WriteLine(rootNodeInfoResponse.DebugInformation);
            }

            if (Debugger.IsAttached)
                Console.ReadKey();
        }
    }
}
