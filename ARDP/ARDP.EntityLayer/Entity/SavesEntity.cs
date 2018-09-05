using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class SavesEntity : EntityBase
    {
        public SavesTable TableSchema
        {
            get
            {
                return (SavesTable)_tableSchema;
            }
        }


        public SavesEntity()
        {
            _tableSchema = SavesTable.Current;
        }

        #region 属性列表

        public string Savesid
        {
            get { return (string)GetData(SavesTable.C_SavesID); }
            set { SetData(SavesTable.C_SavesID, value); }
        }

        public string Accountid
        {
            get { return (string)GetData(SavesTable.C_AccountID); }
            set { SetData(SavesTable.C_AccountID, value); }
        }

        public string Roleid
        {
            get { return (string)GetData(SavesTable.C_RoleID); }
            set { SetData(SavesTable.C_RoleID, value); }
        }

        public string Storyid
        {
            get { return (string)GetData(SavesTable.C_StoryID); }
            set { SetData(SavesTable.C_StoryID, value); }
        }

        public int Currentpoints
        {
            get { return (int)(GetData(SavesTable.C_CurrentPoints)); }
            set { SetData(SavesTable.C_CurrentPoints, value); }
        }

        public bool Isend
        {
            get { return (bool)(GetData(SavesTable.C_IsEnd)); }
            set { SetData(SavesTable.C_IsEnd, value); }
        }

        public int Playtimes
        {
            get { return GetInt(SavesTable.C_PlayTimes) == -1 ? 0 : GetInt(SavesTable.C_PlayTimes); }
            set { SetData(SavesTable.C_PlayTimes, value); }
        }

        public DateTime Savetime
        {
            get { return (DateTime)(GetData(SavesTable.C_SaveTime)); }
            set { SetData(SavesTable.C_SaveTime, value); }
        } 
        #endregion
    }
}
