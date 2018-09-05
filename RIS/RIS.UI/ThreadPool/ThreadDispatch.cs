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
using RIS.Properties;

namespace RIS.ThreadPool
{
    public class ThreadDispatch
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
        public AutoResetEvent ThreadEventDispatch
        { get; set; }
        MainWindow mainWindow;

        public ThreadDispatch(MainWindow mainWindow)
        {
            frame = new Image<Bgr, byte>(640, 480);
            ThreadEventDispatch = new AutoResetEvent(false);
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
                    ThreadEventDispatch.WaitOne(Timeout.Infinite);

                    Image<Bgr, byte> subImage = DetectEyes(frame);
                    mainWindow.ShowImg(frame.Bitmap);
                    if (subImage != null)
                    {
                        DispatchImage.Instance.findEye++;
                        DispatchImage.Instance.findEyeCount++;
                        ThreadReco p = DispatchImage.Instance.GetDispatchedThreadReco();
                        if (p != null)
                        {
                            DispatchImage.Instance.callAPI++;
                            p.frame = subImage;
                            p.ThreadEventReadToFight.Set();

                        }
                        else
                        {
                            DispatchImage.Instance.miss++;
                        }
                    }
                    else
                    {
                        //没找到眼睛
                        DispatchImage.Instance.findEyeCount = 0;
                        DispatchImage.Instance.recoEyeCount = 0;
                    }
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

        private Image<Bgr, byte> DetectEyes(Image<Bgr, byte> frame)
        {
            List<Rectangle> eyes = DetectEye.DetectEyes(frame, mainWindow);
            if (eyes.Count != 1)
                return null;
            else
            {
                Rectangle rect = eyes[0];
                if (eyes[0].Width == eyes[0].Height)
                {
                    double cutYRate = 0.15;
                    int newy = eyes[0].Y + Convert.ToInt32(eyes[0].Height * cutYRate);
                    int newh = Convert.ToInt32(eyes[0].Height * (1 - cutYRate * 2));
                    int newx = eyes[0].X;
                    int neww = eyes[0].Width - eyes[0].Width % 4;
                    rect = new Rectangle(newx, newy, neww, newh);
                }
                Image<Bgr, byte> subImage = frame.GetSubRect(rect).Copy();
                DrawEyes(frame, eyes);
                return subImage;
            }
        }

        public void DrawEyes(Image<Bgr, byte> frame, List<Rectangle> eyes)
        {
            float rr = 2;// r / baser;
            Graphics g = Graphics.FromImage(frame.Bitmap);

            foreach (Rectangle eye in eyes)
            {
                frame.Draw(eye, new Bgr(Color.Blue), 2);
                //g.DrawString("x:" + cnx.ToString() + "  y:" + cny.ToString(), new Font("Verdana", 20),new SolidBrush(Color.Tomato), 40, 40);
                if (DispatchImage.Instance.IsReco == 0)
                {
                    rr = GetFindEyeRR() * 2;//图片扩大两倍
                    int cnx = eye.X + eye.Width / 2 - Convert.ToInt32(Resources.eyeFocus.Width * rr / 2);
                    int cny = eye.Y + eye.Height / 2 - Convert.ToInt32(Resources.eyeFocus.Height * rr / 2);
                    g.DrawImage(Resources.eyeFocus, cnx, cny, Resources.eyeFocus.Width * rr, Resources.eyeFocus.Height * rr);

                }
                else
                {
                    rr = 2;
                    Bitmap recoImage = GetRecoEyeImage();
                    int cnx = eye.X + eye.Width / 2 - Convert.ToInt32(recoImage.Width * rr / 2);
                    int cny = eye.Y + eye.Height / 2 - Convert.ToInt32(recoImage.Height * rr / 2);
                    g.DrawImage(recoImage, cnx, cny, recoImage.Width * rr, recoImage.Height * rr);
                }
            }
            g.Dispose();
        }

        private Bitmap GetRecoEyeImage()
        {
            if (DispatchImage.Instance.recoEyeCount % 2 == 0)
                return Resources.eyeFocusReco;
            else
                return Resources.eyeFocusReco1;
        }

        private float GetFindEyeRR()
        {
            float rr = 1 - (DispatchImage.Instance.findEyeCount % 4) * 0.1f;
            return rr;
        }
    }
}
