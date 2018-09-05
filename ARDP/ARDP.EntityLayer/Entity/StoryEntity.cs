using System;
using System.Collections.Generic;
using System.Text;
using Suzsoft.Smart.EntityCore;
using System.Threading;


namespace ARDP.EntityLayer
{
    [Serializable]
    public partial class StoryEntity : EntityBase
    {
        public StoryTable TableSchema
        {
            get
            {
                return (StoryTable)_tableSchema;
            }
        }


        public StoryEntity()
        {
            _tableSchema = StoryTable.Current;
        }

        #region 属性列表

        public string Storyid
        {
            get { return (string)GetData(StoryTable.C_StoryID); }
            set { SetData(StoryTable.C_StoryID, value); }
        }

        public string Storyname
        {
            get 
            {
                if (Thread.CurrentThread.CurrentCulture.Name.ToLower() == "en-us")
                {
                    return (string)GetData(StoryTable.C_StoryNameEn);
                }
                return (string)GetData(StoryTable.C_StoryName); 
            }
            set { SetData(StoryTable.C_StoryName, value); }
        }

        public string Smallimage
        {
            get { return (string)GetData(StoryTable.C_SmallImage); }
            set { SetData(StoryTable.C_SmallImage, value); }
        }

        public int Fullpoints
        {
            get { return (int)(GetData(StoryTable.C_FullPoints)); }
            set { SetData(StoryTable.C_FullPoints, value); }
        }

        public string FullClassName
        {
            get { return (string)(GetData(StoryTable.C_FullClassName)); }
            set { SetData(StoryTable.C_FullClassName, value); }
        }

        public int Ordernum
        {
            get { return (int)(GetData(StoryTable.C_OrderNum)); }
            set { SetData(StoryTable.C_OrderNum, value); }
        }

        public string Storynameen
        {
            get { return (string)(GetData(StoryTable.C_StoryNameEn)); }
            set { SetData(StoryTable.C_StoryNameEn, value); }
        }

        #endregion
    }
}
