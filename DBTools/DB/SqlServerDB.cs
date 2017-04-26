using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public class SqlServerDB : DB
    {
        private string connectionString;
        private SqlConnection connection;

        public SqlServerDB(string connectionString)
        {
            this.connectionString = connectionString;
            QueryProducer = new SqlQueryProducer();
        }

        override public void Connect()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        override public void Close()
        {
            connection.Close();
        }

        override public Recordset QueryResult(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandTimeout = 0;
            return new SqlRecordset(command.ExecuteReader());
        }
    }
}
