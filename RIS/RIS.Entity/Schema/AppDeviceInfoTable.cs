using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace RIS.Entity.Schema
{
    [Serializable]
    public partial class AppDeviceInfoTable : TableInfo
    {
        public const string C_TableName = "APP_Device_Info";

        public const string C_DeviceId = "DeviceId";

        public const string C_HardwareCode = "HardwareCode";

        public const string C_Location = "Location";

        public const string C_DeviceStatus = "DeviceStatus";

        public const string C_LastModifiedTime = "LastModifiedTime";

        public const string C_LastModifiedBy = "LastModifiedBy";


        public AppDeviceInfoTable()
        {
            _tableName = "APP_Device_Info";
        }

        protected static AppDeviceInfoTable _current;
        public static AppDeviceInfoTable Current
        {
            get
            {
                if (_current == null)
                {
                    Initial();
                }
                return _current;
            }
        }

        private static void Initial()
        {
            _current = new AppDeviceInfoTable();

            _current.Add(C_DeviceId, new ColumnInfo(C_DeviceId, "Deviceid", true, typeof(string)));

            _current.Add(C_HardwareCode, new ColumnInfo(C_HardwareCode, "Hardwarecode", false, typeof(string)));

            _current.Add(C_Location, new ColumnInfo(C_Location, "Location", false, typeof(string)));

            _current.Add(C_DeviceStatus, new ColumnInfo(C_DeviceStatus, "Devicestatus", false, typeof(int)));

            _current.Add(C_LastModifiedTime, new ColumnInfo(C_LastModifiedTime, "Lastmodifiedtime", false, typeof(DateTime)));

            _current.Add(C_LastModifiedBy, new ColumnInfo(C_LastModifiedBy, "Lastmodifiedby", false, typeof(string)));

        }


        public ColumnInfo DeviceId
        {
            get { return this[C_DeviceId]; }
        }

        public ColumnInfo HardwareCode
        {
            get { return this[C_HardwareCode]; }
        }

        public ColumnInfo Location
        {
            get { return this[C_Location]; }
        }

        public ColumnInfo DeviceStatus
        {
            get { return this[C_DeviceStatus]; }
        }

        public ColumnInfo LastModifiedTime
        {
            get { return this[C_LastModifiedTime]; }
        }

        public ColumnInfo LastModifiedBy
        {
            get { return this[C_LastModifiedBy]; }
        }

    }
}
