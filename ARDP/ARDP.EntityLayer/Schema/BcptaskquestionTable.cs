using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskquestionTable : TableInfo
    {
        public const string C_TableName = "BCPTaskQuestion";

        public const string C_BCPTaskQuestionID = "BCPTaskQuestionID";

        public const string C_BCPTaskID = "BCPTaskID";

        public const string C_BCPQuestionID = "BCPQuestionID";


        public BcptaskquestionTable()
        {
            _tableName = "BCPTaskQuestion";
        }

        protected static BcptaskquestionTable _current;
        public static BcptaskquestionTable Current
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
            _current = new BcptaskquestionTable();

            _current.Add(C_BCPTaskQuestionID, new ColumnInfo(C_BCPTaskQuestionID, "Bcptaskquestionid", true, typeof(string)));

            _current.Add(C_BCPTaskID, new ColumnInfo(C_BCPTaskID, "Bcptaskid", false, typeof(string)));

            _current.Add(C_BCPQuestionID, new ColumnInfo(C_BCPQuestionID, "Bcpquestionid", false, typeof(string)));

        }


        public ColumnInfo BCPTaskQuestionID
        {
            get { return this[C_BCPTaskQuestionID]; }
        }

        public ColumnInfo BCPTaskID
        {
            get { return this[C_BCPTaskID]; }
        }

        public ColumnInfo BCPQuestionID
        {
            get { return this[C_BCPQuestionID]; }
        }

    }
}
