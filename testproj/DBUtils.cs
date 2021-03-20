using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testproj
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-ORP9I23\SQLEXPRESS";

            string database = "shop";
            string username = @"dich";
            string password = "11qqAAzz";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
