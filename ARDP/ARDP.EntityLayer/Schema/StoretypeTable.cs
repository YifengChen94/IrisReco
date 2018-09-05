using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoretypeTable : TableInfo
    {
        public const string C_TableName = "StoreType";

        public const string C_StoreTypeID = "StoreTypeID";

        public const string C_StoreTypeName = "StoreTypeName";

        public const string C_StoreTypeImageCode = "StoreTypeImageCode";

        public const string C_StoreTypeDescription = "StoreTypeDescription";

        public const string C_TotalVisitTime = "TotalVisitTime";

        public const string C_VisitTime = "VisitTime";


        public StoretypeTable()
        {
            _tableName = "StoreType";
        }

        protected static StoretypeTable _current;
        public static StoretypeTable Current
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
            _current = new StoretypeTable();

            _current.Add(C_StoreTypeID, new ColumnInfo(C_StoreTypeID, "Storetypeid", true, typeof(string)));

            _current.Add(C_StoreTypeName, new ColumnInfo(C_StoreTypeName, "Storetypename", false, typeof(string)));

            _current.Add(C_StoreTypeImageCode, new ColumnInfo(C_StoreTypeImageCode, "Storetypeimagecode", false, typeof(string)));

            _current.Add(C_StoreTypeDescription, new ColumnInfo(C_StoreTypeDescription, "Storetypedescription", false, typeof(string)));

            _current.Add(C_TotalVisitTime, new ColumnInfo(C_TotalVisitTime, "Totalvisittime", false, typeof(int)));

            _current.Add(C_VisitTime, new ColumnInfo(C_VisitTime, "Visittime", false, typeof(int)));

        }


        public ColumnInfo StoreTypeID
        {
            get { return this[C_StoreTypeID]; }
        }

        public ColumnInfo StoreTypeName
        {
            get { return this[C_StoreTypeName]; }
        }

        public ColumnInfo StoreTypeImageCode
        {
            get { return this[C_StoreTypeImageCode]; }
        }

        public ColumnInfo StoreTypeDescription
        {
            get { return this[C_StoreTypeDescription]; }
        }

        public ColumnInfo TotalVisitTime
        {
            get { return this[C_TotalVisitTime]; }
        }

        public ColumnInfo VisitTime
        {
            get { return this[C_VisitTime]; }
        }

    }
}
