using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class MapregionsaveTable : TableInfo
    {
        public const string C_TableName = "MapRegionSave";

        public const string C_MapRegionSaveID = "MapRegionSaveID";

        public const string C_MapSaveID = "MapSaveID";

        public const string C_MapLayerSaveID = "MapLayerSaveID";

        public const string C_RegionDate = "RegionDate";

        public const string C_RegionColor = "RegionColor";


        public MapregionsaveTable()
        {
            _tableName = "MapRegionSave";
        }

        protected static MapregionsaveTable _current;
        public static MapregionsaveTable Current
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
            _current = new MapregionsaveTable();

            _current.Add(C_MapRegionSaveID, new ColumnInfo(C_MapRegionSaveID, "Mapregionsaveid", true, typeof(string)));

            _current.Add(C_MapLayerSaveID, new ColumnInfo(C_MapLayerSaveID, "Mapsaveid", false, typeof(string)));

            _current.Add(C_MapSaveID, new ColumnInfo(C_MapSaveID, C_MapSaveID, false, typeof(string)));


            _current.Add(C_RegionDate, new ColumnInfo(C_RegionDate, "Regiondate", false, typeof(string)));

            _current.Add(C_RegionColor, new ColumnInfo(C_RegionColor, "Regioncolor", false, typeof(string)));

        }


        public ColumnInfo MapRegionSaveID
        {
            get { return this[C_MapRegionSaveID]; }
        }

        public ColumnInfo MapLayerSaveID
        {
            get { return this[C_MapLayerSaveID]; }
        }

        public ColumnInfo RegionDate
        {
            get { return this[C_RegionDate]; }
        }

        public ColumnInfo RegionColor
        {
            get { return this[C_RegionColor]; }
        }

    }
}
