using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.EntityCore
{
    /// <summary>
    /// 数据库中的表信息
    /// </summary>
    public class TableInfo
    {
        private Dictionary<string, ColumnInfo> _columns;
        /// <summary>
        /// 所有列
        /// </summary>
        protected Dictionary<string, ColumnInfo> Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }

        protected string _tableName;
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return _tableName; }
        }

        public TableInfo()
        {
            _columns = new Dictionary<string, ColumnInfo>();
        }

        public void Add(string columnName, ColumnInfo column)
        {
            this[columnName] = column;
        }

        /// <summary>
        /// 字段索引
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public ColumnInfo this[string columnName]
        {
            get
            {
                return _columns[columnName];
            }
            set
            {
                _columns[columnName] = value;
            }
        }

        protected List<ColumnInfo> _allColumnInfo;
        /// <summary>
        /// 所有字段
        /// </summary>
        public List<ColumnInfo> AllColumnInfo
        {
            get
            {
                if (_allColumnInfo == null)
                {
                    _allColumnInfo = new List<ColumnInfo>();
                    foreach (ColumnInfo ci in _columns.Values)
                    {
                        _allColumnInfo.Add(ci);
                    }
                }
                return _allColumnInfo;
            }
        }

        protected List<ColumnInfo> _keyColumnInfo;
        /// <summary>
        /// 主键字段
        /// </summary>
        public List<ColumnInfo> KeyColumnInfo
        {
            get
            {
                if (_keyColumnInfo == null)
                {
                    _keyColumnInfo = new List<ColumnInfo>();
                    foreach (ColumnInfo ci in _columns.Values)
                    {
                        if (ci.IsPrimaryKey)
                        {
                            _keyColumnInfo.Add(ci);
                        }
                    }
                }
                return _keyColumnInfo;
            }
        }

        protected List<ColumnInfo> _valueColumnInfo;
        /// <summary>
        /// 非主键字段
        /// </summary>
        public List<ColumnInfo> ValueColumnInfo
        {
            get
            {
                if (_valueColumnInfo == null)
                {
                    _valueColumnInfo = new List<ColumnInfo>();
                    foreach (ColumnInfo ci in _columns.Values)
                    {
                        if (!ci.IsPrimaryKey)
                        {
                            _valueColumnInfo.Add(ci);
                        }
                    }
                }
                return _valueColumnInfo;
            }
        }
    }
}
