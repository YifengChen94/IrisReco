using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using C2Olay.TransactionOlayEx.Schema;

namespace C2Olay.TransactionOlayEx.Entity
{
    [Serializable]
    public partial class MstAuditUserEntity : EntityBase
    {
        public MstAuditUserTable TableSchema
        {
            get
            {
                return MstAuditUserTable.Current;
            }
        }


        public MstAuditUserEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return MstAuditUserTable.Current;
            }
        }
        #region 属性列表

        public string Audituserid
        {
            get { return (string)GetData(MstAuditUserTable.C_AuditUserId); }
            set { SetData(MstAuditUserTable.C_AuditUserId, value); }
        }

        public string Usercode
        {
            get { return (string)GetData(MstAuditUserTable.C_UserCode); }
            set { SetData(MstAuditUserTable.C_UserCode, value); }
        }

        public string Username
        {
            get { return (string)GetData(MstAuditUserTable.C_UserName); }
            set { SetData(MstAuditUserTable.C_UserName, value); }
        }

        public string Companyid
        {
            get { return (string)GetData(MstAuditUserTable.C_CompanyId); }
            set { SetData(MstAuditUserTable.C_CompanyId, value); }
        }

        public string Departmentname
        {
            get { return (string)GetData(MstAuditUserTable.C_DepartmentName); }
            set { SetData(MstAuditUserTable.C_DepartmentName, value); }
        }

        public string Title
        {
            get { return (string)GetData(MstAuditUserTable.C_Title); }
            set { SetData(MstAuditUserTable.C_Title, value); }
        }

        public int Gender
        {
            get { return (int)(GetData(MstAuditUserTable.C_Gender)); }
            set { SetData(MstAuditUserTable.C_Gender, value); }
        }

        public string Birthday
        {
            get { return (string)GetData(MstAuditUserTable.C_Birthday); }
            set { SetData(MstAuditUserTable.C_Birthday, value); }
        }

        public int Education
        {
            get { return (int)(GetData(MstAuditUserTable.C_Education)); }
            set { SetData(MstAuditUserTable.C_Education, value); }
        }

        public string Phonenumber
        {
            get { return (string)GetData(MstAuditUserTable.C_PhoneNumber); }
            set { SetData(MstAuditUserTable.C_PhoneNumber, value); }
        }

        public string Photoimage
        {
            get { return (string)GetData(MstAuditUserTable.C_PhotoImage); }
            set { SetData(MstAuditUserTable.C_PhotoImage, value); }
        }

        public int Userstatus
        {
            get { return (int)(GetData(MstAuditUserTable.C_UserStatus)); }
            set { SetData(MstAuditUserTable.C_UserStatus, value); }
        }

        public DateTime Lastmodifiedtime
        {
            get { return (DateTime)(GetData(MstAuditUserTable.C_LastModifiedTime) == null ? DateTime.MinValue : GetData(MstAuditUserTable.C_LastModifiedTime)); }
            set { SetData(MstAuditUserTable.C_LastModifiedTime, value); }
        }

        public string Lastmodifiedby
        {
            get { return (string)GetData(MstAuditUserTable.C_LastModifiedBy); }
            set { SetData(MstAuditUserTable.C_LastModifiedBy, value); }
        }

        #endregion
    }
}
