using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class HelpselltoolEntity : EntityBase
    {
        public HelpselltoolTable TableSchema
        {
            get
            {
                return (HelpselltoolTable)_tableSchema;
            }
        }


        public HelpselltoolEntity()
        {
            _tableSchema = HelpselltoolTable.Current;
        }

        #region 属性列表

        public string Helpselltoolid
        {
            get { return (string)GetData(HelpselltoolTable.C_HelpSellToolID); }
            set { SetData(HelpselltoolTable.C_HelpSellToolID, value); }
        }

        public string Toolname
        {
            get { return (string)GetData(HelpselltoolTable.C_ToolName); }
            set { SetData(HelpselltoolTable.C_ToolName, value); }
        }

        public string Smallpic
        {
            get { return (string)GetData(HelpselltoolTable.C_SmallPic); }
            set { SetData(HelpselltoolTable.C_SmallPic, value); }
        }

        public string Bigpic
        {
            get { return (string)GetData(HelpselltoolTable.C_BigPic); }
            set { SetData(HelpselltoolTable.C_BigPic, value); }
        }

        #endregion
    }
}
