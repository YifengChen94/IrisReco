using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class ShelfsortEntity : EntityBase
    {
        public ShelfsortTable TableSchema
        {
            get
            {
                return (ShelfsortTable)_tableSchema;
            }
        }


        public ShelfsortEntity()
        {
            _tableSchema = ShelfsortTable.Current;
        }

        #region 属性列表

        public string Shelfsortid
        {
            get { return (string)GetData(ShelfsortTable.C_ShelfSortID); }
            set { SetData(ShelfsortTable.C_ShelfSortID, value); }
        }

        public string Shelfid
        {
            get { return (string)GetData(ShelfsortTable.C_ShelfID); }
            set { SetData(ShelfsortTable.C_ShelfID, value); }
        }

        public string Wrongpic
        {
            get { return (string)GetData(ShelfsortTable.C_WrongPic); }
            set { SetData(ShelfsortTable.C_WrongPic, value); }
        }

        public int X
        {
            get { return (int)(GetData(ShelfsortTable.C_X)); }
            set { SetData(ShelfsortTable.C_X, value); }
        }

        public int Y
        {
            get { return (int)(GetData(ShelfsortTable.C_Y)); }
            set { SetData(ShelfsortTable.C_Y, value); }
        }

        #endregion
    }
}
