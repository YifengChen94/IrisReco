using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using C2Olay.TransactionOlayEx.Schema;

namespace C2Olay.TransactionOlayEx.Entity
{
    [Serializable]
    public partial class IrisRecoImageEntity : EntityBase
    {
        public IrisRecoImageTable TableSchema
        {
            get
            {
                return IrisRecoImageTable.Current;
            }
        }


        public IrisRecoImageEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return IrisRecoImageTable.Current;
            }
        }
        #region 属性列表

        public string Imageid
        {
            get { return (string)GetData(IrisRecoImageTable.C_ImageId); }
            set { SetData(IrisRecoImageTable.C_ImageId, value); }
        }

        public string Createtime
        {
            get { return (string)GetData(IrisRecoImageTable.C_CreateTime); }
            set { SetData(IrisRecoImageTable.C_CreateTime, value); }
        }

        public string Imagepath
        {
            get { return (string)GetData(IrisRecoImageTable.C_ImagePath); }
            set { SetData(IrisRecoImageTable.C_ImagePath, value); }
        }

        #endregion
    }
}
