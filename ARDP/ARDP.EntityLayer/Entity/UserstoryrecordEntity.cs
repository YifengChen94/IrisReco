using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class UserstoryrecordEntity : EntityBase
    {
        public UserstoryrecordTable TableSchema
        {
            get
            {
                return (UserstoryrecordTable)_tableSchema;
            }
        }


        public UserstoryrecordEntity()
        {
            _tableSchema = UserstoryrecordTable.Current;
        }

        #region 属性列表

        public string Userstoryrecordid
        {
            get { return (string)GetData(UserstoryrecordTable.C_UserStoryRecordID); }
            set { SetData(UserstoryrecordTable.C_UserStoryRecordID, value); }
        }

        public string Accountid
        {
            get { return (string)GetData(UserstoryrecordTable.C_AccountID); }
            set { SetData(UserstoryrecordTable.C_AccountID, value); }
        }

        public string Storyid
        {
            get { return (string)GetData(UserstoryrecordTable.C_StoryID); }
            set { SetData(UserstoryrecordTable.C_StoryID, value); }
        }

        public int Toppoint
        {
            get { return (int)(GetData(UserstoryrecordTable.C_TopPoint)); }
            set { SetData(UserstoryrecordTable.C_TopPoint, value); }
        }

        public DateTime Createtime
        {
            get { return (DateTime)(GetData(UserstoryrecordTable.C_CreateTime)); }
            set { SetData(UserstoryrecordTable.C_CreateTime, value); }
        }

        #endregion
    }
}
