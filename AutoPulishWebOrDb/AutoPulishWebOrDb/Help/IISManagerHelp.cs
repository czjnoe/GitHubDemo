using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace AutoPulishWebOrDb.Help
{
    public class IISManagerHelp
    {
        private static ServerManager server = null;
        private string _ip = string.Empty;
        public IISManagerHelp(string ip = "localhost")
        {
            _ip = ip;
            server = ServerManager.OpenRemote(_ip);
        }

        /// <summary>
        /// 是否安装IIS
        /// </summary>
        /// <returns></returns>
        public bool IsInstallIIS()
        {
            ServiceController service = ServiceController.GetServices("127.0.0.1").FirstOrDefault(x => x.ServiceName == "W3SVC");
            if (service == null)
            {
                return false;
            }
            return true;
        }

        public bool IsExistPoolName(string poolName)
        {
            if (server.ApplicationPools[poolName] != null)
            {
                return true;
            }

            return false;
        }

        public bool IsExistSiteName(string siteName)
        {
            if (server.Sites[siteName] != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 创建一个站点
        /// </summary>
        /// <param name="siteName">站点名称</param>
        /// <param name="poolName">程序池名称</param>
        /// <param name="physicalPath">项目所在路径</param>
        /// <param name="port">端口号</param>
        /// <param name="mode">程序池托管模式 默认集成模式</param>
        /// <returns></returns>
        public bool CreateWebSite(string siteName,string poolName, string physicalPath, int port,Dictionary<string,string> mimeDic, ManagedPipelineMode mode= ManagedPipelineMode.Integrated)
        {
            try
            {
                server.Sites.Add(siteName, physicalPath, port);

                //添加web应用程序池
                ApplicationPool pool = server.ApplicationPools.Add(poolName);
                pool.ManagedPipelineMode = mode;
                //设置web应用程序池的Framework版本
                pool.ManagedRuntimeVersion = "v4.0";
                //设置是否启用32位应用程序
                pool.SetAttributeValue("enable32BitAppOnWin64", true);

                //设置web网站的应用程序池
                server.Sites[siteName].Applications[0].ApplicationPoolName = poolName;

                server.CommitChanges();
                Microsoft.Web.Administration.Configuration confg = server.GetWebConfiguration(siteName); //webSiteName站点名称
                AddMIMEType(confg, mimeDic);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// 添加IIS mime类型
        /// </summary>
        /// <param name="mimeDic"></param>
        /// <returns></returns>
        private static bool AddMIMEType(Microsoft.Web.Administration.Configuration confg, Dictionary<string, string> mimeDic)
        {
            try
            {
                Microsoft.Web.Administration.ConfigurationSection section;
                section = confg.GetSection("system.webServer/staticContent");     //取得MimeMap所有节点(路径为:%windir%\Windows\System32\inetsrv\config\applicationHost.config)

                Microsoft.Web.Administration.ConfigurationElement filesElement = section.GetCollection();
                Microsoft.Web.Administration.ConfigurationElementCollection filesCollection = filesElement.GetCollection();

                
                foreach (var key in mimeDic.Keys)
                {
                    Microsoft.Web.Administration.ConfigurationElement newElement = filesCollection.CreateElement(); //新建MimeMap节点
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
    }
}
