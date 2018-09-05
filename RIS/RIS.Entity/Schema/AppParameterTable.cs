using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace RIS.Entity.Schema
{
    [Serializable]
    public partial class AppParameterTable : TableInfo
    {
        public const string C_TableName = "APP_Parameter";

        public const string C_ParameterId = "ParameterId";

        public const string C_ParameterName = "ParameterName";

        public const string C_ParameterValue = "ParameterValue";

        public const string C_Catalog = "Catalog";

        public const string C_SeqOrder = "SeqOrder";

        public const string C_LastModifiedTime = "LastModifiedTime";

        public const string C_LastModifiedUserId = "LastModifiedUserId";


        public AppParameterTable()
        {
            _tableName = "APP_Parameter";
        }

        protected static AppParameterTable _current;
        public static AppParameterTable Current
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
            _current = new AppParameterTable();

            _current.Add(C_ParameterId, new ColumnInfo(C_ParameterId, "Parameterid", true, typeof(string)));

            _current.Add(C_ParameterName, new ColumnInfo(C_ParameterName, "Parametername", false, typeof(string)));

            _current.Add(C_ParameterValue, new ColumnInfo(C_ParameterValue, "Parametervalue", false, typeof(string)));

            _current.Add(C_Catalog, new ColumnInfo(C_Catalog, "Catalog", false, typeof(string)));

            _current.Add(C_SeqOrder, new ColumnInfo(C_SeqOrder, "Seqorder", false, typeof(int)));

            _current.Add(C_LastModifiedTime, new ColumnInfo(C_LastModifiedTime, "Lastmodifiedtime", false, typeof(DateTime)));

            _current.Add(C_LastModifiedUserId, new ColumnInfo(C_LastModifiedUserId, "Lastmodifieduserid", false, typeof(string)));

        }


        public ColumnInfo ParameterId
        {
            get { return this[C_ParameterId]; }
        }

        public ColumnInfo ParameterName
        {
            get { return this[C_ParameterName]; }
        }

        public ColumnInfo ParameterValue
        {
            get { return this[C_ParameterValue]; }
        }

        public ColumnInfo Catalog
        {
            get { return this[C_Catalog]; }
        }

        public ColumnInfo SeqOrder
        {
            get { return this[C_SeqOrder]; }
        }

        public ColumnInfo LastModifiedTime
        {
            get { return this[C_LastModifiedTime]; }
        }

        public ColumnInfo LastModifiedUserId
        {
            get { return this[C_LastModifiedUserId]; }
        }

    }
}
