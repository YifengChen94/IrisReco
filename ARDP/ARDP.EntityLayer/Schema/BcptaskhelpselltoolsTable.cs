using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskhelpselltoolsTable : TableInfo
    {
        public const string C_TableName = "BCPTaskHelpSellTools";

        public const string C_BCPTaskHelpSellToolsID = "BCPTaskHelpSellToolsID";

        public const string C_BCPTaskID = "BCPTaskID";

        public const string C_HelpSellToolID = "HelpSellToolID";

        public const string C_SmallPositonX = "SmallPositonX";

        public const string C_SmallPositonY = "SmallPositonY";

        public const string C_BigPositonX = "BigPositonX";

        public const string C_BigPositonY = "BigPositonY";

        public const string C_TipsCode = "TipsCode";


        public BcptaskhelpselltoolsTable()
        {
            _tableName = "BCPTaskHelpSellTools";
        }

        protected static BcptaskhelpselltoolsTable _current;
        public static BcptaskhelpselltoolsTable Current
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
            _current = new BcptaskhelpselltoolsTable();

            _current.Add(C_BCPTaskHelpSellToolsID, new ColumnInfo(C_BCPTaskHelpSellToolsID, "Bcptaskhelpselltoolsid", true, typeof(string)));

            _current.Add(C_BCPTaskID, new ColumnInfo(C_BCPTaskID, "Bcptaskid", false, typeof(string)));

            _current.Add(C_HelpSellToolID, new ColumnInfo(C_HelpSellToolID, "Helpselltoolid", false, typeof(string)));

            _current.Add(C_SmallPositonX, new ColumnInfo(C_SmallPositonX, "Smallpositonx", false, typeof(int)));

            _current.Add(C_SmallPositonY, new ColumnInfo(C_SmallPositonY, "Smallpositony", false, typeof(int)));

            _current.Add(C_BigPositonX, new ColumnInfo(C_BigPositonX, "Bigpositonx", false, typeof(int)));

            _current.Add(C_BigPositonY, new ColumnInfo(C_BigPositonY, "Bigpositony", false, typeof(int)));

            _current.Add(C_TipsCode, new ColumnInfo(C_TipsCode, "TipsCode", false, typeof(string)));

        }


        public ColumnInfo BCPTaskHelpSellToolsID
        {
            get { return this[C_BCPTaskHelpSellToolsID]; }
        }

        public ColumnInfo BCPTaskID
        {
            get { return this[C_BCPTaskID]; }
        }

        public ColumnInfo HelpSellToolID
        {
            get { return this[C_HelpSellToolID]; }
        }

        public ColumnInfo SmallPositonX
        {
            get { return this[C_SmallPositonX]; }
        }

        public ColumnInfo SmallPositonY
        {
            get { return this[C_SmallPositonY]; }
        }

        public ColumnInfo BigPositonX
        {
            get { return this[C_BigPositonX]; }
        }

        public ColumnInfo BigPositonY
        {
            get { return this[C_BigPositonY]; }
        }

        public ColumnInfo TipsCode
        {
            get { return this[C_TipsCode]; }
        }

    }
}
