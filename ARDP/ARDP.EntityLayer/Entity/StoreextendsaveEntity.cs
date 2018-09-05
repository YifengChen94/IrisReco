using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoreextendsaveEntity : EntityBase
    {
        public StoreextendsaveTable TableSchema
        {
            get
            {
                return (StoreextendsaveTable)_tableSchema;
            }
        }


        public StoreextendsaveEntity()
        {
            _tableSchema = StoreextendsaveTable.Current;
        }

        #region 属性列表

        public string Storeextendsaveid
        {
            get { return (string)GetData(StoreextendsaveTable.C_StoreExtendSaveID); }
            set { SetData(StoreextendsaveTable.C_StoreExtendSaveID, value); }
        }

        public string Storeid
        {
            get { return (string)GetData(StoreextendsaveTable.C_StoreID); }
            set { SetData(StoreextendsaveTable.C_StoreID, value); }
        }

        public string MapSaveID
        {
            get { return (string)GetData(StoreextendsaveTable.C_MapSaveID); }
            set { SetData(StoreextendsaveTable.C_MapSaveID, value); }
        }

        public string Mapregionsaveid
        {
            get { return (string)GetData(StoreextendsaveTable.C_MapRegionSaveID); }
            set { SetData(StoreextendsaveTable.C_MapRegionSaveID, value); }
        }

        public string MapLayerSaveID
        {
            get { return (string)GetData(StoreextendsaveTable.C_MapLayerSaveID); }
            set { SetData(StoreextendsaveTable.C_MapLayerSaveID, value); }
        }

        public int UpgradeOrDegrade
        {
            get { return GetInt(StoreextendsaveTable.C_UpgradeOrDegrade); }
            set { SetData(StoreextendsaveTable.C_UpgradeOrDegrade, value); }
        }

        public int Positionx
        {
            get { return (int)(GetInt(StoreextendsaveTable.C_PositionX)); }
            set { SetData(StoreextendsaveTable.C_PositionX, value); }
        }

        public int Positiony
        {
            get { return (int)GetInt(StoreextendsaveTable.C_PositionY); }
            set { SetData(StoreextendsaveTable.C_PositionY, value); }
        }

        public int OwnerD
        {
            get { return (int)GetInt(StoreextendsaveTable.C_Owner); }
            set { SetData(StoreextendsaveTable.C_Owner, value); }
        }

        public int WeekD
        {
            get { return (int)GetInt(StoreextendsaveTable.C_Week1); }
            set { SetData(StoreextendsaveTable.C_Week1, value); }
        }

        public int Week2D
        {
            get { return (int)GetInt(StoreextendsaveTable.C_Week2); }
            set { SetData(StoreextendsaveTable.C_Week2, value); }
        }

        #endregion
    }
}
