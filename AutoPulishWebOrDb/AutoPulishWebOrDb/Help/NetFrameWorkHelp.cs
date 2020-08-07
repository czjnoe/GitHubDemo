using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoPulishWebOrDb.Help
{
    public class NetFrameWorkHelp
    {
        /// <summary>
        /// 判断是否安装 NET4.0 环境 
        /// </summary>
        /// <returns></returns>
        public static bool IsExistNet40()
        {
            DirectoryInfo[] directories = new DirectoryInfo(
                Environment.SystemDirectory + @"\..\Microsoft.NET\Framework").GetDirectories("v?.?.*");
            foreach (DirectoryInfo info2 in directories)
            {
                var versionName = info2.Name.Split('.')[0];
                if (versionName=="v4")
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }
    }
}
