using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class RoleTable : TableInfo
    {
        public const string C_TableName = "Role";

        public const string C_RoleID = "RoleID";

        public const string C_RoleName = "RoleName";

        public const string C_RoleDescription = "RoleDescription";


        public RoleTable()
        {
            _tableName = "Role";
        }

        protected static RoleTable _current;
        public static RoleTable Current
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
            _current = new RoleTable();

            _current.Add(C_RoleID, new ColumnInfo(C_RoleID, "Roleid", true, typeof(string)));

            _current.Add(C_RoleName, new ColumnInfo(C_RoleName, "Rolename", false, typeof(string)));

            _current.Add(C_RoleDescription, new ColumnInfo(C_RoleDescription, "Roledescription", false, typeof(string)));

        }


        public ColumnInfo RoleID
        {
            get { return this[C_RoleID]; }
        }

        public ColumnInfo RoleName
        {
            get { return this[C_RoleName]; }
        }

        public ColumnInfo RoleDescription
        {
            get { return this[C_RoleDescription]; }
        }

    }
}
