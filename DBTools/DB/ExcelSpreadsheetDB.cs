using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public class ExcelSpreadsheetDB : DB
    {
        private string connectionString;
        private ADODB.Connection connection;

        public ExcelSpreadsheetDB(string connectionString)
        {
            this.connectionString = connectionString;

            QueryProducer = new SqlQueryProducer();

            connection = new ADODB.Connection();
        }

        public override void Connect()
        {
            connection.Open(connectionString);
        }

        public override Recordset Query(string query)
        {
            object recordsAffected;
            ADODB.Recordset recordset = connection.Execute(query, out recordsAffected);
            return new AdodbRecordset(recordset);
        }

        public override void Close()
        {
            connection.Close();
        }
    }
}
