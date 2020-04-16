using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FreeSqlDemo.Util
{
    public class FreeSqlHelp
    {
        private static Dictionary<string, string> configDic = null;

        private static IFreeSql fsql = null;

        private static Dictionary<string, IFreeSql> DbCache = new Dictionary<string, IFreeSql>();

        static FreeSqlHelp()
        {
            configDic = new Dictionary<string, string>();
        }
        public static IFreeSql GetFreeSqlClient(FreeSql.DataType DbType, string name = "default")
        {
            if (!DbCache.ContainsKey(name))
            {
                fsql = new FreeSql.FreeSqlBuilder()
             .UseConnectionString(DbType, GetConnectionConfig(DbType, name))
             .UseAutoSyncStructure(true)//自动同步实体结构到数据库
             .UseSyncStructureToUpper(true)//转大小写同步（oracle表都是大写，需要开启大小同步,否则会创建一个名称小写的新表）
             .UseMonitorCommand(cmd => Trace.WriteLine(cmd.CommandText))
             //跟踪SQL执行语句
             .Build();
                //          fsql = new FreeSql.FreeSqlBuilder()
                //.UseConnectionString(FreeSql.DataType.Sqlite,GetConnectionConfig(DbType, name))
                //.UseAutoSyncStructure(true) //自动同步实体结构到数据库
                //.Build();
                DbCache.Add(name, fsql);
            }
            return DbCache[name];
        }

        private static string GetConnectionConfig(FreeSql.DataType type, string name)
        {
            if (!configDic.ContainsKey(name))
            {
                string connstr = System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
                configDic.Add(name, connstr);
            }
            return configDic[name];
        }
    }
}
