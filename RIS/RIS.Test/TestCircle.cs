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

namespace RIS.Test
{
    public partial class TestCircle : Form
    {
        public TestCircle()
        {
            InitializeComponent();
            this.textBox1.Text = "0005C929-0963-4829-A704-897A0C7CE8950.bmp";
        }
        string path = @"D:\1\RIS\RIS.UI\bin\Debug\everyFrame\\";
        string pathO = AppDomain.CurrentDomain.BaseDirectory;
        private void button1_Click(object sender, EventArgs e)
        {
            
           
            CircleF outerC;
            CircleF InnerC;
            string file = path + this.textBox1.Text;
            frame = new Image<Bgr, byte>(file);
            string mess = DetectCircles(out outerC, out InnerC);
            if (outerC.Radius != 0)
                frame.Draw(outerC, new Bgr(Color.Red), 2);
            if (InnerC.Radius != 0)
                frame.Draw(InnerC, new Bgr(Color.Red), 2);
            using (Graphics g = Graphics.FromImage(frame.Bitmap))
            {
                g.DrawString(mess, new Font("Verdana", 20), new SolidBrush(Color.Tomato), 40, 40);
            }
            pictureBox2.Image = frame.Bitmap;
        }
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
            gray.Save(pathO + "00.bmp");
            Image<Gray, Byte> grayCanny = gray.Canny(30, 10);
            pictureBox1.Image = grayCanny.Bitmap;
            grayCanny.Save(pathO + "01.bmp");
            double cannyThreshold = 100;
            double circleAccumulatorThreshold = 120;
            CircleF[] circles = grayCanny.HoughCircles(
                new Gray(cannyThreshold),
                new Gray(circleAccumulatorThreshold),
                2.2, //Resolution of the accumulator used to detect centers of the circles
                25, //min distance 
                25, //min radius
                150 //max radius
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
                
                img.Save(pathO + "02.bmp");

                //Find Outer Circle
                try
                {
                    float outRate = 1.2f;
                    outerC = new CircleF(innerC.Center, innerC.Radius * (outRate + 1));
                    //ROI
                    outRate = 2.0f;
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
                    img.Save(pathO + "03.bmp");
                    Image<Gray, byte> subimage = grayImg.GetSubRect(roi);

                    Image<Gray, Byte> subgray = grayImg.ThresholdToZeroInv(new Gray(100));
                    subgray.Save(pathO + "04.bmp");
                    //subimage = subimage.SmoothGaussian(5);
                    this.pictureBox3.Image = grayImg.Bitmap;
                    Image<Gray, byte> subimageCanny = subgray.Canny(20, 10);
                    subimageCanny.Save(pathO + "05.bmp");
                    pictureBox4.Image = subimageCanny.Bitmap;
                    CircleF[] circlesOuter = subimageCanny.HoughCircles(
                        new Gray(cannyThreshold),
                        new Gray(circleAccumulatorThreshold),
                        2.0, //Resolution of the accumulator used to detect centers of the circles
                        10.0, //min distance 
                        200, //min radius
                        800 //max radius
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
                            if (distance < distanceWithCenter && distance <= innerC.Radius * innerC.Radius && outerC.Radius <= innerC.Radius * 4)
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
