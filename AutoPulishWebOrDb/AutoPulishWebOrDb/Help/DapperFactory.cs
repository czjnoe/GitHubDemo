using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using static AutoPulishWebOrDb.Help.Enums;

namespace AutoPulishWebOrDb.Help
{
    public class DapperFactory
    {
        public static IDbConnection GetConnection(MyDbType type, string connStr)
        {
            IDbConnection dbConnection = null;
            if (type == MyDbType.MySQL)
            {
                dbConnection = new MySqlConnection(connStr);
            }
            else if (type == MyDbType.Oracle)
            {
                dbConnection = new OracleConnection(connStr);
            }
            else if (type == MyDbType.SqlServer)
            {
                dbConnection = new SqlConnection(connStr);
            }
            else if (type == MyDbType.SQlite)
            {
                dbConnection = new SQLiteConnection(connStr);
            }
            return dbConnection;
        }
    }
}
