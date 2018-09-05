using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ResumeExperienceEntity : EntityBase
    {
        public ResumeExperienceTable TableSchema
        {
            get
            {
                return (ResumeExperienceTable)_tableSchema;
            }
        }


        public ResumeExperienceEntity()
        {
            _tableSchema = ResumeExperienceTable.Current;
        }

        #region 属性列表

        public string Id
        {
            get { return (string)GetData(ResumeExperienceTable.C_ID); }
            set { SetData(ResumeExperienceTable.C_ID, value); }
        }

        public string ComponyName
        {
            get { return (string)GetData(ResumeExperienceTable.C_Compony_Name); }
            set { SetData(ResumeExperienceTable.C_Compony_Name, value); }
        }

        public string Position
        {
            get { return (string)GetData(ResumeExperienceTable.C_Position); }
            set { SetData(ResumeExperienceTable.C_Position, value); }
        }

        public string Salary
        {
            get { return (string)GetData(ResumeExperienceTable.C_Salary); }
            set { SetData(ResumeExperienceTable.C_Salary, value); }
        }

        public string Time
        {
            get { return (string)GetData(ResumeExperienceTable.C_Time); }
            set { SetData(ResumeExperienceTable.C_Time, value); }
        }

        public string LeaveReason
        {
            get { return (string)GetData(ResumeExperienceTable.C_Leave_Reason); }
            set { SetData(ResumeExperienceTable.C_Leave_Reason, value); }
        }

        public string ResumeId
        {
            get { return (string)GetData(ResumeExperienceTable.C_Resume_ID); }
            set { SetData(ResumeExperienceTable.C_Resume_ID, value); }
        }

        #endregion
    }
}
