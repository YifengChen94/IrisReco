using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoreextendEntity : EntityBase
    {
        public StoreextendTable TableSchema
        {
            get
            {
                return (StoreextendTable)_tableSchema;
            }
        }


        public StoreextendEntity()
        {
            _tableSchema = StoreextendTable.Current;
        }

        #region 属性列表

        public string Storeextendid
        {
            get { return (string)GetData(StoreextendTable.C_StoreExtendID); }
            set { SetData(StoreextendTable.C_StoreExtendID, value); }
        }

        public string Mapid
        {
            get { return (string)GetData(StoreextendTable.C_MapID); }
            set { SetData(StoreextendTable.C_MapID, value); }
        }

        public string Storeid
        {
            get { return (string)GetData(StoreextendTable.C_StoreID); }
            set { SetData(StoreextendTable.C_StoreID, value); }
        }

        public int Positionx
        {
            get { return (int)(GetInt(StoreextendTable.C_PositionX)); }
            set { SetData(StoreextendTable.C_PositionX, value); }
        }

        public int Positiony
        {
            get { return (int)(GetInt(StoreextendTable.C_PositionY)); }
            set { SetData(StoreextendTable.C_PositionY, value); }
        }

        public int Needtransport
        {
            get { return (int)(GetData(StoreextendTable.C_NeedTransport)); }
            set { SetData(StoreextendTable.C_NeedTransport, value); }
        }

        public int Transporttime
        {
            get { return (int)(GetData(StoreextendTable.C_TransportTime)); }
            set { SetData(StoreextendTable.C_TransportTime, value); }
        }

        public int Needtransporttime
        {
            get { return (int)(GetData(StoreextendTable.C_NeedTransportTime)); }
            set { SetData(StoreextendTable.C_NeedTransportTime, value); }
        }

        #endregion
    }
}
