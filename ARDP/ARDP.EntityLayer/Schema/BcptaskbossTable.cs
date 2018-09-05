using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskbossTable : TableInfo
    {
        public const string C_TableName = "BCPTaskBoss";

        public const string C_BCPTaskBossID = "BCPTaskBossID";

        public const string C_BCPTaskID = "BCPTaskID";

        public const string C_BossID = "BossID";

        public const string C_X = "X";

        public const string C_Y = "Y";


        public BcptaskbossTable()
        {
            _tableName = "BCPTaskBoss";
        }

        protected static BcptaskbossTable _current;
        public static BcptaskbossTable Current
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
            _current = new BcptaskbossTable();

            _current.Add(C_BCPTaskBossID, new ColumnInfo(C_BCPTaskBossID, "Bcptaskbossid", true, typeof(string)));

            _current.Add(C_BCPTaskID, new ColumnInfo(C_BCPTaskID, "Bcptaskid", false, typeof(string)));

            _current.Add(C_BossID, new ColumnInfo(C_BossID, "Bossid", false, typeof(string)));

            _current.Add(C_X, new ColumnInfo(C_X, "X", false, typeof(int)));

            _current.Add(C_Y, new ColumnInfo(C_Y, "Y", false, typeof(int)));

        }


        public ColumnInfo BCPTaskBossID
        {
            get { return this[C_BCPTaskBossID]; }
        }

        public ColumnInfo BCPTaskID
        {
            get { return this[C_BCPTaskID]; }
        }

        public ColumnInfo BossID
        {
            get { return this[C_BossID]; }
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
