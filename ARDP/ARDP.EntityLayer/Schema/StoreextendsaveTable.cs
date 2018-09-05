using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoreextendsaveTable : TableInfo
    {
        public const string C_TableName = "StoreExtendSave";

        public const string C_StoreExtendSaveID = "StoreExtendSaveID";

        public const string C_StoreID = "StoreID";
        public const string C_MapSaveID = "MapSaveID";
        public const string C_MapLayerSaveID = "MapLayerSaveID";
        public const string C_MapRegionSaveID = "MapRegionSaveID";
        

        public const string C_PositionX = "PositionX";

        public const string C_PositionY = "PositionY";
        public const string C_Owner = "Owner";
        public const string C_Week1 = "Week1";
        public const string C_Week2 = "Week2";
        public const string C_UpgradeOrDegrade = "UPGRADEORDEGRADE";


        public StoreextendsaveTable()
        {
            _tableName = "StoreExtendSave";
        }

        protected static StoreextendsaveTable _current;
        public static StoreextendsaveTable Current
        {
            get
            {
                if (_current == null)
                {
                    Initial();
                }
                return _current;
            }
        }

        private static void Initial()
        {
            _current = new StoreextendsaveTable();

            _current.Add(C_StoreExtendSaveID, new ColumnInfo(C_StoreExtendSaveID, "Storeextendsaveid", true, typeof(string)));

            _current.Add(C_StoreID, new ColumnInfo(C_StoreID, "Storeid", false, typeof(string)));
            _current.Add(C_MapSaveID, new ColumnInfo(C_MapSaveID, "C_MapSaveID", false, typeof(string)));
            _current.Add(C_MapLayerSaveID, new ColumnInfo(C_MapLayerSaveID, C_MapLayerSaveID, false, typeof(string)));
            _current.Add(C_MapRegionSaveID, new ColumnInfo(C_MapRegionSaveID, "Mapregionsaveid", false, typeof(string)));

            _current.Add(C_PositionX, new ColumnInfo(C_PositionX, "Positionx", false, typeof(int)));

            _current.Add(C_PositionY, new ColumnInfo(C_PositionY, "Positiony", false, typeof(string)));
            _current.Add(C_Owner, new ColumnInfo(C_Owner, "Positiony", false, typeof(string)));
            _current.Add(C_Week1, new ColumnInfo(C_Week1, "Positiony", false, typeof(string)));
            _current.Add(C_Week2, new ColumnInfo(C_Week2, "Positiony", false, typeof(string)));
            _current.Add(C_UpgradeOrDegrade, new ColumnInfo(C_UpgradeOrDegrade, C_UpgradeOrDegrade, false, typeof(string)));
        }


        public ColumnInfo StoreExtendSaveID
        {
            get { return this[C_StoreExtendSaveID]; }
        }

        public ColumnInfo StoreID
        {
            get { return this[C_StoreID]; }
        }

        public ColumnInfo MapRegionSaveID
        {
            get { return this[C_MapRegionSaveID]; }
        }

        public ColumnInfo PositionX
        {
            get { return this[C_PositionX]; }
        }

        public ColumnInfo PositionY
        {
            get { return this[C_PositionY]; }
        }

    }
}
