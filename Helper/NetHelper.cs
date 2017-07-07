using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Helpers
{
    public class NetHelper
    {
        public static string GetLocalIP()
        {
            ///获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                    break;
                }
            }
            return AddressIP;
        }
    }
}
