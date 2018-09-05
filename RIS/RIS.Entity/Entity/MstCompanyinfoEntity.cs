using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using RIS.Entity.Schema;

namespace RIS.Entity.Entity
{
    [Serializable]
    public partial class MstCompanyinfoEntity : EntityBase
    {
        public MstCompanyinfoTable TableSchema
        {
            get
            {
                return MstCompanyinfoTable.Current;
            }
        }


        public MstCompanyinfoEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return MstCompanyinfoTable.Current;
            }
        }
        #region 属性列表

        public string Companyid
        {
            get { return (string)GetData(MstCompanyinfoTable.C_CompanyId); }
            set { SetData(MstCompanyinfoTable.C_CompanyId, value); }
        }

        public string Companyname
        {
            get { return (string)GetData(MstCompanyinfoTable.C_CompanyName); }
            set { SetData(MstCompanyinfoTable.C_CompanyName, value); }
        }

        public string Address
        {
            get { return (string)GetData(MstCompanyinfoTable.C_Address); }
            set { SetData(MstCompanyinfoTable.C_Address, value); }
        }

        public string Tel
        {
            get { return (string)GetData(MstCompanyinfoTable.C_Tel); }
            set { SetData(MstCompanyinfoTable.C_Tel, value); }
        }

        public DateTime Lastmodifiedtime
        {
            get { return (DateTime)(GetData(MstCompanyinfoTable.C_LastModifiedTime) == null ? DateTime.MinValue : GetData(MstCompanyinfoTable.C_LastModifiedTime)); }
            set { SetData(MstCompanyinfoTable.C_LastModifiedTime, value); }
        }

        public string Lastmodifiedby
        {
            get { return (string)GetData(MstCompanyinfoTable.C_LastModifiedBy); }
            set { SetData(MstCompanyinfoTable.C_LastModifiedBy, value); }
        }

        #endregion
    }
}
