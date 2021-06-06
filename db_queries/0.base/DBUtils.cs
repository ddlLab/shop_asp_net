using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_queries
{
    public class DBUtils
    {
        static string datasource = @"DESKTOP-ORP9I23\SQLEXPRESS";
        static string database = "shop";
        static string username = @"dich";
        static string password = "11qqAAzz";
        public static SqlConnection GetDBConnection()
        {
            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
