using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace RIS.Service
{
    public partial class RISService : ServiceBase
    {
        public RISService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ReadWork.CurrentWorker.StartWork();
        }

        protected override void OnStop()
        {
            ReadWork.CurrentWorker.EndWork();
        }
    }
}
