using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.Structure;
using System.Drawing;
using RIS.UI;
using RIS.Common;
using RIS.Properties;
using System.Drawing.Imaging;
using System.IO;
using RIS.BusinessRule;

namespace RIS.ThreadPool
{
    class ThreadFuzzy
    {
        private bool _isbusy = false;
        public int tid;
        static object busyobject = new object();
        public bool isbusy
        {
            get { return _isbusy; }
            set
            {
                lock (busyobject)
                {
                    _isbusy = value;
                }
            }
        }
        private static string GetStamp()
          {
                string stamp = (Environment.TickCount/1000).ToString();
                return stamp;
                //Convert.ToBase64String();
                //Dictionary<string, string> dic = new Dictionary<string, string>();
               // dic["a"] = "b";
              //  Md5Encode.Encode();


            }

    }
    

    
}
