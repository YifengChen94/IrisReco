using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BossEntity : EntityBase
    {
        public BossTable TableSchema
        {
            get
            {
                return (BossTable)_tableSchema;
            }
        }


        public BossEntity()
        {
            _tableSchema = BossTable.Current;
        }

        #region 属性列表

        public string Bossid
        {
            get { return (string)GetData(BossTable.C_BossID); }
            set { SetData(BossTable.C_BossID, value); }
        }

        public string Bossimage
        {
            get { return (string)GetData(BossTable.C_BossImage); }
            set { SetData(BossTable.C_BossImage, value); }
        }

        public string Bosseye
        {
            get { return (string)GetData(BossTable.C_BossEye); }
            set { SetData(BossTable.C_BossEye, value); }
        }

        public int Bosseyex
        {
            get { return (int)(GetData(BossTable.C_BossEyeX)); }
            set { SetData(BossTable.C_BossEyeX, value); }
        }

        public int Bosseyey
        {
            get { return (int)(GetData(BossTable.C_BossEyeY)); }
            set { SetData(BossTable.C_BossEyeY, value); }
        }

        public string Bossmouth
        {
            get { return (string)GetData(BossTable.C_BossMouth); }
            set { SetData(BossTable.C_BossMouth, value); }
        }

        public int Bossmouthx
        {
            get { return (int)(GetData(BossTable.C_BossMouthX)); }
            set { SetData(BossTable.C_BossMouthX, value); }
        }

        public int Bossmouthy
        {
            get { return (int)(GetData(BossTable.C_BossMouthY)); }
            set { SetData(BossTable.C_BossMouthY, value); }
        }

        #endregion
    }
}
