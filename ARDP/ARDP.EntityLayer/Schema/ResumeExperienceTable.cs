using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ResumeExperienceTable : TableInfo
    {
        public const string C_TableName = "Resume_Experience";

        public const string C_ID = "ID";

        public const string C_Compony_Name = "Compony_Name";

        public const string C_Position = "Position";

        public const string C_Salary = "Salary";

        public const string C_Time = "Time";

        public const string C_Leave_Reason = "Leave_Reason";

        public const string C_Resume_ID = "Resume_ID";


        public ResumeExperienceTable()
        {
            _tableName = "Resume_Experience";
        }

        protected static ResumeExperienceTable _current;
        public static ResumeExperienceTable Current
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
            _current = new ResumeExperienceTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(string)));

            _current.Add(C_Compony_Name, new ColumnInfo(C_Compony_Name, "ComponyName", false, typeof(string)));

            _current.Add(C_Position, new ColumnInfo(C_Position, "Position", false, typeof(string)));

            _current.Add(C_Salary, new ColumnInfo(C_Salary, "Salary", false, typeof(string)));

            _current.Add(C_Time, new ColumnInfo(C_Time, "Time", false, typeof(string)));

            _current.Add(C_Leave_Reason, new ColumnInfo(C_Leave_Reason, "LeaveReason", false, typeof(string)));

            _current.Add(C_Resume_ID, new ColumnInfo(C_Resume_ID, "ResumeId", false, typeof(string)));

        }


        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo Compony_Name
        {
            get { return this[C_Compony_Name]; }
        }

        public ColumnInfo Position
        {
            get { return this[C_Position]; }
        }

        public ColumnInfo Salary
        {
            get { return this[C_Salary]; }
        }

        public ColumnInfo Time
        {
            get { return this[C_Time]; }
        }

        public ColumnInfo Leave_Reason
        {
            get { return this[C_Leave_Reason]; }
        }

        public ColumnInfo Resume_ID
        {
            get { return this[C_Resume_ID]; }
        }

    }
}
