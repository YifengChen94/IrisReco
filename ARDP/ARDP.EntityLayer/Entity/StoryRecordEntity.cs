using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    public partial class StoryRecordEntity : EntityBase
    {
        public StoryRecordTable TableSchema
        {
            get
            {
                return (StoryRecordTable)_tableSchema;
            }
        }


        public StoryRecordEntity()
        {
            _tableSchema = StoryRecordTable.Current;
        }

        #region 属性列表

        public string Storyrecordid
        {
            get { return (string)GetData(StoryRecordTable.C_StoryRecordID); }
            set { SetData(StoryRecordTable.C_StoryRecordID, value); }
        }

        public string Dmsid
        {
            get { return (string)GetData(StoryRecordTable.C_DMSID); }
            set { SetData(StoryRecordTable.C_DMSID, value); }
        }

        public string Accountid
        {
            get { return (string)GetData(StoryRecordTable.C_AccountID); }
            set { SetData(StoryRecordTable.C_AccountID, value); }
        }

        public string Storyid
        {
            get { return (string)GetData(StoryRecordTable.C_StoryID); }
            set { SetData(StoryRecordTable.C_StoryID, value); }
        }

        public int Toppoint
        {
            get { return (int)(GetData(StoryRecordTable.C_TopPoint)); }
            set { SetData(StoryRecordTable.C_TopPoint, value); }
        }

        public DateTime Createtime
        {
            get { return (DateTime)(GetData(StoryRecordTable.C_CreateTime)); }
            set { SetData(StoryRecordTable.C_CreateTime, value); }
        }

        #endregion
    }
}
