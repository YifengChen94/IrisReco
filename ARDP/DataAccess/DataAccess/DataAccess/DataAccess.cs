using System;
using System.Collections;
using System.Collections.Generic;
using Suzsoft.Smart.EntityCore;
using Suzsoft.Smart.Data;
using System.Data;

namespace Suzsoft.Smart.Data
{
    /// <summary>
    /// 数据访问
    /// </summary>
    public class DataAccess
    {
        public static string ParameterPrefix = ":";
		public static string InstanceName = "";
        #region select
        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static EntityCollection<T> SelectAll<T>()
            where T : EntityBase, new()
        {
            T schema = new T();
            string sqlString = "SELECT * FROM " + schema.OringTableSchema.TableName;
            return Select<T>(sqlString);
        }

        public static DataSet SelectAllDataSet<T>()
            where T : EntityBase, new()
        {
            T schema = new T();
            string sqlString = "SELECT * FROM " + schema.OringTableSchema.TableName;
            return SelectDataSet(sqlString);
        }

        /// <summary>
        /// 高性能查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static PerformanceEntityCollection<T> PerformanceSelectAll<T>()
            where T : EntityBase, new()
        {
            T schema = new T();
            string sqlString = "SELECT * FROM " + schema.OringTableSchema.TableName;
            return PerformanceSelect<T>(sqlString, null, CommandType.Text);
        }

        /// <summary>
        /// 根据SQL语句查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static EntityCollection<T> Select<T>(string sqlString)
            where T : EntityBase, new()
        {
            return Select<T>(sqlString, null, CommandType.Text);
        }

        public static DataSet SelectDataSet(string sqlString)
        {
            return Select(sqlString, null);
        }

        /// <summary>
        /// 根据SQL语句与参数集合查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static EntityCollection<T> Select<T>(string sqlString, DataAccessParameterCollection parameters)
            where T : EntityBase, new()
        {
            return Select<T>(sqlString, parameters, CommandType.Text);
        }


        /// <summary>
        /// 根据WhereBuilder查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wb"></param>
        /// <returns></returns>
        public static EntityCollection<T> Select<T>(WhereBuilder wb)
            where T : EntityBase, new()
        {
            return Select<T>(wb.SQLString, wb.Parameters);
        }

        public static DataSet SelectDataSet(WhereBuilder wb)
        {
            return Select(wb.SQLString, wb.Parameters);
        }

        /// <summary>
        /// 根据实体条件查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EntityCollection<T> Select<T>(T entity)
            where T : EntityBase, new()
        {
            WhereBuilder wb = new WhereBuilder(entity);
            return Select<T>(wb);
        }

        public static T SelectSingle<T>(T entity)
            where T : EntityBase, new()
        {
            T result = null;
            EntityCollection<T> list = Select<T>(entity);
            if (list != null && list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }

        public static T SelectSingle<T>(WhereBuilder wb)
            where T : EntityBase, new()
        {
            T result = null;
            EntityCollection<T> list = Select<T>(wb);
            if (list != null && list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }


        public static DataSet SelectDataSet(EntityBase entity)
        {
            WhereBuilder wb = new WhereBuilder(entity);
            return SelectDataSet(wb);
        }

        /// <summary>
        /// 根据存储过程查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandString"></param>
        /// <returns></returns>
        public static EntityCollection<T> SelectCommand<T>(string commandString)
            where T : EntityBase, new()
        {
            return Select<T>(commandString, null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 根据存储过程与参数集合查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static EntityCollection<T> SelectCommand<T>(string commandString, DataAccessParameterCollection parameters)
            where T : EntityBase, new()
        {
            return Select<T>(commandString, parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 获取数据通过Command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">SQL</param>
        /// <returns></returns>
        public static EntityCollection<T> Select<T>(string queryString, DataAccessParameterCollection parameters, CommandType cmdType)
            where T : EntityBase, new()
        {
            EntityCollection<T> result = new EntityCollection<T>();
            using (DataAccessBroker broker = DataAccessFactory.Instance(InstanceName))
            {
                IDataReader reader = broker.ExecuteReader(queryString, parameters, cmdType);

                int fieldCount = reader.FieldCount;
                List<string> columns = new List<string>();
                object[] values = new object[fieldCount];
                for (int i = 0; i < fieldCount; i++)
                {
                    columns.Add(reader.GetName(i));
                }

                while (reader.Read())
                {
                    T t = new T();
                    reader.GetValues(values);
                    for (int i = 0; i < fieldCount; i++)
                    {
                        if (!(values[i] == DBNull.Value))
                        {
                            t.SetData(columns[i], values[i]);
                        }
                    }
                    result.Add(t);
                }
            }
            return result;
        }

		public static List<T> SelectSingleValue<T>(string queryString)
		{
			List<T> result = new List<T>();
			using (DataAccessBroker broker = DataAccessFactory.Instance(InstanceName))
			{
				IDataReader reader = broker.ExecuteReader(queryString, new DataAccessParameterCollection(), CommandType.Text);

				while (reader.Read())
				{
					T tmp = (T)reader.GetValue(0);

					result.Add(tmp);
				}
			}
			return result;
		}
	
        public static DataSet Select(string queryString, DataAccessParameterCollection parameters)
        {
            DataSet ds = null;
            using (DataAccessBroker broker = DataAccessFactory.Instance(InstanceName))
            {
                ds = broker.FillSQLDataSet(queryString, parameters);
            }
            return ds;
        }

        public static PerformanceEntityCollection<T> PerformanceSelect<T>(string queryString, DataAccessParameterCollection parameters, CommandType cmdType)
            where T : EntityBase, new()
        {
            PerformanceEntityCollection<T> result = null;
            using (DataAccessBroker broker = DataAccessFactory.Instance(InstanceName))
            {
                IDataReader reader = broker.ExecuteReader(queryString, parameters, cmdType);

                int fieldCount = reader.FieldCount;
                List<string> columns = new List<string>();
                object[] values = new object[fieldCount];
                for (int i = 0; i < fieldCount; i++)
                {
                    columns.Add(reader.GetName(i));
                }
                result = new PerformanceEntityCollection<T>(columns);

                while (reader.Read())
                {
                    reader.GetValues(values);
                    result.Add(values);
                }
            }
            return result;
        }
        #endregion

        #region update
        /// <summary>
        /// 更新-独立事务
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Update(EntityBase entity)
        {
            bool result = true;
            try
            {
                using (DataAccessBroker broker = DataAccessFactory.Instance(InstanceName))
                {
                    Update(entity, broker);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 更新-事务支持
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="broker"></param>
        public static void Update(EntityBase entity, DataAccessBroker broker)
        {
            string sqlString = "UPDATE " + entity.OringTableSchema.TableName + " SET ";

            DataAccessParameterCollection dpc = new DataAccessParameterCollection();
            foreach (ColumnInfo field in entity.OringTableSchema.AllColumnInfo)
            {
                if (field.IsPrimaryKey)
                {
                    dpc.AddWithValue(field.ColumnName, entity.GetData(field.ColumnName));
                }
                else if (entity.GetData(field.ColumnName) != null)
                {
                    dpc.AddWithValue(field.ColumnName, entity.GetData(field.ColumnName));
                    sqlString += field.ColumnName + "=" + ParameterPrefix + field.ColumnName + ", ";
                }
            }
            sqlString = sqlString.Substring(0, sqlString.Length - 2);
            sqlString += " WHERE " + ParseSQL(entity.OringTableSchema.KeyColumnInfo, " AND ");
            broker.ExecuteSQL(sqlString, dpc);
        }

        /// <summary>
        /// 批量更新-独立事务
        /// </summary>
        /// <param name="entity"></param>
        public static bool Update<T>(List<T> list)
            where T : EntityBase, new()
        {
            DataAccessBroker broker = DataAccessFactory.Instance(InstanceName);
            bool result = true;
            try
            {
                broker.BeginTransaction();
                Update<T>(list, broker);
                broker.Commit();
            }
            catch
            {
                result = false;
                broker.RollBack();
            }
            finally
            {
                broker.Close();
            }
            return result;
        }

        /// <summary>
        /// 批量更新-事务支持
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public static void Update<T>(List<T> list, DataAccessBroker broker)
            where T : EntityBase
        {
            foreach (T entity in list)
            {
                Update(entity, broker);
            }
        }
        #endregion

        #region insert
        /// <summary>
        /// 新增-独立事务
        /// </summary>
        /// <param name="entity"></param>
        public static bool Insert(EntityBase entity)
        {
            bool result = true;
            try
            {
                using (DataAccessBroker broker = DataAccessFactory.Instance(InstanceName))
                {
                    Insert(entity, broker);
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 批量新增-独立事务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static bool Insert<T>(List<T> list)
            where T : EntityBase
        {
            DataAccessBroker broker = DataAccessFactory.Instance(InstanceName);
            bool result = true;
            try
            {
                broker.BeginTransaction();
                Insert(list, broker);
                broker.Commit();
            }
            catch( Exception ex )
            {
                result = false;
                broker.RollBack();
            }
            finally
            {
                broker.Close();
            }
            return result;
        }

        /// <summary>
        /// 新增-事务支持
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="broker"></param>
        public static void Insert(EntityBase entity, DataAccessBroker broker)
        {
            string sqlString = "INSERT INTO " + entity.OringTableSchema.TableName + " ( " + ParseInsertSQL(entity.OringTableSchema.AllColumnInfo, "") + " ) VALUES( " + ParseInsertSQL(entity.OringTableSchema.AllColumnInfo, ParameterPrefix) + ")";
            DataAccessParameterCollection dpc = new DataAccessParameterCollection();
            foreach (ColumnInfo field in entity.OringTableSchema.AllColumnInfo)
            {
                dpc.AddWithValue(field.ColumnName, entity.GetData(field.ColumnName));
            }
            broker.ExecuteSQL(sqlString, dpc);
        }

        /// <summary>
        /// 批量新增-事务支持
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public static void Insert<T>(List<T> list, DataAccessBroker broker)
            where T : EntityBase
        {
            foreach (T entity in list)
            {
                try
                {
                    Insert(entity, broker);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region delete
        /// <summary>
        /// 删除-独立事务-根据主键删除
        /// </summary>
        /// <param name="entity"></param>
        public static bool Delete(EntityBase entity)
        {
            bool result = true;
            try
            {
                using (DataAccessBroker broker = DataAccessFactory.Instance(InstanceName))
                {
                    Delete(entity, broker);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 删除-独立事务-根据所有非空字段AND条件删除
        /// </summary>
        /// <param name="entity"></param>
        public static bool DeleteEntity(EntityBase entity)
        {
            bool result = true;
            try
            {
                using (DataAccessBroker broker = DataAccessFactory.Instance(InstanceName))
                {
                    DeleteEntity(entity, broker);
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 删除-事务支持-根据主键删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="broker"></param>
        public static void Delete(EntityBase entity, DataAccessBroker broker)
        {
            string sqlString = "DELETE FROM " + entity.OringTableSchema.TableName + " WHERE " + ParseSQL(entity.OringTableSchema.KeyColumnInfo, " AND ");
            DataAccessParameterCollection dpc = new DataAccessParameterCollection();
            foreach (ColumnInfo field in entity.OringTableSchema.KeyColumnInfo)
            {
                dpc.AddWithValue(field.ColumnName, entity.GetData(field.ColumnName));
            }
            broker.ExecuteSQL(sqlString, dpc);
        }

        /// <summary>
        /// 删除-事务支持-根据所有非空字段AND条件删除
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="broker"></param>
        public static void DeleteEntity(EntityBase entity, DataAccessBroker broker)
        {
            WhereBuilder wb = new WhereBuilder("DELETE FROM " + entity.OringTableSchema.TableName + " ");
            wb.AddAndCondition(entity);
            broker.ExecuteSQL(wb.SQLString, wb.Parameters);
        }

        /// <summary>
        /// 批量删除-独立事务-根据主键删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static bool Delete<T>(List<T> list)
            where T : EntityBase
        {
            DataAccessBroker broker = DataAccessFactory.Instance(InstanceName);
            bool result = true;
            try
            {
                broker.BeginTransaction();
                Delete<T>(list, broker);
                broker.Commit();
            }
            catch (Exception ex)
            {
                result = false;
                broker.RollBack();
            }
            finally
            {
                broker.Close();
            }
            return result;
        }

        /// <summary>
        /// 批量删除-事务支持-根据主键删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public static void Delete<T>(List<T> list, DataAccessBroker broker)
            where T : EntityBase
        {
            foreach (T entity in list)
            {
                Delete(entity, broker);
            }
        }
        #endregion delete

        #region save
        /// <summary>
        /// 根据状态保存-独立事务
        /// </summary>
        /// <param name="entity"></param>
        public static void Save(EntityBase entity)
        {
            using (DataAccessBroker broker = DataAccessFactory.Instance(InstanceName))
            {
                Save(entity, broker);
            }
        }

        /// <summary>
        /// 根据状态保存-事务支持
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="broker"></param>
        public static void Save(EntityBase entity, DataAccessBroker broker)
        {
            switch (entity.State)
            {
                case BusinessState.Added:
                    Insert(entity, broker);
                    break;
                case BusinessState.Modified:
                    Update(entity, broker);
                    break;
                case BusinessState.Deleted:
                    Delete(entity, broker);
                    break;
            }
        }

        /// <summary>
        /// 批量保存-独立事务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static bool Save<T>(List<T> list)
            where T : EntityBase
        {
            DataAccessBroker broker = DataAccessFactory.Instance(InstanceName);
            bool result = true;
            try
            {
                broker.BeginTransaction();
                Save<T>(list, broker);
                broker.Commit();
            }
            catch
            {
                result = false;
                broker.RollBack();
            }
            finally
            {
                broker.Close();
            }
            return result;
        }

        /// <summary>
        /// 批量保存-事务支持
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="broker"></param>
        /// <returns></returns>
        public static void Save<T>(List<T> list, DataAccessBroker broker)
            where T : EntityBase
        {
            foreach (T entity in list)
            {
                Save(entity, broker);
            }
        }
        #endregion

        #region Others
        /// <summary>
        /// ExecuteScalar 并返还回唯一值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wb"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(WhereBuilder wb, T defaultValue)
        {
            using (DataAccessBroker broker = DataAccessFactory.Instance(InstanceName))
            {
                object result = broker.ExecuteScalar(wb);
                if (result != null && result != DBNull.Value)
                {
                    defaultValue = (T)result;
                }
            }
            return defaultValue;
        }
        #endregion

        #region utils
        private static string ParseInsertSQL(List<ColumnInfo> fields, string pre)
        {
            string result = "";
            foreach (ColumnInfo field in fields)
            {
                result += pre + field.ColumnName + ",";
            }
            if (result.Length > 2)
                result = result.Substring(0, result.Length - 1);
            return result;
        }

        private static string ParseSQL(List<ColumnInfo> fields, string sep)
        {
            string result = "";
            foreach (ColumnInfo field in fields)
            {
                result += " " + field.ColumnName + "=" + ParameterPrefix + field.ColumnName + sep;
            }
            if (result.Length > 2)
                result = result.Substring(0, result.Length - sep.Length);
            return result;
        }
        #endregion 
    }
}
