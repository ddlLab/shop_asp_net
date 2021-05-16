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
    public class QuerySelectSalerByEmailNick : QueryBase
    {
        private string      nick;
        private string      email;
        public List<eSaler> salers;
        public QuerySelectSalerByEmailNick(string        _nick,
                                           string        _email,
                                           SqlConnection _sqlConnection,
                                           fCompleter    _completer)
        : base(_sqlConnection, _completer, ExecType.READER)
        {
            nick  = _nick;
            email = _email;
            salers = new List<eSaler>();
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@nick", SqlDbType.VarChar).Value = nick;
        }

        public override string SqlCommand()
        {
            string sql = "SELECT * FROM Salers";
            if (nick.Length > 0 && email.Length > 0)
            {
                sql += " WHERE saler_nickname=@nick OR saler_email=@email";
            }
            else if (nick.Length > 0)
            {
                sql += " WHERE saler_nickname=@nick";
            }
            else if (email.Length > 0)
            {
                sql += " WHERE saler_email=@email";
            }
            return sql;
        }

        public override void DataRead(DbDataReader reader)
        {
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    eSaler saler      = new eSaler();
                    saler.Id           = (long)GetDataFromDb(reader, "saler_id", eValType.LONG);
                    saler.Email        = (string)GetDataFromDb(reader, "saler_email", eValType.STRING);
                    saler.Password     = (string)GetDataFromDb(reader, "saler_password", eValType.STRING);
                    saler.Nickname     = (string)GetDataFromDb(reader, "saler_nickname", eValType.STRING);
                    saler.Paycard      = (string)GetDataFromDb(reader, "saler_paycard", eValType.STRING);
                    saler.Phone        = (string)GetDataFromDb(reader, "saler_phone", eValType.STRING);
                    saler.Photo        = (string)GetDataFromDb(reader, "saler_photo", eValType.STRING);
                    saler.Desc         = (string)GetDataFromDb(reader, "saler_desc", eValType.STRING);
                    saler.Balance      = (int)GetDataFromDb(reader, "balance", eValType.INT);
                    saler.IsBlocked    = (bool)GetDataFromDb(reader, "is_blocked", eValType.BOOL);
                    salers.Add(saler);
                }
            }
        }
    }
}
