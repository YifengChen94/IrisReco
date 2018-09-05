using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore; 

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcpquestionoptionEntity : EntityBase
    {
        public BcpquestionoptionTable TableSchema
        {
            get
            {
                return (BcpquestionoptionTable)_tableSchema;
            }
        }


        public BcpquestionoptionEntity()
        {
            _tableSchema = BcpquestionoptionTable.Current;
        }

        #region 属性列表

        public string Bcpquestionoptionid
        {
            get { return (string)GetData(BcpquestionoptionTable.C_BCPQuestionOptionID); }
            set { SetData(BcpquestionoptionTable.C_BCPQuestionOptionID, value); }
        }

        public string Bcpquestionid
        {
            get { return (string)GetData(BcpquestionoptionTable.C_BCPQuestionID); }
            set { SetData(BcpquestionoptionTable.C_BCPQuestionID, value); }
        }

        public string Optiontext
        {
            get { return (string)GetData(BcpquestionoptionTable.C_OptionText); }
            set { SetData(BcpquestionoptionTable.C_OptionText, value); }
        }

        public string Optionkey
        {
            get { return (string)GetData(BcpquestionoptionTable.C_OptionKey); }
            set { SetData(BcpquestionoptionTable.C_OptionKey, value); }
        }

        #endregion
    }
}
