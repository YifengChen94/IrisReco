using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskbossEntity : EntityBase
    {
        public BcptaskbossTable TableSchema
        {
            get
            {
                return (BcptaskbossTable)_tableSchema;
            }
        }


        public BcptaskbossEntity()
        {
            _tableSchema = BcptaskbossTable.Current;
        }

        #region 属性列表

        public string Bcptaskbossid
        {
            get { return (string)GetData(BcptaskbossTable.C_BCPTaskBossID); }
            set { SetData(BcptaskbossTable.C_BCPTaskBossID, value); }
        }

        public string Bcptaskid
        {
            get { return (string)GetData(BcptaskbossTable.C_BCPTaskID); }
            set { SetData(BcptaskbossTable.C_BCPTaskID, value); }
        }

        public string Bossid
        {
            get { return (string)GetData(BcptaskbossTable.C_BossID); }
            set { SetData(BcptaskbossTable.C_BossID, value); }
        }

        public int X
        {
            get { return (int)(GetData(BcptaskbossTable.C_X)); }
            set { SetData(BcptaskbossTable.C_X, value); }
        }

        public int Y
        {
            get { return (int)(GetData(BcptaskbossTable.C_Y)); }
            set { SetData(BcptaskbossTable.C_Y, value); }
        }

        #endregion
    }
}
