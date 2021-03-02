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
            string datasource = @"DESKTOP-HIEQ37A\SQLEXPRESS";

            string database = "service";
            string username = @"qwerty";
            string password = "11qqAAzz";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}
