using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;

namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoreextendTable : TableInfo
    {
        public const string C_TableName = "StoreExtend";

        public const string C_StoreExtendID = "StoreExtendID";

        public const string C_MapID = "MapID";

        public const string C_StoreID = "StoreID";

        public const string C_PositionX = "PositionX";

        public const string C_PositionY = "PositionY";

        public const string C_NeedTransport = "NeedTransport";

        public const string C_TransportTime = "TransportTime";

        public const string C_NeedTransportTime = "NeedTransportTime";


        public StoreextendTable()
        {
            _tableName = "StoreExtend";
        }

        protected static StoreextendTable _current;
        public static StoreextendTable Current
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
            _current = new StoreextendTable();

            _current.Add(C_StoreExtendID, new ColumnInfo(C_StoreExtendID, "Storeextendid", true, typeof(string)));

            _current.Add(C_MapID, new ColumnInfo(C_MapID, "Mapid", false, typeof(string)));

            _current.Add(C_StoreID, new ColumnInfo(C_StoreID, "Storeid", false, typeof(string)));

            _current.Add(C_PositionX, new ColumnInfo(C_PositionX, "Positionx", false, typeof(int)));

            _current.Add(C_PositionY, new ColumnInfo(C_PositionY, "Positiony", false, typeof(int)));

            _current.Add(C_NeedTransport, new ColumnInfo(C_NeedTransport, "Needtransport", false, typeof(int)));

            _current.Add(C_TransportTime, new ColumnInfo(C_TransportTime, "Transporttime", false, typeof(DateTime)));

            _current.Add(C_NeedTransportTime, new ColumnInfo(C_NeedTransportTime, "Needtransporttime", false, typeof(int)));

        }


        public ColumnInfo StoreExtendID
        {
            get { return this[C_StoreExtendID]; }
        }

        public ColumnInfo MapID
        {
            get { return this[C_MapID]; }
        }

        public ColumnInfo StoreID
        {
            get { return this[C_StoreID]; }
        }

        public ColumnInfo PositionX
        {
            get { return this[C_PositionX]; }
        }

        public ColumnInfo PositionY
        {
            get { return this[C_PositionY]; }
        }

        public ColumnInfo NeedTransport
        {
            get { return this[C_NeedTransport]; }
        }

        public ColumnInfo TransportTime
        {
            get { return this[C_TransportTime]; }
        }

        public ColumnInfo NeedTransportTime
        {
            get { return this[C_NeedTransportTime]; }
        }

    }
}
