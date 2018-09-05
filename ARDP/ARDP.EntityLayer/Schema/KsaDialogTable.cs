using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class KsaDialogTable : TableInfo
    {
        public const string C_TableName = "KSA_Dialog";

        public const string C_ID = "ID";

        public const string C_K_Index = "K_Index";

        public const string C_Dialog = "Dialog";

        public const string C_Side = "Side";

        public const string C_KSA_ID = "KSA_ID";


        public KsaDialogTable()
        {
            _tableName = "KSA_Dialog";
        }

        protected static KsaDialogTable _current;
        public static KsaDialogTable Current
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
            _current = new KsaDialogTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(string)));

            _current.Add(C_K_Index, new ColumnInfo(C_K_Index, "KIndex", false, typeof(int)));

            _current.Add(C_Dialog, new ColumnInfo(C_Dialog, "Dialog", false, typeof(string)));

            _current.Add(C_Side, new ColumnInfo(C_Side, "Side", false, typeof(int)));

            _current.Add(C_KSA_ID, new ColumnInfo(C_KSA_ID, "KSAID", false, typeof(string)));

        }


        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo K_Index
        {
            get { return this[C_K_Index]; }
        }

        public ColumnInfo Dialog
        {
            get { return this[C_Dialog]; }
        }

        public ColumnInfo Side
        {
            get { return this[C_Side]; }
        }

        public ColumnInfo KSA_ID
        {
            get { return this[C_KSA_ID]; }
        }

    }
}
