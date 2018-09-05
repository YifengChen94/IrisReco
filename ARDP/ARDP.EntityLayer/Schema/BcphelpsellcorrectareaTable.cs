using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcphelpsellcorrectareaTable : TableInfo
    {
        public const string C_TableName = "BCPHelpSellCorrectArea";

        public const string C_BCPHelpSellCorrectAreaID = "BCPHelpSellCorrectAreaID";

        public const string C_BCPTaskHelpSellToolsID = "BCPTaskHelpSellToolsID";

        public const string C_X = "X";

        public const string C_Y = "Y";

        public const string C_Width = "Width";

        public const string C_Height = "Height";


        public BcphelpsellcorrectareaTable()
        {
            _tableName = "BCPHelpSellCorrectArea";
        }

        protected static BcphelpsellcorrectareaTable _current;
        public static BcphelpsellcorrectareaTable Current
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
            _current = new BcphelpsellcorrectareaTable();

            _current.Add(C_BCPHelpSellCorrectAreaID, new ColumnInfo(C_BCPHelpSellCorrectAreaID, "Bcphelpsellcorrectareaid", true, typeof(string)));

            _current.Add(C_BCPTaskHelpSellToolsID, new ColumnInfo(C_BCPTaskHelpSellToolsID, "Bcptaskhelpselltoolsid", false, typeof(string)));

            _current.Add(C_X, new ColumnInfo(C_X, "X", false, typeof(int)));

            _current.Add(C_Y, new ColumnInfo(C_Y, "Y", false, typeof(int)));

            _current.Add(C_Width, new ColumnInfo(C_Width, "Width", false, typeof(int)));

            _current.Add(C_Height, new ColumnInfo(C_Height, "Height", false, typeof(int)));

        }


        public ColumnInfo BCPHelpSellCorrectAreaID
        {
            get { return this[C_BCPHelpSellCorrectAreaID]; }
        }

        public ColumnInfo BCPTaskHelpSellToolsID
        {
            get { return this[C_BCPTaskHelpSellToolsID]; }
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
