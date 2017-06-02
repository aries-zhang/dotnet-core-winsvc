using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventHubListener
{
    public class Listener : IEventProcessor
    {
        private static EventProcessorHost eventProcessorHost;

        public static async Task Run(EventHubParameter param)
        {
            Console.WriteLine("Registering EventProcessor...");

            eventProcessorHost = new EventProcessorHost(param.EntityPath, param.ConsumerGroup, param.ConnectionString, param.StorageConnectionString, param.StorageContainer);

            // Registers the Event Processor Host and starts receiving messages
            await eventProcessorHost.RegisterEventProcessorAsync<Listener>();

        }

        public static async Task Close()
        {
            // Disposes of the Event Processor Host
            await eventProcessorHost.UnregisterEventProcessorAsync();
        }

        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine($"Processor Shutting Down. Partition '{context.PartitionId}', Reason: '{reason}'.");
            return Task.CompletedTask;
        }

        public Task OpenAsync(PartitionContext context)
        {
            Console.WriteLine($"SimpleEventProcessor initialized. Partition: '{context.PartitionId}'");
            return Task.CompletedTask;
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            Console.WriteLine($"Error on Partition: {context.PartitionId}, Error: {error.Message}");
            Console.WriteLine(error.StackTrace);
            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (var eventData in messages)
            {
                try
                {
                    Console.WriteLine($"Message: {Encoding.UTF8.GetString(eventData.Body.Array)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
                }
            }

            return context.CheckpointAsync();
        }
    }
}
