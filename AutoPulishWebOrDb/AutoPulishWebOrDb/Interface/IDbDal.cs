using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoPulishWebOrDb.Interface
{
    public  interface IDbDal
    {
        bool IsExistDb(string dbName);
        bool CreateDb(string dbName, string dbPath);
        bool RestoreDb(string dbName, string dbPath, string savePath);
        bool TestConnection();
    }
}
