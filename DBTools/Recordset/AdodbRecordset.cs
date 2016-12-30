using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTools
{
    public class AdodbRecordset : Recordset
    {
        private ADODB.Recordset recordset;
        private bool isFirstRead = true;

        public AdodbRecordset()
        {
        }

        public AdodbRecordset(ADODB.Recordset recordset)
        {
            this.recordset = recordset;
        }

        override public string GetString(int column)
        {
            return recordset.Fields[column].Value.ToString();
        }

        override public int GetFieldCount()
        {
            return recordset.Fields.Count;
        }

        public override void Close()
        {
            recordset.Close();
        }

        override public bool Read()
        {
            if (isFirstRead)
            {
                isFirstRead = false;
                return !recordset.EOF;
            }

            recordset.MoveNext();
            return !recordset.EOF;
        }

        public override Type GetFieldType(int column)
        {
            switch (recordset.Fields[column].Type)
            {
                case ADODB.DataTypeEnum.adBoolean:
                    return typeof(bool);
                case ADODB.DataTypeEnum.adDouble:
                    return typeof(double);
                case ADODB.DataTypeEnum.adDecimal:
                    return typeof(decimal);
                case ADODB.DataTypeEnum.adInteger:
                    return typeof(int);
            }

            return null;
        }

        public override string GetFieldName(int column)
        {
            return recordset.Fields[column].Name;
        }

        public override DateTime? GetDateTime(int column)
        {
            throw new NotImplementedException();
        }
    }
}
