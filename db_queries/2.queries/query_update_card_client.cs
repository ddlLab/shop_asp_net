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
    public class QueryUpdateClientCard : QueryBase
    {
        private string email;
        private string card;

        public QueryUpdateClientCard(string _email,
                                     string _paycard,
                                     SqlConnection _sqlConnection,
                                     fCompleter _completer)
        : base(_sqlConnection, _completer, ExecType.NON_QUERY)
        {
            email = _email;
            card = _paycard;

        }
        public override string SqlCommand()
        {
            return @"UPDATE Clients
                    SET client_paycard = @client_paycard
                     WHERE client_email = @client_email;";
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@client_email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@client_paycard", SqlDbType.VarChar).Value = card;
        }
    }
}