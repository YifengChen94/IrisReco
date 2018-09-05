using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIS.Common;
using RIS.Entity.Entity;

namespace RIS.Common
{
    public class ServerHeartDataEntity
    {
        private HeadEntity _head = new HeadEntity();
        public HeadEntity head
        {
            get 
            {
                return _head; 
            }
            set { _head = value; }
        
        }


    }

}
