using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class MapEntity : EntityBase
    {
        public MapTable TableSchema
        {
            get
            {
                return (MapTable)_tableSchema;
            }
        }


        public MapEntity()
        {
            _tableSchema = MapTable.Current;
        }

        #region 属性列表

        public string Mapid
        {
            get { return (string)GetData(MapTable.C_MapID); }
            set { SetData(MapTable.C_MapID, value); }
        }

        public string Mapname
        {
            get { return (string)GetData(MapTable.C_MapName); }
            set { SetData(MapTable.C_MapName, value); }
        }

        public string Maprelationcode
        {
            get { return (string)GetData(MapTable.C_MapRelationCode); }
            set { SetData(MapTable.C_MapRelationCode, value); }
        }

        public decimal Maplevel
        {
            get { return (decimal)GetData(MapTable.C_MapLevel); }
            set { SetData(MapTable.C_MapLevel, value); }
        }

        public int Mapscale
        {
            get { return (int)GetData(MapTable.C_MapScale); }
            set { SetData(MapTable.C_MapScale, value); }
        }
        #endregion
    }
}
