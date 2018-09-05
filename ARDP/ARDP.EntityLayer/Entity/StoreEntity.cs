using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoreEntity : EntityBase
    {
        public StoreTable TableSchema
        {
            get
            {
                return (StoreTable)_tableSchema;
            }
        }


        public StoreEntity()
        {
            _tableSchema = StoreTable.Current;
        }

        #region 属性列表

        public string Storeid
        {
            get { return (string)GetData(StoreTable.C_StoreID); }
            set { SetData(StoreTable.C_StoreID, value); }
        }

        public string Storetypeid
        {
            get { return (string)GetData(StoreTable.C_StoreTypeID); }
            set { SetData(StoreTable.C_StoreTypeID, value); }
        }

        public string Storename
        {
            get { return (string)GetData(StoreTable.C_StoreName); }
            set { SetData(StoreTable.C_StoreName, value); }
        }

        public string Storedescription
        {
            get { return (string)GetData(StoreTable.C_StoreDescription); }
            set { SetData(StoreTable.C_StoreDescription, value); }
        }

        public decimal Offtake
        {
            get { return (decimal)(GetData(StoreTable.C_Offtake)); }
            set { SetData(StoreTable.C_Offtake, value); }
        }

        public decimal Storecase
        {
            get { return (decimal)(GetData(StoreTable.C_StoreCase)); }
            set { SetData(StoreTable.C_StoreCase, value); }
        }

        public decimal StorePiece
        {
            get { return (decimal)(GetData(StoreTable.C_StorePiece)); }
            set { SetData(StoreTable.C_StorePiece, value); }
        }

        public decimal StoreTown
        {
            get { return (decimal)(GetData(StoreTable.C_StoreTown)); }
            set { SetData(StoreTable.C_StoreTown, value); }
        }

        #endregion
    }
}
