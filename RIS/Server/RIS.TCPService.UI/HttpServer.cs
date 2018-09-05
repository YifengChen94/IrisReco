using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Configuration;
using RIS.BusinessRule;
using RIS.Entity.Entity;

namespace RIS.TCPService.UI 
{
    public class HttpServer 
    {
        public frmMain frm;
        protected int port;
        TcpListener listener;
        public bool is_active = true;
       
        public HttpServer(int port) {
            this.port = port;
        }

        public void listen() 
        {
            try
            {
                listener = new TcpListener(new System.Net.IPEndPoint(IPAddress.Any, port));
                listener.Start();
                while (is_active)
                {
                    TcpClient s = listener.AcceptTcpClient();
                    HttpProcessor processor = new HttpProcessor(s, this);
                    Thread thread = new Thread(new ThreadStart(processor.process));
                    thread.Start();
                    Thread.Sleep(1);
                }

            }
            catch (Exception ex)
            {
                if (is_active != false)
                    throw ex;
            }
        }

        public void StopListen()
        {
            this.listener.Stop();
        }
        public void handleGETRequest(HttpProcessor p)
        {
            Display("Connect", p.socket.Client.RemoteEndPoint.ToString(), p.http_method, "");
            int len= p.writeSuccess();
            Display("Response", p.socket.Client.RemoteEndPoint.ToString(), p.http_method, len.ToString());
        }

        public void handlePOSTRequest(HttpProcessor p, string postData)
        {
            Display("Connect", p.socket.Client.RemoteEndPoint.ToString(), p.http_method, p.length.ToString());
            p.outputStream.WriteLine("{0}", postData);//Test,will replace by To do
            //To do
            DeviceinfoEntity entity =  DeviceBusiness.GetDeviceInfo();
            Display("Response", p.socket.Client.RemoteEndPoint.ToString(), p.http_method, postData.Length.ToString());
        }

        public void Display(string action, string from, string flag, string length)
        {
            DisplayText dt = new DisplayText();
            dt.Action = action;
            dt.ActionTime = DateTime.Now;
            dt.From = from;
            dt.Flag = flag;
            dt.Length = length;
            frm.AddList(dt);
        }
    }

}



