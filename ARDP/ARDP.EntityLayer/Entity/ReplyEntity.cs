using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ReplyEntity : EntityBase
    {
        public ReplyTable TableSchema
        {
            get
            {
                return (ReplyTable)_tableSchema;
            }
        }


        public ReplyEntity()
        {
            _tableSchema = ReplyTable.Current;
        }

        #region 属性列表

        public string Id
        {
            get { return (string)GetData(ReplyTable.C_ID); }
            set { SetData(ReplyTable.C_ID, value); }
        }

        public int Score
        {
            get { return (int)GetData(ReplyTable.C_Score); }
            set { SetData(ReplyTable.C_Score, value); }
        }

        public string Replydescription
        {
            get { return (string)GetData(ReplyTable.C_ReplyDescription); }
            set { SetData(ReplyTable.C_ReplyDescription, value); }
        }

        public string Isright
        {
            get { return (string)GetData(ReplyTable.C_IsRight); }
            set { SetData(ReplyTable.C_IsRight, value); }
        }

        public string ReplyBackground
        {
            get { return (string)GetData(ReplyTable.C_Reply_Background); }
            set { SetData(ReplyTable.C_Reply_Background, value); }
        }

        public string QuestionId
        {
            get { return (string)GetData(ReplyTable.C_Question_ID); }
            set { SetData(ReplyTable.C_Question_ID, value); }
        }

        public string NPC
        {
            get { return (string)GetData(ReplyTable.C_NPC); }
            set { SetData(ReplyTable.C_NPC, value); }
        }

        #endregion
    }
}
