using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcphelpsellcorrectareaEntity : EntityBase
    {
        public BcphelpsellcorrectareaTable TableSchema
        {
            get
            {
                return (BcphelpsellcorrectareaTable)_tableSchema;
            }
        }


        public BcphelpsellcorrectareaEntity()
        {
            _tableSchema = BcphelpsellcorrectareaTable.Current;
        }

        #region 属性列表

        public string Bcphelpsellcorrectareaid
        {
            get { return (string)GetData(BcphelpsellcorrectareaTable.C_BCPHelpSellCorrectAreaID); }
            set { SetData(BcphelpsellcorrectareaTable.C_BCPHelpSellCorrectAreaID, value); }
        }

        public string Bcptaskhelpselltoolsid
        {
            get { return (string)GetData(BcphelpsellcorrectareaTable.C_BCPTaskHelpSellToolsID); }
            set { SetData(BcphelpsellcorrectareaTable.C_BCPTaskHelpSellToolsID, value); }
        }

        public int X
        {
            get { return (int)(GetData(BcphelpsellcorrectareaTable.C_X)); }
            set { SetData(BcphelpsellcorrectareaTable.C_X, value); }
        }

        public int Y
        {
            get { return (int)(GetData(BcphelpsellcorrectareaTable.C_Y)); }
            set { SetData(BcphelpsellcorrectareaTable.C_Y, value); }
        }

        public int Width
        {
            get { return (int)(GetData(BcphelpsellcorrectareaTable.C_Width)); }
            set { SetData(BcphelpsellcorrectareaTable.C_Width, value); }
        }

        public int Height
        {
            get { return (int)(GetData(BcphelpsellcorrectareaTable.C_Height)); }
            set { SetData(BcphelpsellcorrectareaTable.C_Height, value); }
        }

        #endregion
    }
}
