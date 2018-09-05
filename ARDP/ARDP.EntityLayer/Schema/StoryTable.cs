using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoryTable : TableInfo
    {
        public const string C_TableName = "Story";

        public const string C_StoryID = "StoryID";

        public const string C_StoryName = "StoryName";

        public const string C_SmallImage = "SmallImage";

        public const string C_FullPoints = "FullPoints";

        public const string C_FullClassName = "FullClassName";

        public const string C_OrderNum = "OrderNum";

        public const string C_StoryNameEn = "StoryNameEn";

        


        public StoryTable()
        {
            _tableName = "Story";
        }

        protected static StoryTable _current;
        public static StoryTable Current
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
            _current = new StoryTable();

            _current.Add(C_StoryID, new ColumnInfo(C_StoryID, "Storyid", true, typeof(string)));

            _current.Add(C_StoryName, new ColumnInfo(C_StoryName, "Storyname", false, typeof(string)));

            _current.Add(C_SmallImage, new ColumnInfo(C_SmallImage, "Smallimage", false, typeof(string)));

            _current.Add(C_FullPoints, new ColumnInfo(C_FullPoints, "Fullpoints", false, typeof(int)));

            _current.Add(C_FullClassName, new ColumnInfo(C_FullClassName, "Fullclassname", false, typeof(string)));

            _current.Add(C_OrderNum, new ColumnInfo(C_OrderNum, "OrderNum", false, typeof(int)));

            _current.Add(C_StoryNameEn, new ColumnInfo(C_StoryNameEn, "StoryNameEn", false, typeof(string)));

        }


        public ColumnInfo StoryID
        {
            get { return this[C_StoryID]; }
        }

        public ColumnInfo StoryName
        {
            get { return this[C_StoryName]; }
        }

        public ColumnInfo SmallImage
        {
            get { return this[C_SmallImage]; }
        }

        public ColumnInfo FullPoints
        {
            get { return this[C_FullPoints]; }
        }

        public ColumnInfo FullClassName
        {
            get { return this[C_FullClassName]; }
        }

        public ColumnInfo OrderNum
        {
            get { return this[C_OrderNum]; }
        }

        public ColumnInfo StoryNameEn
        {
            get { return this[C_StoryNameEn]; }
        } 
    }
}
