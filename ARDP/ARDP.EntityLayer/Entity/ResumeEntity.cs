using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ResumeEntity : EntityBase
    {
        public ResumeTable TableSchema
        {
            get
            {
                return (ResumeTable)_tableSchema;
            }
        }


        public ResumeEntity()
        {
            _tableSchema = ResumeTable.Current;
        }

        #region 属性列表

        public string Id
        {
            get { return (string)GetData(ResumeTable.C_ID); }
            set { SetData(ResumeTable.C_ID, value); }
        }

        public string Name
        {
            get { return (string)GetData(ResumeTable.C_Name); }
            set { SetData(ResumeTable.C_Name, value); }
        }

        public string Sex
        {
            get { return (string)GetData(ResumeTable.C_Sex); }
            set { SetData(ResumeTable.C_Sex, value); }
        }

        public string Birthday
        {
            get { return (string)GetData(ResumeTable.C_Birthday); }
            set { SetData(ResumeTable.C_Birthday, value); }
        }

        public string Married
        {
            get { return (string)GetData(ResumeTable.C_Married); }
            set { SetData(ResumeTable.C_Married, value); }
        }

        public string Idno
        {
            get { return (string)GetData(ResumeTable.C_IDNo); }
            set { SetData(ResumeTable.C_IDNo, value); }
        }

        public string Phoneno
        {
            get { return (string)GetData(ResumeTable.C_PhoneNo); }
            set { SetData(ResumeTable.C_PhoneNo, value); }
        }

        public string Email
        {
            get { return (string)GetData(ResumeTable.C_Email); }
            set { SetData(ResumeTable.C_Email, value); }
        }

        public string Address
        {
            get { return (string)GetData(ResumeTable.C_Address); }
            set { SetData(ResumeTable.C_Address, value); }
        }

        public string PostCode
        {
            get { return (string)GetData(ResumeTable.C_Post_Code); }
            set { SetData(ResumeTable.C_Post_Code, value); }
        }

        public string Prize
        {
            get { return (string)GetData(ResumeTable.C_Prize); }
            set { SetData(ResumeTable.C_Prize, value); }
        }

        public string OtherActivity
        {
            get { return (string)GetData(ResumeTable.C_Other_Activity); }
            set { SetData(ResumeTable.C_Other_Activity, value); }
        }

        public string Interesting
        {
            get { return (string)GetData(ResumeTable.C_Interesting); }
            set { SetData(ResumeTable.C_Interesting, value); }
        }

        #endregion
    }
}
