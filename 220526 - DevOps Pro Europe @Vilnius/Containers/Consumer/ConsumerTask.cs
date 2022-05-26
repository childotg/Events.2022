using Azure.Messaging.ServiceBus;
using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public class ConsumerTask
    {

        public async Task RunAsync()
        {
            var client = new ServiceBusClient(Constants.SBConnection)
               .CreateReceiver(Constants.SBTodoQueue);

            while (true)
            {
                var msg = await client.ReceiveMessageAsync(TimeSpan.FromSeconds(60));
                var message = msg.Body.ToString();
                Console.WriteLine($"Receiving --- {message}");
                await client.CompleteMessageAsync(msg);
                await Task.Delay(1000);
            }
        }
    }
}