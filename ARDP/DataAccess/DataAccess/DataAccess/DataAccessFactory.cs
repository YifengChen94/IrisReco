using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// 数据访问工厂//TODO:连接池
    /// </summary>
    public partial class DataAccessFactory
    {
        /// <summary>
        /// 获取默认数据访问
        /// </summary>
        /// <returns></returns>
        public static DataAccessBroker Instance()
        {
            return Instance("");
        }

        /// <summary>
        /// 根据名称获取数据访问
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns></returns>
        public static DataAccessBroker Instance(string instanceName)
        {
            return Instance(GetConfig(instanceName.Trim()));
        }

        protected static DataAccessConfiguration GetConfig(string instanceName)
        {
            return DataAccessConfigurationMangement.GetDataAccessConfiguration(instanceName.Trim());
        }
    }
}
