using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskhelpselltoolsEntity : EntityBase
    {
        public BcptaskhelpselltoolsTable TableSchema
        {
            get
            {
                return (BcptaskhelpselltoolsTable)_tableSchema;
            }
        }


        public BcptaskhelpselltoolsEntity()
        {
            _tableSchema = BcptaskhelpselltoolsTable.Current;
        }

        #region 属性列表

        public string Bcptaskhelpselltoolsid
        {
            get { return (string)GetData(BcptaskhelpselltoolsTable.C_BCPTaskHelpSellToolsID); }
            set { SetData(BcptaskhelpselltoolsTable.C_BCPTaskHelpSellToolsID, value); }
        }

        public string Bcptaskid
        {
            get { return (string)GetData(BcptaskhelpselltoolsTable.C_BCPTaskID); }
            set { SetData(BcptaskhelpselltoolsTable.C_BCPTaskID, value); }
        }

        public string Helpselltoolid
        {
            get { return (string)GetData(BcptaskhelpselltoolsTable.C_HelpSellToolID); }
            set { SetData(BcptaskhelpselltoolsTable.C_HelpSellToolID, value); }
        }

        public int Smallpositonx
        {
            get { return (int)(GetData(BcptaskhelpselltoolsTable.C_SmallPositonX)); }
            set { SetData(BcptaskhelpselltoolsTable.C_SmallPositonX, value); }
        }

        public int Smallpositony
        {
            get { return (int)(GetData(BcptaskhelpselltoolsTable.C_SmallPositonY)); }
            set { SetData(BcptaskhelpselltoolsTable.C_SmallPositonY, value); }
        }

        public int Bigpositonx
        {
            get { return (int)(GetData(BcptaskhelpselltoolsTable.C_BigPositonX)); }
            set { SetData(BcptaskhelpselltoolsTable.C_BigPositonX, value); }
        }

        public int Bigpositony
        {
            get { return (int)(GetData(BcptaskhelpselltoolsTable.C_BigPositonY)); }
            set { SetData(BcptaskhelpselltoolsTable.C_BigPositonY, value); }
        }

        public string Tipscode
        {
            get { return (string)GetData(BcptaskhelpselltoolsTable.C_TipsCode); }
            set { SetData(BcptaskhelpselltoolsTable.C_TipsCode, value); }
        }
        #endregion
    }
}
