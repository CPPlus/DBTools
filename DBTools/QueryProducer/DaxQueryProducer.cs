using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public class DaxQueryProducer : QueryProducer
    {
        public string ColumnNames(string table)
        {
            throw new NotImplementedException();
        }

        public string ColumnValuesFrequency(string table, string column)
        {
            return string.Format(
                @"EVALUATE 
                    ADDCOLUMNS(
                        VALUES('{0}'[{1}]),
                        ""Frequency"",
                        COUNTROWS(
                            FILTER(
                                SELECTCOLUMNS(
                                    '{0}',
                                    ""{1}"", 
                                    '{0}'[{1}]), 
                                [{1}] = EARLIER([{1}])
                            )
                        )
                    )", table, column);
        }

        public string Table(string table)
        {
            throw new NotImplementedException();
        }

        public string TableRowCount(string table)
        {
            return string.Format(
                @"EVALUATE ROW(""Row Count"", COUNTROWS('{0}'))",
                table);
        }
    }
}
