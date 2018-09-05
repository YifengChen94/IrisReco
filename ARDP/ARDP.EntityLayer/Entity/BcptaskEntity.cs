using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore; 

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskEntity : EntityBase
    {
        public BcptaskTable TableSchema
        {
            get
            {
                return (BcptaskTable)_tableSchema;
            }
        }


        public BcptaskEntity()
        {
            _tableSchema = BcptaskTable.Current;
        }

        #region 属性列表

        public string Bcptaskid
        {
            get { return (string)GetData(BcptaskTable.C_BCPTaskID); }
            set { SetData(BcptaskTable.C_BCPTaskID, value); }
        }

        public string Taskname
        {
            get { return (string)GetData(BcptaskTable.C_TaskName); }
            set { SetData(BcptaskTable.C_TaskName, value); }
        }

        public string Bcpbackgroundid
        {
            get { return (string)GetData(BcptaskTable.C_BCPBackgroundID); }
            set { SetData(BcptaskTable.C_BCPBackgroundID, value); }
        }

        public string StackbackgroundId
        {
            get { return (string)GetData(BcptaskTable.C_StackBackgroundID); }
            set { SetData(BcptaskTable.C_StackBackgroundID, value); }
        }
        #endregion
    }
}
