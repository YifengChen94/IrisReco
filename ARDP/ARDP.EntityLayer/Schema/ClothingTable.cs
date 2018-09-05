using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ClothingTable : TableInfo
    {
        public const string C_TableName = "Clothing";

        public const string C_ClothingID = "ClothingID";

        public const string C_BigImage = "BigImage";

        public const string C_SmallImage = "SmallImage";


        public ClothingTable()
        {
            _tableName = "Clothing";
        }

        protected static ClothingTable _current;
        public static ClothingTable Current
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
            _current = new ClothingTable();

            _current.Add(C_ClothingID, new ColumnInfo(C_ClothingID, "Clothingid", true, typeof(string)));

            _current.Add(C_BigImage, new ColumnInfo(C_BigImage, "Bigimage", false, typeof(string)));

            _current.Add(C_SmallImage, new ColumnInfo(C_SmallImage, "Smallimage", false, typeof(string)));

        }


        public ColumnInfo ClothingID
        {
            get { return this[C_ClothingID]; }
        }

        public ColumnInfo BigImage
        {
            get { return this[C_BigImage]; }
        }

        public ColumnInfo SmallImage
        {
            get { return this[C_SmallImage]; }
        }

    }
}
