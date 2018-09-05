using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class AccountTable : TableInfo
    {
        public const string C_TableName = "ACCOUNT";

        public const string C_AccountID = "ACCOUNTID";

        public const string C_FaceID = "FACEID";

        public const string C_DMSID = "DMSID";

        public const string C_AccountName = "ACCOUNTNAME";

        public const string C_AccountPassword = "ACCOUNTPASSWORD";

        public const string C_Status = "STATUS";

        public const string C_CurrentRole = "CURRENTROLE";

        public const string C_RealRole = "REALROLE";

        public const string C_Market = "MARKET";


        public AccountTable()
        {
            _tableName = "ACCOUNT";
        }

        protected static AccountTable _current;
        public static AccountTable Current
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
            _current = new AccountTable();

            _current.Add(C_AccountID, new ColumnInfo(C_AccountID, "Accountid", true, typeof(string)));

            _current.Add(C_FaceID, new ColumnInfo(C_FaceID, "Faceid", false, typeof(string)));

            _current.Add(C_DMSID, new ColumnInfo(C_DMSID, "Dmsid", false, typeof(string)));

            _current.Add(C_AccountName, new ColumnInfo(C_AccountName, "Accountname", false, typeof(string)));

            _current.Add(C_AccountPassword, new ColumnInfo(C_AccountPassword, "Accountpassword", false, typeof(string)));

            _current.Add(C_Status, new ColumnInfo(C_Status, "Status", false, typeof(int)));

            _current.Add(C_CurrentRole, new ColumnInfo(C_CurrentRole, "Currentrole", false, typeof(string)));

            _current.Add(C_RealRole, new ColumnInfo(C_RealRole, "Realrole", false, typeof(string)));

            _current.Add(C_Market, new ColumnInfo(C_Market, "Market", false, typeof(string)));
        }


        public ColumnInfo AccountID
        {
            get { return this[C_AccountID]; }
        }

        public ColumnInfo FaceID
        {
            get { return this[C_FaceID]; }
        }

        public ColumnInfo DMSID
        {
            get { return this[C_DMSID]; }
        }

        public ColumnInfo AccountName
        {
            get { return this[C_AccountName]; }
        }

        public ColumnInfo AccountPassword
        {
            get { return this[C_AccountPassword]; }
        }

        public ColumnInfo Status
        {
            get { return this[C_Status]; }
        }

        public ColumnInfo CurrentRole
        {
            get { return this[C_CurrentRole]; }
        }

        public ColumnInfo RealRole
        {
            get { return this[C_RealRole]; }
        }

        public ColumnInfo Market
        {
            get { return this[C_Market]; }
        }
    }
}
