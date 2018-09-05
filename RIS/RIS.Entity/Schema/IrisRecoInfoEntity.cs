using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using C2Olay.TransactionOlayEx.Schema;

namespace C2Olay.TransactionOlayEx.Entity
{
    [Serializable]
    public partial class IrisRecoInfoEntity : EntityBase
    {
        public IrisRecoInfoTable TableSchema
        {
            get
            {
                return IrisRecoInfoTable.Current;
            }
        }


        public IrisRecoInfoEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return IrisRecoInfoTable.Current;
            }
        }
        #region 属性列表

        public string Imageid
        {
            get { return (string)GetData(IrisRecoInfoTable.C_ImageId); }
            set { SetData(IrisRecoInfoTable.C_ImageId, value); }
        }

        public int Recoresult
        {
            get { return (int)(GetData(IrisRecoInfoTable.C_RecoResult)); }
            set { SetData(IrisRecoInfoTable.C_RecoResult, value); }
        }

        public string Audituserid
        {
            get { return (string)GetData(IrisRecoInfoTable.C_AuditUserId); }
            set { SetData(IrisRecoInfoTable.C_AuditUserId, value); }
        }

        public string Recoirisid
        {
            get { return (string)GetData(IrisRecoInfoTable.C_RecoIrisId); }
            set { SetData(IrisRecoInfoTable.C_RecoIrisId, value); }
        }

        public string Recotime
        {
            get { return (string)GetData(IrisRecoInfoTable.C_RecoTime); }
            set { SetData(IrisRecoInfoTable.C_RecoTime, value); }
        }

        #endregion
    }
}
