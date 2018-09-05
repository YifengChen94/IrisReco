using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ResumeTable : TableInfo
    {
        public const string C_TableName = "Resume";

        public const string C_ID = "ID";

        public const string C_Name = "Name";

        public const string C_Birthday = "Birthday";

        public const string C_Married = "Married";

        public const string C_IDNo = "IDNo";

        public const string C_PhoneNo = "PhoneNo";

        public const string C_Email = "Email";

        public const string C_Address = "Address";

        public const string C_Post_Code = "Post_Code";

        public const string C_Prize = "Prize";

        public const string C_Other_Activity = "Other_Activity";

        public const string C_Interesting = "Interesting";

        public const string C_Sex = "Sex";

        public ResumeTable()
        {
            _tableName = "Resume";
        }

        protected static ResumeTable _current;


        public static ResumeTable Current
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
            _current = new ResumeTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(string)));

            _current.Add(C_Name, new ColumnInfo(C_Name, "Name", false, typeof(string)));

            _current.Add(C_Name, new ColumnInfo(C_Sex, "Sex", false, typeof(string)));

            _current.Add(C_Birthday, new ColumnInfo(C_Birthday, "Birthday", false, typeof(string)));

            _current.Add(C_Married, new ColumnInfo(C_Married, "Married", false, typeof(string)));

            _current.Add(C_IDNo, new ColumnInfo(C_IDNo, "Idno", false, typeof(string)));

            _current.Add(C_PhoneNo, new ColumnInfo(C_PhoneNo, "Phoneno", false, typeof(string)));

            _current.Add(C_Email, new ColumnInfo(C_Email, "Email", false, typeof(string)));

            _current.Add(C_Address, new ColumnInfo(C_Address, "Address", false, typeof(string)));

            _current.Add(C_Post_Code, new ColumnInfo(C_Post_Code, "PostCode", false, typeof(string)));

            _current.Add(C_Prize, new ColumnInfo(C_Prize, "Prize", false, typeof(string)));

            _current.Add(C_Other_Activity, new ColumnInfo(C_Other_Activity, "OtherActivity", false, typeof(string)));

            _current.Add(C_Interesting, new ColumnInfo(C_Interesting, "Interesting", false, typeof(string)));

        }


        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo Name
        {
            get { return this[C_Name]; }
        }

        public ColumnInfo Sex
        {
            get { return this[C_Sex]; }
        }

        public ColumnInfo Birthday
        {
            get { return this[C_Birthday]; }
        }

        public ColumnInfo Married
        {
            get { return this[C_Married]; }
        }

        public ColumnInfo IDNo
        {
            get { return this[C_IDNo]; }
        }

        public ColumnInfo PhoneNo
        {
            get { return this[C_PhoneNo]; }
        }

        public ColumnInfo Email
        {
            get { return this[C_Email]; }
        }

        public ColumnInfo Address
        {
            get { return this[C_Address]; }
        }

        public ColumnInfo Post_Code
        {
            get { return this[C_Post_Code]; }
        }

        public ColumnInfo Prize
        {
            get { return this[C_Prize]; }
        }

        public ColumnInfo Other_Activity
        {
            get { return this[C_Other_Activity]; }
        }

        public ColumnInfo Interesting
        {
            get { return this[C_Interesting]; }
        }

    }
}
