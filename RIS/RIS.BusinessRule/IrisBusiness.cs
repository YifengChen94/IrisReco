using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using RIS.Common;
using System.Drawing.Imaging;
using Suzsoft.Smart.Data;
using System.Data;
using RIS.Entity.Entity;

namespace RIS.BusinessRule
{
    public class IrisBusiness
    {
        public static bool CanGenrateFile()
        {
            string sql = "select count(*) from Iris_Reco_Image";
            using (DataAccessBroker broker = DataAccessFactory.Instance())
            {
                int count = Convert.ToInt32(broker.ExecuteScalar(sql, null, CommandType.Text));
            
                return count < 5;
            }
        }
        public static List<IrisRecoImageEntity> GetAllRecoImage()
        {
            return DataAccess.SelectAll<IrisRecoImageEntity>();
        }
        public static void InsertImageRecoInfo(Bitmap bitmap)
        {
            string imageid = Guid.NewGuid().ToString();
            string imageName = Guid.NewGuid().ToString();
            bitmap.Save(ConstAndEnum.WaitingPath + imageName+".jpg", ImageFormat.Jpeg);
            //Todo
            IrisRecoImageEntity entity = new IrisRecoImageEntity();
            entity.Imageid = imageid;
            entity.Imagepath = ConstAndEnum.WaitingPath + imageName + ".jpg";
            entity.Createtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataAccess.Insert(entity);
        }

        public static void DeleteAllIrisRecoResult()
        {
            using (DataAccessBroker broker = DataAccessFactory.Instance())
            {
                broker.ExecuteSQL("delete from Iris_Reco_Result");
            }
        }

        public static List<IrisRecoResultEntity> ReadAllResult()
        {
            return DataAccess.SelectAll<IrisRecoResultEntity>();
        }

        public static void DeleteIrisImage(IrisRecoImageEntity entity)
        {
            DataAccess.Delete(entity);
        }
    }
}
