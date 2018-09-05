using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ShelfTable : TableInfo
    {
        public const string C_TableName = "Shelf";

        public const string C_ShelfID = "ShelfID";

        public const string C_ShelfName = "ShelfName";

        public const string C_ProductImage = "ProductImage";

        public const string C_ShelfImage = "ShelfImage";

        public const string C_BackImage = "BackImage";

        public const string C_ForeImage = "ForeImage"; 

        public const string C_ProductX = "ProductX";

        public const string C_ProductY = "ProductY";

        public ShelfTable()
        {
            _tableName = "Shelf";
        }

        protected static ShelfTable _current;
        public static ShelfTable Current
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
            _current = new ShelfTable();

            _current.Add(C_ShelfID, new ColumnInfo(C_ShelfID, "Shelfid", true, typeof(string)));

            _current.Add(C_ShelfName, new ColumnInfo(C_ShelfName, "Shelfname", false, typeof(string)));

            _current.Add(C_ProductImage, new ColumnInfo(C_ProductImage, "Productimage", false, typeof(string)));

            _current.Add(C_ShelfImage, new ColumnInfo(C_ShelfImage, "Shelfimage", false, typeof(string)));

            _current.Add(C_BackImage, new ColumnInfo(C_BackImage, "Backimage", false, typeof(string)));

            _current.Add(C_ForeImage, new ColumnInfo(C_ForeImage, "Foreimage", false, typeof(string))); 

            _current.Add(C_ProductX, new ColumnInfo(C_ProductX, "ProductX", false, typeof(int)));

            _current.Add(C_ProductY, new ColumnInfo(C_ProductY, "ProductY", false, typeof(int))); 
        }


        public ColumnInfo ShelfID
        {
            get { return this[C_ShelfID]; }
        }

        public ColumnInfo ShelfName
        {
            get { return this[C_ShelfName]; }
        }

        public ColumnInfo ProductImage
        {
            get { return this[C_ProductImage]; }
        }

        public ColumnInfo ShelfImage
        {
            get { return this[C_ShelfImage]; }
        }

        public ColumnInfo BackImage
        {
            get { return this[C_BackImage]; }
        }

        public ColumnInfo ForeImage
        {
            get { return this[C_ForeImage]; }
        }

        public ColumnInfo ProductX
        {
            get { return this[C_ProductX]; }
        }

        public ColumnInfo ProductY
        {
            get { return this[C_ProductY]; }
        }
    }
}
