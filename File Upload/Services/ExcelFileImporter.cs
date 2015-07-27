using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace File_Upload.Services
{
    public class ExcelFileImporter: FileImporter
    {
        public ExcelFileImporter(IFieldValidator fieldValidator, ITransactionStore transactionStore): base(fieldValidator, transactionStore)
        {
        }

        public bool ProcessFile(MemoryStream fileStream)
        {
            bool returnValue = true;

            GetRows(fileStream);

            return returnValue;

        }

        private void GetRows(System.IO.MemoryStream fileStream)
        {
            var reader = Excel.ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            while (reader.Read())
            {
                int fields = reader.FieldCount;

                if (fields == 4)
                {
                    // get from spreadsheet row 
                    var record = new Models.ImportRecord{
                        Account = reader.GetString(0),
                        Description = reader.GetString(1),
                        CurrencyCode = reader.GetString(2),
                        AmountString = reader.GetString(3)
                    };

                    if (_fieldValidator.Validate(record))
                    {
                        if (_transactionStore.Save(record))
                        {
                            NumberImported++;
                        }
                        else
                        {
                            NumberFailed++;
                        }
                    }
                    else
                    {
                        NumberSkipped++;
                    }
                }
            }
        }


    }
}