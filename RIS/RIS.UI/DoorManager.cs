using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Threading;
using RIS.Common;

namespace RIS.UI
{
    public class DoorManager
    {
        SerialPort com1;
        MainWindow mainWindow;
        private DispatcherTimer timerCloseDoor;
        public bool OpenStatus
        {
            get;
            set;
        }
        public DoorManager(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            if (InitialDoor())
            {
                CloseDoor();
                timerCloseDoor = new DispatcherTimer();
                timerCloseDoor.Interval = TimeSpan.FromMilliseconds(ConstAndEnum.SHOW_END_DELAY);
                timerCloseDoor.Tick += new EventHandler(timerCloseDoor_Tick);
            }
        }

        void timerCloseDoor_Tick(object sender, EventArgs e)
        {
            this.timerCloseDoor.Stop();
            CloseDoor();
        }

        private bool InitialDoor()
        {
            try
            {
                com1 = new SerialPort();
                string[] names = SerialPort.GetPortNames();
                if (names.Length > 0)
                {

                    com1.PortName = names[1];
                    com1.BaudRate = 9600;
                    com1.DataBits = 8;
                    com1.StopBits = StopBits.One;
                    try
                    {
                        if (!com1.IsOpen)
                            com1.Open();
                        com1.DataReceived += new SerialDataReceivedEventHandler(com1_DataReceived);
                        mainWindow.ShowLable2("打开串口成功！");
                        return true;
                    }
                    catch (Exception ex)
                    {
                        mainWindow.ShowLable2("打开串口失败！", false);
                        return false;
                    }
                }
                else
                {
                    mainWindow.ShowLable2("未找到串口", false);
                    return false;
                }
            }
            catch (Exception ex)
            {
                mainWindow.ShowLable2(ex.Message, false);
                return false;
            }

        }
        void com1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string DataTemp = this.com1.ReadLine();
            DataTemp = DataTemp.Trim();
        }
        public bool OpenDoor()
        {
            try
            {
                byte[] send = { 0xA0, 0x01,0x01, 0xA2 };
                if (com1.IsOpen)
                {
                    com1.Write(send, 0, send.Length);
                    OpenStatus = true;
                    //Auto Close
                    if (this.timerCloseDoor.IsEnabled)
                        this.timerCloseDoor.Stop();
                    this.timerCloseDoor.Start();
                }
            }
            catch (Exception ex)
            {
                mainWindow.ShowLable2("打开门禁失败！",false);
                return false;
            }
            return true;
        }

        internal bool CloseDoor()
        {
            try
            {
                byte[] send = { 0xA0, 0x01, 0x00, 0xA1 };
                if (com1.IsOpen)
                {
                    com1.Write(send, 0, send.Length);
                    OpenStatus = false;
                }
            }
            catch (Exception ex)
            {
                mainWindow.ShowLable2("关闭门禁失败！",false);
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            if (com1.IsOpen)
            {
                this.com1.Close();
            }
            if (com1 != null)
            {
                com1.Dispose();
                com1 = null;
            }
        }
    }


}
