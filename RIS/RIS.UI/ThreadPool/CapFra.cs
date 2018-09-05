using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using RIS.UI;
using System.Drawing;
using RIS.Common;
using Emgu.CV.CvEnum;
using System.Threading;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Windows;

namespace RIS.ThreadPool
{
    public class CapFra
    {
        public VideoCaptureDevice videoSource;
        public Image<Bgr, byte> frame_rgb;
        public bool stop = false;
        MainWindow mainWindow;
        public CapFra(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            DispatchImage.Instance.Initial(mainWindow);
            videoSource = GetDevice();
            if (this.videoSource == null)
            {
                return;
            }
            videoSource.VideoResolution = videoSource.VideoCapabilities[3];
            Thread.Sleep(1000);
            videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
            
            videoSource.Start();

            
        }

        public VideoCaptureDevice GetDevice()
        {
            try
            {
                //枚举所有视频输入设备  
                FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count != 0)
                {
                    mainWindow.ShowLable1("已找到视频设备.", false);
                    videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                    return videoSource;
                }
                else
                {
                    MessageBox.Show("没有找到视频设备！");
                    mainWindow.ShowLable1("没有找到视频设备！", false);
                    return null;
                }
            }
            catch (Exception ex)
            {
                mainWindow.ShowLable1("error:没有找到视频设备！具体原因：" + ex.Message, false);
                return null;
            }
        }

        void videoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            frame_rgb = new Image<Bgr, byte>(bmp);
            frame_rgb = GetStandandSize(frame_rgb);
            CvInvoke.cvFlip(frame_rgb.Ptr, IntPtr.Zero, FLIP.HORIZONTAL);

            DispatchImage.Instance.Dispath(frame_rgb.Copy());

        }

        private Image<Bgr, byte> GetStandandSize(Image<Bgr, byte> frame_rgb)
        {
            double standard = 640.0 / 480;
            double r = frame_rgb.Width * 1.0 / frame_rgb.Height;
            if (r > standard)
            {
                int w = Convert.ToInt32(frame_rgb.Height * standard);
                int x = (frame_rgb.Width - w) / 2;
                return frame_rgb.GetSubRect(new Rectangle(x, 0, w, frame_rgb.Height));
            }
            else if (r < standard)
            {
                int h = Convert.ToInt32(frame_rgb.Width / standard);
                int y = (frame_rgb.Height - h) / 2;
                return frame_rgb.GetSubRect(new Rectangle(0, y, frame_rgb.Width, h));
            }
            else
                return frame_rgb;
        }
        public void QueryAndDispatch()
        {



        }

        internal void StopAndDispose()
        {
            if (this.videoSource != null)
            {
                videoSource.NewFrame -= new NewFrameEventHandler(videoSource_NewFrame);
                this.videoSource.Stop();
                videoSource = null;
            }
        }
    }
}
