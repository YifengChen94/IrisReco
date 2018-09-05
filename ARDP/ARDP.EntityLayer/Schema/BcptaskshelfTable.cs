using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskshelfTable : TableInfo
    {
        public const string C_TableName = "BCPTaskShelf";

        public const string C_BCPTaskShelfID = "BCPTaskShelfID";

        public const string C_BCPTaskID = "BCPTaskID";

        public const string C_ShelfID = "ShelfID";

        public const string C_X = "X";

        public const string C_Y = "Y";

        public const string C_Rate = "Rate";

        public BcptaskshelfTable()
        {
            _tableName = "BCPTaskShelf";
        }

        protected static BcptaskshelfTable _current;
        public static BcptaskshelfTable Current
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
            _current = new BcptaskshelfTable();

            _current.Add(C_BCPTaskShelfID, new ColumnInfo(C_BCPTaskShelfID, "Bcptaskshelfid", true, typeof(string)));

            _current.Add(C_BCPTaskID, new ColumnInfo(C_BCPTaskID, "Bcptaskid", false, typeof(string)));

            _current.Add(C_ShelfID, new ColumnInfo(C_ShelfID, "Shelfid", false, typeof(string)));

            _current.Add(C_X, new ColumnInfo(C_X, "X", false, typeof(int)));

            _current.Add(C_Y, new ColumnInfo(C_Y, "Y", false, typeof(int)));

            _current.Add(C_Rate, new ColumnInfo(C_Rate, "Rate", false, typeof(int)));
        }


        public ColumnInfo BCPTaskShelfID
        {
            get { return this[C_BCPTaskShelfID]; }
        }

        public ColumnInfo BCPTaskID
        {
            get { return this[C_BCPTaskID]; }
        }

        public ColumnInfo ShelfID
        {
            get { return this[C_ShelfID]; }
        }

        public ColumnInfo X
        {
            get { return this[C_X]; }
        }

        public ColumnInfo Y
        {
            get { return this[C_Y]; }
        }
         
        public ColumnInfo Rate
        {
            get { return this[C_Rate]; }
        }
    }
}
