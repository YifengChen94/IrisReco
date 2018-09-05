using Newtonsoft.Json;
//----------------------------------------------------------------------------
// Copyright (C) 2014 Shanghai Hewlett-Packard Development Company,L.P.
//
// File Description： JsonHelper
//
// Created By：Jin,Yong
// Create Time：12/23/2014 10:46:24 AM
// Modifier：
// Modify Time：
// Modify Desc：
//----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RIS.Common
{
    /// <summary>
    /// Author:Jin,Yong  at  12/23/2014 10:46:24 AM
    /// </summary>
    public class JsonHelper
    {
        public static string ObjectToJsonString(object value)
        {
            try
            {
                string json = JsonConvert.SerializeObject(value);
                return json;
            }
            catch(Exception ex) {}
            return "";
        }

        public static T JsonStringToObject<T>(string jsonValue)
        {
            return JsonConvert.DeserializeObject<T>(jsonValue);
        }
    }
}
