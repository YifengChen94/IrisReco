using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcpquestionTable : TableInfo
    {
        public const string C_TableName = "BCPQuestion";

        public const string C_BCPQuestionID = "BCPQuestionID";

        public const string C_Question = "Question";

        public const string C_QuestionType = "QuestionType";

        public const string C_Answer = "Answer";


        public BcpquestionTable()
        {
            _tableName = "BCPQuestion";
        }

        protected static BcpquestionTable _current;
        public static BcpquestionTable Current
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
            _current = new BcpquestionTable();

            _current.Add(C_BCPQuestionID, new ColumnInfo(C_BCPQuestionID, "Bcpquestionid", true, typeof(string)));

            _current.Add(C_Question, new ColumnInfo(C_Question, "Question", false, typeof(string)));

            _current.Add(C_QuestionType, new ColumnInfo(C_QuestionType, "Questiontype", false, typeof(int)));

            _current.Add(C_Answer, new ColumnInfo(C_Answer, "Answer", false, typeof(string)));

        }


        public ColumnInfo BCPQuestionID
        {
            get { return this[C_BCPQuestionID]; }
        }

        public ColumnInfo Question
        {
            get { return this[C_Question]; }
        }

        public ColumnInfo QuestionType
        {
            get { return this[C_QuestionType]; }
        }

        public ColumnInfo Answer
        {
            get { return this[C_Answer]; }
        }

    }
}
