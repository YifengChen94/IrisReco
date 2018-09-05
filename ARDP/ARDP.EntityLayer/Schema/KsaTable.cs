using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class KsaTable : TableInfo
    {
        public const string C_TableName = "KSA";

        public const string C_ID = "ID";

        public const string C_K_Score = "K_Score";

        public const string C_S_Score = "S_Score";

        public const string C_A_Score = "A_Score";

        public const string C_Face = "Face";

        public const string C_DAM_Face = "DAM_Face";


        public KsaTable()
        {
            _tableName = "KSA";
        }

        protected static KsaTable _current;
        public static KsaTable Current
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
            _current = new KsaTable();

            _current.Add(C_ID, new ColumnInfo(C_ID, "Id", true, typeof(string)));

            _current.Add(C_K_Score, new ColumnInfo(C_K_Score, "KScore", false, typeof(int)));

            _current.Add(C_S_Score, new ColumnInfo(C_S_Score, "SScore", false, typeof(int)));

            _current.Add(C_A_Score, new ColumnInfo(C_A_Score, "AScore", false, typeof(int)));

            _current.Add(C_Face, new ColumnInfo(C_Face, "Face", false, typeof(int)));

            _current.Add(C_DAM_Face, new ColumnInfo(C_DAM_Face, "DamFace", false, typeof(int)));

        }


        public ColumnInfo ID
        {
            get { return this[C_ID]; }
        }

        public ColumnInfo K_Score
        {
            get { return this[C_K_Score]; }
        }

        public ColumnInfo S_Score
        {
            get { return this[C_S_Score]; }
        }

        public ColumnInfo A_Score
        {
            get { return this[C_A_Score]; }
        }

        public ColumnInfo Face
        {
            get { return this[C_Face]; }
        }

        public ColumnInfo DAM_Face
        {
            get { return this[C_DAM_Face]; }
        }

    }
}
