using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class MapregionsaveEntity : EntityBase
    {
        public MapregionsaveTable TableSchema
        {
            get
            {
                return (MapregionsaveTable)_tableSchema;
            }
        }


        public MapregionsaveEntity()
        {
            _tableSchema = MapregionsaveTable.Current;
        }

        #region 属性列表

        public string Mapregionsaveid
        {
            get { return (string)GetData(MapregionsaveTable.C_MapRegionSaveID); }
            set { SetData(MapregionsaveTable.C_MapRegionSaveID, value); }
        }

        public string MapSaveID
        {
            get { return (string)GetData(MapregionsaveTable.C_MapSaveID); }
            set { SetData(MapregionsaveTable.C_MapSaveID, value); }
        }

        public string MapLayerSaveID
        {
            get { return (string)GetData(MapregionsaveTable.C_MapLayerSaveID); }
            set { SetData(MapregionsaveTable.C_MapLayerSaveID, value); }
        }

        public string Regiondate
        {
            get { return (string)GetData(MapregionsaveTable.C_RegionDate); }
            set { SetData(MapregionsaveTable.C_RegionDate, value); }
        }

        public string Regioncolor
        {
            get { return (string)GetData(MapregionsaveTable.C_RegionColor); }
            set { SetData(MapregionsaveTable.C_RegionColor, value); }
        }

        #endregion
    }
}
