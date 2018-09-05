using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Reflection;

namespace RIS.Service
{
    public class ReadWork
    {
        SerialPort com1= new SerialPort();
        /// <summary>
        /// 当前Worker
        /// </summary>
        private static ReadWork _current = null;
        public static ReadWork CurrentWorker
        {
            get
            {
                if (_current == null)
                {
                    _current = new ReadWork();

                }
                return _current;
            }
        }
        bool Working = false;
        /// <summary>
        /// 开始工作
        /// </summary>
        public void StartWork()
        {
            if (this.Working == true)
            {
                return;
            }
            WriteLog("RIS Service开始工作");

            this.Working = true;
        }

        /// <summary>
        /// 结束工作
        /// </summary>
        public void EndWork()
        {
            this.Working = false;
           
            WriteLog( "RIS Service结束工作");
        }

        

        static object logobj = new object();
        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="error"></param>
        public static void WriteLog(string error)
        {
            try
            {
                lock (logobj)
                {
                    string path = "";
                    string fullName = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
                    string fullPath = Path.GetDirectoryName(fullName);
                    path = fullPath + @"\";
                    if (!File.Exists(path + "log.txt"))
                    {
                        File.Create(path + "log.txt").Close();
                    }
                    else
                    {
                        FileInfo fi = new FileInfo(path + "log.txt");
                        if (fi.Length > (100 * 1000))//100K
                        {
                            File.Delete(path + "log.txt");
                            File.Create(path + "log.txt").Close();
                        }
                    }
                    StreamWriter sw = new StreamWriter(path + "log.txt", true, Encoding.Unicode);
                    sw.WriteLine(DateTime.Now.ToString() + " " + error);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }
    }
}
