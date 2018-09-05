using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskTable : TableInfo
    {
        public const string C_TableName = "BCPTask";

        public const string C_BCPTaskID = "BCPTaskID";

        public const string C_TaskName = "TaskName";

        public const string C_BCPBackgroundID = "BCPBackgroundID";

        public const string C_StackBackgroundID = "StackBackgroundID";

        public BcptaskTable()
        {
            _tableName = "BCPTask";
        }

        protected static BcptaskTable _current;
        public static BcptaskTable Current
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
            _current = new BcptaskTable();

            _current.Add(C_BCPTaskID, new ColumnInfo(C_BCPTaskID, "Bcptaskid", true, typeof(string)));

            _current.Add(C_TaskName, new ColumnInfo(C_TaskName, "Taskname", false, typeof(string)));

            _current.Add(C_BCPBackgroundID, new ColumnInfo(C_BCPBackgroundID, "Bcpbackgroundid", false, typeof(string)));

            _current.Add(C_StackBackgroundID, new ColumnInfo(C_StackBackgroundID, "StackbackgroundId", false, typeof(string)));

        }


        public ColumnInfo BCPTaskID
        {
            get { return this[C_BCPTaskID]; }
        }

        public ColumnInfo TaskName
        {
            get { return this[C_TaskName]; }
        }

        public ColumnInfo BCPBackgroundID
        {
            get { return this[C_BCPBackgroundID]; }
        }
 
        public ColumnInfo StackBackgroundID
        {
            get { return this[C_StackBackgroundID]; }
        }
    }
}
