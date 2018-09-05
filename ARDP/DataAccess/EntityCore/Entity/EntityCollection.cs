/******************************************************************
 * Copyright(c)  Suzsoft Co., Ltd.
 * Description	 : 
 * CreateDate	 : 2006-04-13 10:31:35
 * Creater		 : Johnson Cao
 * LastChangeDate: 
 * LastChanger	 : 
 * Version Info	 : 
 * ******************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;

namespace Suzsoft.Smart.EntityCore
{
    /// <summary>
    /// 数据实体集合
    /// </summary>
    /// <typeparam name="T">数据实体类型</typeparam>
    public class EntityCollection<T> : List<T>, IListSource, IBindingList 
        where T : EntityBase, new()
    {
        /// <summary>
        /// 根据键与值查询符合条件的数据集合
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="Value">值</param>
        /// <returns></returns>
        public EntityCollection<T> SeekRow(string key, object Value)
        {
            EntityCollection<T> result = new EntityCollection<T>();
            foreach (T obj in this)
            {
                object value = obj.GetData(key);
                if (value != null && value == obj)
                {
                    result.Add(obj);
                }
            }
            return result;
        }

        /// <summary>
        /// 返回特定状态的集合
        /// </summary>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public EntityCollection<T> SeekState(BusinessState state)
        {
            EntityCollection<T> result = new EntityCollection<T>();
            foreach (T obj in this)
            {
                if (obj.State == state)
                {
                    result.Add(obj);
                }
            }
            return result;
        }

        public EntityCollection<targetT> Covert<targetT>()
            where targetT : EntityBase, new()
        {
            EntityCollection<targetT> result = new EntityCollection<targetT>();
            foreach (T t in this)
            {
                result.Add(t.Covert<targetT>());
            }
            return result;
        }

        public static List<targetT> DataTable2List<targetT>(DataTable table)
             where targetT : EntityBase, new()
        {
            List<targetT> result = new List<targetT>();
            foreach (DataRow row in table.Rows)
            {
                targetT t = new targetT();
                t.ConvertEntity(row);
                result.Add(t);
            }
            return result;
        }

        public static DataTable List2DataTable<targetT>(List<targetT> list)
             where targetT : EntityBase, new()
        {
            targetT schema = new targetT();
            DataTable table = new DataTable();
            foreach( ColumnInfo field in schema.OringTableSchema.AllColumnInfo )
            {
                table.Columns.Add(field.ColumnName);
            }
            foreach (targetT t in list)
            {
                DataRow row = table.NewRow();
                row = t.ConvertRow(row);
                table.Rows.Add(row);
            }
            return table;
        }

        public override string ToString()
        {
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //sb.Append("<" + this.GetType().Name);
            //System.Reflection.PropertyInfo[] pis = this.GetType().GetProperties();
            //foreach (System.Reflection.PropertyInfo pi in this.GetType().GetProperties())
            //    sb.Append(" " + pi.Name + "=" + pi.GetValue(this, null).ToString());
            //sb.Append(" >");
            //sb.Append("</" + this.GetType().Name);
            //return sb.ToString();
            return "";
        }
        #region IListSource Members

        public bool ContainsListCollection
        {
            get { return true; }
        }

        public System.Collections.IList GetList()
        {
            return this;
        }

        #endregion

        #region IBindingList Members

        public void AddIndex(PropertyDescriptor property)
        {
            throw new NotSupportedException();
        }

        public object AddNew()
        {
            T obj = new T();
            this.Add(obj);
            return obj;
        }

        public bool AllowEdit
        {
            get { return true; }
        }

        public bool AllowNew
        {
            get { return true; }
        }

        public bool AllowRemove
        {
            get { return true; }
        }

        public void ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotSupportedException();
        }

        public int Find(PropertyDescriptor property, object key)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (property.GetValue(this[i]).Equals(key))
                    return i;
            }
            return -1;
        }

        public bool IsSorted
        {
            get { throw new NotSupportedException(); }
        }

        public event ListChangedEventHandler ListChanged;

        public void RemoveIndex(PropertyDescriptor property)
        {
            throw new NotSupportedException();
        }

        public void RemoveSort()
        {
            throw new NotSupportedException();
        }

        public ListSortDirection SortDirection
        {
            get { throw new NotSupportedException(); }
        }

        public PropertyDescriptor SortProperty
        {
            get { throw new NotSupportedException(); }
        }

        public bool SupportsChangeNotification
        {
            get { return true; }
        }

        public bool SupportsSearching
        {
            get { return true; }
        }

        public bool SupportsSorting
        {
            get { return false; }
        }

        #endregion
    }
}