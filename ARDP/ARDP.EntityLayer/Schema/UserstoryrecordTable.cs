using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class UserstoryrecordTable : TableInfo
    {
        public const string C_TableName = "UserStoryRecord";

        public const string C_UserStoryRecordID = "UserStoryRecordID";

        public const string C_AccountID = "AccountID";

        public const string C_StoryID = "StoryID";

        public const string C_TopPoint = "TopPoint";

        public const string C_CreateTime = "CreateTime";


        public UserstoryrecordTable()
        {
            _tableName = "UserStoryRecord";
        }

        protected static UserstoryrecordTable _current;
        public static UserstoryrecordTable Current
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
            _current = new UserstoryrecordTable();

            _current.Add(C_UserStoryRecordID, new ColumnInfo(C_UserStoryRecordID, "Userstoryrecordid", true, typeof(string)));

            _current.Add(C_AccountID, new ColumnInfo(C_AccountID, "Accountid", false, typeof(string)));

            _current.Add(C_StoryID, new ColumnInfo(C_StoryID, "Storyid", false, typeof(string)));

            _current.Add(C_TopPoint, new ColumnInfo(C_TopPoint, "Toppoint", false, typeof(int)));

            _current.Add(C_CreateTime, new ColumnInfo(C_CreateTime, "Createtime", false, typeof(DateTime)));

        }


        public ColumnInfo UserStoryRecordID
        {
            get { return this[C_UserStoryRecordID]; }
        }

        public ColumnInfo AccountID
        {
            get { return this[C_AccountID]; }
        }

        public ColumnInfo StoryID
        {
            get { return this[C_StoryID]; }
        }

        public ColumnInfo TopPoint
        {
            get { return this[C_TopPoint]; }
        }

        public ColumnInfo CreateTime
        {
            get { return this[C_CreateTime]; }
        }

    }
}
