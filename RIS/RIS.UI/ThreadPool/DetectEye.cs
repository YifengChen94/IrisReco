using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using RIS.UI;

namespace RIS.ThreadPool
{
    public class DetectEye
    {
        const string eyeFileName = "haarcascade_eye.xml";
        static CascadeClassifier eyeClassifier = new CascadeClassifier(eyeFileName);
        public static List<Rectangle> DetectEyes(Image<Bgr, Byte> image,MainWindow mainWindow)
        {

                List<Rectangle> eyes = new List<Rectangle>();

                //Read the HaarCascade objects
                using (Image<Gray, Byte> gray = image.Convert<Gray, Byte>()) //Convert it to Grayscale
                {
                    //normalizes brightness and increases contrast of the image
                    gray._EqualizeHist();

                    int t1 = Environment.TickCount;
                    Rectangle[] eyesDetected = eyeClassifier.DetectMultiScale(
                        gray,
                        1.1,
                        3,
                        new Size(300, 300),
                        Size.Empty);
                    gray.ROI = Rectangle.Empty;
                    int t2 = Environment.TickCount;

                    foreach (Rectangle e in eyesDetected)
                    {
                        eyes.Add(e);
                    }
                    int t3 = Environment.TickCount;

                    //mainWindow.ShowLable2((t2 - t1).ToString() + ":" + (t3 - t2).ToString());
                }
                return eyes;
        }
    }
}
