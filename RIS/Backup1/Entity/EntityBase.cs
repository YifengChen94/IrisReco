using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Suzsoft.Smart.EntityCore
{
    /// <summary>
    /// 数据实体基类
    /// </summary>
    public class EntityBase : IDictionary<string, object>
    {
        protected TableInfo _tableSchema;
        /// <summary>
        /// 对应数据库的表信息
        /// </summary>
        public TableInfo OringTableSchema
        {
            get
            {
                return _tableSchema;
            }
        }
        
        protected Dictionary<string, object> _data;
        /// <summary>
        /// 数据存储
        /// </summary>
        public Dictionary<string, object> DataCollection
        {
            get
            {
                return _data;
            }
        }

        protected BusinessState _state;
        /// <summary>
        /// 状态
        /// </summary>
        public BusinessState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public EntityBase()
        {
            _data = new Dictionary<string, object>();
            _state = BusinessState.Added;
            
        }

        /// <summary>
        /// 根据其他EntityBase内容重新初始化
        /// </summary>
        /// <param name="entity"></param>
        public void ReInitialize(EntityBase entity)
        {
            this._state = entity.State;
            this._data = entity.DataCollection;
            //_tableSchema = entity.OringTableSchema;
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public targetT Covert<targetT>()
            where targetT : EntityBase, new()
        {
            targetT t = new targetT();
            t.ReInitialize(this);
            return t;
        }

        public DataRow ConvertRow(DataRow row)
        {
            foreach (ColumnInfo column in _tableSchema.AllColumnInfo)
            {
                row[column.ColumnName] = GetData(column.ColumnName);
            }
            return row;
        }

        public void ConvertEntity(DataRow row)
        {
            foreach (ColumnInfo column in _tableSchema.AllColumnInfo)
            {
                this[column.ColumnName] = row[column.ColumnName];
            }
        }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetData(string key, object value)
        {
            this[key.Trim().ToUpper()] = value;
        }

        /// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object GetData(string key)
        {
            object result = null;
            if (ContainsKey(key.Trim().ToUpper()))
                result = this[key.Trim().ToUpper()];
            return result;
        }

        public int GetInt(string key)
        {
            object o = GetData(key);
            if (o == null)
            {
                return -1;
            }
            else
            {
                return int.Parse(o.ToString());
            }
        }

        #region ==
        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //        return false;
        //    EntityBase right = obj as EntityBase;
        //    if (right == null)
        //        return false;
        //    if (this.Count != right.Count)
        //        return false;
        //    //foreach (string key in this.Keys)
        //    //{
        //    //    if (!right.ContainsKey(key))
        //    //        return false;
        //    //    if (this[key] != right[key])
        //    //        return false;
        //    //}
        //    return true;
        //}

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(EntityBase left, object right)
        {
            if (Object.Equals (left, null ))
            {
                if (Object.Equals(right, null))
                    return true;
                else
                    return false;
            }
            return left.Equals(right);
        }

        public static bool operator !=(EntityBase left, object right)
        {
            return !(left == right);
        }
        #endregion

        #region IDictionary<string,object> Members

        public void Add(string key, object value)
        {
            _data.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return _data.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get
            {
                return _data.Keys;
            }
        }

        public bool Remove(string key)
        {
            return _data.Remove(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return _data.TryGetValue(key, out value);
        }

        public ICollection<object> Values
        {
            get { return _data.Values; }
        }

        public object this[string key]
        {
            get
            {
                return _data[key];
            }
            set
            {
                _data[key] = value;
            }
        }

        #endregion

        #region ICollection<KeyValuePair<string,object>> Members

        public void Add(KeyValuePair<string, object> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)_data).Contains(item);
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, object>>)_data).CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _data.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((ICollection<KeyValuePair<string, object>>)_data).IsReadOnly; }
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            return ((ICollection<KeyValuePair<string, object>>)_data).Remove(item);
        }

        #endregion

        #region IEnumerable<KeyValuePair<string,object>> Members

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_data).GetEnumerator();
        }

        #endregion
    }
}
