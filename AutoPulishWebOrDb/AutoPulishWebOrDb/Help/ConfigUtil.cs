/*
*┌──────────────────────────────────────────┐
*│  描述：ConfigUtil                                   
*│　作   者：chenzhaojie                                              
*│　版   本：1.0                                              
*│　创建时间：2020/8/2 23:54:22                        
*└──────────────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace AutoPulishWebOrDb.Help
{
    public static class ConfigUtil
    {
        /// <summary>
        /// 获取管理配置文件对象Configuration
        /// </summary>
        /// <param name="configPath">指定要管理的配置文件路径，如果为空或不存在，则管理程序集默认的配置文件路径</param>
        /// <returns></returns>
        private static Configuration GetConfiguration(string configPath = null)
        {
            if (!string.IsNullOrEmpty(configPath) && File.Exists(configPath))
            {
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = configPath;
                return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            }
            else
            {
                return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
        }


        /// <summary>
        /// 获取指定配置文件+配置名称的配置项的值
        /// </summary>
        public static string GetAppSettingValue(string key, string defaultValue = null, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            var appSetting = config.AppSettings.Settings[key];
            return appSetting?.Value;
        }


        /// <summary>
        /// 设置配置值（存在则更新，不存在则新增）
        /// </summary>
        public static void SetAppSettingValue(string key, string value, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            var setting = config.AppSettings.Settings[key];
            if (setting == null)
            {
                config.AppSettings.Settings.Add(key, value);
            }
            else
            {
                setting.Value = value;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 删除配置值
        /// </summary>
        public static void RemoveAppSetting(string key, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            config.AppSettings.Settings.Remove(key);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 设置多个配置值（存在则更新，不存在则新增）
        /// </summary>
        public static void SetAppSettingValues(IEnumerable<KeyValuePair<string, string>> settingValues, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            foreach (var item in settingValues)
            {
                var setting = config.AppSettings.Settings[item.Key];
                if (setting == null)
                {
                    config.AppSettings.Settings.Add(item.Key, item.Value);
                }
                else
                {
                    setting.Value = item.Value;
                }
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// 获取所有配置值
        /// </summary>
        public static Dictionary<string, string> GetAppSettingValues(string configPath = null)
        {
            Dictionary<string, string> settingDic = new Dictionary<string, string>();
            var config = GetConfiguration(configPath);
            var settings = config.AppSettings.Settings;
            foreach (string key in settings.AllKeys)
            {
                settingDic[key] = settings[key].Value.ToString();
            }
            return settingDic;
        }

        /// <summary>
        /// 删除多个配置值
        /// </summary>
        public static void RemoveAppSettings(string configPath = null, params string[] keys)
        {
            var config = GetConfiguration(configPath);
            if (keys != null)
            {
                foreach (string key in keys)
                {
                    config.AppSettings.Settings.Remove(key);
                }
            }
            else
            {
                config.AppSettings.Settings.Clear();
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }



        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string GetConnectionString(string name, string defaultconnStr = null, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            var connStrSettings = config.ConnectionStrings.ConnectionStrings[name];
            if (connStrSettings == null)
            {
                return defaultconnStr;
            }
            return connStrSettings.ConnectionString;
        }

        /// <summary>
        /// 获取指定配置文件+连接名称的连接字符串配置项
        /// </summary>
        public static ConnectionStringSettings GetConnectionStringSetting(string name, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            var connStrSettings = config.ConnectionStrings.ConnectionStrings[name];
            return connStrSettings;
        }

        /// <summary>
        /// 设置连接字符串的值（存在则更新，不存在则新增）
        /// </summary>
        public static void SetConnectionString(string name, string connstr, string provider, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            ConnectionStringSettings connStrSettings = config.ConnectionStrings.ConnectionStrings[name];
            if (connStrSettings != null)
            {
                connStrSettings.ConnectionString = connstr;
                connStrSettings.ProviderName = provider;
            }
            else
            {
                connStrSettings = new ConnectionStringSettings(name, connstr, provider);
                config.ConnectionStrings.ConnectionStrings.Add(connStrSettings);
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// 删除连接字符串配置项
        /// </summary>
        public static void RemoveConnectionString(string name, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            config.ConnectionStrings.ConnectionStrings.Remove(name);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// 获取所有的连接字符串配置项
        /// </summary>
        public static Dictionary<string, ConnectionStringSettings> GetConnectionStringSettings(string configPath = null)
        {
            var config = GetConfiguration(configPath);
            var connStrSettingDic = new Dictionary<string, ConnectionStringSettings>();
            var connStrSettings = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings item in config.ConnectionStrings.ConnectionStrings)
            {
                connStrSettingDic[item.Name] = item;
            }
            foreach (ConnectionStringSettings item in connStrSettings)
            {
                connStrSettingDic.Remove(item.Name);
            }
            return connStrSettingDic;
        }

        /// <summary>
        /// 设置多个连接字符串的值（存在则更新，不存在则新增）
        /// </summary>
        public static void SetConnectionStrings(IEnumerable<ConnectionStringSettings> connStrSettings, string configPath = null)
        {
            var config = GetConfiguration(configPath);
            foreach (var item in connStrSettings)
            {
                ConnectionStringSettings connStrSetting = config.ConnectionStrings.ConnectionStrings[item.Name];
                if (connStrSetting != null)
                {
                    connStrSetting.ConnectionString = item.ConnectionString;
                    connStrSetting.ProviderName = item.ProviderName;
                }
                else
                {
                    config.ConnectionStrings.ConnectionStrings.Add(item);
                }
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// 删除多个连接字符串配置项
        /// </summary>
        public static void RemoveConnectionStrings(string configPath = null, params string[] names)
        {
            var config = GetConfiguration(configPath);
            if (names != null)
            {
                foreach (string name in names)
                {
                    config.ConnectionStrings.ConnectionStrings.Remove(name);
                }
            }
            else
            {
                config.ConnectionStrings.ConnectionStrings.Clear();
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

    }
}
