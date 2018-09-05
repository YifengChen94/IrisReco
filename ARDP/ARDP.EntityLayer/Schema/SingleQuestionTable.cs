using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class SinglequestionTable : TableInfo
    {
        public const string C_TableName = "SingleQuestion";

        public const string C_ID = "ID";

        public const string C_Sentence = "Sentence";

        public const string C_Answer = "Answer";

        public const string C_Type = "Type";

        public const string C_Image = "Image";


        public SinglequestionTable()
        {
            _tableName = "SingleQuestion";
        }

        protected static SinglequestionTable _current;
        public static SinglequestionTable Current
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
            _current = new SinglequestionTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(string)));

            _current.Add(C_Sentence, new ColumnInfo(C_Sentence, "Sentence", false, typeof(string)));

            _current.Add(C_Answer, new ColumnInfo(C_Answer, "Answer", false, typeof(string)));

            _current.Add(C_Type, new ColumnInfo(C_Type, "Type", false, typeof(string)));

            _current.Add(C_Image, new ColumnInfo(C_Image, "Image", false, typeof(string)));

        }


        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo Sentence
        {
            get { return this[C_Sentence]; }
        }

        public ColumnInfo Answer
        {
            get { return this[C_Answer]; }
        }

        public ColumnInfo Type
        {
            get { return this[C_Type]; }
        }

        public ColumnInfo Image
        {
            get { return this[C_Image]; }
        }

    }
}
