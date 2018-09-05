using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class SingleoptionTable : TableInfo
    {
        public const string C_TableName = "SingleOption";

        public const string C_ID = "ID";

        public const string C_Sentence = "Sentence";

        public const string C_Question_ID = "Question_ID";


        public SingleoptionTable()
        {
            _tableName = "SingleOption";
        }

        protected static SingleoptionTable _current;
        public static SingleoptionTable Current
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
            _current = new SingleoptionTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(string)));

            _current.Add(C_Sentence, new ColumnInfo(C_Sentence, "Sentence", false, typeof(string)));

            _current.Add(C_Question_ID, new ColumnInfo(C_Question_ID, "QuestionId", false, typeof(string)));

        }


        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo Sentence
        {
            get { return this[C_Sentence]; }
        }

        public ColumnInfo Question_ID
        {
            get { return this[C_Question_ID]; }
        }

    }
}
