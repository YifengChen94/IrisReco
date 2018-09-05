using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows;
using System.Windows.Media;
using Emgu.CV.CvEnum;
using System.Windows.Shapes;

namespace RIS
{
    public class ImageHandler
    {
        private static DenseHistogram Cal1DHsvHist(Image<Bgr, Byte> srcImage, int h_bins)
        {
            try
            {
                DenseHistogram histDense; //最后计算完存放回DenseHistogram类别
                int h_max_range = 180;
                System.Drawing.Size a = srcImage.Size;
                //使用CvInvoke的cvCreateImage方法分别创建存放转换至Hsv色彩空间的影像与分割取得Hue信道的影像空间
                IntPtr hsv = CvInvoke.cvCreateImage(a, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 3);
                IntPtr h_plane = CvInvoke.cvCreateImage(a, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 1);

                /** Hue的变化范围 */
                float[] h_ranges = new float[2] { 0, h_max_range };
                IntPtr[] h_plane_ptr = new IntPtr[] { h_plane };
                //转换成Hsv色彩空间 
                CvInvoke.cvCvtColor(srcImage, hsv, Emgu.CV.CvEnum.COLOR_CONVERSION.BGR2HSV);
                // 分离取出色相空到的影像数据
                CvInvoke.cvSplit(hsv, h_plane, IntPtr.Zero, IntPtr.Zero, System.IntPtr.Zero);

                //创建值方图 
                RangeF hRange = new RangeF(0f, h_max_range); //H色调分量的变化范围

                //初始化，配置空间（告知色相的范围与切割的bin值）
                histDense = new DenseHistogram(h_bins, hRange);
                //把色相的影像数据传入，透过计算存入DenseHistogram 类别的histDense值方图信息
                CvInvoke.cvCalcHist(h_plane_ptr, histDense, true, System.IntPtr.Zero);
                CvInvoke.cvReleaseImage(ref hsv);
                CvInvoke.cvReleaseImage(ref h_plane);
                return histDense;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);

            }
        }

        private static DenseHistogram Cal2DHsvHist(Image<Bgr, Byte> srcImage, int h_bins, int s_bins)
        {
            try
            {
                DenseHistogram histDense;
                System.Drawing.Size a = srcImage.Size;
                int h_max_range = 180;
                int s_max_range = 180;
                int[] hist_size = new int[2] { h_bins, s_bins };

                IntPtr hsv = CvInvoke.cvCreateImage(a, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 3);

                //创建存放色相与饱和度影像信息的空间
                IntPtr h_plane = CvInvoke.cvCreateImage(a, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 1);
                IntPtr s_plane = CvInvoke.cvCreateImage(a, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 1);
                IntPtr v_plane = CvInvoke.cvCreateImage(a, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 1);
                IntPtr[] planes = new IntPtr[2] { h_plane, s_plane };

                /** Hue的变化范围 */
                float[] h_ranges = new float[2] { 0, h_max_range };

                /** 饱和度的变化范围 */
                float[] s_ranges = new float[2] { 0, s_max_range };

                CvInvoke.cvCvtColor(srcImage, hsv, Emgu.CV.CvEnum.COLOR_CONVERSION.BGR2HSV); //转换成Hsv色彩空间  
                CvInvoke.cvSplit(hsv, h_plane, s_plane, v_plane, System.IntPtr.Zero); // 分离取出色相空到的影像数据

                //计算

                RangeF hRange = new RangeF(0f, h_max_range);       //H色调分量的变化范围
                RangeF sRange = new RangeF(0f, s_max_range);       //S饱和度分量的变化范围
                histDense = new DenseHistogram(hist_size, new RangeF[] { hRange, sRange });
                CvInvoke.cvCalcHist(planes, histDense, false, System.IntPtr.Zero);
                CvInvoke.cvReleaseImage(ref hsv);
                CvInvoke.cvReleaseImage(ref h_plane);
                CvInvoke.cvReleaseImage(ref s_plane);
                CvInvoke.cvReleaseImage(ref v_plane);
                return histDense;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        private static Image<Bgr, Byte> drawHistImg(DenseHistogram histDense, int width, int height)
        {

            float max_value = 0.0f;
            int[] a1 = new int[100];
            int[] b1 = new int[100];
            float ax = 0;
            int h_bins = histDense.BinDimension[0].Size;
            CvInvoke.cvGetMinMaxHistValue(histDense, ref ax, ref max_value, a1, b1);
            Image<Bgr, Byte> hist_Img = new Image<Bgr, byte>(width, height, new Bgr(System.Drawing.Color.Black));
            System.Drawing.Color color = System.Drawing.Color.Blue;
            //設定值方圖圖像顯示的寬高
            int bin_w = width / (h_bins); //h_bin設定為50

            for (int h = 0; h < h_bins; h++)
            {

                /** 取得直方圖的統計資料，計算值方圖中的所有顏色中最高統計的數值，作為實際顯示時的圖像高 */
                //取得值方圖的數值位置,以便之後存成檔案
                double bin_val = CvInvoke.cvQueryHistValue_1D(histDense, h);

                //計算取得的bin值要顯示在240高的圖像上時的位置
                int intensity = (int)System.Math.Round(bin_val * height / max_value);

                /** 取得現在抓取的直方圖的hue顏色，並為了顯示成圖像可觀看，轉換成RGB色彩 */
                hist_Img.Draw(new System.Drawing.Rectangle(h * bin_w, height - intensity, bin_w, intensity), new Bgr(color),
                                1);

            }

            Image<Bgr, Byte> hist_emgu_img = new Image<Bgr, Byte>(new System.Drawing.Size(width, height));
            CvInvoke.cvCopy(hist_Img, hist_emgu_img.Ptr, IntPtr.Zero);
            return hist_emgu_img;


        }
        private static Image<Bgr, Byte> draw2DHistImg(DenseHistogram histDense, int width, int height)
        {

            float max_value = 0.0f;
            int[] a1 = new int[100];
            int[] b1 = new int[100];
            float ax = 0;
            int h_bins = histDense.BinDimension[0].Size;
            int s_bins = histDense.BinDimension[1].Size;
            CvInvoke.cvGetMinMaxHistValue(histDense, ref ax, ref max_value, a1, b1);
            if(max_value>5000)
                max_value -= 3000;
            //如果設定的bins超過視窗設定的顯示範圍,另外給予可以符合用額外的彈出視窗顯示的值,因為要同時看到h與s的bin值，顯示的圖像寬可能會太寬
            if (h_bins * s_bins > 466)
            {
                width = h_bins * s_bins * 2;
            }
            else
            {
                width = 466;
            }

            IntPtr hist_img = CvInvoke.cvCreateImage(new System.Drawing.Size(width, height), Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 3);
            CvInvoke.cvZero(hist_img);

            IntPtr hsv_color = CvInvoke.cvCreateImage(new System.Drawing.Size(1, 1), Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 3);
            IntPtr rgb_color = CvInvoke.cvCreateImage(new System.Drawing.Size(1, 1), Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 3);

            int bin_w = width / (h_bins * s_bins);
            for (int h = 0; h < h_bins; h++)
            {
                for (int s = 0; s < s_bins; s++)
                {
                    int i = h * s_bins + s;

                    /** 取得直方圖的統計資料，計算值方圖中的所有顏色中最高統計的數值，作為實際顯示時的圖像高 */
                    //取得值方圖的數值位置,以便之後存成檔案
                    double bin_val = CvInvoke.cvQueryHistValue_2D(histDense, h, s);
                    int intensity = (int)System.Math.Round(bin_val * height / max_value);

                    /** 取得現在抓取的直方圖的hue顏色，並為了顯示成圖像可觀看，轉換成RGB色彩 */
                    CvInvoke.cvSet2D(hsv_color, 0, 0, new Emgu.CV.Structure.MCvScalar(h * 180.0f / h_bins, s * 255.0f / s_bins, 255, 0)); //這邊用來計算色相與飽和度的統計資料轉換到圖像上 hsv_color的數值
                    CvInvoke.cvCvtColor(hsv_color, rgb_color, COLOR_CONVERSION.HSV2BGR);   //在把hsv顏色空間轉換為RGB
                    Emgu.CV.Structure.MCvScalar color = CvInvoke.cvGet2D(rgb_color, 0, 0);
                    CvInvoke.cvRectangle(hist_img, new System.Drawing.Point(i * bin_w, height), new System.Drawing.Point((i + 1) * bin_w, height - intensity), color, 2, Emgu.CV.CvEnum.LINE_TYPE.EIGHT_CONNECTED, 0);
                }
            }
            Image<Bgr, Byte> hist_emgu_img = new Image<Bgr, Byte>(new System.Drawing.Size(width, height));
            CvInvoke.cvCopy(hist_img, hist_emgu_img.Ptr, IntPtr.Zero);
            CvInvoke.cvReleaseImage(ref hist_img);
            CvInvoke.cvReleaseImage(ref hsv_color);
            CvInvoke.cvReleaseImage(ref rgb_color);
            return hist_emgu_img;
        }
        /// <summary>
        /// hue色相轉換成rgb color
        /// </summary>
        /// <param name="hue"></param>
        /// <returns></returns>
        private static MCvScalar HueToBgr(double hue)
        {
            int[] rgb = new int[3];
            int p, sector;
            int[,] sector_data = { { 0, 2, 1 }, { 1, 2, 0 }, { 1, 0, 2 }, { 2, 0, 1 }, { 2, 1, 0 }, { 0, 1, 2 } };
            hue *= 0.033333333333333333333333333333333f;
            sector = (int)Math.Floor(hue);
            p = (int)Math.Round(255 * (hue - sector));
            //p ^= sector & 1 ? 255 : 0;
            if ((sector & 1) == 1) p ^= 255;
            else p ^= 0;
            rgb[sector_data[sector, 0]] = 255;
            rgb[sector_data[sector, 1]] = 0;
            rgb[sector_data[sector, 2]] = p;
            MCvScalar scalar = new MCvScalar(rgb[2], rgb[1], rgb[0], 0);
            return scalar;
        }

        public static Image<Bgr, Byte> DrawHisImg(Image<Bgr, Byte> srcImage, int h_bins)
        {
            DenseHistogram histDense = Cal1DHsvHist(srcImage, h_bins);
            return drawHistImg(histDense, 466, 72);
        }

        public static Image<Bgr, Byte> Draw2DHisImg(Image<Bgr, Byte> srcImage, int h_bins,int s_bins)
        {
            DenseHistogram histDense = Cal2DHsvHist(srcImage, h_bins,s_bins);
            return draw2DHistImg(histDense, 466, 72);
        }

        public static Image<Bgr, Byte> DrawHisImg(Image<Bgr, Byte> srcImage)
        {
            System.Drawing.Size a = srcImage.Size;
            IntPtr gray_plane = CvInvoke.cvCreateImage(a, Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 1);
            CvInvoke.cvCvtColor(srcImage, gray_plane, Emgu.CV.CvEnum.COLOR_CONVERSION.BGR2GRAY);  
  
            int hist_size = 256;    //直方图尺寸  
            int[] hist_sizes = new int[1] {256};
            int hist_height = 256;  
            float[] ranges = {0,255};  //灰度级的范围  

            //创建一维直方图，统计图像在[0 255]像素的均匀分布  
            IntPtr gray_hist = CvInvoke.cvCreateHist(1,hist_sizes,Emgu.CV.CvEnum.HIST_TYPE.CV_HIST_ARRAY,null,1);  
            //计算灰度图像的一维直方图  
            IntPtr[] inPtr1 = new IntPtr[1] { gray_plane };
            CvInvoke.cvCalcHist(inPtr1, gray_hist, false, IntPtr.Zero);  
            //归一化直方图  
            CvInvoke.cvNormalizeHist(gray_hist, 1.0);  
  
            int scale = 2;  
            //创建一张一维直方图的“图”，横坐标为灰度级，纵坐标为像素个数（*scale）  
            IntPtr hist_image = CvInvoke.cvCreateImage(new System.Drawing.Size(hist_size * scale, hist_height), Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 3);
            
            CvInvoke.cvZero(hist_image);  
            //统计直方图中的最大直方块  
            float max_value = 0;
            int[] a1 = new int[100];
            int[] b1 = new int[100];
            float ax = 0;
            CvInvoke.cvGetMinMaxHistValue(gray_hist, ref ax, ref max_value, a1, b1);
            //分别将每个直方块的值绘制到图中  
            for(int i=0;i<hist_size;i++)  
            {
                double bin_val = CvInvoke.cvQueryHistValue_1D(gray_hist, i);

                //計算取得的bin值要顯示在240高的圖像上時的位置
                int intensity = (int)System.Math.Round(bin_val * hist_height / max_value);

                /** 取得現在抓取的直方圖的hue顏色，並為了顯示成圖像可觀看，轉換成RGB色彩 */
                 CvInvoke.cvRectangle(hist_image, new System.Drawing.Point(i * scale, hist_height), new System.Drawing.Point((i + 1) * scale - 1, hist_height - intensity), new MCvScalar(0,255,0), 1, Emgu.CV.CvEnum.LINE_TYPE.CV_AA, 0);
    
            }

            Image<Bgr, Byte> hist_emgu_img = new Image<Bgr, Byte>(new System.Drawing.Size(hist_size * scale, hist_height));
            CvInvoke.cvCopy(hist_image, hist_emgu_img.Ptr, IntPtr.Zero);
            CvInvoke.cvReleaseImage(ref hist_image);
            CvInvoke.cvReleaseImage(ref gray_plane);
            CvInvoke.cvReleaseHist(ref gray_hist);
            return hist_emgu_img;
        }

        
    }
}
