using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIS.Common;

namespace RIS.Common
{
    public class ServerResponseEntity
    {
        private HeadEntity _head = new HeadEntity();
        public HeadEntity head
        {
            get { return _head; }
            set { _head = value; }
        
        }

        private ResponseBodyEntity _body = new ResponseBodyEntity();
        public ResponseBodyEntity body
        {
            get { return _body; }
            set { _body = value; }

        }
    }
    public class ResponseBodyEntity
    {
        private int _res=0;
        public int res
        {
            get
            {
                return _res;
            }
            set
            {
                _res=value;
            }
        }
        public string desc
        {
            get;
            set;
        }

        public int bizflag;

        public ResponseDataEntity data
        { get; set; }

    }

    public class ResponseDataEntity
    {
        public string name;
        public string title;
        public string fcid;
        public byte[] photo;
    }
    
}
