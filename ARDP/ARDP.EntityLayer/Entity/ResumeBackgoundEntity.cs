using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ResumeBackgoundEntity : EntityBase
    {
        public ResumeBackgoundTable TableSchema
        {
            get
            {
                return (ResumeBackgoundTable)_tableSchema;
            }
        }


        public ResumeBackgoundEntity()
        {
            _tableSchema = ResumeBackgoundTable.Current;
        }

        #region 属性列表

        public string Id
        {
            get { return (string)GetData(ResumeBackgoundTable.C_ID); }
            set { SetData(ResumeBackgoundTable.C_ID, value); }
        }

        public string SchoolName
        {
            get { return (string)GetData(ResumeBackgoundTable.C_School_Name); }
            set { SetData(ResumeBackgoundTable.C_School_Name, value); }
        }

        public string Major
        {
            get { return (string)GetData(ResumeBackgoundTable.C_Major); }
            set { SetData(ResumeBackgoundTable.C_Major, value); }
        }

        public string GraduateDate
        {
            get { return (string)GetData(ResumeBackgoundTable.C_Graduate_Date); }
            set { SetData(ResumeBackgoundTable.C_Graduate_Date, value); }
        }

        public string Degree
        {
            get { return (string)GetData(ResumeBackgoundTable.C_Degree); }
            set { SetData(ResumeBackgoundTable.C_Degree, value); }
        }

        public string ResumeId
        {
            get { return (string)GetData(ResumeBackgoundTable.C_Resume_ID); }
            set { SetData(ResumeBackgoundTable.C_Resume_ID, value); }
        }

        #endregion
    }
}
