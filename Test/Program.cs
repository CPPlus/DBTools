using DBTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneralDB db = new GeneralDB(
                TextFileConnectionString(@"C:\Users\Grigorov\Documents\User Created\Tools\DBTools\Test\bin\Debug\"));
            db.Connect();

            Recordset recordset = db.QueryResult(
                "SELECT * FROM test.txt WHERE Id = 1");
            while (recordset.Read())
            {
                for (int i = 0; i < recordset.GetFieldCount(); i++)
                {
                    Console.Write(recordset.GetString(i) + ", ");
                }
                Console.WriteLine();
                
            }
            recordset.Close();
        }

        static string ExcelFileConnectionString(string fileName)
        {
            return string.Format(@"
                    Provider=Microsoft.ACE.OLEDB.12.0; 
                    Data Source={0};
                    Extended Properties=""Excel 12.0;HDR=YES"";",
                    fileName);
        }

        static string TextFileConnectionString(string fileName)
        {
            return string.Format(@"
                    Provider=Microsoft.ACE.OLEDB.12.0;
                    Data Source={0};
                    Extended Properties=""text;HDR=Yes;FMT=CSVDelimited""", fileName);
        }
    }
}
