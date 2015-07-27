using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace File_Upload.Services
{
    public class ExcelFileUploader
    {

        private IFieldValidator _fieldValidator;
        private IFileParser _fileParser;
        private IIsoValidation _isoValidation;
        private ITransactionStore _transactionStore;

        private HashSet<Models.TransactionRecord> records;

        public ExcelFileUploader(IFieldValidator fieldValidator, IFileParser fileParser, IIsoValidation isovalidation, ITransactionStore transactionStore)
        {
            _fieldValidator = fieldValidator;
            _fileParser = fileParser;
            _isoValidation = isovalidation;
            _transactionStore = transactionStore;
        }

        public bool ParseFile(FileStream fileStream)
        {
            bool returnValue = true;

            var fileParser = new ExcelFileParser();

            GetRows(fileStream);

            return returnValue;

        }

        private void GetRows(System.IO.FileStream fileStream)
        {
            var reader = Excel.ExcelReaderFactory.CreateOpenXmlReader(fileStream);
            while (reader.Read())
            {
                int fields = reader.FieldCount;

                if (fields == 4)
                {
                    // get and validate 
                    string account = reader.GetString(0);
                    string description = reader.GetString(1);
                    string isoCode = reader.GetString(2);
                    string amount = reader.GetString(3);
                }
            }
        }
    }
}