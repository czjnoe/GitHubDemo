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

        private string createDb = @"use master
go 
begin
    create database {0}
    on  primary        --表示属于 primary 文件组
    (
        name='{1}'_data,        -- 主数据文件的逻辑名称
        filename='{5}\'{2}'_data.mdf',    -- 主数据文件的物理名称
        size=5mb,    --主数据文件的初始大小
        maxsize=100mb,     -- 主数据文件增长的最大值
        filegrowth=15%        --主数据文件的增长率
    )
    log on
    (
        name='{3}_log',        -- 日志文件的逻辑名称
        filename='{6}\{4}_log.ldf',    -- 日志文件的物理名称
        size=2mb,            --日志文件的初始大小
        maxsize=20mb,        --日志文件增长的最大值
        filegrowth=1mb        --日志文件的增长率
    )
end";

        private string restoreSql = @"restore database {0} from disk='{1}' with REPLACE";

        public SqlServerDal(string connString) : base(connString)
        {
        }

        public override bool CreateDb(string dbName,string dbPath)
        {
            using (var db = DapperFactory.GetConnection(MyDbType.SqlServer, this._connString))
            {
                var result = db.Execute(createDb.ToFormat(dbName, dbName, dbName, dbName, dbName, dbPath, dbPath));
                if (result > 0)
                    return true;
            }
            return false;
        }

        public override bool RestoreDb(string dbName, string dbPath)
        {
            using (var db = DapperFactory.GetConnection(MyDbType.SqlServer, this._connString))
            {
                var result = db.Execute(restoreSql.ToFormat(dbName, dbPath));
                if (result > 0)
                    return true;
            }
            return false;
        }

        public override bool IsExistDb(string dbName)
        {
            using (var db = DapperFactory.GetConnection(MyDbType.SqlServer, this._connString))
            {
                var result = db.Execute(isExistDb.ToFormat(dbName));
                if (result > 0)
                    return true;
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
