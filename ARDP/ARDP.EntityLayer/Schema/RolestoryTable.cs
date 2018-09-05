using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class RolestoryTable : TableInfo
    {
        public const string C_TableName = "RoleStory";

        public const string C_RoleStoryID = "RoleStoryID";

        public const string C_RoleID = "RoleID";

        public const string C_StoryID = "StoryID";


        public RolestoryTable()
        {
            _tableName = "RoleStory";
        }

        protected static RolestoryTable _current;
        public static RolestoryTable Current
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
            _current = new RolestoryTable();

            _current.Add(C_RoleStoryID, new ColumnInfo(C_RoleStoryID, "Rolestoryid", true, typeof(string)));

            _current.Add(C_RoleID, new ColumnInfo(C_RoleID, "Roleid", false, typeof(string)));

            _current.Add(C_StoryID, new ColumnInfo(C_StoryID, "Storyid", false, typeof(string)));

        }


        public ColumnInfo RoleStoryID
        {
            get { return this[C_RoleStoryID]; }
        }

        public ColumnInfo RoleID
        {
            get { return this[C_RoleID]; }
        }

        public ColumnInfo StoryID
        {
            get { return this[C_StoryID]; }
        }

    }
}
