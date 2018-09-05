using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace RIS.Entity.Schema
{
    [Serializable]
    public partial class LogAuditRecoTable : TableInfo
    {
        public const string C_TableName = "Log_Audit_Reco";

        public const string C_LogId = "LogId";

        public const string C_RecoDate = "RecoDate";

        public const string C_RecoTime = "RecoTime";

        public const string C_HardwareCode = "HardwareCode";

        public const string C_RecoResult = "RecoResult";

        public const string C_AuditUserId = "AuditUserId";


        public LogAuditRecoTable()
        {
            _tableName = "Log_Audit_Reco";
        }

        protected static LogAuditRecoTable _current;
        public static LogAuditRecoTable Current
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
            _current = new LogAuditRecoTable();

            _current.Add(C_LogId, new ColumnInfo(C_LogId, "Logid", true, typeof(string)));

            _current.Add(C_RecoDate, new ColumnInfo(C_RecoDate, "Recodate", false, typeof(string)));

            _current.Add(C_RecoTime, new ColumnInfo(C_RecoTime, "Recotime", false, typeof(string)));

            _current.Add(C_HardwareCode, new ColumnInfo(C_HardwareCode, "Hardwarecode", false, typeof(string)));

            _current.Add(C_RecoResult, new ColumnInfo(C_RecoResult, "Recoresult", false, typeof(int)));

            _current.Add(C_AuditUserId, new ColumnInfo(C_AuditUserId, "Audituserid", false, typeof(string)));

        }


        public ColumnInfo LogId
        {
            get { return this[C_LogId]; }
        }

        public ColumnInfo RecoDate
        {
            get { return this[C_RecoDate]; }
        }

        public ColumnInfo RecoTime
        {
            get { return this[C_RecoTime]; }
        }

        public ColumnInfo HardwareCode
        {
            get { return this[C_HardwareCode]; }
        }

        public ColumnInfo RecoResult
        {
            get { return this[C_RecoResult]; }
        }

        public ColumnInfo AuditUserId
        {
            get { return this[C_AuditUserId]; }
        }

    }
}
