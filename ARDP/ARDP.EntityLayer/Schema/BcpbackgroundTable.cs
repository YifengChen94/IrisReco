using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcpbackgroundTable : TableInfo
    {
        public const string C_TableName = "BCPBackground";

        public const string C_BCPBackgroundID = "BCPBackgroundID";

        public const string C_BackgroundName = "BackgroundName";

        public const string C_Background = "Background";


        public BcpbackgroundTable()
        {
            _tableName = "BCPBackground";
        }

        protected static BcpbackgroundTable _current;
        public static BcpbackgroundTable Current
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
            _current = new BcpbackgroundTable();

            _current.Add(C_BCPBackgroundID, new ColumnInfo(C_BCPBackgroundID, "Bcpbackgroundid", true, typeof(string)));

            _current.Add(C_BackgroundName, new ColumnInfo(C_BackgroundName, "Backgroundname", false, typeof(string)));

            _current.Add(C_Background, new ColumnInfo(C_Background, "Background", false, typeof(string)));

        }


        public ColumnInfo BCPBackgroundID
        {
            get { return this[C_BCPBackgroundID]; }
        }

        public ColumnInfo BackgroundName
        {
            get { return this[C_BackgroundName]; }
        }

        public ColumnInfo Background
        {
            get { return this[C_Background]; }
        }

    }
}
