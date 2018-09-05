using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ClothingEntity : EntityBase
    {
        public ClothingTable TableSchema
        {
            get
            {
                return (ClothingTable)_tableSchema;
            }
        }


        public ClothingEntity()
        {
            _tableSchema = ClothingTable.Current;
        }

        #region 属性列表

        public string Clothingid
        {
            get { return (string)GetData(ClothingTable.C_ClothingID); }
            set { SetData(ClothingTable.C_ClothingID, value); }
        }

        public string Bigimage
        {
            get { return (string)GetData(ClothingTable.C_BigImage); }
            set { SetData(ClothingTable.C_BigImage, value); }
        }

        public string Smallimage
        {
            get { return (string)GetData(ClothingTable.C_SmallImage); }
            set { SetData(ClothingTable.C_SmallImage, value); }
        }

        #endregion
    }
}
