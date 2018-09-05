using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class RoleclothingEntity : EntityBase
    {
        public RoleclothingTable TableSchema
        {
            get
            {
                return (RoleclothingTable)_tableSchema;
            }
        }


        public RoleclothingEntity()
        {
            _tableSchema = RoleclothingTable.Current;
        }

        #region 属性列表

        public string Roleclothingid
        {
            get { return (string)GetData(RoleclothingTable.C_RoleClothingID); }
            set { SetData(RoleclothingTable.C_RoleClothingID, value); }
        }

        public string Roleid
        {
            get { return (string)GetData(RoleclothingTable.C_RoleID); }
            set { SetData(RoleclothingTable.C_RoleID, value); }
        }

        public string Clothingid
        {
            get { return (string)GetData(RoleclothingTable.C_ClothingID); }
            set { SetData(RoleclothingTable.C_ClothingID, value); }
        }

        public string Season
        {
            get { return (string)GetData(RoleclothingTable.C_Season); }
            set { SetData(RoleclothingTable.C_Season, value); }
        }

        #endregion
    }
}
