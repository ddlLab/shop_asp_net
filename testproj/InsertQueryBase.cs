using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testproj
{
   public abstract class QueryBase
    {
        public enum ExecType
        {
            READER,
            NON_QUERY,
        }
        public QueryBase(SqlConnection _sqlConnection,
                         ExecType      _type)
        {
            sqlConnection = _sqlConnection;
            type = _type;
        }
        public abstract string SqlCommand();
        public abstract void PrepareParams(SqlCommand cmd);
        public void Execute()
        {
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = SqlCommand();
            PrepareParams(cmd);
            if (type == ExecType.NON_QUERY)
            {
                cmd.ExecuteNonQuery();
            }
            else
            {
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    OnQueryCompleted(reader);
                }
            }
        }
        public virtual void OnQueryCompleted(DbDataReader cmd)
        {

        } 

        public enum eValType
        {
            INT,
            LONG,
            FLOAT,
            BOOL,
            STRING,
            TIMESHTAMP
        }
        static int GetRowIdByName(DbDataReader reader, string rowName)
        {
            int id = reader.GetOrdinal(rowName);
            return reader.IsDBNull(id) ? -1 : id;
        }
        public static object GetDataFromDb(DbDataReader reader, string rowName, eValType valType)
        {
            int id = GetRowIdByName(reader, rowName);
            if (id != -1)
            {
                switch (valType)
                {
                    case eValType.LONG:
                        return reader.GetInt64(id);
                    case eValType.INT:
                        return reader.GetInt32(id);
                    case eValType.BOOL:
                        return reader.GetBoolean(id);
                    case eValType.STRING:
                        return reader.GetString(id);
                    case eValType.FLOAT:
                        return reader.GetFloat(id);
                }
                throw new Exception($"Unknown ValType:{valType}");
            }
            throw new Exception($"Unknown rowName:{rowName}");
        }

        private static void SetupVal(DbDataReader reader, ref float _item, int id)
        {
            _item = reader.GetFloat(id);
        }

        private static void SetupVal(DbDataReader reader, ref bool _item, int id)
        {
            _item = reader.GetBoolean(id);
        }

        static void SetupVal(DbDataReader reader, ref string _item, int id)
        {
            _item = reader.GetString(id);
        }
        static void SetupVal(DbDataReader reader, ref int _item, int id)
        {
            _item = reader.GetInt32(id);
        }
        static void SetupVal(DbDataReader reader, ref long _item, int id)
        {
            _item = reader.GetInt64(id);
        }

        SqlConnection   sqlConnection = null;
        ExecType        type = ExecType.NON_QUERY;
    }

    class InsertUser : QueryBase
    {
        public InsertUser(string _login,
                          string _email,
                          string _password,
                          SqlConnection _sqlConnection)
        : base(_sqlConnection, ExecType.NON_QUERY)
        {
            login       = _login;
            email       = _email;
            password    = _password;
        }
        public override string SqlCommand() {
            return "Insert into user_info (login, email, pass) "
                        + " values (@login, @email, @pass) ";
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@login", SqlDbType.Text).Value  = login;
            cmd.Parameters.Add("@email", SqlDbType.Text).Value  = email;
            cmd.Parameters.Add("@pass", SqlDbType.Text).Value   = password;
        }
        
        public string login;
        public string email;
        public string password;

    }

    class SelectUserByEmail : QueryBase
    {
        public SelectUserByEmail(string _email, SqlConnection _sqlConnection)
        : base(_sqlConnection, ExecType.READER)
        { email = _email; }
        public override string SqlCommand()
        {
            return "Select * FROM user_info WHERE email=@email";
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@email", SqlDbType.Text).Value = email;
        }
        public override void OnQueryCompleted(DbDataReader reader)
        {
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    user = new eUser();
                    user.id = (long)GetDataFromDb(reader, "id", eValType.LONG);
                    user.login = (string)GetDataFromDb(reader, "login", eValType.STRING);
                    user.email = (string)GetDataFromDb(reader, "email", eValType.STRING);
                    user.phone = (string)GetDataFromDb(reader, "client_phone", eValType.STRING);
                    user.balance = (int)GetDataFromDb(reader, "balance", eValType.INT);
                }
            }
        }
        public string email;
        public eUser user = null;
    }
    //    update email for user

    class SelectUserByLogin : QueryBase
    {
        public SelectUserByLogin(
            string _login,
            SqlConnection _sqlConnection)
        : base(_sqlConnection, ExecType.READER)
        { login = _login; }
        public override string SqlCommand()
        {
            return "Select * FROM user_info WHERE login=@login";
        }
        public override void PrepareParams(SqlCommand cmd)
        {
            cmd.Parameters.Add("@login", SqlDbType.Text).Value = login;
        }
        public override void OnQueryCompleted(DbDataReader reader)
        {
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    user = new eUser();
                    user.id = (long)GetDataFromDb(reader, "id", eValType.LONG);
                    user.login = (string)GetDataFromDb(reader, "login", eValType.STRING);
                    user.email = (string)GetDataFromDb(reader, "email", eValType.STRING);
                    user.phone = (string)GetDataFromDb(reader, "client_phone", eValType.STRING);
                    user.balance = (int)GetDataFromDb(reader, "balance", eValType.INT);
                }
            }
        }
        public string login;
        public eUser user = null;
    }
}
