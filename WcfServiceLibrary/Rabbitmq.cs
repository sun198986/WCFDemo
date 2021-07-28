using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using WCF.log4netLib;

namespace WcfServiceLibrary
{
    public class Rabbitmq
    {
        private readonly BusinessRabbitMq _businessRabbitMq;
        public Rabbitmq()
        {
            _businessRabbitMq = new BusinessRabbitMq();
        }

        public void OnStart()
        {
            var factory = new ConnectionFactory() { UserName = "massuser1", Password = "mass.2021", HostName = "192.168.40.128", Port = AmqpTcpEndpoint.UseDefaultPort };

            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                string nameDeclare = channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += _businessRabbitMq.DelRecive;
                channel.BasicConsume(queue: "hello",
                    autoAck: true,
                    consumer: consumer);
                Thread.Sleep(Timeout.Infinite);
                //Console.ReadLine();
            }
        }
    }
}