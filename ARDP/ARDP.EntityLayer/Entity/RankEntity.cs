using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class RankEntity : EntityBase
    {
        public RankTable TableSchema
        {
            get
            {
                return (RankTable)_tableSchema;
            }
        }


        public RankEntity()
        {
            _tableSchema = RankTable.Current;
        }

        #region 属性列表

        public string Rankid
        {
            get { return (string)GetData(RankTable.C_RankID); }
            set { SetData(RankTable.C_RankID, value); }
        }

        public int Ranktype
        {
            get { return int.Parse(GetData(RankTable.C_RankType).ToString()); }
            set { SetData(RankTable.C_RankType, value); }
        }

        public int Ordernum
        {
            get { return int.Parse(GetData(RankTable.C_OrderNum).ToString()); }
            set { SetData(RankTable.C_OrderNum, value); }
        }

        public string Content
        {
            get { return (string)GetData(RankTable.C_Content); }
            set { SetData(RankTable.C_Content, value); }
        }
        #endregion
    }
}
