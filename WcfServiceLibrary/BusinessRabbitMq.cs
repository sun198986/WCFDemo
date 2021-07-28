using System;
using System.Text;
using RabbitMQ.Client.Events;
using WCF.log4netLib;

namespace WcfServiceLibrary
{
    public class BusinessRabbitMq
    {
        public void DelRecive(object obj, BasicDeliverEventArgs ea)
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());
            //业务判断
            IService1 service1 = new Service1();
            service1.GetData(int.Parse(message));
            Console.WriteLine(message);
            LogHelper.InfoLog.Info($"channel{message}");
        }
    }
}