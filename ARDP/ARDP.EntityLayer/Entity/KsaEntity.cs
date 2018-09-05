using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class KsaEntity : EntityBase
    {
        public KsaTable TableSchema
        {
            get
            {
                return (KsaTable)_tableSchema;
            }
        }


        public KsaEntity()
        {
            _tableSchema = KsaTable.Current;
        }

        #region 属性列表

        public string Id
        {
            get { return (string)GetData(KsaTable.C_ID); }
            set { SetData(KsaTable.C_ID, value); }
        }

        public int KScore
        {
            get { return (int)(GetData(KsaTable.C_K_Score)); }
            set { SetData(KsaTable.C_K_Score, value); }
        }

        public int SScore
        {
            get { return (int)(GetData(KsaTable.C_S_Score)); }
            set { SetData(KsaTable.C_S_Score, value); }
        }

        public int AScore
        {
            get { return (int)(GetData(KsaTable.C_A_Score)); }
            set { SetData(KsaTable.C_A_Score, value); }
        }

        public int Face
        {
            get { return (int)(GetData(KsaTable.C_Face)); }
            set { SetData(KsaTable.C_Face, value); }
        }

        public int DamFace
        {
            get { return (int)(GetData(KsaTable.C_DAM_Face)); }
            set { SetData(KsaTable.C_DAM_Face, value); }
        }

        #endregion
    }
}
