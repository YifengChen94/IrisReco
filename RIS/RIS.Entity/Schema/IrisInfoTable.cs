using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace RIS.Entity.Schema
{
    [Serializable]
    public partial class IrisInfoTable : TableInfo
    {
        public const string C_TableName = "Iris_Info";

        public const string C_IrisId = "IrisId";

        public const string C_LeftRight = "LeftRight";

        public const string C_AuditUserId = "AuditUserId";

        public const string C_IrisVector = "IrisVector";

        public const string C_LastModifiedTime = "LastModifiedTime";

        public const string C_LastModifiedBy = "LastModifiedBy";


        public IrisInfoTable()
        {
            _tableName = "Iris_Info";
        }

        protected static IrisInfoTable _current;
        public static IrisInfoTable Current
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
            _current = new IrisInfoTable();

            _current.Add(C_IrisId, new ColumnInfo(C_IrisId, "Irisid", true, typeof(string)));

            _current.Add(C_LeftRight, new ColumnInfo(C_LeftRight, "Leftright", false, typeof(int)));

            _current.Add(C_AuditUserId, new ColumnInfo(C_AuditUserId, "Audituserid", false, typeof(string)));

            _current.Add(C_IrisVector, new ColumnInfo(C_IrisVector, "Irisvector", false, typeof(string)));

            _current.Add(C_LastModifiedTime, new ColumnInfo(C_LastModifiedTime, "Lastmodifiedtime", false, typeof(DateTime)));

            _current.Add(C_LastModifiedBy, new ColumnInfo(C_LastModifiedBy, "Lastmodifiedby", false, typeof(string)));

        }


        public ColumnInfo IrisId
        {
            get { return this[C_IrisId]; }
        }

        public ColumnInfo LeftRight
        {
            get { return this[C_LeftRight]; }
        }

        public ColumnInfo AuditUserId
        {
            get { return this[C_AuditUserId]; }
        }

        public ColumnInfo IrisVector
        {
            get { return this[C_IrisVector]; }
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
