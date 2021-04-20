using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace db_queries
{

    public delegate void fCompleter(QueryBase query);

    public abstract class QueryBase
    {
        public enum ExecType
        {
            READER,
            NON_QUERY,
        }
        public QueryBase(SqlConnection _sqlConnection,
                         fCompleter    _completer,
                         ExecType      _type)
        {
            sqlConnection = _sqlConnection;
            completer     = _completer;
            type          = _type;
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
                    DataRead(reader);
                }
            }
            if(completer != null)
            {
                completer(this);
            }
        }
        public virtual void DataRead(DbDataReader cmd)
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

        SqlConnection sqlConnection = null;
        fCompleter    completer = null;
        ExecType type = ExecType.NON_QUERY;
    }
}
