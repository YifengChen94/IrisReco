using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using RIS.UI;
using RIS.Common;
using RIS.Properties;
using System.Drawing.Imaging;
using System.IO;
using RIS.BusinessRule;

namespace RIS.ThreadPool
{
    public class ThreadReco
    {
        public Image<Bgr, byte> frame;
        private bool _isbusy = false;
        public int tid;
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

        public AutoResetEvent ThreadEventReadToFight
        { get; set; }
        MainWindow mainWindow;
        public ThreadReco(MainWindow mainWindow)
        {
            frame = new Image<Bgr, byte>(640, 480);
            ThreadEventReadToFight = new AutoResetEvent(false);
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
                ThreadEventReadToFight.WaitOne(Timeout.Infinite);
                
                //DispatchImage.Instance.ThreadReceiveFromReco.Set();
                try
                {
                    //To do 存初始的眼睛图片
                    mainWindow.ShowLable2("正在读取识别结果......");
                    bool canGenrateFile = IrisBusiness.CanGenrateFile();
                    if (canGenrateFile)
                    {
                        IrisBusiness.InsertImageRecoInfo(frame.Bitmap);
                    }
                        

                }
                
                catch (Exception ex)
                {
                    DispatchImage.Instance.IsReco = 0;
                    mainWindow.ShowEyeImg(-1);
                }
                finally
                {

                    isbusy = false;
                }
            }

        }
        
    }
}
