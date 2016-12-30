using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public class SqlRecordset : Recordset
    {
        private SqlDataReader reader;

        public SqlRecordset()
        {
        }

        public SqlRecordset(SqlDataReader reader)
        {
            this.reader = reader;
        }

        public override int GetFieldCount()
        {
            return reader.FieldCount;
        }

        public override string GetString(int column)
        {
            string value = reader.IsDBNull(column) ? "" : reader.GetValue(column).ToString();
            return value;
        }

        public override DateTime? GetDateTime(int column)
        {
            DateTime? value = reader.IsDBNull(column) ? null : (DateTime?)reader.GetDateTime(column);
            return value;
        }

        public override void Close()
        {
            reader.Close();
        }

        override public bool Read()
        {
            return reader.Read();
        }

        public override Type GetFieldType(int column)
        {
            return reader.GetFieldType(column);
        }

        public override string GetFieldName(int column)
        {
            return reader.GetName(column);
        }
    }
}
