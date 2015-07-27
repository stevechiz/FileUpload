using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace File_Upload.Services
{
    public class FileImporter: IFileImporter
    {

        public int NumberImported { get; set; }

        public int NumberProcessed { get; set; }

        public int NumberSkipped { get; set; }

        public int NumberFailed { get; set; }

        public List<string> FailedRecords { get; set; }
        
        protected IFieldValidator _fieldValidator;
        protected ITransactionStore _transactionStore;


        public FileImporter(IFieldValidator fieldValidator, ITransactionStore transactionStore)
        {
            _fieldValidator = fieldValidator;
            _transactionStore = transactionStore;
        }

        public virtual bool ProcessFile (FileStream inputFile)
        {
            return true;
        }
    }
}