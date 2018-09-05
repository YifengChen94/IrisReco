using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class FaceTable : TableInfo
    {
        public const string C_TableName = "Face";

        public const string C_FaceID = "FaceID";

        public const string C_BigImage = "BigImage";

        public const string C_SmallImage = "SmallImage";


        public FaceTable()
        {
            _tableName = "Face";
        }

        protected static FaceTable _current;
        public static FaceTable Current
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
            _current = new FaceTable();

            _current.Add(C_FaceID, new ColumnInfo(C_FaceID, "Faceid", true, typeof(string)));

            _current.Add(C_BigImage, new ColumnInfo(C_BigImage, "Bigimage", false, typeof(string)));

            _current.Add(C_SmallImage, new ColumnInfo(C_SmallImage, "Smallimage", false, typeof(string)));

        }


        public ColumnInfo FaceID
        {
            get { return this[C_FaceID]; }
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
