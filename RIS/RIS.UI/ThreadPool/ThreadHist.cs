using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;
using RIS.UI;
using System.IO;
using RIS.Common;
using RIS.BusinessRule;
using RIS.Entity.Entity;

namespace RIS.ThreadPool
{
    public class ThreadHist
    {
        private bool _isbusy = false;
        static object busyobject = new object();
        public bool isbusy
        {
            get{return _isbusy;}
            set
            {
                lock(busyobject)
                {
                    _isbusy=value;
                }
            }
        }
        public Image<Bgr, byte> frame;
        public AutoResetEvent ThreadEventReadToHist
        { get; set; }
        MainWindow mainWindow;

        public ThreadHist(MainWindow mainWindow)
        {
            frame = new Image<Bgr, byte>(640, 480);
            ThreadEventReadToHist = new AutoResetEvent(false);
            this.mainWindow = mainWindow;
        }

        Thread trd;
        public void StartThread()
        {
            this.trd = new Thread(new ThreadStart(this.ThreadTask));
            this.trd.IsBackground = true;
            this.trd.Start();
        }

        bool stop = false;
        public void EndThread()
        {
            stop = true;
            if (trd != null)
            {
                this.trd.Abort();
            }
        }

        public void ThreadTask()
        {
            while (!stop)
            {
                try
                {
                    ThreadEventReadToHist.WaitOne(Timeout.Infinite);

                    DispatchImage.Instance.ThreadReceiveFromHist.Set();
                
                    Image<Bgr, Byte> img = ImageHandler.Draw2DHisImg(frame,100,100);
                    mainWindow.ShowHistImg(img.Bitmap);
                }
                catch (Exception ex)
                {

                }
                finally
                {

                    isbusy = false;
                }
             }

        }
    }
}
