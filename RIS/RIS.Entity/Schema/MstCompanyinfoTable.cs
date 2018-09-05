using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace RIS.Entity.Schema
{
    [Serializable]
    public partial class MstCompanyinfoTable : TableInfo
    {
        public const string C_TableName = "MST_CompanyInfo";

        public const string C_CompanyId = "CompanyId";

        public const string C_CompanyName = "CompanyName";

        public const string C_Address = "Address";

        public const string C_Tel = "Tel";

        public const string C_LastModifiedTime = "LastModifiedTime";

        public const string C_LastModifiedBy = "LastModifiedBy";


        public MstCompanyinfoTable()
        {
            _tableName = "MST_CompanyInfo";
        }

        protected static MstCompanyinfoTable _current;
        public static MstCompanyinfoTable Current
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
            _current = new MstCompanyinfoTable();

            _current.Add(C_CompanyId, new ColumnInfo(C_CompanyId, "Companyid", true, typeof(string)));

            _current.Add(C_CompanyName, new ColumnInfo(C_CompanyName, "Companyname", false, typeof(string)));

            _current.Add(C_Address, new ColumnInfo(C_Address, "Address", false, typeof(string)));

            _current.Add(C_Tel, new ColumnInfo(C_Tel, "Tel", false, typeof(string)));

            _current.Add(C_LastModifiedTime, new ColumnInfo(C_LastModifiedTime, "Lastmodifiedtime", false, typeof(DateTime)));

            _current.Add(C_LastModifiedBy, new ColumnInfo(C_LastModifiedBy, "Lastmodifiedby", false, typeof(string)));

        }


        public ColumnInfo CompanyId
        {
            get { return this[C_CompanyId]; }
        }

        public ColumnInfo CompanyName
        {
            get { return this[C_CompanyName]; }
        }

        public ColumnInfo Address
        {
            get { return this[C_Address]; }
        }

        public ColumnInfo Tel
        {
            get { return this[C_Tel]; }
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
