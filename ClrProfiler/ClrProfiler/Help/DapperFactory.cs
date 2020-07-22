
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using static ClrProfiler.Help.Enums;

namespace ClrProfiler.Help
{
    public class DapperFactory
    {
        public static IDbConnection GetConnection(MyDbType type, string connStr)
        {
            IDbConnection dbConnection = null;
            if (type == MyDbType.Oracle)
            {
                dbConnection = new OracleConnection(connStr);
            }
            else if (type == MyDbType.SqlServer)
            {
                dbConnection = new SqlConnection(connStr);
            }
            return dbConnection;
        }
    }
}
