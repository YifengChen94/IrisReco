using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace RIS.Entity.Schema
{
    [Serializable]
    public partial class IrisRecoImageTable : TableInfo
    {
        public const string C_TableName = "Iris_Reco_Image";

        public const string C_ImageId = "ImageId";

        public const string C_CreateTime = "CreateTime";

        public const string C_ImagePath = "ImagePath";


        public IrisRecoImageTable()
        {
            _tableName = "Iris_Reco_Image";
        }

        protected static IrisRecoImageTable _current;
        public static IrisRecoImageTable Current
        {
            get
            {
                if (_current == null)
                {
                    Initial();
                }
                return _current;
            }
        }

        private static void Initial()
        {
            _current = new IrisRecoImageTable();

            _current.Add(C_ImageId, new ColumnInfo(C_ImageId, "Imageid", true, typeof(string)));

            _current.Add(C_CreateTime, new ColumnInfo(C_CreateTime, "Createtime", false, typeof(string)));

            _current.Add(C_ImagePath, new ColumnInfo(C_ImagePath, "Imagepath", false, typeof(string)));

        }


        public ColumnInfo ImageId
        {
            get { return this[C_ImageId]; }
        }

        public ColumnInfo CreateTime
        {
            get { return this[C_CreateTime]; }
        }

        public ColumnInfo ImagePath
        {
            get { return this[C_ImagePath]; }
        }

    }
}
