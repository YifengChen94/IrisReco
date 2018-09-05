using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class MapsaveEntity : EntityBase
    {
        public MapsaveTable TableSchema
        {
            get
            {
                return (MapsaveTable)_tableSchema;
            }
        }


        public MapsaveEntity()
        {
            _tableSchema = MapsaveTable.Current;
        }

        #region 属性列表

        public string Mapsaveid
        {
            get { return (string)GetData(MapsaveTable.C_MapSaveID); }
            set { SetData(MapsaveTable.C_MapSaveID, value); }
        }

        public string Mapid
        {
            get { return (string)GetData(MapsaveTable.C_MapID); }
            set { SetData(MapsaveTable.C_MapID, value); }
        }

        public string Usersaveid
        {
            get { return (string)GetData(MapsaveTable.C_UserSaveID); }
            set { SetData(MapsaveTable.C_UserSaveID, value); }
        }

        public string Dsrtype
        {
            get { return (string)GetData(MapsaveTable.C_DSRType); }
            set { SetData(MapsaveTable.C_DSRType, value); }
        }

        #endregion
    }
}
