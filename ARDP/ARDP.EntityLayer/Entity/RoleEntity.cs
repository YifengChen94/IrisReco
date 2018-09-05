using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class RoleEntity : EntityBase
    {
        public RoleTable TableSchema
        {
            get
            {
                return (RoleTable)_tableSchema;
            }
        }


        public RoleEntity()
        {
            _tableSchema = RoleTable.Current;
        }

        #region 属性列表

        public string Roleid
        {
            get { return (string)GetData(RoleTable.C_RoleID); }
            set { SetData(RoleTable.C_RoleID, value); }
        }

        public string Rolename
        {
            get { return (string)GetData(RoleTable.C_RoleName); }
            set { SetData(RoleTable.C_RoleName, value); }
        }

        public string Roledescription
        {
            get { return (string)GetData(RoleTable.C_RoleDescription); }
            set { SetData(RoleTable.C_RoleDescription, value); }
        }

        #endregion
    }
}
