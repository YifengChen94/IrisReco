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


namespace RIS.ThreadPool
{
    public class ThreadRead
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

        public AutoResetEvent ThreadEventReadToSend
        { get; set; }
        MainWindow mainWindow;

        public ThreadRead(MainWindow mainWindow)
        {
            ThreadEventReadToSend = new AutoResetEvent(false);
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
                    ThreadEventReadToSend.WaitOne(Timeout.Infinite);
                    if (mainWindow.ShowRecing)
                        continue;
                    MstAuditUserEntity authorInfo;
                    int ret = ReadRecoResult(out authorInfo);

                    if (ret>0)
                    {
                        //Show Image data
                        mainWindow.ShowRecoImg(true, CommonUntil.GetByteFromBitmap(authorInfo.ImageBitmap), authorInfo.Username, authorInfo.Title, "认证成功");
                        mainWindow.ShowLable2("认证成功.");
                        //mainWindow.Door.OpenDoor();
                    }
                    else if (ret == -1)
                    {
                        mainWindow.ShowRecoImg(false, null, "", "", "认证失败");
                        mainWindow.ShowLable2("认证失败.");
                    }

                    else//无数据或数据已失效
                    {
                        mainWindow.ShowLable2("无有效数据.");
                    }
 
                }
                catch (Exception ex)
                {
                    mainWindow.ShowLable2("读取识别异常!", false);
                }
                finally
                {

                    isbusy = false;
                }
            }
            
        }

        private int ReadRecoResult(out MstAuditUserEntity authorInfo)
        {
            authorInfo = null;
            List<IrisRecoResultEntity> content = ReadRecoResult();

            if (content.Count == 0)
                return -2;//没有数据
            else if (content.Count >= 10)
            {
                ClearRecoResult();
            }
            else//结果不足
            {
                return -2;
            }
            Dictionary<string, int> dicRec = new Dictionary<string, int>();
            int invalidCount = 0;
            foreach (IrisRecoResultEntity entity in content)
            {
                string id = entity.Audituserid;
                string time = entity.Recotime;

                DateTime dt = DateTime.Parse(time);
                TimeSpan ts = DateTime.Now - dt;
                if (ts.TotalSeconds < 60)
                {
                    if (!dicRec.ContainsKey(id))
                        dicRec[id] = 0;
                    dicRec[id]++;

                }
                else
                {
                    invalidCount++;
                    ;//有数据但是已失效
                }
            }
            string maxUserid = "";
            int count = 0;
            foreach (string key in dicRec.Keys)
            {
                if (dicRec[key] > count)
                {
                    count = dicRec[key];
                    maxUserid = key;
                }
            }
            if ((invalidCount * 100.0 / content.Count) >= 20)
                return -3;//失效数据过多

            if (count * 100.0 / content.Count >=60)
            {
                authorInfo = AuthorListCaching.GetAuthorInfoById(maxUserid);
                return 1;
            }
            else
                return -1;//识别失败数量过多，认定识别失败
        }

        private void ClearRecoResult()
        {
            IrisBusiness.DeleteAllIrisRecoResult();
        }

        private static List<IrisRecoResultEntity> ReadRecoResult()
        {
            return IrisBusiness.ReadAllResult();
        }

        
    }
}
