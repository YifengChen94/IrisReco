using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Configuration;

namespace RIS.TCPService 
{
    public class HttpServer 
    {
        protected int port;
        TcpListener listener;
        public bool is_active = true;
        StreamWriter _log;
        public HttpServer(int port) {
            _log = new StreamWriter(ConfigurationManager.AppSettings["TcpLog"], true);
            _log.AutoFlush = true;
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
            p.outputStream.WriteLine("{0}", postData);
            Display("Response", p.socket.Client.RemoteEndPoint.ToString(), p.http_method, postData.Length.ToString());
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



