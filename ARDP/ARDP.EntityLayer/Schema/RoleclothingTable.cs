using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class RoleclothingTable : TableInfo
    {
        public const string C_TableName = "RoleClothing";

        public const string C_RoleClothingID = "RoleClothingID";

        public const string C_RoleID = "RoleID";

        public const string C_ClothingID = "ClothingID";

        public const string C_Season = "Season";


        public RoleclothingTable()
        {
            _tableName = "RoleClothing";
        }

        protected static RoleclothingTable _current;
        public static RoleclothingTable Current
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
            _current = new RoleclothingTable();

            _current.Add(C_RoleClothingID, new ColumnInfo(C_RoleClothingID, "Roleclothingid", true, typeof(string)));

            _current.Add(C_RoleID, new ColumnInfo(C_RoleID, "Roleid", false, typeof(string)));

            _current.Add(C_ClothingID, new ColumnInfo(C_ClothingID, "Clothingid", false, typeof(string)));

            _current.Add(C_Season, new ColumnInfo(C_Season, "Season", false, typeof(string)));

        }


        public ColumnInfo RoleClothingID
        {
            get { return this[C_RoleClothingID]; }
        }

        public ColumnInfo RoleID
        {
            get { return this[C_RoleID]; }
        }

        public ColumnInfo ClothingID
        {
            get { return this[C_ClothingID]; }
        }

        public ColumnInfo Season
        {
            get { return this[C_Season]; }
        }

    }
}
