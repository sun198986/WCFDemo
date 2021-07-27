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
        public Rabbitmq()
        {
            var factory = new ConnectionFactory() { UserName = "sunshijie", Password = "123456", HostName = "192.168.241.128", Port = AmqpTcpEndpoint.UseDefaultPort};

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body.ToArray());
                    IService1 service1 = new Service1();
                    service1.GetData(int.Parse(message));
                    LogHelper.InfoLog.Info($"channel{message}");
                };
                
                channel.BasicConsume(queue: "hello",
                    autoAck: true,
                    consumer: consumer);
                Thread.Sleep(Timeout.Infinite);
                //Console.ReadLine();
            }
        }
    }
}