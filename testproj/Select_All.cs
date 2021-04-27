using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testproj
{
    public class eUser
    {
        public long id;
        public string login;
        public string email;
        public string phone;
        public int balance;

        public override string ToString()
        {
            return $"id:{id}, login:{login}, email:{email}, phone: {phone}, balance: {balance}";
        }
    }


    public class SelectAllUsers : QueryBase
    {
        public SelectAllUsers(SqlConnection _sqlConnection)
        : base(_sqlConnection, ExecType.READER)
        {
            users = new List<eUser>();
        }
        public override string SqlCommand()
        {
            return "Select * FROM Clients";
        }
        public override void PrepareParams(SqlCommand cmd)
        { }
        public override void OnQueryCompleted(DbDataReader reader)
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    eUser user = new eUser();
                    user.id = (long)GetDataFromDb(reader, "client_id", eValType.LONG);
                    user.login = (string)GetDataFromDb(reader, "client_nickname", eValType.STRING);
                    user.email = (string)GetDataFromDb(reader, "client_email", eValType.STRING);
                    user.phone = (string)GetDataFromDb(reader, "client_phone", eValType.STRING);
                    user.balance = (int) GetDataFromDb(reader, "balance", eValType.INT);
                    users.Add(user);
                }
            }
        }
        public List<eUser> users;
    }
}
