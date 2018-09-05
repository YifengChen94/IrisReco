using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore; 

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskquestionEntity : EntityBase
    {
        public BcptaskquestionTable TableSchema
        {
            get
            {
                return (BcptaskquestionTable)_tableSchema;
            }
        }


        public BcptaskquestionEntity()
        {
            _tableSchema = BcptaskquestionTable.Current;
        }

        #region 属性列表

        public string Bcptaskquestionid
        {
            get { return (string)GetData(BcptaskquestionTable.C_BCPTaskQuestionID); }
            set { SetData(BcptaskquestionTable.C_BCPTaskQuestionID, value); }
        }

        public string Bcptaskid
        {
            get { return (string)GetData(BcptaskquestionTable.C_BCPTaskID); }
            set { SetData(BcptaskquestionTable.C_BCPTaskID, value); }
        }

        public string Bcpquestionid
        {
            get { return (string)GetData(BcptaskquestionTable.C_BCPQuestionID); }
            set { SetData(BcptaskquestionTable.C_BCPQuestionID, value); }
        }

        #endregion
    }
}
