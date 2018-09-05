using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Net;
using System.Diagnostics;

namespace RIS.Common
{
    public class ComputerUtility
    {
        ///<summary>
        ///   获取cpu序列号
        ///</summary>
        ///<returns> string </returns>
        private static string GetCpuInfo()
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
        private static string GetHDid()
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
        private static string GetMoAddress()
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
        private static string _deviceId = "";
        public static string DeviceID
        {
            get
            {
                if (string.IsNullOrEmpty(_deviceId))
                {
                    string s1 = GetCpuInfo();
                    string s2 = GetHDid();
                    string s3 = GetMoAddress();
                    string s = s1 + "-" + s2;
                    _deviceId = Md5Encode.Encode(s);
                }
                return _deviceId;
            }
        }

        private static string _ipAddress = "";
        public static string IpAddress
        {
            get
            {

                _ipAddress = GetLocalIp();
                
                return _ipAddress;
            }
        }
        private static string GetLocalIp()  
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }

        public static void AddAddress(string address)
        {
            try
            {
                AddAddress(address, Environment.UserDomainName, Environment.UserName);
            }
            catch (Exception ex) { }
        }

        public static void AddAddress(string address, string domain, string user)
        {
            string argsDll = String.Format(@"http delete urlacl url={0}", address);
            string args = string.Format(@"http add urlacl url={0} user={1}\{2}", address, domain, user);
            ProcessStartInfo psi = new ProcessStartInfo("netsh", argsDll);
            psi.Verb = "runas";
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            Process.Start(psi).WaitForExit();//删除urlacl
            psi = new ProcessStartInfo("netsh", args);
            psi.Verb = "runas";
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            Process.Start(psi).WaitForExit();//添加urlacl
        }

    }
}
