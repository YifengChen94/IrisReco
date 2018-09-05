using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class BcptaskstackEntity : EntityBase
    {
        public BcptaskstackTable TableSchema
        {
            get
            {
                return (BcptaskstackTable)_tableSchema;
            }
        }


        public BcptaskstackEntity()
        {
            _tableSchema = BcptaskstackTable.Current;
        }

        #region 属性列表

        public string Bcptaskstackid
        {
            get { return (string)GetData(BcptaskstackTable.C_BCPTaskStackID); }
            set { SetData(BcptaskstackTable.C_BCPTaskStackID, value); }
        }

        public string Bcptaskid
        {
            get { return (string)GetData(BcptaskstackTable.C_BCPTaskID); }
            set { SetData(BcptaskstackTable.C_BCPTaskID, value); }
        }

        public string Smallpic
        {
            get { return (string)GetData(BcptaskstackTable.C_SmallPic); }
            set { SetData(BcptaskstackTable.C_SmallPic, value); }
        }

        public int Smallpositonx
        {
            get { return (int)(GetData(BcptaskstackTable.C_SmallPositonX)); }
            set { SetData(BcptaskstackTable.C_SmallPositonX, value); }
        }

        public int Smallpositony
        {
            get { return (int)(GetData(BcptaskstackTable.C_SmallPositonY)); }
            set { SetData(BcptaskstackTable.C_SmallPositonY, value); }
        }

        public string Bigpic
        {
            get { return (string)GetData(BcptaskstackTable.C_BigPic); }
            set { SetData(BcptaskstackTable.C_BigPic, value); }
        }

        public int Bigpositonx
        {
            get { return (int)(GetData(BcptaskstackTable.C_BigPositonX)); }
            set { SetData(BcptaskstackTable.C_BigPositonX, value); }
        }

        public int Bigpositony
        {
            get { return (int)(GetData(BcptaskstackTable.C_BigPositonY)); }
            set { SetData(BcptaskstackTable.C_BigPositonY, value); }
        }

        public string Stackcode
        {
            get { return (string)GetData(BcptaskstackTable.C_StackCode); }
            set { SetData(BcptaskstackTable.C_StackCode, value); }
        }

        #endregion
    }
}
