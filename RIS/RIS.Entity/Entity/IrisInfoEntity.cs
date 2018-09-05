using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using RIS.Entity.Schema;

namespace RIS.Entity.Entity
{
    [Serializable]
    public partial class IrisInfoEntity : EntityBase
    {
        public IrisInfoTable TableSchema
        {
            get
            {
                return IrisInfoTable.Current;
            }
        }


        public IrisInfoEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return IrisInfoTable.Current;
            }
        }
        #region 属性列表

        public string Irisid
        {
            get { return (string)GetData(IrisInfoTable.C_IrisId); }
            set { SetData(IrisInfoTable.C_IrisId, value); }
        }

        public int Leftright
        {
            get { return (int)(GetData(IrisInfoTable.C_LeftRight)); }
            set { SetData(IrisInfoTable.C_LeftRight, value); }
        }

        public string Audituserid
        {
            get { return (string)GetData(IrisInfoTable.C_AuditUserId); }
            set { SetData(IrisInfoTable.C_AuditUserId, value); }
        }

        public string Irisvector
        {
            get { return (string)GetData(IrisInfoTable.C_IrisVector); }
            set { SetData(IrisInfoTable.C_IrisVector, value); }
        }

        public DateTime Lastmodifiedtime
        {
            get { return (DateTime)(GetData(IrisInfoTable.C_LastModifiedTime) == null ? DateTime.MinValue : GetData(IrisInfoTable.C_LastModifiedTime)); }
            set { SetData(IrisInfoTable.C_LastModifiedTime, value); }
        }

        public string Lastmodifiedby
        {
            get { return (string)GetData(IrisInfoTable.C_LastModifiedBy); }
            set { SetData(IrisInfoTable.C_LastModifiedBy, value); }
        }

        #endregion
    }
}
