using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BossTable : TableInfo
    {
        public const string C_TableName = "Boss";

        public const string C_BossID = "BossID";

        public const string C_BossImage = "BossImage";

        public const string C_BossEye = "BossEye";

        public const string C_BossEyeX = "BossEyeX";

        public const string C_BossEyeY = "BossEyeY";

        public const string C_BossMouth = "BossMouth";

        public const string C_BossMouthX = "BossMouthX";

        public const string C_BossMouthY = "BossMouthY";


        public BossTable()
        {
            _tableName = "Boss";
        }

        protected static BossTable _current;
        public static BossTable Current
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
            _current = new BossTable();

            _current.Add(C_BossID, new ColumnInfo(C_BossID, "Bossid", true, typeof(string)));

            _current.Add(C_BossImage, new ColumnInfo(C_BossImage, "Bossimage", false, typeof(string)));

            _current.Add(C_BossEye, new ColumnInfo(C_BossEye, "Bosseye", false, typeof(string)));

            _current.Add(C_BossEyeX, new ColumnInfo(C_BossEyeX, "Bosseyex", false, typeof(int)));

            _current.Add(C_BossEyeY, new ColumnInfo(C_BossEyeY, "Bosseyey", false, typeof(int)));

            _current.Add(C_BossMouth, new ColumnInfo(C_BossMouth, "Bossmouth", false, typeof(string)));

            _current.Add(C_BossMouthX, new ColumnInfo(C_BossMouthX, "Bossmouthx", false, typeof(int)));

            _current.Add(C_BossMouthY, new ColumnInfo(C_BossMouthY, "Bossmouthy", false, typeof(int)));

        }


        public ColumnInfo BossID
        {
            get { return this[C_BossID]; }
        }

        public ColumnInfo BossImage
        {
            get { return this[C_BossImage]; }
        }

        public ColumnInfo BossEye
        {
            get { return this[C_BossEye]; }
        }

        public ColumnInfo BossEyeX
        {
            get { return this[C_BossEyeX]; }
        }

        public ColumnInfo BossEyeY
        {
            get { return this[C_BossEyeY]; }
        }

        public ColumnInfo BossMouth
        {
            get { return this[C_BossMouth]; }
        }

        public ColumnInfo BossMouthX
        {
            get { return this[C_BossMouthX]; }
        }

        public ColumnInfo BossMouthY
        {
            get { return this[C_BossMouthY]; }
        }

    }
}
