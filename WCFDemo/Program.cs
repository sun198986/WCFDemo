using System;
using System.ServiceModel;
using System.Web.Hosting;
using WCF.log4netLib;
using WcfServiceLibrary;

namespace WCFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory+ "WCFDemo.exe.config"));
            using (ServiceHost host = new ServiceHost(typeof(WcfServiceLibrary.Service1)))
            {
                host.Open();
                var rabbitmq = new Rabbitmq();
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
