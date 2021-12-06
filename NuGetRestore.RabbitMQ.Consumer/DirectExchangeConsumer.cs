using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Consumer
{
    public static class DirectExchangeConsumer
    {
        public static void Consume(IModel channel)
        {
            // Declare the exchange
            channel.ExchangeDeclare("demo-direct-exchange", ExchangeType.Direct);

            // Declare a queue
            channel.QueueDeclare("demo-direct-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            // Bind the queue to the exchange using the routing key
            channel.QueueBind("demo-direct-queue", "demo-direct-exchange", "account.init");

            // Qaulity of Service: setup the consumer to de-queue 10 messages at a time
            channel.BasicQos(0, 10, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("demo-direct-queue", true, consumer);
            Console.WriteLine("Consumer started");
            Console.ReadLine();
        }
    }
}
