using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class HubEntity : EntityBase
    {
        public HubTable TableSchema
        {
            get
            {
                return (HubTable)_tableSchema;
            }
        }


        public HubEntity()
        {
            _tableSchema = HubTable.Current;
        }

        #region 属性列表

        public string Dmsid
        {
            get { return (string)GetData(HubTable.C_DMSID); }
            set { SetData(HubTable.C_DMSID, value); }
        }

        public string Cityid
        {
            get { return (string)GetData(HubTable.C_CityID); }
            set { SetData(HubTable.C_CityID, value); }
        }

        public string Market
        {
            get { return (string)GetData(HubTable.C_Market); }
            set { SetData(HubTable.C_Market, value); }
        }

        public string Shiptocode
        {
            get { return (string)GetData(HubTable.C_ShiptoCode); }
            set { SetData(HubTable.C_ShiptoCode, value); }
        }

        public string Soldtocode
        {
            get { return (string)GetData(HubTable.C_SoldtoCode); }
            set { SetData(HubTable.C_SoldtoCode, value); }
        }

        public string Rdid
        {
            get { return (string)GetData(HubTable.C_RDID); }
            set { SetData(HubTable.C_RDID, value); }
        }

        public string Customername
        {
            get { return (string)GetData(HubTable.C_CustomerName); }
            set { SetData(HubTable.C_CustomerName, value); }
        }

        public string City
        {
            get { return (string)GetData(HubTable.C_City); }
            set { SetData(HubTable.C_City, value); }
        }

        public string Hubtype
        {
            get { return (string)GetData(HubTable.C_HubType); }
            set { SetData(HubTable.C_HubType, value); }
        }

        public int Hm
        {
            get { return (int)(GetData(HubTable.C_HM)); }
            set { SetData(HubTable.C_HM, value); }
        }

        public int Sm
        {
            get { return (int)(GetData(HubTable.C_SM)); }
            set { SetData(HubTable.C_SM, value); }
        }

        public int Mm
        {
            get { return (int)(GetData(HubTable.C_MM)); }
            set { SetData(HubTable.C_MM, value); }
        }

        public string Hubaccount
        {
            get { return (string)GetData(HubTable.C_HubAccount); }
            set { SetData(HubTable.C_HubAccount, value); }
        }

        public string Hubpassword
        {
            get { return (string)GetData(HubTable.C_HubPassword); }
            set { SetData(HubTable.C_HubPassword, value); }
        }

        public int Hubstatus
        {
            get { return (int)(GetData(HubTable.C_HubStatus)); }
            set { SetData(HubTable.C_HubStatus, value); }
        }

        public int Merchandisernum
        {
            get { return (int)(GetData(HubTable.C_MerchandiserNum)); }
            set { SetData(HubTable.C_MerchandiserNum, value); }
        }

        public DateTime Lockedtime
        {
            get { return (DateTime)(GetData(HubTable.C_LockedTime)); }
            set { SetData(HubTable.C_LockedTime, value); }
        }

        public DateTime Lastmodifypasswordtime
        {
            get { return (DateTime)(GetData(HubTable.C_LastModifyPasswordTime)); }
            set { SetData(HubTable.C_LastModifyPasswordTime, value); }
        }

        public DateTime Lastuploadtime
        {
            get { return (DateTime)(GetData(HubTable.C_LastUploadTime)); }
            set { SetData(HubTable.C_LastUploadTime, value); }
        }

        public DateTime Lastdownloadtime
        {
            get { return (DateTime)(GetData(HubTable.C_LastDownloadTime)); }
            set { SetData(HubTable.C_LastDownloadTime, value); }
        }

        #endregion
    }
}
