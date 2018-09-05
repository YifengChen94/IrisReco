using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoreTable : TableInfo
    {
        public const string C_TableName = "Store";

        public const string C_StoreID = "StoreID";

        public const string C_StoreTypeID = "StoreTypeID";

        public const string C_StoreName = "StoreName";

        public const string C_StoreDescription = "StoreDescription";

        public const string C_Offtake = "Offtake";

        public const string C_StoreCase = "StoreCase";

        public const string C_StorePiece = "StorePiece";

        public const string C_StoreTown = "StoreTown";

        public StoreTable()
        {
            _tableName = "Store";
        }

        protected static StoreTable _current;
        public static StoreTable Current
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
            _current = new StoreTable();

            _current.Add(C_StoreID, new ColumnInfo(C_StoreID, "Storeid", true, typeof(string)));

            _current.Add(C_StoreTypeID, new ColumnInfo(C_StoreTypeID, "Storetypeid", false, typeof(string)));

            _current.Add(C_StoreName, new ColumnInfo(C_StoreName, "Storename", false, typeof(string)));

            _current.Add(C_StoreDescription, new ColumnInfo(C_StoreDescription, "Storedescription", false, typeof(string)));

            _current.Add(C_Offtake, new ColumnInfo(C_Offtake, "Offtake", false, typeof(decimal)));

            _current.Add(C_StoreCase, new ColumnInfo(C_StoreCase, "Storecase", false, typeof(decimal)));

            _current.Add(C_StorePiece, new ColumnInfo(C_StorePiece, C_StorePiece, false, typeof(decimal)));

            _current.Add(C_StoreTown, new ColumnInfo(C_StoreTown, C_StoreTown, false, typeof(decimal)));

        }


        public ColumnInfo StoreID
        {
            get { return this[C_StoreID]; }
        }

        public ColumnInfo StoreTypeID
        {
            get { return this[C_StoreTypeID]; }
        }

        public ColumnInfo StoreName
        {
            get { return this[C_StoreName]; }
        }

        public ColumnInfo StoreDescription
        {
            get { return this[C_StoreDescription]; }
        }

        public ColumnInfo Offtake
        {
            get { return this[C_Offtake]; }
        }

        public ColumnInfo StoreCase
        {
            get { return this[C_StoreCase]; }
        }

    }
}
