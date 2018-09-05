using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class QuestionEntity : EntityBase
    {
        public QuestionTable TableSchema
        {
            get
            {
                return (QuestionTable)_tableSchema;
            }
        }


        public QuestionEntity()
        {
            _tableSchema = QuestionTable.Current;
        }

        #region 属性列表

        public string Id
        {
            get { return (string)GetData(QuestionTable.C_ID); }
            set { SetData(QuestionTable.C_ID, value); }
        }

        public string QuestionDescription
        {
            get { return (string)GetData(QuestionTable.C_Question_Description); }
            set { SetData(QuestionTable.C_Question_Description, value); }
        }

        public string QuestionType
        {
            get { return (string)GetData(QuestionTable.C_Question_type); }
            set { SetData(QuestionTable.C_Question_type, value); }
        }

        public string QuestionBackground
        {
            get { return (string)GetData(QuestionTable.C_Question_Background); }
            set { SetData(QuestionTable.C_Question_Background, value); }
        }

        public string QuestionTitle
        {
            get { return (string)GetData(QuestionTable.C_Question_Title); }
            set { SetData(QuestionTable.C_Question_Title, value); }
        }

        #endregion
    }
}
