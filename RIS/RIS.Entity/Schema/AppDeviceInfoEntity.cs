using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using C2Olay.TransactionOlayEx.Schema;

namespace C2Olay.TransactionOlayEx.Entity
{
    [Serializable]
    public partial class AppDeviceInfoEntity : EntityBase
    {
        public AppDeviceInfoTable TableSchema
        {
            get
            {
                return AppDeviceInfoTable.Current;
            }
        }


        public AppDeviceInfoEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return AppDeviceInfoTable.Current;
            }
        }
        #region 属性列表

        public string Deviceid
        {
            get { return (string)GetData(AppDeviceInfoTable.C_DeviceId); }
            set { SetData(AppDeviceInfoTable.C_DeviceId, value); }
        }

        public string Hardwarecode
        {
            get { return (string)GetData(AppDeviceInfoTable.C_HardwareCode); }
            set { SetData(AppDeviceInfoTable.C_HardwareCode, value); }
        }

        public string Location
        {
            get { return (string)GetData(AppDeviceInfoTable.C_Location); }
            set { SetData(AppDeviceInfoTable.C_Location, value); }
        }

        public int Devicestatus
        {
            get { return (int)(GetData(AppDeviceInfoTable.C_DeviceStatus)); }
            set { SetData(AppDeviceInfoTable.C_DeviceStatus, value); }
        }

        public DateTime Lastmodifiedtime
        {
            get { return (DateTime)(GetData(AppDeviceInfoTable.C_LastModifiedTime) == null ? DateTime.MinValue : GetData(AppDeviceInfoTable.C_LastModifiedTime)); }
            set { SetData(AppDeviceInfoTable.C_LastModifiedTime, value); }
        }

        public string Lastmodifiedby
        {
            get { return (string)GetData(AppDeviceInfoTable.C_LastModifiedBy); }
            set { SetData(AppDeviceInfoTable.C_LastModifiedBy, value); }
        }

        #endregion
    }
}
