using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Threading;
using RIS.UI;
using RIS.Common;
using RIS.Properties;
using System.Drawing;

namespace RIS.ThreadPool
{
    public class DispatchImage
    {

        bool _isInitialed = false;
        public int total = 0;
        public int findEye = 0;
        public int validHandle = 0;
        public int miss = 0;

        /////////////////////图片显示计数用
        internal int findEyeCount = 0;
        internal int recoEyeCount = 0;
        static DispatchImage _instance = null;

        public static DispatchImage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DispatchImage();
                }
                return _instance;
            }
        }

        ThreadParallel thp;
        ThreadRead thSend;
        ThreadHist thHist;
        int _isReco = 0;
        static object _flagReco=new object();
        public int IsReco
        {
            get { return _isReco; }
            set
            {
                lock (_flagReco)
                {
                    _isReco = value;
                    if (_isReco==1)
                        recoEyeCount++;
                }
            }
        }

        public AutoResetEvent ThreadReceiveFromReco
        { get; set; }
        public AutoResetEvent ThreadReceiveFromHist
        { get; set; }
        MainWindow mainWindow;
        DispatchImage()
        {
            ThreadReceiveFromReco = new AutoResetEvent(false);
            ThreadReceiveFromHist = new AutoResetEvent(false);
        }

        public void Initial(MainWindow mainWindow)
        {  
            if (_isInitialed == true)
                return;
            this.mainWindow = mainWindow;
            thSend = new ThreadRead(mainWindow);
            thSend.StartThread();

            thHist = new ThreadHist(mainWindow);
            thHist.StartThread();

            thp = new ThreadParallel(mainWindow);
            this.mainWindow = mainWindow;
            _isInitialed = true;

            
        }


        public void DisposeAll()
        {

        }

        public void Dispath(Image<Bgr, byte> frame_rgb)
        {
            total++;
            if (thSend.isbusy == false)
            {
                thSend.isbusy = true;
                thSend.ThreadEventReadToSend.Set();


            }
            //if (thHist.isbusy == false)
            //{
            //    thHist.isbusy = true;
            //    if (thHist.frame != null)
            //        thHist.frame.Dispose();
            //    thHist.frame = frame_rgb.Copy();
            //    thHist.ThreadEventReadToHist.Set();
            //    ThreadReceiveFromHist.WaitOne(Timeout.Infinite);


            //}


            Image<Bgr, byte> subImage = null;
            if (!mainWindow.ShowRecing)
            {
                subImage = DetectEyes(frame_rgb);
                mainWindow.ShowImg(frame_rgb.Bitmap);
                
                if (subImage != null)
                {
                    //Show eye
                    DispatchImage.Instance.IsReco = 1;
                    int rand = (new Random()).Next(1, 10);
                    mainWindow.ShowEyeImg(rand);

                    findEye++;
                    findEyeCount++;
                    ThreadReco p = GetDispatchedThreadReco();
                    if (p != null)
                    {
                        validHandle++;
                        p.frame = subImage;
                        p.ThreadEventReadToFight.Set();

                    }
                    else
                    {
                        DispatchImage.Instance.IsReco = 0;
                        mainWindow.ShowEyeImg(-1);
                        miss++;
                    }
                }
                else
                {
                    DispatchImage.Instance.IsReco = 0;
                    mainWindow.ShowEyeImg(-1);
                    //没找到眼睛
                    //findEyeCount = 0;
                    recoEyeCount = 0;
                }
            }
            else
            {
                mainWindow.ShowImg(frame_rgb.Bitmap);
            }
            

            
        }


        public ThreadReco GetDispatchedThreadReco()
        {
            bool isDispatched = false;
            ThreadReco ret = null;

            foreach (ThreadReco p in thp.threadparallel)
            {
                if (p.isbusy == false)
                {
                    p.isbusy = true;
                    isDispatched = true;
                    ret = p;
                    break;
                }
            }
            if (isDispatched == false)
            {
                return null;
            }
            return ret;
        }

        private Image<Bgr, byte> DetectEyes(Image<Bgr, byte> frame_rgb)
        {
            List<Rectangle> eyes = new List<Rectangle>();
            try
            {
                eyes = DetectEye.DetectEyes(frame_rgb, mainWindow);
            }
            catch(Exception ex)
            {
                mainWindow.ShowLable2("Detect eyes exception!!"+ ex.Message, false);
                return null;
            }
            if (eyes.Count !=1 )
            {
                return null;
            }
            else
            {
                //Rectangle rect = eyes[0];
                //if (eyes[0].Width == eyes[0].Height)
                //{
                //    double cutXRate = 0.1;
                //    int newy = eyes[0].Y ;
                //    int newh =eyes[0].Height ;
                //    int newx = Convert.ToInt32(eyes[0].Width*(1-cutXRate));
                //    if(newx<0)
                //        newx=0;
                //    int neww = Convert.ToInt32(eyes[0].Width * ((1 +2* cutXRate)) + eyes[0].Width % 4);
                //    if (newx + neww > frame_rgb.Width)
                //        neww = frame_rgb.Width - newx;
                //    rect = new Rectangle(newx, newy, neww, newh);
                //}
                //Image<Bgr, byte> subImage = frame_rgb.GetSubRect(rect).Copy();
                Image<Bgr, byte> subImage = frame_rgb.Resize(640,480,Emgu.CV.CvEnum.INTER.CV_INTER_AREA).Copy();
                DrawEyes(frame_rgb, eyes);
                return subImage;
            }
        }

        public  void DrawEyes(Image<Bgr, byte> frame_rgb, List<Rectangle> eyes)
        {
            float rr = 2;// r / baser;
            Graphics g = Graphics.FromImage(frame_rgb.Bitmap);

            foreach (Rectangle eye in eyes)
            {
                //frame_rgb.Draw(eye, new Bgr(Color.Blue), 2);
                //g.DrawString("x:" + cnx.ToString() + "  y:" + cny.ToString(), new Font("Verdana", 20),new SolidBrush(Color.Tomato), 40, 40);

                //------------------另一种显示方法
                //int eyeIndex = 0;
                //rr = GetFindEyeRR(out eyeIndex);//图片放大两倍
                //Bitmap img = Resources.eyeFocus;
                //int cnx = eye.X + eye.Width / 2 - Convert.ToInt32(img.Width * rr / 2);
                //int cny = eye.Y + eye.Height / 2 - Convert.ToInt32(img.Height * rr / 2);
                //g.DrawImage(img, cnx, cny, img.Width * rr, img.Height * rr);
                ////Mask
                //img = Resources.ResourceManager.GetObject("eyeMask" + eyeIndex.ToString(), Resources.Culture) as Bitmap;
                //cnx = eye.X + eye.Width / 2 - Convert.ToInt32(img.Width * rr / 2);
                //cny = eye.Y + eye.Height / 2 - Convert.ToInt32(img.Height * rr / 2);
                //g.DrawImage(img, cnx, cny, img.Width * rr, img.Height * rr);

                rr = 2;
                Bitmap recoImage = GetRecoEyeImage();
                int cnx = eye.X + eye.Width / 2 - Convert.ToInt32(recoImage.Width * rr / 2);
                int cny = eye.Y + eye.Height / 2 - Convert.ToInt32(recoImage.Height * rr / 2);
                g.DrawImage(recoImage, cnx, cny, recoImage.Width * rr, recoImage.Height * rr);
                
            }
            g.Dispose();
        }

        private Bitmap GetRecoEyeImage()
        {
            if (recoEyeCount % 2 == 0)
                return Resources.eyeFocusReco;
            else
                return Resources.eyeFocusReco1;
        }

        private float GetFindEyeRR(out int eyeIndex)
        {
            float rr = 1;// -(findEyeCount % 4) * 0.1f;
            eyeIndex = findEyeCount % 36;
            return rr;
        }
    }
}
