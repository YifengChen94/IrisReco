using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ShelfEntity : EntityBase
    {
        public ShelfTable TableSchema
        {
            get
            {
                return (ShelfTable)_tableSchema;
            }
        }


        public ShelfEntity()
        {
            _tableSchema = ShelfTable.Current;
        }

        #region 属性列表

        public string Shelfid
        {
            get { return (string)GetData(ShelfTable.C_ShelfID); }
            set { SetData(ShelfTable.C_ShelfID, value); }
        }

        public string Shelfname
        {
            get { return (string)GetData(ShelfTable.C_ShelfName); }
            set { SetData(ShelfTable.C_ShelfName, value); }
        }

        public string Productimage
        {
            get { return (string)GetData(ShelfTable.C_ProductImage); }
            set { SetData(ShelfTable.C_ProductImage, value); }
        }

        public string Shelfimage
        {
            get { return (string)GetData(ShelfTable.C_ShelfImage); }
            set { SetData(ShelfTable.C_ShelfImage, value); }
        }

        public string Backimage
        {
            get { return (string)GetData(ShelfTable.C_BackImage); }
            set { SetData(ShelfTable.C_BackImage, value); }
        }

        public string Foreimage
        {
            get { return (string)GetData(ShelfTable.C_ForeImage); }
            set { SetData(ShelfTable.C_ForeImage, value); }
        }

        public int ProductX
        {
            get { return (int)(GetData(ShelfTable.C_ProductX)); }
            set { SetData(ShelfTable.C_ProductX, value); }
        }

        public int ProductY
        {
            get { return (int)(GetData(ShelfTable.C_ProductY)); }
            set { SetData(ShelfTable.C_ProductY, value); }
        }
        #endregion
    }
}
