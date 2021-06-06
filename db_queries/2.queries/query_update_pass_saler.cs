using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using db_queries._3.structures;
using System.Data;
using System.Data.SqlClient;

namespace db_queries._2.queries
{
    public class QueryUpdateSalerPass : QueryBase
    {
        private string password;
        private string email;

        public QueryUpdateSalerPass(string _email,
                                     string _password,
                                     SqlConnection _sqlConnection,
                                     fCompleter _completer)
        : base(_sqlConnection, _completer, ExecType.NON_QUERY)
        {
            password = _password;
            email = _email;

        }
        public override string SqlCommand()
        {
            return @"UPDATE Salers
                    SET saler_password = @saler_password
                     WHERE saler_email = @saler_email;";
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@saler_email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@saler_password", SqlDbType.VarChar).Value = password;
        }
    }
}