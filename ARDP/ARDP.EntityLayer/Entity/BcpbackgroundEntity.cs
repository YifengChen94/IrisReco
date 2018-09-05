using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore; 

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcpbackgroundEntity : EntityBase
    {
        public BcpbackgroundTable TableSchema
        {
            get
            {
                return (BcpbackgroundTable)_tableSchema;
            }
        }


        public BcpbackgroundEntity()
        {
            _tableSchema = BcpbackgroundTable.Current;
        }

        #region 属性列表

        public string Bcpbackgroundid
        {
            get { return (string)GetData(BcpbackgroundTable.C_BCPBackgroundID); }
            set { SetData(BcpbackgroundTable.C_BCPBackgroundID, value); }
        }

        public string Backgroundname
        {
            get { return (string)GetData(BcpbackgroundTable.C_BackgroundName); }
            set { SetData(BcpbackgroundTable.C_BackgroundName, value); }
        }

        public string Background
        {
            get { return (string)GetData(BcpbackgroundTable.C_Background); }
            set { SetData(BcpbackgroundTable.C_Background, value); }
        }

        #endregion
    }
}
