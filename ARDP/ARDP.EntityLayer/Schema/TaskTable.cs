using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class TaskTable : TableInfo
    {
        public const string C_TableName = "Task";

        public const string C_TaskID = "TaskID";

        public const string C_SavesID = "SavesID";

        public const string C_TaskName = "TaskName";

        public const string C_TaskImage = "TaskImage";


        public TaskTable()
        {
            _tableName = "Task";
        }

        protected static TaskTable _current;
        public static TaskTable Current
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
            _current = new TaskTable();

            _current.Add(C_TaskID, new ColumnInfo(C_TaskID, "Taskid", true, typeof(string)));

            _current.Add(C_SavesID, new ColumnInfo(C_SavesID, "Savesid", false, typeof(string)));

            _current.Add(C_TaskName, new ColumnInfo(C_TaskName, "Taskname", false, typeof(string)));

            _current.Add(C_TaskImage, new ColumnInfo(C_TaskImage, "Taskimage", false, typeof(string)));

        }


        public ColumnInfo TaskID
        {
            get { return this[C_TaskID]; }
        }

        public ColumnInfo SavesID
        {
            get { return this[C_SavesID]; }
        }

        public ColumnInfo TaskName
        {
            get { return this[C_TaskName]; }
        }

        public ColumnInfo TaskImage
        {
            get { return this[C_TaskImage]; }
        }

    }
}
