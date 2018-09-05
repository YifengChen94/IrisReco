using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore; 

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcpquestionEntity : EntityBase
    {
        public BcpquestionTable TableSchema
        {
            get
            {
                return (BcpquestionTable)_tableSchema;
            }
        }


        public BcpquestionEntity()
        {
            _tableSchema = BcpquestionTable.Current;
        }

        #region 属性列表

        public string Bcpquestionid
        {
            get { return (string)GetData(BcpquestionTable.C_BCPQuestionID); }
            set { SetData(BcpquestionTable.C_BCPQuestionID, value); }
        }

        public string Question
        {
            get { return (string)GetData(BcpquestionTable.C_Question); }
            set { SetData(BcpquestionTable.C_Question, value); }
        }

        public int Questiontype
        {
            get { return (int)(GetData(BcpquestionTable.C_QuestionType)); }
            set { SetData(BcpquestionTable.C_QuestionType, value); }
        }

        public string Answer
        {
            get { return (string)GetData(BcpquestionTable.C_Answer); }
            set { SetData(BcpquestionTable.C_Answer, value); }
        }

        #endregion
    }
}
