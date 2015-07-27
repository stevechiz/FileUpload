using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel.Core.OpenXmlFormat;

namespace File_Upload.Services
{
    public class ExcelFileParser
    {

        public void GetRows(System.IO.FileStream fileStream)
        {
            var reader = Excel.ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            while ( reader.Read())
            {
                int fields = reader.FieldCount;

                if (fields == 4)
                {
                    string account = reader.GetString(0);
                    string description = reader.GetString(1);
                    string isoCode = reader.GetString(2);
                    string amount = reader.GetString(3);
                }
            }
        }
    }
}