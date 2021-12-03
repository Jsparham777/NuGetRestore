using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace NuGetRestore.RabbitMQ
{
    /// <summary>
    /// Producer.
    /// Start a RabbitMQ instance (either installed or in a docker container).
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a factory connected to the RabbitMQ docker instance
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            // Create a connection
            using var connection = factory.CreateConnection();

            // Create a channel
            using var channel = connection.CreateModel();

            // Create a queue
            channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            // Create a message
            var message = new { Name = "Producer", Message = "Hello!" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            // Publish the message to the bus
            channel.BasicPublish("", "demo-queue", null, body);


        }
    }

    /// <summary>
    /// Consumer.
    /// Move this is another console application.
    /// </summary>
    public class Program2
    {
        static void Main(string[] args)
        {
            // Create a factory connected to the RabbitMQ docker instance
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            // Create a connection
            using var connection = factory.CreateConnection();

            // Create a channel
            using var channel = connection.CreateModel();

            // Create a queue
            channel.QueueDeclare("demo-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            // Create a consumer
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("demo-queue", true, consumer);
        }
    }
}
