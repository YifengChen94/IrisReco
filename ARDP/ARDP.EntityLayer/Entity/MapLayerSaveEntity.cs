using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class MapLayerSaveEntity : EntityBase
    {
        public MapLayerSaveTable TableSchema
        {
            get
            {
                return (MapLayerSaveTable)_tableSchema;
            }
        }


        public MapLayerSaveEntity()
        {
            _tableSchema = MapLayerSaveTable.Current;
        }

        #region 属性列表

        public string MapLayerSaveID
        {
            get { return (string)GetData(MapLayerSaveTable.C_MapLayerSaveID); }
            set { SetData(MapLayerSaveTable.C_MapLayerSaveID, value); }
        }

        public string MapSaveID
        {
            get { return (string)GetData(MapLayerSaveTable.C_MapSaveID); }
            set { SetData(MapLayerSaveTable.C_MapSaveID, value); }
        }

        public string MapLayerCode
        {
            get { return (string)GetData(MapLayerSaveTable.C_MapLayerCode); }
            set { SetData(MapLayerSaveTable.C_MapLayerCode, value); }
        }
        #endregion
    }
}
