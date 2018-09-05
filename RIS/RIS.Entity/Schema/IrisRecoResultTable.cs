using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace RIS.Entity.Schema
{
    [Serializable]
    public partial class IrisRecoResultTable : TableInfo
    {
        public const string C_TableName = "Iris_Reco_Result";

        public const string C_ImageId = "ImageId";

        public const string C_RecoResult = "RecoResult";

        public const string C_AuditUserId = "AuditUserId";

        public const string C_RecoIrisId = "RecoIrisId";

        public const string C_RecoTime = "RecoTime";


        public IrisRecoResultTable()
        {
            _tableName = "Iris_Reco_Result";
        }

        protected static IrisRecoResultTable _current;
        public static IrisRecoResultTable Current
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
            _current = new IrisRecoResultTable();

            _current.Add(C_ImageId, new ColumnInfo(C_ImageId, "Imageid", true, typeof(string)));

            _current.Add(C_RecoResult, new ColumnInfo(C_RecoResult, "Recoresult", false, typeof(int)));

            _current.Add(C_AuditUserId, new ColumnInfo(C_AuditUserId, "Audituserid", false, typeof(string)));

            _current.Add(C_RecoIrisId, new ColumnInfo(C_RecoIrisId, "Recoirisid", false, typeof(string)));

            _current.Add(C_RecoTime, new ColumnInfo(C_RecoTime, "Recotime", false, typeof(string)));

        }


        public ColumnInfo ImageId
        {
            get { return this[C_ImageId]; }
        }

        public ColumnInfo RecoResult
        {
            get { return this[C_RecoResult]; }
        }

        public ColumnInfo AuditUserId
        {
            get { return this[C_AuditUserId]; }
        }

        public ColumnInfo RecoIrisId
        {
            get { return this[C_RecoIrisId]; }
        }

        public ColumnInfo RecoTime
        {
            get { return this[C_RecoTime]; }
        }

    }
}
