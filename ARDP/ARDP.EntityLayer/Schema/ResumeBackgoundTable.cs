using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ResumeBackgoundTable : TableInfo
    {
        public const string C_TableName = "Resume_Backgound";

        public const string C_ID = "ID";

        public const string C_School_Name = "School_Name";

        public const string C_Major = "Major";

        public const string C_Graduate_Date = "Graduate_Date";

        public const string C_Degree = "Degree";

        public const string C_Resume_ID = "Resume_ID";


        public ResumeBackgoundTable()
        {
            _tableName = "Resume_Backgound";
        }

        protected static ResumeBackgoundTable _current;
        public static ResumeBackgoundTable Current
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
            _current = new ResumeBackgoundTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(string)));

            _current.Add(C_School_Name, new ColumnInfo(C_School_Name, "SchoolName", false, typeof(string)));

            _current.Add(C_Major, new ColumnInfo(C_Major, "Major", false, typeof(string)));

            _current.Add(C_Graduate_Date, new ColumnInfo(C_Graduate_Date, "GraduateDate", false, typeof(string)));

            _current.Add(C_Degree, new ColumnInfo(C_Degree, "Degree", false, typeof(string)));

            _current.Add(C_Resume_ID, new ColumnInfo(C_Resume_ID, "ResumeId", false, typeof(string)));

        }


        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo School_Name
        {
            get { return this[C_School_Name]; }
        }

        public ColumnInfo Major
        {
            get { return this[C_Major]; }
        }

        public ColumnInfo Graduate_Date
        {
            get { return this[C_Graduate_Date]; }
        }

        public ColumnInfo Degree
        {
            get { return this[C_Degree]; }
        }

        public ColumnInfo Resume_ID
        {
            get { return this[C_Resume_ID]; }
        }

    }
}
