using AutoPulishWebOrDb.Help;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AutoPulishWebOrDb.Help.Enums;

namespace AutoPulishWebOrDb.Dal
{
    public class OracleDal : BaseDal
    {
        private string isExistTableSpace = @"select * from dba_tablespaces
                            where tablespace_name ='{0}'";

        private string createTableSpace = @"CREATE TABLESPACE {0}
 
         datafile '{1}\{2}.dbf'
 
         SIZE 32M
 
         AUTOEXTEND ON
 
         NEXT 32M MASIZE UNLIMITED
 
         EXTENT MANAGEMENT LOCAL;";

        private string createUser = @" CREATE USER {0} IDENTIFIED BY {1} 
                        DEFAULT TABLESPACE {2};
            grant connect,resource,dba to {3};
";
        public OracleDal(string connString) : base(connString)
        {
        }

        public override bool CreateDb(string dbName, string dbPath)
        {
            using (var db = DapperFactory.GetConnection(MyDbType.Oracle, this._connString))
            {
                var result = db.Execute(createTableSpace.ToFormat(dbName, dbPath, dbName));
                if (result > 0)
                    return true;
            }
            return false;
        }

        public override bool CreateUser(string userName, string passWord, string dbName)
        {
            using (var db = DapperFactory.GetConnection(MyDbType.Oracle, this._connString))
            {
                var result = db.Execute(createUser.ToFormat(userName, passWord, dbName, userName));
                if (result > 0)
                    return true;
            }
            return false;
        }

        public override bool IsExistDb(string dbName)
        {
            using (var db = DapperFactory.GetConnection(MyDbType.Oracle, this._connString))
            {
                var result = db.Execute(isExistTableSpace.ToFormat(dbName));
                if (result > 0)
                    return true;
            }
            return false;
        }

        public override bool RestoreDb(string dbName, string dbPath)
        {
            throw new NotImplementedException();
        }

        public override bool TestConnection()
        {
            try
            {
                using (var db = DapperFactory.GetConnection(MyDbType.Oracle, this._connString))
                {
                    db.Open();
                    db.Dispose();
                    db.Close();
                    return true;
                }
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
