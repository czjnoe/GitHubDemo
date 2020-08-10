using AutoPulishWebOrDb.Help;
using AutoPulishWebOrDb.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using static AutoPulishWebOrDb.Help.Enums;

namespace AutoPulishWebOrDb.Dal
{
    public class SqlServerDal : BaseDal
    {
        private string isExistDb = @"select count(1) from sys.databases where name='{0}'";

        //private string createDb = @"create database {0}";

        private string createDb = @"
    create database {0}
    on  primary        --表示属于 primary 文件组
    (
        name='{1}_data',        -- 主数据文件的逻辑名称
        filename='{5}\{2}.mdf',    -- 主数据文件的物理名称
        size=5mb,    --主数据文件的初始大小
        maxsize=1024mb,     -- 主数据文件增长的最大值
        filegrowth=10%        --主数据文件的增长率
    )
    log on
    (
        name='{3}_log',        -- 日志文件的逻辑名称
        filename='{6}\{4}_log.ldf',    -- 日志文件的物理名称
        size=2mb,            --日志文件的初始大小
        maxsize=200mb,        --日志文件增长的最大值
        filegrowth=1mb        --日志文件的增长率
    )";

        private const string NORECOVERY = "NORECOVERY";
        private const string RECOVERY = "RECOVERY";

        private string fullRestoreSql = @"RESTORE DATABASE {0}  
   FROM disk='{1}' 
   WITH {9}, FILE = {8},move '{2}' to '{3}\{4}.mdf',
            move '{5}' to '{6}\{7}_log.ldf';
";
        private string diffRestoreSql = @"RESTORE DATABASE {0}  
   FROM disk='{1}'   
   WITH FILE = {2},  
   RECOVERY; ";

        private string bakDetailSql = @"restore headeronly from disk = '{0}'";

        private string bakFileSql = " restore  filelistonly from disk = '{0}'";

        public SqlServerDal(string connString) : base(connString)
        {
        }

        public override bool CreateDb(string dbName, string dbPath)
        {
            try
            {
                using (var db = DapperFactory.GetConnection(MyDbType.SqlServer, this._connString))
                {
                    var result = db.Execute(createDb.ToFormat(dbName, dbName, dbName, dbName, dbName, dbPath, dbPath));
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public override bool RestoreDb(string dbName, string dbPath, string savePath)
        {
            try
            {
                using (var db = DapperFactory.GetConnection(MyDbType.SqlServer, this._connString))
                {
                    var dynamic = db.Query<dynamic>(bakDetailSql.ToFormat(dbPath)).ToList();

                    var full=dynamic.Where(w => (string)w.BackupTypeDescription == "Database").OrderByDescending(o => o.Position).ToList();
                    var diff = dynamic.Where(w => (string)w.BackupTypeDescription == "Database Differential").OrderByDescending(o => o.Position).ToList();
                    if (full.Count()>0)
                    {
                        string fullPosition =Convert.ToString( full[0].Position);
                        var dynamicFile = db.Query<dynamic>(bakFileSql.ToFormat(dbPath)).ToList();
                        string mdfName = dynamicFile[0].LogicalName;
                        string ldfName = dynamicFile[1].LogicalName;

                        if (diff.Count() > 0)
                        {
                            var result = db.Execute(fullRestoreSql.ToFormat
                            (dbName, dbPath,
                                mdfName, savePath, dbName, ldfName, savePath,
                                dbName, fullPosition,NORECOVERY));
                        }
                        else
                        {
                            var result = db.Execute(fullRestoreSql.ToFormat
                            (dbName, dbPath,
                                mdfName, savePath, dbName, ldfName, savePath,
                                dbName, fullPosition, RECOVERY));
                        }
                    }
                   
                    if (diff.Count() > 0)
                    {
                      string diffPosition= Convert.ToString(diff[0].Position);
                        var result1 = db.Execute(diffRestoreSql.ToFormat
                       (dbName, dbPath, diffPosition));
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public override bool IsExistDb(string dbName)
        {
            try
            {
                using (var db = DapperFactory.GetConnection(MyDbType.SqlServer, this._connString))
                {
                    var result = Convert.ToInt32(db.ExecuteScalar(isExistDb.ToFormat(dbName)));
                    if (result > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public override bool TestConnection()
        {
            try
            {
                using (var db = DapperFactory.GetConnection(MyDbType.SqlServer, this._connString))
                {
                    db.Open();
                    db.Dispose();
                    db.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public override bool CreateUser(string userName, string passWord, string dbName)
        {
            throw new NotImplementedException();
        }
    }
}
