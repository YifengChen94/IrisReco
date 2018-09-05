using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoryRecordTable : TableInfo
    {
        public const string C_TableName = "STORY_RECORD";

        public const string C_StoryRecordID = "STORYRECORDID";

        public const string C_DMSID = "DMSID";

        public const string C_AccountID = "ACCOUNTID";

        public const string C_StoryID = "STORYID";

        public const string C_TopPoint = "TOPPOINT";

        public const string C_CreateTime = "CREATETIME";


        public StoryRecordTable()
        {
            _tableName = "STORY_RECORD";
        }

        protected static StoryRecordTable _current;
        public static StoryRecordTable Current
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
            _current = new StoryRecordTable();

            _current.Add(C_StoryRecordID, new ColumnInfo(C_StoryRecordID, "Storyrecordid", true, typeof(string)));

            _current.Add(C_DMSID, new ColumnInfo(C_DMSID, "Dmsid", false, typeof(string)));

            _current.Add(C_AccountID, new ColumnInfo(C_AccountID, "Accountid", false, typeof(string)));

            _current.Add(C_StoryID, new ColumnInfo(C_StoryID, "Storyid", false, typeof(string)));

            _current.Add(C_TopPoint, new ColumnInfo(C_TopPoint, "Toppoint", false, typeof(int)));

            _current.Add(C_CreateTime, new ColumnInfo(C_CreateTime, "Createtime", false, typeof(DateTime)));

        }


        public ColumnInfo StoryRecordID
        {
            get { return this[C_StoryRecordID]; }
        }

        public ColumnInfo DMSID
        {
            get { return this[C_DMSID]; }
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
