using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class SingleoptionEntity : EntityBase
    {
        public SingleoptionTable TableSchema
        {
            get
            {
                return (SingleoptionTable)_tableSchema;
            }
        }


        public SingleoptionEntity()
        {
            _tableSchema = SingleoptionTable.Current;
        }

        #region 属性列表

        public string Id
        {
            get { return (string)GetData(SingleoptionTable.C_ID); }
            set { SetData(SingleoptionTable.C_ID, value); }
        }

        public string Sentence
        {
            get { return (string)GetData(SingleoptionTable.C_Sentence); }
            set { SetData(SingleoptionTable.C_Sentence, value); }
        }

        public string QuestionId
        {
            get { return (string)GetData(SingleoptionTable.C_Question_ID); }
            set { SetData(SingleoptionTable.C_Question_ID, value); }
        }

        #endregion
    }
}
