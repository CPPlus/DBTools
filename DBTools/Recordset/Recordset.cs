using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public abstract class Recordset
    {
        public abstract int GetFieldCount();
        public abstract bool Read();
        public abstract string GetString(int column);
        public abstract Type GetFieldType(int column);
        public abstract void Close();
        public abstract string GetFieldName(int column);
        public void Print()
        {
            while (Read())
            {
                for (int i = 0; i < GetFieldCount(); i++)
                {
                    Console.Write("'" + GetString(i) + "' ");
                }
                Console.WriteLine();
            }
        }
    }
}
