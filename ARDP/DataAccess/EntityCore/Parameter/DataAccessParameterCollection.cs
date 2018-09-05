using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.EntityCore
{
    /// <summary>
    /// SQL参数集合
    /// </summary>
    public class DataAccessParameterCollection : Dictionary<string, DataAccessParameter>
    {
        public DataAccessParameterCollection()
        {
        }

        /// <summary>
        /// 添加SQL参数列表-输入参数
        /// </summary>
        /// <param name="ParamName"></param>
        /// <param name="ParamValue"></param>
        public virtual void AddWithValue(string parameterName, object parameterValue)
        {
            AddWithValue(parameterName, parameterValue, System.Data.ParameterDirection.Input);
        }


        /// <summary>
        /// 添加SQL参数列表
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="parameterValue"></param>
        /// <param name="direction"></param>
        public virtual void AddWithValue(string parameterName, object parameterValue, System.Data.ParameterDirection direction)
        {
            DataAccessParameter parameter = new DataAccessParameter(parameterName, parameterValue, direction);
            this[parameterName] = parameter;
            if (parameterValue is int)
            {
                parameter.DbType = System.Data.DbType.Int32;
            }
        }
    }
}
