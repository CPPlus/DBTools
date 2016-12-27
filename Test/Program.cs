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
            ExcelSpreadsheetDB db = new ExcelSpreadsheetDB(
                string.Format(@"
                    Provider=Microsoft.ACE.OLEDB.12.0; 
                    Data Source={0};
                    Extended Properties=""Excel 12.0;HDR=YES"";",
                    "read.xlsx"));
            db.Connect();

            Recordset recordset = db.Query(
                db.QueryProducer.Table(
                    "[Sheet1$]"));
            while (recordset.Read())
            {
                for (int i = 0; i < recordset.GetFieldCount(); i++)
                {
                    Console.WriteLine(recordset.GetString(i));
                }
                
            }
            recordset.Close();
        }
    }
}
