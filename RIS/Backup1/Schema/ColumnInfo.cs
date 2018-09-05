using System;
using System.Collections.Generic;
using System.Text;

namespace Suzsoft.Smart.EntityCore
{
    /// <summary>
    /// 数据库库中的列信息
    /// </summary>
    public class ColumnInfo
    {
        private string _columnName;
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        private string _columnCaption;
        /// <summary>
        /// 列描述
        /// </summary>
        public string ColumnCaption
        {
            get { return _columnCaption; }
            set { _columnCaption = value; }
        }

        private bool _isPrimaryKey;
        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }

        private bool _allowNull;
        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool AllowNull
        {
            get { return _allowNull; }
            set { _allowNull = value; }
        }

        private object _defaultValue;
        /// <summary>
        /// 不允许为空的默认值
        /// </summary>
        public object DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        private Type _dataType;
        /// <summary>
        /// 类型
        /// </summary>
        public Type DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        private int _maxLength;
        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength
        {
            get { return _maxLength; }
            set { _maxLength = value; }
        }

        public ColumnInfo(string columnName, string columnCaption, bool isPrimaryKey, Type dataType)
        {
            _columnName = columnName;
            _columnCaption = columnCaption;
            _isPrimaryKey = isPrimaryKey;
            _dataType = dataType;
            _allowNull = false;
            _defaultValue = null;
            _maxLength = -1;
        }
    }
}
