using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace RabbitMQ.Producer
{
    public static class QueueProducer
    {
        /// <summary>
        /// Publishes a message to the channel.
        /// </summary>
        /// <param name="channel">The channel to publish the message to.</param>
        /// <param name="rate">The message rate in milliseconds.</param>
        public static void Publish(IModel channel, int rate = 10)
        {
            // Declare a queue
            channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            var statusMessage = "Publishing message ";
            var statusMessageLength = statusMessage.Length;

            Console.WriteLine(statusMessage);

            int count = 0;

            // Publish the message
            while(true)
            {
                // Create a message
                var message = new { Name = "Producer", Message = $"{count:00000}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("", "demo-queue", null, body);
                Thread.Sleep(rate);

                Console.SetCursorPosition(statusMessageLength, 0);
                Console.Write(count);
                count++;
            }
        }
    }
}
