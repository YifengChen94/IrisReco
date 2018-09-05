using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ShelfsortTable : TableInfo
    {
        public const string C_TableName = "ShelfSort";

        public const string C_ShelfSortID = "ShelfSortID";

        public const string C_ShelfID = "ShelfID";

        public const string C_WrongPic = "WrongPic";

        public const string C_X = "X";

        public const string C_Y = "Y";


        public ShelfsortTable()
        {
            _tableName = "ShelfSort";
        }

        protected static ShelfsortTable _current;
        public static ShelfsortTable Current
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
            _current = new ShelfsortTable();

            _current.Add(C_ShelfSortID, new ColumnInfo(C_ShelfSortID, "Shelfsortid", true, typeof(string)));

            _current.Add(C_ShelfID, new ColumnInfo(C_ShelfID, "Shelfid", false, typeof(string)));

            _current.Add(C_WrongPic, new ColumnInfo(C_WrongPic, "Wrongpic", false, typeof(string)));

            _current.Add(C_X, new ColumnInfo(C_X, "X", false, typeof(int)));

            _current.Add(C_Y, new ColumnInfo(C_Y, "Y", false, typeof(int)));

        }


        public ColumnInfo ShelfSortID
        {
            get { return this[C_ShelfSortID]; }
        }

        public ColumnInfo ShelfID
        {
            get { return this[C_ShelfID]; }
        }

        public ColumnInfo WrongPic
        {
            get { return this[C_WrongPic]; }
        }

        public ColumnInfo X
        {
            get { return this[C_X]; }
        }

        public ColumnInfo Y
        {
            get { return this[C_Y]; }
        }

    }
}
