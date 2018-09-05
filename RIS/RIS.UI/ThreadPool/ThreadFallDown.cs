using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;

namespace RIS.ThreadPool
{
    public class ThreadFallDown
    {
        public Image<Bgr, byte> frame_rgb;
        public bool isbusy = false;

        public AutoResetEvent ThreadEventReadToFD
        { get; set; }

        public ThreadFallDown()
        {
            frame_rgb = new Image<Bgr, byte>(1920, 1080);
            ThreadEventReadToFD = new AutoResetEvent(false);
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
                ThreadEventReadToFD.WaitOne(Timeout.Infinite);

                DispatchImage.Instance.ThreadReceiveFromFD.Set();

                isbusy = false;
            }

        }
    }
}
