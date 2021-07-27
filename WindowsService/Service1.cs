using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WCF.log4netLib;
using WcfServiceLibrary;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        ServiceHost host = new ServiceHost(typeof(WcfServiceLibrary.Service1));

        protected override void OnStart(string[] args)
        {
              host.Open();
              LogHelper.InfoLog.Info("服务启动");
              var rabbitmq = new Rabbitmq();
            // host.Close();
        }

        protected override void OnStop()
        {
            host.Close();
        }
    }
}
