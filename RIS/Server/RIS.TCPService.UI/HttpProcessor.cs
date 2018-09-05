using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Collections;

namespace RIS.TCPService.UI
{
    public class HttpProcessor
    {
        public TcpClient socket;
        public HttpServer srv;

        private Stream inputStream;
        public StreamWriter outputStream;

        public String http_method;
        public String http_url;
        public int length;
        public String http_protocol_versionstring;
        public Hashtable httpHeaders = new Hashtable();

        public HttpProcessor(TcpClient s, HttpServer srv)
        {
            this.socket = s;
            this.srv = srv;
        }

        public void process()
        {
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BufferedStream(socket.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream = new StreamWriter(new BufferedStream(socket.GetStream()));
            try
            {
                readHeaders();
                if (http_method.Equals("GET"))
                {
                    handleGETRequest();
                }
                else if (http_method.Equals("POST"))
                {
                    handlePOSTRequest();
                }
            }
            catch (Exception e)
            {
                srv.Display("Exception: " + e.ToString(), "", "", "");
                writeFailure();
            }
            outputStream.Flush();
            // bs.Flush(); // flush any remaining output
            inputStream = null; outputStream = null; // bs = null;            
            socket.Close();
        }

        public void readHeaders()
        {
            byte[] buffer = new byte[socket.ReceiveBufferSize];
            //读取进来的流
            int bytesRead = inputStream.Read(buffer, 0, socket.ReceiveBufferSize);

            //接收的数据转换成字符串
            string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            length = dataReceived.Length;
            string[] lines = dataReceived.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int i = 0;
            foreach (string line in lines)
            {
                i++;
                if (i == 1)
                {
                    string[] tokens = line.Split(' ');
                    if (tokens.Length != 3)
                    {
                        throw new Exception("invalid http request line");
                    }
                    http_method = tokens[0].ToUpper();
                    http_url = tokens[1];
                    http_protocol_versionstring = tokens[2];

                    continue;
                }
                if (line.Equals(""))
                {
                    return;
                }

                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    continue;
                }
                String name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++; // strip any spaces
                }

                string value = line.Substring(pos, line.Length - pos);
                httpHeaders[name] = value;

            }

        }

        public void handleGETRequest()
        {
            srv.handleGETRequest(this);
        }

        private const int BUF_SIZE = 4096;
        public void handlePOSTRequest()
        {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 

            string postData = "";
            if (this.httpHeaders.ContainsKey("Post-Data"))
            {
                postData = httpHeaders["Post-Data"].ToString();

            }

            srv.handlePOSTRequest(this, postData);

        }

        public int writeSuccess()
        {
            string success = "successful";
            outputStream.WriteLine(success);
            return success.Length;
        }

        public int writeFailure()
        {
            string s1 = "HTTP/1.1 404 File not found";
            string s2 = "Connection: close";
            outputStream.WriteLine(s1);
            outputStream.WriteLine(s2);
            outputStream.WriteLine("");
            return s1.Length + s2.Length;
        }
    }

}
