using System;
using System.Collections.Generic;
using System.Text;

namespace EventHubListener
{
    public class EventHubParameter
    {
        public string EntityPath { get; set; }
        public string ConsumerGroup { get; set; }
        public string ConnectionString { get; set; }
        public string StorageConnectionString { get; set; }
        public string StorageContainer { get; set; }
    }
}
