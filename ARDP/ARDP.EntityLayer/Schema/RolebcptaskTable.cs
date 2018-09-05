using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class RolebcptaskTable : TableInfo
    {
        public const string C_TableName = "RoleBCPTask";

        public const string C_RoleBCPTask = "RoleBCPTask";

        public const string C_RoleID = "RoleID";

        public const string C_BCPTaskID = "BCPTaskID";


        public RolebcptaskTable()
        {
            _tableName = "RoleBCPTask";
        }

        protected static RolebcptaskTable _current;
        public static RolebcptaskTable Current
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
            _current = new RolebcptaskTable();

            _current.Add(C_RoleBCPTask, new ColumnInfo(C_RoleBCPTask, "Rolebcptask", true, typeof(string)));

            _current.Add(C_RoleID, new ColumnInfo(C_RoleID, "Roleid", false, typeof(string)));

            _current.Add(C_BCPTaskID, new ColumnInfo(C_BCPTaskID, "Bcptaskid", false, typeof(string)));

        }


        public ColumnInfo RoleBCPTask
        {
            get { return this[C_RoleBCPTask]; }
        }

        public ColumnInfo RoleID
        {
            get { return this[C_RoleID]; }
        }

        public ColumnInfo BCPTaskID
        {
            get { return this[C_BCPTaskID]; }
        }

    }
}
