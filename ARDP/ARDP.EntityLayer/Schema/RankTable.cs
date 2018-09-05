using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class RankTable : TableInfo
    {
        public const string C_TableName = "RANK";

        public const string C_RankID = "RANKID";

        public const string C_RankType = "RANKTYPE";

        public const string C_OrderNum = "ORDERNUM";

        public const string C_Content = "CONTENT";

        public RankTable()
        {
            _tableName = "RANK";
        }

        protected static RankTable _current;
        public static RankTable Current
        {
            get
            {
                if (_current == null)
                {
                    Initial();
                }
                return _current;
            }
        }

        private static void Initial()
        {
            _current = new RankTable();

            _current.Add(C_RankID, new ColumnInfo(C_RankID, "Rankid", true, typeof(string)));

            _current.Add(C_RankType, new ColumnInfo(C_RankType, "Ranktype", false, typeof(int)));

            _current.Add(C_OrderNum, new ColumnInfo(C_OrderNum, "Ordernum", false, typeof(int)));

            _current.Add(C_Content, new ColumnInfo(C_Content, "Content", false, typeof(string))); 
        }


        public ColumnInfo RankID
        {
            get { return this[C_RankID]; }
        }

        public ColumnInfo RankType
        {
            get { return this[C_RankType]; }
        }

        public ColumnInfo OrderNum
        {
            get { return this[C_OrderNum]; }
        }

        public ColumnInfo Content
        {
            get { return this[C_Content]; }
        } 
    }
}
