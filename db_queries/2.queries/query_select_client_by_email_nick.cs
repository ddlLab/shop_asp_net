using db_queries._3.structures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_queries._2.queries
{
    public class QuerySelectClientByEmailNick : QueryBase
    {
        private string       nick;
        private string       email;
        public List<eClient> clients;
        public QuerySelectClientByEmailNick(string          _nick,
                                            string          _email,
                                            SqlConnection   _sqlConnection,
                                            fCompleter      _completer)
        : base(_sqlConnection, _completer, ExecType.READER)
        {
            nick = _nick;
            email = _email;
            clients = new List<eClient>();
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@nick", SqlDbType.VarChar).Value = nick;
        }

        public override string SqlCommand()
        {
            string sql = "SELECT * FROM Clients";
            if (nick.Length > 0 && email.Length > 0)
            {
                sql += " WHERE client_nickname=@nick OR client_email=@email";
            }
            else if (nick.Length > 0)
            {
                sql += " WHERE client_nickname=@nick";
            }
            else if (email.Length > 0)
            {
                sql += " WHERE client_email=@email";
            }
            return sql;
        }

        public override void DataRead(DbDataReader reader)
        {
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    eClient client   = new eClient();
                    client.Id        = (long)GetDataFromDb(reader, "client_id", eValType.LONG);
                    client.Email     = (string)GetDataFromDb(reader, "client_email", eValType.STRING);
                    client.Password  = (string)GetDataFromDb(reader, "client_password", eValType.STRING);
                    client.Nickname  = (string)GetDataFromDb(reader, "client_nickname", eValType.STRING);
                    client.Paycard   = (string)GetDataFromDb(reader, "client_paycard", eValType.STRING);
                    client.Phone     = (string)GetDataFromDb(reader, "client_phone", eValType.STRING);
                    client.Photo     = (string)GetDataFromDb(reader, "client_photo", eValType.STRING);
                    client.Desc      = (string)GetDataFromDb(reader, "client_desc", eValType.STRING);
                    client.Balance   = (int)GetDataFromDb(reader, "balance", eValType.INT);
                    client.IsBlocked = (bool)GetDataFromDb(reader, "is_blocked", eValType.BOOL);
                    clients.Add(client);
                }
            }
        }
    }
}
