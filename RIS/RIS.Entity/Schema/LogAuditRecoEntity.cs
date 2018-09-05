using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using C2Olay.TransactionOlayEx.Schema;

namespace C2Olay.TransactionOlayEx.Entity
{
    [Serializable]
    public partial class LogAuditRecoEntity : EntityBase
    {
        public LogAuditRecoTable TableSchema
        {
            get
            {
                return LogAuditRecoTable.Current;
            }
        }


        public LogAuditRecoEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return LogAuditRecoTable.Current;
            }
        }
        #region 属性列表

        public string Logid
        {
            get { return (string)GetData(LogAuditRecoTable.C_LogId); }
            set { SetData(LogAuditRecoTable.C_LogId, value); }
        }

        public string Recodate
        {
            get { return (string)GetData(LogAuditRecoTable.C_RecoDate); }
            set { SetData(LogAuditRecoTable.C_RecoDate, value); }
        }

        public string Recotime
        {
            get { return (string)GetData(LogAuditRecoTable.C_RecoTime); }
            set { SetData(LogAuditRecoTable.C_RecoTime, value); }
        }

        public string Hardwarecode
        {
            get { return (string)GetData(LogAuditRecoTable.C_HardwareCode); }
            set { SetData(LogAuditRecoTable.C_HardwareCode, value); }
        }

        public int Recoresult
        {
            get { return (int)(GetData(LogAuditRecoTable.C_RecoResult)); }
            set { SetData(LogAuditRecoTable.C_RecoResult, value); }
        }

        public string Audituserid
        {
            get { return (string)GetData(LogAuditRecoTable.C_AuditUserId); }
            set { SetData(LogAuditRecoTable.C_AuditUserId, value); }
        }

        #endregion
    }
}
