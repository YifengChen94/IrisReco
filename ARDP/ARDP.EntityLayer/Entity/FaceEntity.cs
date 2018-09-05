using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class FaceEntity : EntityBase
    {
        public FaceTable TableSchema
        {
            get
            {
                return (FaceTable)_tableSchema;
            }
        }


        public FaceEntity()
        {
            _tableSchema = FaceTable.Current;
        }

        #region 属性列表

        public string Faceid
        {
            get { return (string)GetData(FaceTable.C_FaceID); }
            set { SetData(FaceTable.C_FaceID, value); }
        }

        public string Bigimage
        {
            get { return (string)GetData(FaceTable.C_BigImage); }
            set { SetData(FaceTable.C_BigImage, value); }
        }

        public string Smallimage
        {
            get { return (string)GetData(FaceTable.C_SmallImage); }
            set { SetData(FaceTable.C_SmallImage, value); }
        }

        #endregion
    }
}
