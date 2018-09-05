using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// 数据库连接配置
    /// </summary>
    public class DataAccessConfiguration
    {
        #region var
        private Dictionary<string, string> _parameters;
        /// <summary>
        /// 参数集合
        /// </summary>
        public Dictionary<string, string> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        private string _configName;
        /// <summary>
        /// 配置项名称
        /// </summary>
		public string ConfigName
		{
			get
			{
                return _configName;
			}
			set
			{
                _configName = value;
			}
		}

        private string _dBType;
        /// <summary>
        /// 数据库类型
        /// </summary>
		public string DBType
		{
			get
			{
                return _dBType;
			}
			set
			{
                _dBType = value;
			}
		}

        #endregion

        public DataAccessConfiguration()
		{
            _parameters = new Dictionary<string, string>();
		}
    }
}
