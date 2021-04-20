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
    public class QueryInsertSaler : QueryBase
    {
        public eSaler saler = null;
        public QueryInsertSaler(eSaler          _saler,
                                SqlConnection   _sqlConnection,
                                fCompleter      _completer) 
        : base(_sqlConnection, _completer, ExecType.NON_QUERY)
        {
            saler = _saler;
        }
        public override string SqlCommand()
        {
            return @"INSERT INTO Salers  (saler_email,
                                          saler_password,
                                          saler_nickname,
                                          saler_phone,
                                          saler_photo,
                                          saler_desc,
                                          saler_paycard,
                                          balance,
                                          is_blocked)
                     VALUES(@saler_email,
                            @saler_password,
                            @saler_nickname,
                            @saler_phone,
                            @saler_photo,
                            @saler_desc,
                            @saler_paycard,
                            @balance,
                            @is_blocked)";
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@saler_email", SqlDbType.Text).Value = saler.Email;
            cmd.Parameters.Add("@saler_password", SqlDbType.Text).Value = saler.Password;
            cmd.Parameters.Add("@saler_nickname", SqlDbType.Text).Value = saler.Nickname;
            cmd.Parameters.Add("@saler_phone", SqlDbType.Text).Value = saler.Phone;
            cmd.Parameters.Add("@saler_photo", SqlDbType.Text).Value = saler.Photo;
            cmd.Parameters.Add("@saler_desc", SqlDbType.Text).Value = saler.Desc;
            cmd.Parameters.Add("@saler_paycard", SqlDbType.Text).Value = saler.Paycard;
            cmd.Parameters.Add("@balance", SqlDbType.Int).Value = saler.Balance;
            cmd.Parameters.Add("@is_blocked", SqlDbType.Bit).Value = saler.IsBlocked;
        }
    }
}

