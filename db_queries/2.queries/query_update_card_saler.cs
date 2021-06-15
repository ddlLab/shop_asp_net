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
    public class QueryUpdateSalerCard : QueryBase
    {
        private string email;
        private string card;

        public QueryUpdateSalerCard(string _email,
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
            return @"UPDATE Salers
                    SET saler_paycard = @saler_paycard
                     WHERE saler_email = @saler_email;";
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@saler_email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@saler_paycard", SqlDbType.VarChar).Value = card;
        }
    }
}