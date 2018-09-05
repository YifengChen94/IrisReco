using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIS.Entity.Entity;
using RIS.Common;
using Suzsoft.Smart.Data;

namespace RIS.BusinessRule
{
    public class DeviceBusiness
    {
        public static string WriteDeviceInfo()
        {
            try
            {
                AppDeviceInfoEntity entity = new AppDeviceInfoEntity();
                entity.Hardwarecode = ComputerUtility.DeviceID;
                entity = DataAccess.SelectSingle<AppDeviceInfoEntity>(entity);
                if (entity == null)
                {
                    DataAccess.DeleteAll<AppDeviceInfoEntity>();
                    entity = new AppDeviceInfoEntity();
                    entity.Hardwarecode = ComputerUtility.DeviceID;
                    entity.Lastmodifiedtime = DateTime.Now;
                    entity.Devicestatus = 1;
                    entity.Deviceid = Guid.NewGuid().ToString();
                    entity.Lastmodifiedby = "1";
                    entity.Location = "门口";
                    DataAccess.Insert(entity);
                }
                else
                {
                    DataAccess.Update(entity);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }




        public static AppDeviceInfoEntity GetDeviceInfo()
        {
            return DataAccess.SelectSingle<AppDeviceInfoEntity>(new AppDeviceInfoEntity());
        }
    }
}
