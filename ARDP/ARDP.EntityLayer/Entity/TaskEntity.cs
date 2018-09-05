using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class TaskEntity : EntityBase
    {
        public TaskTable TableSchema
        {
            get
            {
                return (TaskTable)_tableSchema;
            }
        }


        public TaskEntity()
        {
            _tableSchema = TaskTable.Current;
        }

        #region 属性列表

        public string Taskid
        {
            get { return (string)GetData(TaskTable.C_TaskID); }
            set { SetData(TaskTable.C_TaskID, value); }
        }

        public string Savesid
        {
            get { return (string)GetData(TaskTable.C_SavesID); }
            set { SetData(TaskTable.C_SavesID, value); }
        }

        public string Taskname
        {
            get { return (string)GetData(TaskTable.C_TaskName); }
            set { SetData(TaskTable.C_TaskName, value); }
        }

        public string Taskimage
        {
            get { return (string)GetData(TaskTable.C_TaskImage); }
            set { SetData(TaskTable.C_TaskImage, value); }
        }

        #endregion
    }
}
