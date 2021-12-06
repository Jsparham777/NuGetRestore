using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMQ.Producer
{
    public static class DirectExchangePublisher
    {
        public static void Publish(IModel channel, int rate = 100)
        {
            // Time To Live
            var ttl = new Dictionary<string, object> 
            {
                {"message-ttl", 30000 } //time to leave for the message is 30 seconds
            };

            // Declare an Exchange
            channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct, arguments: ttl);

            var statusMessage = "Publishing message ";
            var statusMessageLength = statusMessage.Length;

            Console.WriteLine(statusMessage);

            int count = 0;

            // Publish the message
            while (true)
            {
                // Create a message
                var message = new { Name = "Producer", Message = $"{count:00000}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                // Publish to the exchange, providing a routing kek
                channel.BasicPublish("demo-direct-exchange", "account.init", null, body);
                Thread.Sleep(rate);

                Console.SetCursorPosition(statusMessageLength, 0);
                Console.Write(count);
                count++;
            }
        }
    }
}
