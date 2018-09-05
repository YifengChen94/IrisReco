using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskshelfEntity : EntityBase
    {
        public BcptaskshelfTable TableSchema
        {
            get
            {
                return (BcptaskshelfTable)_tableSchema;
            }
        }


        public BcptaskshelfEntity()
        {
            _tableSchema = BcptaskshelfTable.Current;
        }

        #region 属性列表

        public string Bcptaskshelfid
        {
            get { return (string)GetData(BcptaskshelfTable.C_BCPTaskShelfID); }
            set { SetData(BcptaskshelfTable.C_BCPTaskShelfID, value); }
        }

        public string Bcptaskid
        {
            get { return (string)GetData(BcptaskshelfTable.C_BCPTaskID); }
            set { SetData(BcptaskshelfTable.C_BCPTaskID, value); }
        }

        public string Shelfid
        {
            get { return (string)GetData(BcptaskshelfTable.C_ShelfID); }
            set { SetData(BcptaskshelfTable.C_ShelfID, value); }
        }

        public int X
        {
            get { return (int)(GetData(BcptaskshelfTable.C_X)); }
            set { SetData(BcptaskshelfTable.C_X, value); }
        }

        public int Y
        {
            get { return (int)(GetData(BcptaskshelfTable.C_Y)); }
            set { SetData(BcptaskshelfTable.C_Y, value); }
        } 
        public int Rate
        {
            get { return (int)(GetData(BcptaskshelfTable.C_Rate)); }
            set { SetData(BcptaskshelfTable.C_Rate, value); }
        }
        #endregion
    }
}
