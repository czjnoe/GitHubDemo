using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace AutoPulishWebOrDb.Help
{
    public class PortHelper
    {
        /// <summary>
        /// 判断端口号是否占用
        /// </summary>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public static bool PortInUse(int port)
        {
            bool flag = false;
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            List<IPEndPoint> ipendpoints = new List<IPEndPoint>();

            ipendpoints.AddRange(properties.GetActiveTcpListeners());
            ipendpoints.AddRange(properties.GetActiveUdpListeners());

            foreach (IPEndPoint ipendpoint in ipendpoints)
            {
                if (ipendpoint.Port == port)
                {
                    flag = true;
                    break;
                }
            }
            ipendpoints = null;
            properties = null;
            return flag;
        }


    }

}
