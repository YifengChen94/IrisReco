using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcpquestionoptionTable : TableInfo
    {
        public const string C_TableName = "BCPQuestionOption";

        public const string C_BCPQuestionOptionID = "BCPQuestionOptionID";

        public const string C_BCPQuestionID = "BCPQuestionID";

        public const string C_OptionText = "OptionText";

        public const string C_OptionKey = "OptionKey";


        public BcpquestionoptionTable()
        {
            _tableName = "BCPQuestionOption";
        }

        protected static BcpquestionoptionTable _current;
        public static BcpquestionoptionTable Current
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
            _current = new BcpquestionoptionTable();

            _current.Add(C_BCPQuestionOptionID, new ColumnInfo(C_BCPQuestionOptionID, "Bcpquestionoptionid", true, typeof(string)));

            _current.Add(C_BCPQuestionID, new ColumnInfo(C_BCPQuestionID, "Bcpquestionid", false, typeof(string)));

            _current.Add(C_OptionText, new ColumnInfo(C_OptionText, "Optiontext", false, typeof(string)));

            _current.Add(C_OptionKey, new ColumnInfo(C_OptionKey, "Optionkey", false, typeof(string)));

        }


        public ColumnInfo BCPQuestionOptionID
        {
            get { return this[C_BCPQuestionOptionID]; }
        }

        public ColumnInfo BCPQuestionID
        {
            get { return this[C_BCPQuestionID]; }
        }

        public ColumnInfo OptionText
        {
            get { return this[C_OptionText]; }
        }

        public ColumnInfo OptionKey
        {
            get { return this[C_OptionKey]; }
        }

    }
}
