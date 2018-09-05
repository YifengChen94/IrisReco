using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace Suzsoft.Smart.Data
{
    public class SQLOperator
    {
        public const string Equal = "=";
        public const string NotEquals = "<>";
        public const string Greater = ">";
        public const string GreaterEquals = ">=";
        public const string Less = "<";
        public const string LessEquals = "<=";
        public const string Like = "LIKE";
    }

    public class LogicalOperator
    {
        public const string AND = "AND";
        public const string OR = "OR";
        public const string NOT = "NOT";
    }

    /// <summary>
    /// 拼SQL条件用类
    /// </summary>
    public class WhereBuilder
    {

        #region var
        private string _sqlString;
        private string _whereString;

        /// <summary>
        /// 判断Where条件是否以与或非开头
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private bool FixFirstCondtion(string whereString)
        {
            bool result = whereString.IndexOf(LogicalOperator.AND + " ", 0, 4) == 0;
            result = result || whereString.IndexOf(LogicalOperator.NOT + " ", 0, 4) == 0;
            result = result || whereString.IndexOf(LogicalOperator.OR + " ", 0, 3) == 0;
            return result;
        }

        /// <summary>
        /// SQL语句
        /// </summary>
        public string SQLString
        {
            get
            {
                string whereString = _whereString.Trim();

                if (FixFirstCondtion(whereString) && whereString.Length > 3)
                {
                    int first = whereString.IndexOf(" ");
                    whereString = whereString.Substring(first, whereString.Length - first);
                }
                if (whereString.Trim().Length > 0)
                    return _sqlString + " WHERE " + whereString;
                else
                    return _sqlString;                              
            }
        }

        private DataAccessParameterCollection _parameters;
        /// <summary>
        /// 参数列表
        /// </summary>
        public DataAccessParameterCollection Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        /// <summary>
        /// SQL
        /// </summary>
        /// <param name="sqlString"></param>
        public WhereBuilder(string sqlString)
        {
            _whereString = "";
            _sqlString = sqlString;
            _parameters = new DataAccessParameterCollection();
        }
        #endregion 

        #region constructor
        /// <summary>
        /// SQL 与 参数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="parameters"></param>
        public WhereBuilder(string sqlString, DataAccessParameterCollection parameters):this(sqlString)
        {
            _parameters = parameters;
        }

        /// <summary>
        /// SelectAll
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static WhereBuilder SelectAll(string tableName)
        {
            return new WhereBuilder("SELECT * FROM " + tableName);
        }

        /// <summary>
        /// 根据实体生成关系为AND的条件
        /// </summary>
        /// <param name="entity"></param>
        public WhereBuilder(EntityBase entity)
        {
            _sqlString = "SELECT * FROM " + entity.OringTableSchema.TableName;
            _whereString = "";
            _parameters = new DataAccessParameterCollection();
            AddAndCondition(entity);
        }

        /// <summary>
        /// 根据实体产生与条件
        /// </summary>
        /// <param name="entity"></param>
        public void AddAndCondition(EntityBase entity)
        {
            foreach (string key in entity.Keys)
            {
                if (entity[key] != null)
                {
                    //if (entity[key] is string && ((string)entity[key]).Length == 0)//若Hash里为string且值为空则不能构成条件
                    //{
                    //    continue;
                    //}
                    AddAndCondition(key, entity[key]);
                }
            }
        }
        #endregion

        #region base function
        public void AddCondition(string condition)
        {
            _whereString += " " + condition;
        }

        public void AddCondition(string logicalOperator, string left, string preParameter, string parameterName, string sqlOperator, object parameterValue, string right)
        {
            string parameter = PrepareParameter(parameterName);
            if (preParameter.Length > 0)
            {
                parameterName = preParameter + "." + parameterName;
            }
            _whereString += " " + logicalOperator + " " + left + " " + parameterName + " " + sqlOperator + " " + parameter + " " + right;
            if (sqlOperator.ToUpper() == SQLOperator.Like)
            {
                parameterValue = "%" + parameterValue.ToString() + "%";
            }
            _parameters.AddWithValue(parameter, parameterValue);
        }

        private string PrepareParameter(string parameterName)
        {
            string parameter = DataAccess.ParameterPrefix + parameterName;
            if (_parameters.ContainsKey(parameter))
            {
                parameter += Guid.NewGuid().ToString().Substring(0, 4);
            }
            if (_parameters.ContainsKey(parameter))
            {
                parameter += Guid.NewGuid().ToString().Substring(0, 4);
            }
            return parameter;
        }

        public void AddCondition(string logicalOperator, string left, string preParameter, ColumnInfo parameter, string sqlOperator, object parameterValue, string right)
        {
            AddCondition(logicalOperator, left, preParameter, parameter.ColumnName, sqlOperator, parameterValue, right);
        }

        #endregion

        #region and
        public void AddAndCondition(string left, string preParameter, string parameterName, string sqlOperator, object parameterValue, string right)
        {
            AddCondition(LogicalOperator.AND, left, preParameter, parameterName, sqlOperator, parameterValue, right);
        }

        public void AddAndCondition(string preParameter, string parameterName, string sqlOperator, object parameterValue)
        {
            AddAndCondition("", preParameter, parameterName, sqlOperator, parameterValue, "");
        }

        public void AddAndCondition(string parameterName, string sqlOperator, object parameterValue)
        {
            AddAndCondition("", "", parameterName, sqlOperator, parameterValue, "");
        }

        public void AddAndCondition(string parameterName, object parameterValue)
        {
            AddAndCondition("", "", parameterName, "=", parameterValue, "");
        }

        public void AddAndCondition(string left, string preParameter, ColumnInfo parameter, string sqlOperator, object parameterValue, string right)
        {
            AddCondition(LogicalOperator.AND, left, preParameter, parameter, sqlOperator, parameterValue, right);
        }

        public void AddAndCondition(ColumnInfo parameter, string sqlOperator, object parameterValue)
        {
            AddAndCondition("", "", parameter, sqlOperator, parameterValue, "");
        }

        public void AddAndCondition(ColumnInfo parameter, object parameterValue)
        {
            AddAndCondition("", "", parameter, "=", parameterValue, "");
        }
        #endregion 

        #region OR
        public void AddORCondition(string left, string preParameter, string parameterName, string sqlOperator, object parameterValue, string right)
        {
            AddCondition(LogicalOperator.OR, left, preParameter, parameterName, sqlOperator, parameterValue, right);
        }

        public void AddORCondition(string parameterName, string sqlOperator, object parameterValue)
        {
            AddORCondition("", "", parameterName, sqlOperator, parameterValue, "");
        }

        public void AddORCondition(string parameterName, object parameterValue)
        {
            AddORCondition("", "", parameterName, "=", parameterValue, "");
        }

        public void AddORCondition(string left, string preParameter, ColumnInfo parameter, string sqlOperator, object parameterValue, string right)
        {
            AddCondition(LogicalOperator.OR, left, preParameter, parameter, sqlOperator, parameterValue, right);
        }

        public void AddORCondition(ColumnInfo parameter, string sqlOperator, object parameterValue)
        {
            AddORCondition("", "", parameter, sqlOperator, parameterValue, "");
        }

        public void AddORCondition(ColumnInfo parameter, object parameterValue)
        {
            AddORCondition("", "", parameter, "=", parameterValue, "");
        }
        #endregion

        #region NOT
        public void AddNOTCondition(string left, string preParameter, string parameterName, string sqlOperator, object parameterValue, string right)
        {
            AddCondition(LogicalOperator.NOT, left, preParameter, parameterName, sqlOperator, parameterValue, right);
        }

        public void AddNOTCondition(string parameterName, string sqlOperator, object parameterValue)
        {
            AddNOTCondition("", "", parameterName, sqlOperator, parameterValue, "");
        }

        public void AddNOTCondition(string parameterName, object parameterValue)
        {
            AddNOTCondition("", "", parameterName, "=", parameterValue, "");
        }

        public void AddNOTCondition(string left, string preParameter, ColumnInfo parameter, string sqlOperator, object parameterValue, string right)
        {
            AddCondition(LogicalOperator.NOT, left, preParameter, parameter, sqlOperator, parameterValue, right);
        }

        public void AddNOTCondition(ColumnInfo parameter, string sqlOperator, object parameterValue)
        {
            AddNOTCondition("", "", parameter, sqlOperator, parameterValue, "");
        }

        public void AddNOTCondition(ColumnInfo parameter, object parameterValue)
        {
            AddNOTCondition("", "", parameter, "=", parameterValue, "");
        }
        #endregion
    }
}
