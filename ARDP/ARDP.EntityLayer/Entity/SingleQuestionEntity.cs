using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class SinglequestionEntity : EntityBase
    {
        public SinglequestionTable TableSchema
        {
            get
            {
                return (SinglequestionTable)_tableSchema;
            }
        }


        public SinglequestionEntity()
        {
            _tableSchema = SinglequestionTable.Current;
        }

        #region 属性列表

        public string Id
        {
            get { return (string)GetData(SinglequestionTable.C_ID); }
            set { SetData(SinglequestionTable.C_ID, value); }
        }

        public string Sentence
        {
            get { return (string)GetData(SinglequestionTable.C_Sentence); }
            set { SetData(SinglequestionTable.C_Sentence, value); }
        }

        public string Answer
        {
            get { return (string)GetData(SinglequestionTable.C_Answer); }
            set { SetData(SinglequestionTable.C_Answer, value); }
        }

        public string Type
        {
            get { return (string)GetData(SinglequestionTable.C_Type); }
            set { SetData(SinglequestionTable.C_Type, value); }
        }

        public string Image
        {
            get { return (string)GetData(SinglequestionTable.C_Image); }
            set { SetData(SinglequestionTable.C_Image, value); }
        }

        #endregion
    }
}
