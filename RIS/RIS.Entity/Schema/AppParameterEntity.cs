using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using C2Olay.TransactionOlayEx.Schema;

namespace C2Olay.TransactionOlayEx.Entity
{
    [Serializable]
    public partial class AppParameterEntity : EntityBase
    {
        public AppParameterTable TableSchema
        {
            get
            {
                return AppParameterTable.Current;
            }
        }


        public AppParameterEntity()
        {

        }

        public override TableInfo OringTableSchema
        {
            get
            {
                return AppParameterTable.Current;
            }
        }
        #region 属性列表

        public string Parameterid
        {
            get { return (string)GetData(AppParameterTable.C_ParameterId); }
            set { SetData(AppParameterTable.C_ParameterId, value); }
        }

        public string Parametername
        {
            get { return (string)GetData(AppParameterTable.C_ParameterName); }
            set { SetData(AppParameterTable.C_ParameterName, value); }
        }

        public string Parametervalue
        {
            get { return (string)GetData(AppParameterTable.C_ParameterValue); }
            set { SetData(AppParameterTable.C_ParameterValue, value); }
        }

        public string Catalog
        {
            get { return (string)GetData(AppParameterTable.C_Catalog); }
            set { SetData(AppParameterTable.C_Catalog, value); }
        }

        public int Seqorder
        {
            get { return (int)(GetData(AppParameterTable.C_SeqOrder)); }
            set { SetData(AppParameterTable.C_SeqOrder, value); }
        }

        public DateTime Lastmodifiedtime
        {
            get { return (DateTime)(GetData(AppParameterTable.C_LastModifiedTime) == null ? DateTime.MinValue : GetData(AppParameterTable.C_LastModifiedTime)); }
            set { SetData(AppParameterTable.C_LastModifiedTime, value); }
        }

        public string Lastmodifieduserid
        {
            get { return (string)GetData(AppParameterTable.C_LastModifiedUserId); }
            set { SetData(AppParameterTable.C_LastModifiedUserId, value); }
        }

        #endregion
    }
}
