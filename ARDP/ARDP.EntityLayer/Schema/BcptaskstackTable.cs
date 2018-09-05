using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskstackTable : TableInfo
    {
        public const string C_TableName = "BCPTaskStack";

        public const string C_BCPTaskStackID = "BCPTaskStackID";

        public const string C_BCPTaskID = "BCPTaskID";

        public const string C_SmallPic = "SmallPic";

        public const string C_SmallPositonX = "SmallPositonX";

        public const string C_SmallPositonY = "SmallPositonY";

        public const string C_BigPic = "BigPic";

        public const string C_BigPositonX = "BigPositonX";

        public const string C_BigPositonY = "BigPositonY";

        public const string C_StackCode = "StackCode";


        public BcptaskstackTable()
        {
            _tableName = "BCPTaskStack";
        }

        protected static BcptaskstackTable _current;
        public static BcptaskstackTable Current
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
            _current = new BcptaskstackTable();

            _current.Add(C_BCPTaskStackID, new ColumnInfo(C_BCPTaskStackID, "BcptaskstackId", true, typeof(string)));

            _current.Add(C_BCPTaskID, new ColumnInfo(C_BCPTaskID, "Bcptaskid", false, typeof(string)));

            _current.Add(C_SmallPic, new ColumnInfo(C_SmallPic, "Smallpic", false, typeof(string)));

            _current.Add(C_SmallPositonX, new ColumnInfo(C_SmallPositonX, "Smallpositonx", false, typeof(int)));

            _current.Add(C_SmallPositonY, new ColumnInfo(C_SmallPositonY, "Smallpositony", false, typeof(int)));

            _current.Add(C_BigPic, new ColumnInfo(C_BigPic, "Bigpic", false, typeof(string)));

            _current.Add(C_BigPositonX, new ColumnInfo(C_BigPositonX, "Bigpositonx", false, typeof(int)));

            _current.Add(C_BigPositonY, new ColumnInfo(C_BigPositonY, "Bigpositony", false, typeof(int)));

            _current.Add(C_StackCode, new ColumnInfo(C_StackCode, "Stackcode", false, typeof(string)));

        }


        public ColumnInfo BCPTaskStackID
        {
            get { return this[C_BCPTaskStackID]; }
        }

        public ColumnInfo BCPTaskID
        {
            get { return this[C_BCPTaskID]; }
        }

        public ColumnInfo SmallPic
        {
            get { return this[C_SmallPic]; }
        }

        public ColumnInfo SmallPositonX
        {
            get { return this[C_SmallPositonX]; }
        }

        public ColumnInfo SmallPositonY
        {
            get { return this[C_SmallPositonY]; }
        }

        public ColumnInfo BigPic
        {
            get { return this[C_BigPic]; }
        }
         
        public ColumnInfo BigPositonX
        {
            get { return this[C_BigPositonX]; }
        }

        public ColumnInfo BigPositonY
        {
            get { return this[C_BigPositonY]; }
        }

        public ColumnInfo StackCode
        {
            get { return this[C_StackCode]; }
        }

    }
}
