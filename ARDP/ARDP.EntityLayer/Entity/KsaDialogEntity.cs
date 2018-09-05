using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class KsaDialogEntity : EntityBase
    {
        public KsaDialogTable TableSchema
        {
            get
            {
                return (KsaDialogTable)_tableSchema;
            }
        }


        public KsaDialogEntity()
        {
            _tableSchema = KsaDialogTable.Current;
        }

        #region 属性列表

        public string Id
        {
            get { return (string)GetData(KsaDialogTable.C_ID); }
            set { SetData(KsaDialogTable.C_ID, value); }
        }

        public int KIndex
        {
            get { return (int)(GetData(KsaDialogTable.C_K_Index)); }
            set { SetData(KsaDialogTable.C_K_Index, value); }
        }

        public string Dialog
        {
            get { return (string)GetData(KsaDialogTable.C_Dialog); }
            set { SetData(KsaDialogTable.C_Dialog, value); }
        }

        public int Side
        {
            get { return (int)(GetData(KsaDialogTable.C_Side)); }
            set { SetData(KsaDialogTable.C_Side, value); }
        }

        public string KSAID
        {
            get { return (string)(GetData(KsaDialogTable.C_KSA_ID)); }
            set { SetData(KsaDialogTable.C_KSA_ID, value); }
        }

        #endregion
    }
}
