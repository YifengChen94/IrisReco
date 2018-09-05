using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV;

namespace RIS.ThreadPool
{
    public class ThreadComputePeople
    {
        public Image<Bgr, byte> frame_rgb;
        public bool isbusy = false;

        public AutoResetEvent ThreadEventReadToCP
        { get; set; }

        public ThreadComputePeople()
        {
            frame_rgb = new Image<Bgr, byte>(1920, 1080);
            ThreadEventReadToCP = new AutoResetEvent(false);
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
                ThreadEventReadToCP.WaitOne(Timeout.Infinite);

                DispatchImage.Instance.ThreadReceiveFromCP.Set();

                isbusy = false;
            }

        }
    }
}
