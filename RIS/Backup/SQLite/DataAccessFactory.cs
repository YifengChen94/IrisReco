using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// 数据访问工厂
    /// </summary>
    public partial class DataAccessFactory
    {
        /// <summary>
        /// 根据配置获取数据访问
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static DataAccessBroker Instance(DataAccessConfiguration config)
        {
            DataAccessBroker _broker = new SQLiteDataAccessBroker();
            _broker.Configuration = new SQLiteConnectConfiguration(config);
            _broker.Create();//创建并打开数据库连接
            return _broker;
        }

        public static IConnectConfiguration Config
        {
            get
            {
                return new SQLiteConnectConfiguration(GetConfig(""));
            }
        }

        public static string AssemblyPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory+@"\";
            }
        }
    }
}
