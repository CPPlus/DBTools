using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public class SqlQueryProducer : QueryProducer
    {
        public string ColumnNames(string table)
        {
            return string.Format(
                @"SELECT COLUMN_NAME
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME='{0}'",
                table);
        }

        public string ColumnValuesFrequency(string table, string column)
        {
            return string.Format(
                @"SELECT 
                    [{1}], Count(*) 
                FROM 
                    [{0}] 
                GROUP BY 
                    [{1}]",
                table, column);
        }

        public string Table(string table)
        {
            return string.Format(@"SELECT * FROM [{0}]", table);
        }

        public string TableRowCount(string table)
        {
            return string.Format(
                @"SELECT COUNT(*) AS 'Row Count' FROM [{0}]",
                table);
        }
    }
}
