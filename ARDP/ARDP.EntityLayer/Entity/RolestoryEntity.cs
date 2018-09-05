using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class RolestoryEntity : EntityBase
    {
        public RolestoryTable TableSchema
        {
            get
            {
                return (RolestoryTable)_tableSchema;
            }
        }


        public RolestoryEntity()
        {
            _tableSchema = RolestoryTable.Current;
        }

        #region 属性列表

        public string Rolestoryid
        {
            get { return (string)GetData(RolestoryTable.C_RoleStoryID); }
            set { SetData(RolestoryTable.C_RoleStoryID, value); }
        }

        public string Roleid
        {
            get { return (string)GetData(RolestoryTable.C_RoleID); }
            set { SetData(RolestoryTable.C_RoleID, value); }
        }

        public string Storyid
        {
            get { return (string)GetData(RolestoryTable.C_StoryID); }
            set { SetData(RolestoryTable.C_StoryID, value); }
        }

        #endregion
    }
}
