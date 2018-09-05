using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class MapsaveTable : TableInfo
    {
        public const string C_TableName = "MapSave";

        public const string C_MapSaveID = "MapSaveID";

        public const string C_MapID = "MapID";

        public const string C_UserSaveID = "UserSaveID";

        public const string C_DSRType = "DSRType";


        public MapsaveTable()
        {
            _tableName = "MapSave";
        }

        protected static MapsaveTable _current;
        public static MapsaveTable Current
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
            _current = new MapsaveTable();

            _current.Add(C_MapSaveID, new ColumnInfo(C_MapSaveID, "Mapsaveid", true, typeof(string)));

            _current.Add(C_MapID, new ColumnInfo(C_MapID, "Mapid", false, typeof(string)));

            _current.Add(C_UserSaveID, new ColumnInfo(C_UserSaveID, "Usersaveid", false, typeof(string)));

            _current.Add(C_DSRType, new ColumnInfo(C_DSRType, "Dsrtype", false, typeof(string)));

        }


        public ColumnInfo MapSaveID
        {
            get { return this[C_MapSaveID]; }
        }

        public ColumnInfo MapID
        {
            get { return this[C_MapID]; }
        }

        public ColumnInfo UserSaveID
        {
            get { return this[C_UserSaveID]; }
        }

        public ColumnInfo DSRType
        {
            get { return this[C_DSRType]; }
        }

    }
}
