using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ReplyTable : TableInfo
    {
        public const string C_TableName = "Reply";

        public const string C_ID = "ID";

        public const string C_Score = "Score";

        public const string C_ReplyDescription = "ReplyDescription";

        public const string C_IsRight = "IsRight";

        public const string C_Reply_Background = "Reply_Background";

        public const string C_Question_ID = "Question_ID";

        public const string C_NPC = "NPC";

        public ReplyTable()
        {
            _tableName = "Reply";
        }

        protected static ReplyTable _current;
        public static ReplyTable Current
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
            _current = new ReplyTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(string)));

            _current.Add(C_Score, new ColumnInfo(C_Score, "Score", false, typeof(int)));

            _current.Add(C_ReplyDescription, new ColumnInfo(C_ReplyDescription, "Replydescription", false, typeof(string)));

            _current.Add(C_IsRight, new ColumnInfo(C_IsRight, "Isright", false, typeof(string)));

            _current.Add(C_Reply_Background, new ColumnInfo(C_Reply_Background, "ReplyBackground", false, typeof(string)));

            _current.Add(C_Question_ID, new ColumnInfo(C_Question_ID, "QuestionId", false, typeof(string)));

            _current.Add(C_NPC, new ColumnInfo(C_NPC, "NPC", false, typeof(string)));

        }


        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo Score
        {
            get { return this[C_Score]; }
        }

        public ColumnInfo ReplyDescription
        {
            get { return this[C_ReplyDescription]; }
        }

        public ColumnInfo IsRight
        {
            get { return this[C_IsRight]; }
        }

        public ColumnInfo Reply_Background
        {
            get { return this[C_Reply_Background]; }
        }

        public ColumnInfo Question_ID
        {
            get { return this[C_Question_ID]; }
        }

        public ColumnInfo NPC
        {
            get { return this[C_NPC]; }
        }

    }
}
