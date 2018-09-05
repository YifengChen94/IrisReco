using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RIS.Common;
using System.IO;
using RIS.Entity.Entity;
using Suzsoft.Smart.Data;
using System.Drawing;

namespace RIS.BusinessRule
{
    public class AuthorListCaching
    {
        private static List<MstAuditUserEntity> _list = null;
        private static Dictionary<string, MstAuditUserEntity> _dic=null;
        public static List<MstAuditUserEntity> AuthorList
        {
            get
            {
                if (_list == null)
                {
                    _list = DataAccess.SelectAll<MstAuditUserEntity>();
                    foreach (MstAuditUserEntity entity in _list)
                    {
                        if(!string.IsNullOrEmpty(entity.Photoimage))
                            entity.ImageBitmap = Bitmap.FromFile(entity.Photoimage) as Bitmap;
                        else 
                            entity.ImageBitmap=null;
                    }
                }
                return _list;
            }
            set
            {
                _list = value;
                _dic = null;
            }

        }
        public static Dictionary<string, MstAuditUserEntity> AuthorDic
        {
            get
            {
                if (_dic == null)
                {
                    _dic = ReadFromList();

                }
                return _dic;
            }
        }

        private static Dictionary<string, MstAuditUserEntity> ReadFromList()
        {
            _dic = new Dictionary<string, MstAuditUserEntity>();
            foreach(MstAuditUserEntity entity in AuthorList)
            {
                _dic[entity.Audituserid] = entity;
            }
            return _dic;
        }

        public static MstAuditUserEntity GetAuthorInfoById(string Id)
        {
            if (AuthorDic.ContainsKey(Id))
                return AuthorDic[Id];
            return null;
        }

    }
}
