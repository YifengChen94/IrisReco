using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore; 

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class RolebcptaskEntity : EntityBase
    {
        public RolebcptaskTable TableSchema
        {
            get
            {
                return (RolebcptaskTable)_tableSchema;
            }
        }


        public RolebcptaskEntity()
        {
            _tableSchema = RolebcptaskTable.Current;
        }

        #region 属性列表

        public string Rolebcptask
        {
            get { return (string)GetData(RolebcptaskTable.C_RoleBCPTask); }
            set { SetData(RolebcptaskTable.C_RoleBCPTask, value); }
        }

        public string Roleid
        {
            get { return (string)GetData(RolebcptaskTable.C_RoleID); }
            set { SetData(RolebcptaskTable.C_RoleID, value); }
        }

        public string Bcptaskid
        {
            get { return (string)GetData(RolebcptaskTable.C_BCPTaskID); }
            set { SetData(RolebcptaskTable.C_BCPTaskID, value); }
        }

        #endregion
    }
}
