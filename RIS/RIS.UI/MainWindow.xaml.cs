using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.IO.Ports;
using WPFMediaKit.DirectShow.Controls;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Threading;
using System.Windows.Threading;
using RIS.BusinessRule;
using RIS.Common;
using System.Runtime.InteropServices;
using RIS.Entity.Entity;
using Emgu.CV.CvEnum;
using RIS.ThreadPool;

namespace RIS.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CapFra capFra;
        private DoorManager _door;
        private DispatcherTimer timer;
        private System.Windows.Media.Color ColorRed = System.Windows.Media.Color.FromRgb(255, 0, 0);
        private System.Windows.Media.Color ColorWhite = System.Windows.Media.Color.FromRgb(255, 255, 255);
        private DispatcherTimer timerEndShowLable;
        private DispatcherTimer timerEndShowReco;
        public bool ShowRecing = false;
        private DispatcherTimer timerHeart;
        public MainWindow()
        {
            InitializeComponent();
            //_door = new DoorManager(this);
            this.label1.Content = ConstAndEnum.WELCOME;
        }
        public DoorManager Door
        {
            get
            {
                return _door;
            }
        }
        public void ThreadWriteDevice()
        {
            try
            {
                string iniMess = DeviceBusiness.WriteDeviceInfo();
                if (iniMess == "")
                    ShowLable1("初始化成功！", false);
                else
                    ShowLable2(iniMess,false);
              

            }
            catch (Exception ex)
            {
                ShowLable2(ex.Message,false);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DeviceBusiness.WriteDeviceInfo();
            ///IrisRecoInterface.initialClassifier();
            capFra = new CapFra(this);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(ConstAndEnum.VEDIO_FREQUENCE);
            timer.Tick += timer1_Tick;
            //timer.Start();

            timerEndShowLable = new DispatcherTimer();
            timerEndShowLable.Interval = TimeSpan.FromMilliseconds(ConstAndEnum.SHOW_END_DELAY);
            timerEndShowLable.Tick += timerEndShowLable_Tick;

            timerEndShowReco = new DispatcherTimer();
            timerEndShowReco.Interval = TimeSpan.FromMilliseconds(ConstAndEnum.SHOW_END_DELAY);
            timerEndShowReco.Tick += timerEndShowReco_Tick;

            timerHeart = new DispatcherTimer();
            timerHeart.Interval = TimeSpan.FromMilliseconds(ConstAndEnum.HEART_BEAT_INTERVAL);
            timerHeart.Tick += timerHeart_Tick;
            timerHeart.Start();

            DelayEndShowLable();

            
        }
        private void DelayEndShowLable()
        {
            lableShowing = true;
            this.timerEndShowLable.Start();
        }
        
        private void timerEndShowLable_Tick(object sender, EventArgs e)
        {
            lableShowing = false;
            this.timerEndShowLable.Stop();
            this.ShowLable1(ConstAndEnum.WELCOME, false); ;
        }
        private void timerEndShowReco_Tick(object sender, EventArgs e)
        {
            this.timerEndShowReco.Stop();
            this.lblName.Content = "";
            this.lblTitle.Content = "";
            this.imgRec.Source = null;
            this.lblAccess.Content = "";
            this.lblAccess.Visibility = System.Windows.Visibility.Hidden;
            this.ShowRecing = false;
        }
        bool isShowEyeOpen = false;
        private void timerEyeOpen_Tick(object sender, EventArgs e)
        {
            isShowEyeOpen = !isShowEyeOpen;
            Action action = new Action(() =>
            {
                if (isShowEyeOpen)
                {
                    this.imgEyeOpen.Source = new BitmapImage(new Uri("/RIS;component/Images/EyeOpen.png", UriKind.Relative));
                }
                else
                {
                    this.imgEyeOpen.Source = new BitmapImage(new Uri("/RIS;component/Images/EyeClose.png", UriKind.Relative));
                }
            });
            if (Thread.CurrentThread != this.label1.Dispatcher.Thread)
                this.Dispatcher.Invoke(action);
            else
                action();
        }

        private void timerHeart_Tick(object sender, EventArgs e)
        {
            num++;
            if (num == 100000)
                num = 0;
            /////////////////////////////////////////Test
            //FileStream filer = File.OpenRead("D:\\createFCResponse.txt");
            //StreamReader sr1 = new StreamReader(filer);
            //string jsString = sr1.ReadToEnd();
            //sr1.Close();
            //filer.Close();
            //ServerResponseEntity data = JsonHelper.JsonStringToObject<ServerResponseEntity>(jsString);
            //////////////////////////////////////////////////
            //FileStream filer2 = File.OpenRead("D:\\recognizeResponse.txt");
            //StreamReader sr2 = new StreamReader(filer2);
            //string jsString2 = sr2.ReadToEnd();
            //sr2.Close();
            //filer2.Close();
            //ServerResponseEntity data2 = JsonHelper.JsonStringToObject<ServerResponseEntity>(jsString2);

            //Bitmap bmp2 = CommonUntil.GetBitmapFromBytes(data2.body.data.photo);
            ///////////////////////////////////////////////
            //显示时间
            this.lblTime.Content = DateTime.Now.ToString("HH:mm:ss");

            //检查设备状态
            if (num % 5 == 0)
            {
                if (capFra.videoSource != null)
                {
                    AppDeviceInfoEntity deviceEntity = DeviceBusiness.GetDeviceInfo();
                    if (deviceEntity != null)
                    {
                        //check device status
                        string devicestatus = "设备状态为" + ((DeviceStatus)deviceEntity.Devicestatus).ToString();
                        if (deviceEntity.Devicestatus != DeviceStatus.正常.GetHashCode() || ShowRecing)
                        {
                            ShowLable1(devicestatus, false);

                        }
                        else
                        {
                            ShowLable1(devicestatus, true);
                        }
                    }
                }
                else
                {
                    this.ShowLable1("没有找到视频设备！", false);
                }
                
            }
            if (num % 60 == 0)
            {
                //delete Data
                //delete file 10 second
                List<IrisRecoImageEntity> list = IrisBusiness.GetAllRecoImage();
                foreach (IrisRecoImageEntity entity in list)
                {

                    if ((DateTime.Now - DateTime.ParseExact(entity.Createtime,"yyyy-MM-dd HH:mm:ss",null)).Seconds > 10)
                    {
                        IrisBusiness.DeleteIrisImage(entity);
                        FileInfo fi = new FileInfo(entity.Imagepath);
                        fi.Delete();
                    }
                }
            }
            

        }
        int num = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Query Frame
            //capFra.QueryAndDispatch();

                      
        }
        bool lableShowing = false;
        public void ShowLable1(string content, bool isDelay)
        {
            Action action = new Action(() =>
            {
                if (isDelay)
                {
                    this.label1.Content = content;
                    DelayEndShowLable();
                }
                else if (lableShowing == false)
                {
                    this.label1.Content = content;
                }
                else
                {
                    return;
                }
            });
            if (Thread.CurrentThread != this.label1.Dispatcher.Thread)
                this.Dispatcher.Invoke(action);
            else
                action();
        }
        public void ShowLable2(string content)
        {
            ShowLable2(content,true);
        }
        public void ShowLable2(string content, bool bRet)
        {
            Action action = new Action(() =>
            {
                System.Windows.Media.Color color;
                if (bRet)
                    color = ColorWhite;
                else
                    color = ColorRed;
                this.label2.Foreground = new SolidColorBrush(color);
                this.label2.Content = content;

            });
            if (Thread.CurrentThread != this.label1.Dispatcher.Thread)
                this.Dispatcher.Invoke(action);
            else
                action();
        }


        public void ShowImg(byte[] imgBytes)
        {
            Action action = new Action(() =>
            {
                MemoryStream stream = new MemoryStream(imgBytes);
                BitmapImage bmpImg = new BitmapImage();
                bmpImg.BeginInit();
                bmpImg.StreamSource = stream;
                bmpImg.EndInit();
                this.imgSource.Source = bmpImg;
            });
            if (Thread.CurrentThread != this.imgRec.Dispatcher.Thread)
                this.Dispatcher.Invoke(action);
            else
                action();
        }
        public void ShowImg(Bitmap b)
        {
            MemoryStream ms = new MemoryStream();
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();
            ms.Close();
            ShowImg(bytes);
        }

        public void ShowHistImg(Bitmap b)
        {
            MemoryStream ms = new MemoryStream();
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();
            ms.Close();
            Action action = new Action(() =>
            {
                MemoryStream stream = new MemoryStream(bytes);
                BitmapImage bmpImg = new BitmapImage();
                bmpImg.BeginInit();
                bmpImg.StreamSource = stream;
                bmpImg.EndInit();
                
                this.imgZF.Source = bmpImg;
            });
            if (Thread.CurrentThread != this.imgRec.Dispatcher.Thread)
                this.Dispatcher.Invoke(action);
            else
                action();
        }

        public void ShowRecoImg(bool isSucc,byte[] imgBytes, string name, string title,string accessContent)
        {
            Action action = new Action(() =>
                {
                    if (isSucc)
                    {
                        if (imgBytes != null && imgBytes.Length > 0)
                        {
                            MemoryStream stream = new MemoryStream(imgBytes);
                            BitmapImage bmpImg = new BitmapImage();
                            bmpImg.BeginInit();
                            bmpImg.StreamSource = stream;
                            bmpImg.EndInit();
                            this.imgRec.Source = bmpImg;
                            
                        }
                        else
                        {
                            this.imgRec.Source = new BitmapImage(new Uri("/RIS;component/Images/default.png", UriKind.Relative));
                        }
                        
                        
                        this.lblName.Content = name;
                        this.lblTitle.Content = title;
                    }
                    else
                    {
                        this.imgRec.Source = new BitmapImage(new Uri("/RIS;component/Images/default.png", UriKind.Relative));
                        this.lblName.Content = name;
                        this.lblTitle.Content = title;
                    }
                    this.lblAccess.Content = accessContent;
                    this.lblAccess.Visibility = System.Windows.Visibility.Visible;
                    this.ShowRecing = true;
                    timerEndShowReco.Start();
                });
            if (Thread.CurrentThread != this.imgRec.Dispatcher.Thread)
                this.Dispatcher.Invoke(action);
            else
                action();
                
        }
        public void ShowEyeImg(int num)
        {
            Action action = new Action(() =>
            {
                if(ShowRecing==false)
                {
                    if(num==-1)
                        this.imgEye.Source = new BitmapImage(new Uri("/RIS;component/Images/eye.png", UriKind.Relative));
                    else
                        this.imgEye.Source = new BitmapImage(new Uri("/RIS;component/Images/eye/"+num.ToString()+".png", UriKind.Relative));
                }

                
            });
            if (Thread.CurrentThread != this.imgRec.Dispatcher.Thread)
                this.Dispatcher.Invoke(action);
            else
                action();

        }
        /// <summary>
        /// 拍照
        /// </summary>

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            this.capFra.frame_rgb.Save("c:\\image\\1.bmp");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.capFra.StopAndDispose();
            if (_door != null)
            {
                _door.CloseDoor();
                _door.Dispose();
                _door = null;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Input.KeyboardDevice kd = e.KeyboardDevice;
            if ((kd.GetKeyStates(Key.LeftAlt) & System.Windows.Input.KeyStates.Down) > 0 ||
                (kd.GetKeyStates(Key.RightAlt) & System.Windows.Input.KeyStates.Down) > 0)
            {

                if ((kd.GetKeyStates(Key.F4) & System.Windows.Input.KeyStates.Down) > 0)
                {
                    this.capFra.StopAndDispose();
                }
            }

        }

      
    }
}
