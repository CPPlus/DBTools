 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public interface QueryProducer
    {
        string ColumnValuesFrequency(string table, string column);
        string ColumnNames(string table);
        string TableRowCount(string table);
        string Table(string table);
    }
}
