using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.EntityCore
{
    /// <summary>
    /// 数据访问参数 
    /// </summary>
    public class DataAccessParameter
    {
        private string _parameterName;
        /// <summary>
        /// 参数名
        /// </summary>
        public string ParameterName
        {
            get
            {
                return _parameterName;
            }
            set
            {
                this._parameterName = value;
            }
        }

        private object _parameterValue;
        /// <summary>
        /// 参数值
        /// </summary>
        public object ParameterValue
        {
            get
            {
                return _parameterValue;
            }
            set
            {
                _parameterValue = value;
            }
        }

        private System.Data.DbType _dbType;
        /// <summary>
        /// 参数类型
        /// </summary>
        public System.Data.DbType DbType
        {
            get
            {
                return _dbType;
            }
            set
            {
                _dbType = value;
            }
        }

        private System.Data.ParameterDirection _direction;
        /// <summary>
        /// 参数方向
        /// </summary>
        public System.Data.ParameterDirection Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
            }
        }

        public DataAccessParameter(string parameterName, object parameterValue)
        {
            InitData(parameterName, parameterValue, System.Data.ParameterDirection.Input);
        }

        public DataAccessParameter(string parameterName, object parameterValue, System.Data.ParameterDirection direction)
        {
            InitData(parameterName, parameterValue, direction);
        }

        private void InitData(string parameterName, object parameterValue, System.Data.ParameterDirection direction)
        {
            this.ParameterName = parameterName;
            this.ParameterValue = parameterValue ?? DBNull.Value;
            this.Direction = direction;
            //this.DbType = System.Data.DbType.String;
            //TODO: DBType
        }
    }
}
