using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;

namespace AutoPulishWebOrDb.Help
{
    public class IISHelp
    {
        /// <summary>
        /// 添加IIS 默认站点 mime类型
        /// </summary>
        /// <param name="mimeDic"></param>
        /// <returns></returns>
        public static bool AddMIMEType(Dictionary<string, string> mimeDic)
        {
            try
            {
                ServerManager server = new ServerManager();
                Configuration confg = server.GetWebConfiguration("Default Web Site"); //webSiteName站点名称

                ConfigurationSection section;
                section = confg.GetSection("system.webServer/staticContent");     //取得MimeMap所有节点(路径为:%windir%\Windows\System32\inetsrv\config\applicationHost.config)

                ConfigurationElement filesElement = section.GetCollection();
                ConfigurationElementCollection filesCollection = filesElement.GetCollection();

                foreach (var key in mimeDic.Keys)
                {
                    ConfigurationElement newElement = filesCollection.CreateElement(); //新建MimeMap节点
                    newElement.Attributes["fileExtension"].Value = key;
                    newElement.Attributes["mimeType"].Value = mimeDic[key];
                    if (!filesCollection.Contains(newElement))
                    {
                        filesCollection.Add(newElement);
                    }
                }
                server.CommitChanges();//更改
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 取得IIS版本
        /// </summary>
        /// <returns></returns>
        public static int GetIISVersion()
        {
            try
            {
                DirectoryEntry getEntity = new DirectoryEntry("IIS://localhost/W3SVC/INFO");
                string strVersion = getEntity.Properties["MajorIISVersionNumber"].Value.ToString();
                return Convert.ToInt32(strVersion);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
