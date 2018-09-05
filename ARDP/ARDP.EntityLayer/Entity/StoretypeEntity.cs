using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoretypeEntity : EntityBase
    {
        public StoretypeTable TableSchema
        {
            get
            {
                return (StoretypeTable)_tableSchema;
            }
        }


        public StoretypeEntity()
        {
            _tableSchema = StoretypeTable.Current;
        }

        #region 属性列表

        public string Storetypeid
        {
            get { return (string)GetData(StoretypeTable.C_StoreTypeID); }
            set { SetData(StoretypeTable.C_StoreTypeID, value); }
        }

        public string Storetypename
        {
            get { return (string)GetData(StoretypeTable.C_StoreTypeName); }
            set { SetData(StoretypeTable.C_StoreTypeName, value); }
        }

        public string Storetypeimagecode
        {
            get { return (string)GetData(StoretypeTable.C_StoreTypeImageCode); }
            set { SetData(StoretypeTable.C_StoreTypeImageCode, value); }
        }

        public string Storetypedescription
        {
            get { return (string)GetData(StoretypeTable.C_StoreTypeDescription); }
            set { SetData(StoretypeTable.C_StoreTypeDescription, value); }
        }

        public int Totalvisittime
        {
            get { return (int)(GetData(StoretypeTable.C_TotalVisitTime)); }
            set { SetData(StoretypeTable.C_TotalVisitTime, value); }
        }

        public int Visittime
        {
            get { return (int)(GetData(StoretypeTable.C_VisitTime)); }
            set { SetData(StoretypeTable.C_VisitTime, value); }
        }

        #endregion
    }
}
