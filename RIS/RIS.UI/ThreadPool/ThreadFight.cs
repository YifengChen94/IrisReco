using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;

namespace RIS.ThreadPool
{
    public class ThreadFight
    {
        public Image<Bgr, byte> frame;
        public bool isbusy = false;

        public AutoResetEvent ThreadEventReadToFight
        { get; set; }

        public ThreadFight()
        {
            frame = new Image<Bgr, byte>(640, 480);
            ThreadEventReadToFight = new AutoResetEvent(false);
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
                ThreadEventReadToFight.WaitOne(Timeout.Infinite);
                
                DispatchImage.Instance.ThreadReceiveFromFight.Set();
                //To do

                isbusy = false;
            }

        }
    }
}
