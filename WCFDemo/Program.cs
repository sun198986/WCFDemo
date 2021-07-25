using System;
using System.ServiceModel;

namespace WCFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WcfServiceLibrary.Service1)))
            {
                host.Open();
                Console.WriteLine("服务已启动");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
