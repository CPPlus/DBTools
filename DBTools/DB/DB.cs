using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public abstract class DB
    {
        public QueryProducer QueryProducer { get; protected set; }
        public abstract void Connect();
        public abstract void Close();
        public abstract Recordset Query(string query);
    }
}
