using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_queries
{
    public class DBSQLServerUtils
    {

        public static SqlConnection sqlConnection = null;

        public static void Init(string datasource,
                                string database,
                                string username,
                                string password)
        {
            sqlConnection = GetDBConnection(datasource,
                                            database,
                                            username,
                                            password);
        }
        public static SqlConnection GetDBConnection(string datasource,
                                                    string database,
                                                    string username,
                                                    string password)
        {
            string connString = @"Data Source=" + datasource
                              + ";Initial Catalog=" + database
                              + ";Persist Security Info=True;"
                              + "User ID=" + username
                              + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }


    }
}
