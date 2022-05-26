using Azure.Messaging.ServiceBus;
using Common;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Producer
{
    internal class ProducerTask
    {
        public ProducerTask()
        {
        }

        internal async Task RunAsync()
        {
            var client = new ServiceBusClient(Constants.SBConnection)
                .CreateSender(Constants.SBTodoQueue);

            while (true)
            {
                var message = $"Hello! It's {DateTime.UtcNow}";
                Console.WriteLine($"Sending --- {message}");
                await client.SendMessageAsync(new ServiceBusMessage(message));
                await Task.Delay(1000);
            }
            
        }
    }
}