using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class SavesTable : TableInfo
    {
        public const string C_TableName = "Saves";

        public const string C_SavesID = "SavesID";

        public const string C_AccountID = "AccountID";

        public const string C_RoleID = "RoleID";

        public const string C_StoryID = "StoryID";

        public const string C_CurrentPoints = "CurrentPoints";

        public const string C_IsEnd = "IsEnd";

        public const string C_PlayTimes = "PlayTimes";

        public const string C_SaveTime = "SaveTime"; 

        public SavesTable()
        {
            _tableName = "Saves";
        }

        protected static SavesTable _current;
        public static SavesTable Current
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
            _current = new SavesTable();

            _current.Add(C_SavesID, new ColumnInfo(C_SavesID, "Savesid", true, typeof(string)));

            _current.Add(C_AccountID, new ColumnInfo(C_AccountID, "Accountid", false, typeof(string)));

            _current.Add(C_RoleID, new ColumnInfo(C_RoleID, "Roleid", false, typeof(string)));

            _current.Add(C_StoryID, new ColumnInfo(C_StoryID, "Storyid", false, typeof(string)));

            _current.Add(C_CurrentPoints, new ColumnInfo(C_CurrentPoints, "Currentpoints", false, typeof(int)));

            _current.Add(C_IsEnd, new ColumnInfo(C_IsEnd, "Isend", false, typeof(bool)));

            _current.Add(C_PlayTimes, new ColumnInfo(C_PlayTimes, "Playtimes", false, typeof(int)));

            _current.Add(C_SaveTime, new ColumnInfo(C_SaveTime, "Savetime", false, typeof(DateTime))); 

        }


        public ColumnInfo SavesID
        {
            get { return this[C_SavesID]; }
        }

        public ColumnInfo AccountID
        {
            get { return this[C_AccountID]; }
        }

        public ColumnInfo RoleID
        {
            get { return this[C_RoleID]; }
        }

        public ColumnInfo StoryID
        {
            get { return this[C_StoryID]; }
        }

        public ColumnInfo CurrentPoints
        {
            get { return this[C_CurrentPoints]; }
        }

        public ColumnInfo IsEnd
        {
            get { return this[C_IsEnd]; }
        }

        public ColumnInfo PlayTimes
        {
            get { return this[C_PlayTimes]; }
        }

        public ColumnInfo SaveTime
        {
            get { return this[C_SaveTime]; }
        } 
    }
}
