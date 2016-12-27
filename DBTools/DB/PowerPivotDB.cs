using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ADODB;

namespace DBTools
{
    public class PowerPivotDB : DB
    {
        private Workbook workbook;

        public PowerPivotDB()
        {
            QueryProducer = new DaxQueryProducer();
        }
        
        override public void Connect()
        {
            Application application = (Application)Marshal.GetActiveObject("Excel.Application");
            workbook = application.ActiveWorkbook;
            workbook.Model.Initialize();
        }

        override public void Close()
        {

        }

        override public Recordset Query(string query)
        {
            Connection connection = workbook.Model.DataModelConnection.ModelConnection.ADOConnection;

            object recordsAffected = null;
            ADODB.Recordset recordset = connection.Execute(query, out recordsAffected);

            return new AdodbRecordset(recordset);
        }
    }
}
