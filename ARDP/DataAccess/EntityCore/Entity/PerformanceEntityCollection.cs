using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.EntityCore
{
    /// <summary>
    /// 高性能集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PerformanceEntityCollection<T> : ICollection<T>
        where T : EntityBase, new()
    {
        private Dictionary<string, List<object>> _data;
        private List<string> _columns;
        public PerformanceEntityCollection(List<string> columns)
        {
            _data = new Dictionary<string, List<object>>();
            _columns = columns;
            foreach (string column in columns)
            {
                _data[column] = new List<object>();
            }
        }

        public void Add(object[] objs)
        {
            for (int i = 0; i < _columns.Count; i++)
            {
                _data[_columns[i]].Add(objs[i]);
            }
        }

        public int Count
        {
            get
            {
                return _data[_columns[0]].Count;
            }
        }

        public T this[int index]
        {
            get
            {
                T t = new T();
                for (int i = 0; i < _columns.Count; i++)
                {
                    t.SetData(_columns[i], _data[_columns[i]][index]);
                }
                return t;
            }
            set
            {
                for (int i = 0; i < _columns.Count; i++)
                {
                    _data[_columns[i]][index] = value.GetData(_columns[i]);
                }
            }
        }

        #region ICollection<T> Members

        public void Add(T item)
        {
            for (int i = 0; i < _columns.Count; i++)
            {
                _data[_columns[i]].Add(item[_columns[i]]);
            }
        }

        public void Clear()
        {
        }

        public bool Contains(T item)
        {
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return false;
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
