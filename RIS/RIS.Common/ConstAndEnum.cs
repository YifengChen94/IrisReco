using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RIS.Common
{
    public class ConstAndEnum
    {
        public const string RootPath = @"D:\IrisReco\";
        public const string WaitingPath = @"D:\IrisReco\image\";
        public const string WELCOME = "欢迎光临！";
        public const int VEDIO_FREQUENCE = 93;
        public const int SHOW_END_DELAY = 5000;
        public const int FILE_MINCOUNTFORUPLOAD = 1;
        public const int FILE_COLLECTCOUNTFORUPLOAD = 3;
        public const int FILE_MAXCOUNTFORUPLOAD = 5;
        public const int HEART_BEAT_INTERVAL = 1000;
        public const int SHOW_EYE_INTERVAL = 250;
        public const int IMAGE_CACHED_TIME = 10;//Second
        public const int IMAGE_CACHED_TIME_COLLECT = 60;//Second
        public const int COLLECT_OPERATION_TIMEOUT = 300;//Second
        public const string IMAGE_DIR_PATH = ".\\RecoTemp\\";
    }

    public enum DeviceStatus
    {
        正常,
        故障
    }


}
