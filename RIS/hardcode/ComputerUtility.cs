using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace RIS.Common
{
    public class ComputerUtility
    {
        ///<summary>
        ///   获取cpu序列号
        ///</summary>
        ///<returns> string </returns>
        public static string GetCpuInfo()
        {
           string cpuInfo = " ";
           using (ManagementClass cimobject = new ManagementClass("Win32_Processor"))
            {
                ManagementObjectCollection moc = cimobject.GetInstances();
     
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                    mo.Dispose();
                }
            }
            return cpuInfo.ToString();
        }
     
        ///<summary>
        ///   获取硬盘ID
        ///</summary>
        ///<returns> string </returns>
        public static string GetHDid()
        {
            string HDid = " ";
            using (ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive"))
            {
                ManagementObjectCollection moc1 = cimobject1.GetInstances();
                foreach (ManagementObject mo in moc1)
                {
                    HDid = (string)mo.Properties["Model"].Value;
                    mo.Dispose();
                }
            }
            return HDid.ToString();
        }
     
        ///<summary>
        ///   获取网卡硬件地址
        //</summary>
        ///<returns> string </returns>
        public static string GetMoAddress()
        {
            string MoAddress = " ";
            using (ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                ManagementObjectCollection moc2 = mc.GetInstances();
                foreach (ManagementObject mo in moc2)
                {
                    if ((bool)mo["IPEnabled"] == true)
                        MoAddress = mo["MacAddress"].ToString();
                    mo.Dispose();
                }
            }
            return MoAddress.ToString();
        }
        public static string GetDeviceID()
        {
            string s1 = GetCpuInfo();
            string s2 = GetHDid();
            string s3 = GetMoAddress();
            string s = s1 + "-" + s2;
            return Md5Encode.Encode(s);
        }
    }
}
