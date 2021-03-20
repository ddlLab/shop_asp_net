using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testproj
{

    class eUser
    {
        public long id;
        public string login;
        public string email;
        public string password;

        public override string ToString()
        {
            return $"id:{id}, login:{login}, email:{email}, password: {password}";
        }
    }


    class SelectAllUsers : QueryBase
    {
        public SelectAllUsers(SqlConnection _sqlConnection)
        : base(_sqlConnection, ExecType.READER)
        {
            users = new List<eUser>();
        }
        public override string SqlCommand()
        {
            return "Select * FROM user_info";
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
                    user.id = (long)GetDataFromDb(reader, "id", eValType.LONG);
                    user.login = (string)GetDataFromDb(reader, "login", eValType.STRING);
                    user.email = (string)GetDataFromDb(reader, "email", eValType.STRING);
                    user.password = (string)GetDataFromDb(reader, "pass", eValType.STRING);
                    users.Add(user);
                }
            }
        }
        public List<eUser> users;
    }
}
