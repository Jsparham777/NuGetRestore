using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Producer;
using System;
using System.Text;
using System.Threading;

namespace RabbitMQ
{
    /// <summary>
    /// https://www.youtube.com/watch?v=w84uFSwulBI
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            Countdown(8);

            //QueueProducer.Publish(channel, 100);
            DirectExchangePublisher.Publish(channel, 100);

            Console.Clear();
            Console.WriteLine("Transmission complete.");

            Console.ReadLine();
        }

        /// <summary>
        /// Prints a countdown to the console.
        /// </summary>
        /// <param name="countDown">The beginning count down number.</param>
        private static void Countdown(int countDown = 5)
        {
            var startMessage = "Starting transmission in ";
            var startMessageLength = startMessage.Length;

            Console.WriteLine(startMessage);

            for (int i = countDown; i > 0; i--)
            {
                Console.SetCursorPosition(startMessageLength, 0);
                Console.Write(i);
                Thread.Sleep(1000);
            }

            Console.Clear();
        }
    }
}
