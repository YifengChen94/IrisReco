using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class AccountEntity : EntityBase
    {
        public AccountTable TableSchema
        {
            get
            {
                return (AccountTable)_tableSchema;
            }
        }


        public AccountEntity()
        {
            _tableSchema = AccountTable.Current;
        }

        #region 属性列表

        public string Accountid
        {
            get { return (string)GetData(AccountTable.C_AccountID); }
            set { SetData(AccountTable.C_AccountID, value); }
        }

        public string Faceid
        {
            get { return (string)GetData(AccountTable.C_FaceID); }
            set { SetData(AccountTable.C_FaceID, value); }
        }

        public string Dmsid
        {
            get { return (string)GetData(AccountTable.C_DMSID); }
            set { SetData(AccountTable.C_DMSID, value); }
        }

        public string Accountname
        {
            get { return (string)GetData(AccountTable.C_AccountName); }
            set { SetData(AccountTable.C_AccountName, value); }
        }

        public string Accountpassword
        {
            get { return (string)GetData(AccountTable.C_AccountPassword); }
            set { SetData(AccountTable.C_AccountPassword, value); }
        }

        public int Status
        {
            get { return (int)(GetData(AccountTable.C_Status)); }
            set { SetData(AccountTable.C_Status, value); }
        }

        public string Currentrole
        {
            get { return (string)GetData(AccountTable.C_CurrentRole); }
            set { SetData(AccountTable.C_CurrentRole, value); }
        }

        public string Realrole
        {
            get { return (string)GetData(AccountTable.C_RealRole); }
            set { SetData(AccountTable.C_RealRole, value); }
        }

        public string Market
        {
            get { return (string)GetData(AccountTable.C_Market); }
            set { SetData(AccountTable.C_Market, value); }
        }
        #endregion
    }
}
