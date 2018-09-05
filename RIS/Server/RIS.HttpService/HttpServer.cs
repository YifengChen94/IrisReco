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

namespace RIS.HttpService
{
    public class HttpServer
    {
        protected int port;
        StreamWriter _log;
        HttpListener listener;
        public bool is_active = true;

        public HttpServer(int port)
        {
            this.port = port;
            _log = new StreamWriter(ConfigurationManager.AppSettings["HttpLog"], true);
            _log.AutoFlush = true;
        }

        public void listen()
        {
            try
            {
                listener = new HttpListener();
                listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                listener.Prefixes.Add(string.Format("http://*:{0}/RIS/", port));
                listener.Start();
                while(is_active)
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpProcessor processor = new HttpProcessor(context, this);
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
            Display("Connect", p.context.Request.RemoteEndPoint.ToString(), p.http_method, "");

            //To do
            bool ret=false;
            if(p.context.Request.QueryString.HasKeys())
            {
                ret = HttpRequstService.HandleRequest(p.context.Request.QueryString);
            }

            //
            
            p.context.Response.Headers.Add("Access-Control-Allow-Origin", "*"); 
            p.context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");
            p.context.Response.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT");
            p.context.Response.Headers.Add("Allow", "GET,POST,PUT");
            int len = 0;
            if (ret)
                len = p.writeSuccess();
            else
                len = p.writeFailure();

            Display("Response", p.context.Request.RemoteEndPoint.ToString(), p.http_method, len.ToString());
        }

        public void handlePOSTRequest(HttpProcessor p, string postData)
        {
            Display("Connect", p.context.Request.RemoteEndPoint.ToString(), p.http_method, p.length.ToString());

            //To do
            DeviceinfoEntity entity = DeviceBusiness.GetDeviceInfo();

            byte[] buffer = Encoding.UTF8.GetBytes(postData);
            p.context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            //

            Display("Response", p.context.Request.RemoteEndPoint.ToString(), p.http_method, postData.Length.ToString());
        }

        public void Display(string action, string from, string flag, string length)
        {
            try
            {
                _log.WriteLine("|action:" + action + "\t|from" + from + "\t|length:" + length + "\t|ActionTime:" + DateTime.Now.ToString());
            }
            catch
            {

            }
        }
    }

}



