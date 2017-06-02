using EventHubListener;
using System;
using System.Net.Http;

namespace DotnetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var param = new EventHubParameter()
            {
                ConnectionString = "",
                ConsumerGroup = "",
                EntityPath = "",
                StorageConnectionString = "",
                StorageContainer = ""
            };

            Listener.Run(param).Wait();

            Console.Read();
            Console.WriteLine("Press any key to exit...");

            Listener.Close().Wait();
        }
    }
}