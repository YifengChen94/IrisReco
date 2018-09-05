using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using Suzsoft.Smart.EntityCore;

namespace Suzsoft.Smart.Data
{
    public delegate void DbExceptionHandler(DataAccessBroker sender, Exception ex);

    /// <summary>
    /// 数据访问Broker基类
    /// </summary>
    public abstract class DataAccessBroker : IDisposable
    {
        protected DataAccessBroker()
        {
        }

        #region attributes&commom method
        private bool _disposed = false;//资源释放标志
        bool _inTransaction;//是否启用事务

        protected DbConnection _connection;
        /// <summary>
        /// 数据库连接
        /// </summary>
        public DbConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        protected DbTransaction _transaction;
        /// <summary>
        /// 数据库事务
        /// </summary>
        protected DbTransaction Transaction
        {
            get
            {
                return _transaction;
            }
        }

        IConnectConfiguration _configuration;
        /// <summary>
        /// 数据访问配置
        /// </summary>
        public IConnectConfiguration Configuration
        {
            get
            {
                return _configuration;
            }
            set
            {
                _configuration = value;
            }
        }

        public static event DbExceptionHandler DBException;
        /// <summary>
        /// 发生数据库异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ex"></param>
        public void OnDBException(DataAccessBroker sender, Exception ex)
        {
            if (DBException != null)
            {
                DBException(sender, ex);
            }
        }
        #endregion

        #region Abstract Method
        /// <summary>
        /// 由子类创建相应的DBConnection并打开
        /// </summary>
        internal abstract void Create();

        /// <summary>
        /// 子类对应数据库的参数前缀
        /// </summary>
        protected abstract string ParameterPrefix
        {
            get;
        }

        /// <summary>
        /// 由子类创建Command
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        protected abstract DbCommand CreateCommand(string commandString);

        /// <summary>
        /// 由子类创建Parameter
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameter"></param>
        protected abstract void AddParameter(DbCommand command, DataAccessParameter parameter);

        /// <summary>
        /// 由子类利用相应Adapter执行command并传回Dataset
        /// </summary>
        /// <param name="command"></param>
        /// <param name="mapping"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public abstract int ExecuteDataSet(DbCommand command, DataTableMapping mapping, ref DataSet result);
        #endregion

        #region NonQuery
        public int ExecuteNonQuery(string executeString, DataAccessParameterCollection parameters, CommandType cmdType)
        {
            DbCommand command = CreateCommand(executeString);
            command.CommandType = cmdType;
            PrepareCommand(command, parameters);
            int iReturn = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return iReturn;
        }

        public int ExecuteNonQuery(WhereBuilder wb)
        {
            return ExecuteNonQuery(wb.SQLString, wb.Parameters, CommandType.Text);
        }

        /// <summary>
        /// 执行存储过程-无参数
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        public int ExecuteCommand(string commandString)
        {
            return ExecuteCommand(commandString, null);
        }

        /// <summary>
        /// 执行存储过程-有参数
        /// </summary>
        /// <param name="commandString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteCommand(string commandString, DataAccessParameterCollection parameters)
        {
            return ExecuteNonQuery(commandString, parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行SQL语句-无参数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public int ExecuteSQL(string sqlString)
        {
            return ExecuteSQL(sqlString, null);
        }

        /// <summary>
        /// 执行SQL语句-有参数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteSQL(string sqlString, DataAccessParameterCollection parameters)
        {
            return ExecuteNonQuery(sqlString, parameters, CommandType.Text);
        }
        #endregion

        #region Scalar
        /// <summary>
        /// 执行存储过程并返回执行结果-无参数
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        public object ExecuteCommandScalar(string commandString)
        {
            return ExecuteScalar(commandString, null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行存储过程并返回执行结果-有参数
        /// </summary>
        /// <param name="commandString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteCommandScalar(string commandString, DataAccessParameterCollection parameters)
        {
            return ExecuteScalar(commandString, parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行SQL语句并返回执行结果-无参数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public object ExecuteSQLScalar(string sqlString)
        {
            return ExecuteScalar(sqlString, null, CommandType.Text);
        }

        /// <summary>
        /// 执行SQL语句并返回执行结果-有参数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteSQLScalar(string sqlString, DataAccessParameterCollection parameters)
        {
            return ExecuteScalar(sqlString, parameters, CommandType.Text);
        }

        /// <summary>
        /// 执行executeString
        /// </summary>
        /// <param name="executeString"></param>
        /// <param name="parameters"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public object ExecuteScalar(string executeString, DataAccessParameterCollection parameters, CommandType cmdType)
        {
            DbCommand command = CreateCommand(executeString);
            command.CommandType = cmdType;
            PrepareCommand(command, parameters);
            object val = command.ExecuteScalar();
            command.Parameters.Clear();
            return val;
        }

        public object ExecuteScalar(WhereBuilder wb)
        {
            return ExecuteScalar(wb.SQLString, wb.Parameters, CommandType.Text);
        }
        #endregion

        #region Reader
        /// <summary>
        /// 执行存储过程并返回DataReader-无参数
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        public IDataReader ExecuteCommandReader(string commandString)
        {
            return ExecuteReader(commandString, null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行存储过程并返回DataReader-有参数
        /// </summary>
        /// <param name="commandString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IDataReader ExecuteCommandReader(string commandString, DataAccessParameterCollection parameters)
        {
            return ExecuteReader(commandString, parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行SQl语句并返回DataReader-无参数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public IDataReader ExecuteSQLReader(string sqlString)
        {
            return ExecuteReader(sqlString, null, CommandType.Text);
        }

        /// <summary>
        /// 执行SQl语句并返回DataReader-有参数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IDataReader ExecuteSQLReader(string sqlString, DataAccessParameterCollection parameters)
        {
            return ExecuteReader(sqlString, parameters, CommandType.Text);
        }

        /// <summary>
        /// 执行queryString语句并返回DataReader
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="parameters"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string queryString, DataAccessParameterCollection parameters, CommandType cmdType)
        {
            DbCommand command = CreateCommand(queryString);
            command.CommandType = cmdType;
            PrepareCommand(command, parameters);
            DbDataReader rdr = command.ExecuteReader();
            command.Parameters.Clear();
            return (IDataReader)rdr;
        }

        public IDataReader ExecuteReader(WhereBuilder wb)
        {
            return ExecuteReader(wb.SQLString, wb.Parameters, CommandType.Text);
        }
        #endregion

        #region Dataset
        
        /// <summary>
        /// 执行存储过程并返回DataReader-无参数
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="parameters"></param>
        /// <param name="cmdType"></param>
        /// <param name="mapping"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public int ExecuteDataSet(string queryString, DataAccessParameterCollection parameters, CommandType cmdType, DataTableMapping mapping, ref DataSet result)
        {
            DbCommand command = CreateCommand(queryString);
            command.CommandType = cmdType;
            PrepareCommand(command, parameters);
            return ExecuteDataSet(command, mapping, ref result);
        }

        /// <summary>
        /// 执行存储过程并返回Dataset-无参数
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        public DataSet FillCommandDataSet(string commandString)
        {
            DataSet result = new DataSet();
            ExecuteDataSet(commandString, null, CommandType.StoredProcedure, null, ref result);
            return result;
        }

        /// <summary>
        /// 执行存储过程并返回Dataset-有参数
        /// </summary>
        /// <param name="commandString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataSet FillCommandDataSet(string commandString, DataAccessParameterCollection parameters)
        {
            DataSet result = new DataSet();
            ExecuteDataSet(commandString, parameters, CommandType.StoredProcedure, null, ref result);
            return result;
        }

        /// <summary>
        /// 执行SQL语句并返回Dataset-无参数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public DataSet FillSQLDataSet(string sqlString)
        {
            DataSet result = new DataSet();
            ExecuteDataSet(sqlString, null, CommandType.Text, null, ref result);
            return result;
        }

        /// <summary>
        /// 执行SQL语句并返回Dataset-有参数
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataSet FillSQLDataSet(string sqlString, DataAccessParameterCollection parameters)
        {
            DataSet result = new DataSet();
            ExecuteDataSet(sqlString, parameters, CommandType.Text, null, ref result);
            return result;
        }

        public DataSet FillSQLDataSet(WhereBuilder wb)
        {
            return FillSQLDataSet(wb.SQLString, wb.Parameters);
        }
        #endregion

        #region function
        /// <summary>
        /// 关闭连接-已判断连接是否为空
        /// </summary>
        public virtual void Close()
        {
            if (null != _connection)
            {
                _connection.Close();
            }
        }

        /// <summary>
        /// 打开连接-已判断连接是否为空
        /// </summary>
        public virtual void Open()
        {
            if (null != _connection)
            {
                _connection.Open();
            }
        }

        /// <summary>
        /// 开始事务-已判断连接状态
        /// </summary>
        public virtual void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.Unspecified);
        }

        /// <summary>
        /// 开始事务-已判断连接状态
        /// </summary>
        /// <param name="isolationLevel"></param>
        public virtual void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (_connection != null && _connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            _inTransaction = true;
            _transaction = _connection.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// 提交事务-已判断事务是否为空
        /// </summary>
        public virtual void Commit()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
            _inTransaction = false;
        }

        /// <summary>
        /// 回滚事务-已判断事务是否为空
        /// </summary>
        public virtual void RollBack()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
            _inTransaction = false;
        }

        /// <summary>
        /// 准备Command及相应参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        protected virtual void PrepareCommand(DbCommand command, DataAccessParameterCollection parameters)
        {
            if (null != parameters && parameters.Count > 0)
            {
                ResolveParameters(command, parameters);
            }
            if (_inTransaction)//如果使用事务则该command应该使用事务
            {
                command.Transaction = _transaction;
            }
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameters"></param>
        protected virtual void ResolveParameters(DbCommand command, DataAccessParameterCollection parameters)
        {
            foreach (DataAccessParameter parameter in parameters.Values)
            {
                AddParameter(command, parameter);
            }
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// 析构
        /// </summary>
        ~DataAccessBroker()
        {
            Dispose(false);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposeManageResourse)
        {
            if (!_disposed)
            {
                if (disposeManageResourse)
                {
                    //释放托管资源
                }
                Close();
                _disposed = true;
            }
        }

        #endregion
    }
}
