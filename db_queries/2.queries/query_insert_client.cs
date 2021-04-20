using db_queries._3.structures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_queries._2.queries
{
    public class QueryInsertClient : QueryBase
    {
        public eClient client = null;
        public QueryInsertClient(eClient       _client,
                                 SqlConnection _sqlConnection,
                                 fCompleter    _completer)
        :  base(_sqlConnection, _completer, ExecType.NON_QUERY)
        {
            client = _client;
        }
        public override string SqlCommand()
        {
            return @"INSERT INTO Clients (client_email,
                                          client_password,
                                          client_nickname,
                                          client_phone,
                                          client_photo,
                                          client_desc,
                                          client_paycard,
                                          balance,
                                          is_blocked)
                     VALUES(@client_email,
                            @client_password,
                            @client_nickname,
                            @client_phone,
                            @client_photo,
                            @client_desc,
                            @client_paycard,
                            @balance,
                            @is_blocked)";
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@client_email",    SqlDbType.Text).Value = client.Email;
            cmd.Parameters.Add("@client_password", SqlDbType.Text).Value = client.Password;
            cmd.Parameters.Add("@client_nickname", SqlDbType.Text).Value = client.Nickname;
            cmd.Parameters.Add("@client_phone",    SqlDbType.Text).Value = client.Phone;
            cmd.Parameters.Add("@client_photo",    SqlDbType.Text).Value = client.Photo;
            cmd.Parameters.Add("@client_desc",     SqlDbType.Text).Value = client.Desc;
            cmd.Parameters.Add("@client_paycard",  SqlDbType.Text).Value = client.Paycard;
            cmd.Parameters.Add("@balance",         SqlDbType.Int).Value  = client.Balance;
            cmd.Parameters.Add("@is_blocked",      SqlDbType.Bit).Value  = client.IsBlocked;
        }
    }
}
