using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using RIS.Entity.Schema;

namespace RIS.Entity.Entity
{
    [Serializable]
    public partial class IrisRecoResultEntity : EntityBase
    {
        public IrisRecoResultTable TableSchema
        {
            get
            {
                return IrisRecoResultTable.Current;
            }
        }


        public IrisRecoResultEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return IrisRecoResultTable.Current;
            }
        }
        #region 属性列表

        public string Imageid
        {
            get { return (string)GetData(IrisRecoResultTable.C_ImageId); }
            set { SetData(IrisRecoResultTable.C_ImageId, value); }
        }

        public int Recoresult
        {
            get { return (int)(GetData(IrisRecoResultTable.C_RecoResult)); }
            set { SetData(IrisRecoResultTable.C_RecoResult, value); }
        }

        public string Audituserid
        {
            get { return (string)GetData(IrisRecoResultTable.C_AuditUserId); }
            set { SetData(IrisRecoResultTable.C_AuditUserId, value); }
        }

        public string Recoirisid
        {
            get { return (string)GetData(IrisRecoResultTable.C_RecoIrisId); }
            set { SetData(IrisRecoResultTable.C_RecoIrisId, value); }
        }

        public string Recotime
        {
            get { return (string)GetData(IrisRecoResultTable.C_RecoTime); }
            set { SetData(IrisRecoResultTable.C_RecoTime, value); }
        }

        #endregion
    }
}
