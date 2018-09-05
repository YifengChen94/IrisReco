using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIS.Common;

namespace RIS.Common
{
    public class ServerDataEntity
    {
        private HeadEntity _head = new HeadEntity();
        public HeadEntity head
        {
            get { return _head; }
            set { _head = value; }
        
        }

        private BodyEntity _body = new BodyEntity();
        public BodyEntity body
        {
            get { return _body; }
            set { _body = value; }

        }
    }

    public class HeadEntity
    {
        private string _ver = "1.0";
        public string ver
        {
            get
            {
                return _ver;
            }
            set
            {
                _ver = value;
            }
        }
        private string _id;
        public string id
        {
            get { return Guid.NewGuid().ToString(); }
            set { _id = value; }
        }
        private string _type = "createFC";
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _createtime;
        public string createtime
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { _createtime = value; }

        }
        private string _extend="";
        public string extend
        {
            get { return _extend; }
            set { _extend = value; }
        }

    }

    public class BodyEntity
    {
        private string _hardcode = ComputerUtility.DeviceID;
        public string hardcode
        {
            get
            {
                return _hardcode;
            }
            set { _hardcode = value; }
        }
        public int status { get; set; }

        public int eye = 0;

        public byte[] files { get; set; }


    }
}
