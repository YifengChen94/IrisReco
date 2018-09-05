using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcpstackcorrectareaTable : TableInfo
    {
        public const string C_TableName = "BCPStackCorrectArea";

        public const string C_BCPStackCorrectAreaID = "BCPStackCorrectAreaID";

        public const string C_BCPTaskStackID = "BCPTaskStackID";

        public const string C_X = "X";

        public const string C_Y = "Y";

        public const string C_Width = "Width";

        public const string C_Height = "Height";


        public BcpstackcorrectareaTable()
        {
            _tableName = "BCPStackCorrectArea";
        }

        protected static BcpstackcorrectareaTable _current;
        public static BcpstackcorrectareaTable Current
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
            _current = new BcpstackcorrectareaTable();

            _current.Add(C_BCPStackCorrectAreaID, new ColumnInfo(C_BCPStackCorrectAreaID, "BCPStackCorrectAreaID", true, typeof(string)));

            _current.Add(C_BCPTaskStackID, new ColumnInfo(C_BCPTaskStackID, "BCPTaskStackID", false, typeof(string)));

            _current.Add(C_X, new ColumnInfo(C_X, "X", false, typeof(int)));

            _current.Add(C_Y, new ColumnInfo(C_Y, "Y", false, typeof(int)));

            _current.Add(C_Width, new ColumnInfo(C_Width, "Width", false, typeof(int)));

            _current.Add(C_Height, new ColumnInfo(C_Height, "Height", false, typeof(int)));

        }


        public ColumnInfo  BCPStackCorrectAreaID
        {
            get { return this[C_BCPStackCorrectAreaID]; }
        }

        public ColumnInfo  BCPTaskStackID
        {
            get { return this[C_BCPTaskStackID]; }
        }

        public ColumnInfo X
        {
            get { return this[C_X]; }
        }

        public ColumnInfo Y
        {
            get { return this[C_Y]; }
        }

        public ColumnInfo Width
        {
            get { return this[C_Width]; }
        }

        public ColumnInfo Height
        {
            get { return this[C_Height]; }
        }

    }
}
