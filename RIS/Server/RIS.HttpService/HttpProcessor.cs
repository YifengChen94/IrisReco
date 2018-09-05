using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Collections;
using System.Net;
using RIS.Common;

namespace RIS.HttpService
{
    public class HttpProcessor
    {
        public HttpListener listener;
        public HttpServer srv;
        public HttpListenerContext context;

        public String http_method;
        public String http_url;
        public int length;
        public Hashtable httpHeaders = new Hashtable();

        public HttpProcessor(HttpListenerContext s, HttpServer srv)
        {
            this.context = s;
            this.srv = srv;
        }

        public void process()
        {
            try
            {
                http_method = context.Request.HttpMethod;
                http_url = context.Request.Url.AbsoluteUri;
                if (context.Request.HttpMethod == "POST")
                {
                    handlePOSTRequest();
                }
                else if (context.Request.HttpMethod == "GET")
                {
                    handleGETRequest();
                }
            }
            catch (Exception e)
            {
                srv.Display("Exception: " + e.ToString(), "", "", "");
                writeFailure();
            }

            context.Response.OutputStream.Close();
            context.Response.Close();
        }

        public void handleGETRequest()
        {
            //To do
            //string userName = context.Request.QueryString["userName"];
            //string password = context.Request.QueryString["password"];

            srv.handleGETRequest(this);
        }

        public void handlePOSTRequest()
        {
            string postData = "";
            StreamReader sr = new StreamReader(context.Request.InputStream, Encoding.UTF8);
            postData = sr.ReadToEnd();
            length = postData.Length;
            sr.Close();
            srv.handlePOSTRequest(this, postData);

        }

        public int writeSuccess()
        {
            ServerResponseEntity response = new ServerResponseEntity();
            response.body.res = 1;
            response.body.desc = "OK";
            string content = JsonHelper.ObjectToJsonString(response);
            object callback = context.Request.QueryString["myCallbackFunction"];
            if (callback != null)
            {
                content = context.Request.QueryString["myCallbackFunction"].ToString() + "(" + content + ");";
            }
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            Stream output = context.Response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            return content.Length;
        }

        public int writeFailure()
        {
            ServerResponseEntity response = new ServerResponseEntity();
            response.body.res = 0;
            response.body.desc = "Failed";
            string content = JsonHelper.ObjectToJsonString(response);
            object callback = context.Request.QueryString["myCallbackFunction"];
            if (callback != null)
            {
                content = context.Request.QueryString["myCallbackFunction"].ToString() + "(" + content + ");";
            }
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            Stream output = context.Response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            return content.Length;
        }
    }

}
