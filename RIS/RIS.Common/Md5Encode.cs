using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace RIS.Common
{
    public class Md5Encode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strOriginal"></param>
        /// <returns></returns>
        public static string Encode(string strOriginal)
        {
            byte[] byteInput = UTF8Encoding.UTF8.GetBytes(strOriginal);
            MD5CryptoServiceProvider objMD5 = new MD5CryptoServiceProvider();
            byte[] byteOutput = objMD5.ComputeHash(byteInput);
            return BitConverter.ToString(byteOutput).Replace("-", "");
        }
    }
}
