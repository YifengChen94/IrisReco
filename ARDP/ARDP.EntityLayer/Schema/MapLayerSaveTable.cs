using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class MapLayerSaveTable : TableInfo
    {
        public const string C_TableName = "MapLayerSave";

        public const string C_MapLayerSaveID = "MapLayerSaveID";

        public const string C_MapSaveID = "MapSaveID";

        public const string C_MapLayerCode = "MapLayerCode";

        public MapLayerSaveTable()
        {
            _tableName = C_TableName;
        }

        protected static MapLayerSaveTable _current;
        public static MapLayerSaveTable Current
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
            _current = new MapLayerSaveTable();

            _current.Add(C_MapLayerSaveID, new ColumnInfo(C_MapLayerSaveID, C_MapLayerSaveID, true, typeof(string)));

            _current.Add(C_MapSaveID, new ColumnInfo(C_MapSaveID, C_MapSaveID, false, typeof(string)));

            _current.Add(C_MapLayerCode, new ColumnInfo(C_MapLayerCode, C_MapLayerCode, false, typeof(string)));
        }

    }
}
