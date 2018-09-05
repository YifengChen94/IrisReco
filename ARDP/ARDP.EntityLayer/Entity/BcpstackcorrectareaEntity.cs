using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcpstackcorrectareaEntity : EntityBase
    {
        public BcpstackcorrectareaTable TableSchema
        {
            get
            {
                return (BcpstackcorrectareaTable)_tableSchema;
            }
        }


        public BcpstackcorrectareaEntity()
        {
            _tableSchema = BcpstackcorrectareaTable.Current;
        }

        #region 属性列表

        public string Bcpstackcorrectareaid
        {
            get { return (string)GetData(BcpstackcorrectareaTable.C_BCPStackCorrectAreaID); }
            set { SetData(BcpstackcorrectareaTable.C_BCPStackCorrectAreaID, value); }
        }

        public string Bcptaskstackid
        {
            get { return (string)GetData(BcpstackcorrectareaTable.C_BCPTaskStackID); }
            set { SetData(BcpstackcorrectareaTable.C_BCPTaskStackID, value); }
        }

        public int X
        {
            get { return (int)(GetData(BcpstackcorrectareaTable.C_X)); }
            set { SetData(BcpstackcorrectareaTable.C_X, value); }
        }

        public int Y
        {
            get { return (int)(GetData(BcpstackcorrectareaTable.C_Y)); }
            set { SetData(BcpstackcorrectareaTable.C_Y, value); }
        }

        public int Width
        {
            get { return (int)(GetData(BcpstackcorrectareaTable.C_Width)); }
            set { SetData(BcpstackcorrectareaTable.C_Width, value); }
        }

        public int Height
        {
            get { return (int)(GetData(BcpstackcorrectareaTable.C_Height)); }
            set { SetData(BcpstackcorrectareaTable.C_Height, value); }
        }

        #endregion
    }
}
