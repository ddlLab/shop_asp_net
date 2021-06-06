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
    public class QueryUpdateClientPass : QueryBase
    {
        private string password;
        private string email;
      
        public QueryUpdateClientPass(string _email,
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
            return @"UPDATE Clients
                    SET client_password = @client_password
                     WHERE client_email = @client_email;";
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@client_email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@client_password", SqlDbType.VarChar).Value = password;
        }
    }
}
