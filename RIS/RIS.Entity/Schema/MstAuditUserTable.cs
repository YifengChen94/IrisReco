using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace RIS.Entity.Schema
{
    [Serializable]
    public partial class MstAuditUserTable : TableInfo
    {
        public const string C_TableName = "MST_Audit_User";

        public const string C_AuditUserId = "AuditUserId";

        public const string C_UserCode = "UserCode";

        public const string C_UserName = "UserName";

        public const string C_CompanyId = "CompanyId";

        public const string C_DepartmentName = "DepartmentName";

        public const string C_Title = "Title";

        public const string C_Gender = "Gender";

        public const string C_Birthday = "Birthday";

        public const string C_Education = "Education";

        public const string C_PhoneNumber = "PhoneNumber";

        public const string C_PhotoImage = "PhotoImage";

        public const string C_UserStatus = "UserStatus";

        public const string C_LastModifiedTime = "LastModifiedTime";

        public const string C_LastModifiedBy = "LastModifiedBy";


        public MstAuditUserTable()
        {
            _tableName = "MST_Audit_User";
        }

        protected static MstAuditUserTable _current;
        public static MstAuditUserTable Current
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
            _current = new MstAuditUserTable();

            _current.Add(C_AuditUserId, new ColumnInfo(C_AuditUserId, "Audituserid", true, typeof(string)));

            _current.Add(C_UserCode, new ColumnInfo(C_UserCode, "Usercode", false, typeof(string)));

            _current.Add(C_UserName, new ColumnInfo(C_UserName, "Username", false, typeof(string)));

            _current.Add(C_CompanyId, new ColumnInfo(C_CompanyId, "Companyid", false, typeof(string)));

            _current.Add(C_DepartmentName, new ColumnInfo(C_DepartmentName, "Departmentname", false, typeof(string)));

            _current.Add(C_Title, new ColumnInfo(C_Title, "Title", false, typeof(string)));

            _current.Add(C_Gender, new ColumnInfo(C_Gender, "Gender", false, typeof(int)));

            _current.Add(C_Birthday, new ColumnInfo(C_Birthday, "Birthday", false, typeof(string)));

            _current.Add(C_Education, new ColumnInfo(C_Education, "Education", false, typeof(int)));

            _current.Add(C_PhoneNumber, new ColumnInfo(C_PhoneNumber, "Phonenumber", false, typeof(string)));

            _current.Add(C_PhotoImage, new ColumnInfo(C_PhotoImage, "Photoimage", false, typeof(string)));

            _current.Add(C_UserStatus, new ColumnInfo(C_UserStatus, "Userstatus", false, typeof(int)));

            _current.Add(C_LastModifiedTime, new ColumnInfo(C_LastModifiedTime, "Lastmodifiedtime", false, typeof(DateTime)));

            _current.Add(C_LastModifiedBy, new ColumnInfo(C_LastModifiedBy, "Lastmodifiedby", false, typeof(string)));

        }


        public ColumnInfo AuditUserId
        {
            get { return this[C_AuditUserId]; }
        }

        public ColumnInfo UserCode
        {
            get { return this[C_UserCode]; }
        }

        public ColumnInfo UserName
        {
            get { return this[C_UserName]; }
        }

        public ColumnInfo CompanyId
        {
            get { return this[C_CompanyId]; }
        }

        public ColumnInfo DepartmentName
        {
            get { return this[C_DepartmentName]; }
        }

        public ColumnInfo Title
        {
            get { return this[C_Title]; }
        }

        public ColumnInfo Gender
        {
            get { return this[C_Gender]; }
        }

        public ColumnInfo Birthday
        {
            get { return this[C_Birthday]; }
        }

        public ColumnInfo Education
        {
            get { return this[C_Education]; }
        }

        public ColumnInfo PhoneNumber
        {
            get { return this[C_PhoneNumber]; }
        }

        public ColumnInfo PhotoImage
        {
            get { return this[C_PhotoImage]; }
        }

        public ColumnInfo UserStatus
        {
            get { return this[C_UserStatus]; }
        }

        public ColumnInfo LastModifiedTime
        {
            get { return this[C_LastModifiedTime]; }
        }

        public ColumnInfo LastModifiedBy
        {
            get { return this[C_LastModifiedBy]; }
        }

    }
}
