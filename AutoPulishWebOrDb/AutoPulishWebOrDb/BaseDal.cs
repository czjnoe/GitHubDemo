using AutoPulishWebOrDb.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoPulishWebOrDb
{
    public abstract class BaseDal : IDbDal
    {
        public string _connString = string.Empty;
        public BaseDal(string connString)
        {
            _connString = connString;
        }
        public abstract bool CreateDb(string dbName, string dbPath);
        public abstract bool IsExistDb(string dbName);
        public abstract bool RestoreDb(string dbName, string dbPath);
        public abstract bool TestConnection();

        public abstract bool CreateUser(string userName, string passWord,string dbName);
    }
}
