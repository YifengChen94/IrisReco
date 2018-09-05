using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using RIS.HttpService;
using System.Threading;
using System.Configuration;

namespace RIS.HttpService
{
    public partial class HttpService : ServiceBase
    {
        int port = 8010;
        HttpServer httpServer;
        public HttpService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            port = int.Parse(ConfigurationManager.AppSettings["Port"]);
            httpServer = new HttpServer(port);
            Thread thread = new Thread(new ThreadStart(httpServer.listen));
            thread.Start();
            httpServer.Display("Start listen to " + port.ToString(), "", "", "");
        }

        protected override void OnStop()
        {
            if (httpServer != null)
            {
                httpServer.is_active = false;
                httpServer.StopListen();
            }
        }
    }
}
