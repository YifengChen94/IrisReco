using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class HubTable : TableInfo
    {
        public const string C_TableName = "HUB";

        public const string C_DMSID = "DMSID";

        public const string C_CityID = "CITYID";

        public const string C_Market = "MARKET";

        public const string C_ShiptoCode = "SHIPTOCODE";

        public const string C_SoldtoCode = "SOLDTOCODE";

        public const string C_RDID = "RDID";

        public const string C_CustomerName = "CUSTOMERNAME";

        public const string C_City = "CITY";

        public const string C_HubType = "HUBTYPE";

        public const string C_HM = "HM";

        public const string C_SM = "SM";

        public const string C_MM = "MM";

        public const string C_HubAccount = "HUBACCOUNT";

        public const string C_HubPassword = "HUBPASSWORD";

        public const string C_HubStatus = "HUBSTATUS";

        public const string C_MerchandiserNum = "MERCHANDISERNUM";

        public const string C_LockedTime = "LOCKEDTIME";

        public const string C_LastModifyPasswordTime = "LASTMODIFYPASSWORDTIME";

        public const string C_LastUploadTime = "LASTUPLOADTIME";

        public const string C_LastDownloadTime = "LASTDOWNLOADTIME";


        public HubTable()
        {
            _tableName = "HUB";
        }

        protected static HubTable _current;
        public static HubTable Current
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
            _current = new HubTable();

            _current.Add(C_DMSID, new ColumnInfo(C_DMSID, "Dmsid", true, typeof(string)));

            _current.Add(C_CityID, new ColumnInfo(C_CityID, "Cityid", false, typeof(string)));

            _current.Add(C_Market, new ColumnInfo(C_Market, "Market", false, typeof(string)));

            _current.Add(C_ShiptoCode, new ColumnInfo(C_ShiptoCode, "Shiptocode", false, typeof(string)));

            _current.Add(C_SoldtoCode, new ColumnInfo(C_SoldtoCode, "Soldtocode", false, typeof(string)));

            _current.Add(C_RDID, new ColumnInfo(C_RDID, "Rdid", false, typeof(string)));

            _current.Add(C_CustomerName, new ColumnInfo(C_CustomerName, "Customername", false, typeof(string)));

            _current.Add(C_City, new ColumnInfo(C_City, "City", false, typeof(string)));

            _current.Add(C_HubType, new ColumnInfo(C_HubType, "Hubtype", false, typeof(string)));

            _current.Add(C_HM, new ColumnInfo(C_HM, "Hm", false, typeof(int)));

            _current.Add(C_SM, new ColumnInfo(C_SM, "Sm", false, typeof(int)));

            _current.Add(C_MM, new ColumnInfo(C_MM, "Mm", false, typeof(int)));

            _current.Add(C_HubAccount, new ColumnInfo(C_HubAccount, "Hubaccount", false, typeof(string)));

            _current.Add(C_HubPassword, new ColumnInfo(C_HubPassword, "Hubpassword", false, typeof(string)));

            _current.Add(C_HubStatus, new ColumnInfo(C_HubStatus, "Hubstatus", false, typeof(int)));

            _current.Add(C_MerchandiserNum, new ColumnInfo(C_MerchandiserNum, "Merchandisernum", false, typeof(int)));

            _current.Add(C_LockedTime, new ColumnInfo(C_LockedTime, "Lockedtime", false, typeof(DateTime)));

            _current.Add(C_LastModifyPasswordTime, new ColumnInfo(C_LastModifyPasswordTime, "Lastmodifypasswordtime", false, typeof(DateTime)));

            _current.Add(C_LastUploadTime, new ColumnInfo(C_LastUploadTime, "Lastuploadtime", false, typeof(DateTime)));

            _current.Add(C_LastDownloadTime, new ColumnInfo(C_LastDownloadTime, "Lastdownloadtime", false, typeof(DateTime)));

        }


        public ColumnInfo DMSID
        {
            get { return this[C_DMSID]; }
        }

        public ColumnInfo CityID
        {
            get { return this[C_CityID]; }
        }

        public ColumnInfo Market
        {
            get { return this[C_Market]; }
        }

        public ColumnInfo ShiptoCode
        {
            get { return this[C_ShiptoCode]; }
        }

        public ColumnInfo SoldtoCode
        {
            get { return this[C_SoldtoCode]; }
        }

        public ColumnInfo RDID
        {
            get { return this[C_RDID]; }
        }

        public ColumnInfo CustomerName
        {
            get { return this[C_CustomerName]; }
        }

        public ColumnInfo City
        {
            get { return this[C_City]; }
        }

        public ColumnInfo HubType
        {
            get { return this[C_HubType]; }
        }

        public ColumnInfo HM
        {
            get { return this[C_HM]; }
        }

        public ColumnInfo SM
        {
            get { return this[C_SM]; }
        }

        public ColumnInfo MM
        {
            get { return this[C_MM]; }
        }

        public ColumnInfo HubAccount
        {
            get { return this[C_HubAccount]; }
        }

        public ColumnInfo HubPassword
        {
            get { return this[C_HubPassword]; }
        }

        public ColumnInfo HubStatus
        {
            get { return this[C_HubStatus]; }
        }

        public ColumnInfo MerchandiserNum
        {
            get { return this[C_MerchandiserNum]; }
        }

        public ColumnInfo LockedTime
        {
            get { return this[C_LockedTime]; }
        }

        public ColumnInfo LastModifyPasswordTime
        {
            get { return this[C_LastModifyPasswordTime]; }
        }

        public ColumnInfo LastUploadTime
        {
            get { return this[C_LastUploadTime]; }
        }

        public ColumnInfo LastDownloadTime
        {
            get { return this[C_LastDownloadTime]; }
        }

    }
}
