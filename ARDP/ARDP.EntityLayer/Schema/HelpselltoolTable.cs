using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class HelpselltoolTable : TableInfo
    {
        public const string C_TableName = "HelpSellTool";

        public const string C_HelpSellToolID = "HelpSellToolID";

        public const string C_ToolName = "ToolName";

        public const string C_SmallPic = "SmallPic";

        public const string C_BigPic = "BigPic";


        public HelpselltoolTable()
        {
            _tableName = "HelpSellTool";
        }

        protected static HelpselltoolTable _current;
        public static HelpselltoolTable Current
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
            _current = new HelpselltoolTable();

            _current.Add(C_HelpSellToolID, new ColumnInfo(C_HelpSellToolID, "Helpselltoolid", true, typeof(string)));

            _current.Add(C_ToolName, new ColumnInfo(C_ToolName, "Toolname", false, typeof(string)));

            _current.Add(C_SmallPic, new ColumnInfo(C_SmallPic, "Smallpic", false, typeof(string)));

            _current.Add(C_BigPic, new ColumnInfo(C_BigPic, "Bigpic", false, typeof(string)));

        }


        public ColumnInfo HelpSellToolID
        {
            get { return this[C_HelpSellToolID]; }
        }

        public ColumnInfo ToolName
        {
            get { return this[C_ToolName]; }
        }

        public ColumnInfo SmallPic
        {
            get { return this[C_SmallPic]; }
        }

        public ColumnInfo BigPic
        {
            get { return this[C_BigPic]; }
        }

    }
}
