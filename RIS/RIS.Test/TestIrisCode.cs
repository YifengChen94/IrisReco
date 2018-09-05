using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV.Structure;
using Emgu.CV;
using System.IO;
using System.Runtime.InteropServices;

namespace RIS.Test
{
    public partial class TestIrisCode : Form
    {
        public TestIrisCode()
        {
            InitializeComponent();
            this.textBox1.Text = "";
        }
        string path = AppDomain.CurrentDomain.BaseDirectory + "TestImage\\";

        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(path);
            int i = 0;
            foreach (string file in files)
            {
                i++;
                CircleF outerC;
                CircleF InnerC;

                frame = new Image<Bgr, byte>(file);
                string mess = DetectCircles(out outerC, out InnerC);
                if (InnerC.Radius != 0)
                {
                    int rr = 0;
                    int rx = Convert.ToInt32(outerC.Center.X - outerC.Radius) - rr;
                    int ry = Convert.ToInt32(outerC.Center.Y - outerC.Radius) - rr;
                    int rw = Convert.ToInt32(outerC.Radius * 2) + rr;
                    int rh = Convert.ToInt32(outerC.Radius * 2) + rr;

                    if (rx < 0) rx = 0;
                    if (ry < 0) ry = 0;
                    if (rx + rw > frame.Width) rw = frame.Width - rx;
                    if (ry + rh > frame.Height) rh = frame.Height - ry;
                    Image<Bgr, byte> frameOuterC = frame.GetSubRect(new Rectangle(rx, ry, rw, rh));

                    int x = Convert.ToInt32(InnerC.Center.X - rx);
                    int y = Convert.ToInt32(InnerC.Center.Y - ry);
                    int r = Convert.ToInt32(InnerC.Radius);
                    int x1 = Convert.ToInt32(outerC.Center.X - rx);
                    int y1 = Convert.ToInt32(outerC.Center.Y - ry);
                    int r1 = Convert.ToInt32(outerC.Radius);
                    int ret = detectEyeCSharp(frameOuterC.Data, frameOuterC.Width, frameOuterC.Height, 8, 3, ref x, ref y, ref r, i);
                    ShowText("File Name:"+file+"\t Seq:"+i.ToString()+"\t"+ret.ToString());
                }
                else
                {
                    ShowText("File Name:" + file + "\t Seq:" + i.ToString() + "\t" + "没找到圆");
                }

            }
        }
        void ShowText(string text)
        {
            this.textBox1.Text += text + "\r\n";
        }
        [DllImport(@".\lib\IrisReco.dll")]
        public static extern int detectEyeCSharp(byte[, ,] src, int width, int height, int depth, int channels, ref int x, ref int y, ref int r, int tid);

        Image<Bgr, byte> frame;
        private string DetectCircles(out CircleF outerC, out CircleF innerC)
        {
            outerC = new CircleF();
            innerC = new CircleF();
            
            Image<Bgr, Byte> img = frame.Copy();//.Resize(400, 400, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR, true);

            //Convert the image to grayscale and filter out the noise
            Image<Gray, Byte> grayImg = img.Convert<Gray, Byte>().PyrDown().PyrUp();
            grayImg = grayImg.SmoothGaussian(5).SmoothMedian(17);
            Image<Gray, Byte> gray = grayImg.ThresholdToZeroInv(new Gray(50));
            Image<Gray, Byte> grayCanny = gray.Canny(30, 10);
            pictureBox1.Image = grayImg.Bitmap;
            pictureBox2.Image = grayCanny.Bitmap;

            double cannyThreshold = 100;
            double circleAccumulatorThreshold = 120;
            CircleF[] circles = grayCanny.HoughCircles(
                new Gray(cannyThreshold),
                new Gray(circleAccumulatorThreshold),
                2.2, //Resolution of the accumulator used to detect centers of the circles
                25, //min distance 
                25, //min radius
                100 //max radius
                )[0]; //Get the circles from the first channel
            
            if (circles.Length == 0)
            {
                return "Not Find Inner Circle";
            }
            else 
            {
                foreach (CircleF circle in circles)
                {
                    img.Draw(circle, new Bgr(Color.Blue), 2);
                }
                
                float distanceInnerWithCenter1 = float.MaxValue;
                for (int i = 0; i < circles.Length; i++)
                {
                    CircleF circleInner = circles[i];

                    float distance = (circleInner.Center.X - gray.Width / 2) * (circleInner.Center.X - gray.Width / 2) +
                        (circleInner.Center.Y - gray.Height / 2) * (circleInner.Center.Y - gray.Height / 2);
                    if (distance < distanceInnerWithCenter1)
                    {
                        distanceInnerWithCenter1 = distance;
                        innerC = circleInner;
                    }
                }
                
                //Find Outer Circle
                try
                {
                    float outRate = 1.3f;
                    outerC = new CircleF(innerC.Center, innerC.Radius * (outRate + 1));
                    //ROI
                    outRate = 1.4f;
                    int rx = Convert.ToInt32(innerC.Center.X - innerC.Radius * (1 + outRate));
                    int ry = Convert.ToInt32(innerC.Center.Y - innerC.Radius * (1 + outRate));
                    int rw = Convert.ToInt32(innerC.Radius * 2 * (1 + outRate));
                    int rh = Convert.ToInt32(innerC.Radius * 2 * (1 + outRate));
                    if (rw <= 0 || rh <= 0)
                        return "ROI Too Small";
                    if (rx < 0) rx = 0;
                    if (ry < 0) ry = 0;
                    if (rx + rw > gray.Width) rw = gray.Width - rx;
                    if (ry + rh > gray.Height) rh = gray.Height - ry;
                    float distanceWithCenter = float.MaxValue;

                    cannyThreshold = 180;
                    circleAccumulatorThreshold = 80;

                    Rectangle roi = new Rectangle(rx, ry, rw, rh);
                    img.Draw(roi, new Bgr(Color.Blue), 2);
                    Image<Gray, byte> subimage = grayImg.GetSubRect(roi);
                    Image<Gray, Byte> subgray = subimage.ThresholdToZeroInv(new Gray(100));

                    //subimage = subimage.SmoothGaussian(5);
                    this.pictureBox3.Image = subimage.Bitmap;
                    Image<Gray, byte> subimageCanny = subgray.Canny(20, 10);
                    pictureBox4.Image = subimageCanny.Bitmap;
                    CircleF[] circlesOuter = subimageCanny.HoughCircles(
                        new Gray(cannyThreshold),
                        new Gray(circleAccumulatorThreshold),
                        2.0, //Resolution of the accumulator used to detect centers of the circles
                        10.0, //min distance 
                        200, //min radius
                        600 //max radius
                        )[0]; //Get the circles from the first channel
                    if (circlesOuter.Length == 0)
                    {
                        return "Not find Outer circle";
                    }
                    else
                    {
                        bool findOut = false;
                        for (int i = 0; i < circlesOuter.Length; i++)
                        {
                            CircleF circleOut = circlesOuter[i];
                            subimage.Draw(circleOut, new Gray(255), 2);

                            circleOut.Center = new PointF(circleOut.Center.X + roi.X, circleOut.Center.Y + roi.Y);
                            float distance = (innerC.Center.X - circleOut.Center.X) * (innerC.Center.X - circleOut.Center.X) +
                                (innerC.Center.Y - circleOut.Center.Y) * (innerC.Center.Y - circleOut.Center.Y);
                            if (distance < distanceWithCenter && distance <= innerC.Radius && outerC.Radius <= innerC.Radius * 4)
                            {
                                distanceWithCenter = distance;
                                outerC = circleOut;
                                findOut = true;
                            }
                        }
                        if (findOut == false)
                        {
                            return "Not find Correct Outer circle";
                        }
                    }
 
                }
                catch (Exception ex)
                {
                    return "ROI calculate Exception:" + ex.Message;
                }
                
                return "OK";
            }
        }
    }
}
