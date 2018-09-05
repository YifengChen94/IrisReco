using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class QuestionTable : TableInfo
    {
        public const string C_TableName = "Question";

        public const string C_ID = "ID";

        public const string C_Question_Description = "Question_Description";

        public const string C_Question_type = "Question_type";

        public const string C_Question_Background = "Question_Background";

        public const string C_Question_Title = "Question_Title";

        public QuestionTable()
        {
            _tableName = "Question";
        }

        protected static QuestionTable _current;
        public static QuestionTable Current
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
            _current = new QuestionTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(string)));

            _current.Add(C_Question_Description, new ColumnInfo(C_Question_Description, "QuestionDescription", false, typeof(string)));

            _current.Add(C_Question_type, new ColumnInfo(C_Question_type, "QuestionType", false, typeof(string)));

            _current.Add(C_Question_Background, new ColumnInfo(C_Question_Background, "QuestionBackground", false, typeof(string)));

            _current.Add(C_Question_Background, new ColumnInfo(C_Question_Title, "QuestionTitle", false, typeof(string)));

        }


        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo Question_Description
        {
            get { return this[C_Question_Description]; }
        }

        public ColumnInfo Question_type
        {
            get { return this[C_Question_type]; }
        }

        public ColumnInfo Question_Background
        {
            get { return this[C_Question_Background]; }
        }

        public ColumnInfo Question_Title
        {
            get { return this[C_Question_Title]; }
        }

    }
}
