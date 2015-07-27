using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace File_Upload.Models
{
    public class ImportRecord
    {

        public string Account { get; set; }

        public string Description { get; set; }

        public string CurrencyCode { get; set; }

        public string AmountString { get; set; }

        public decimal Amount { get; set; }

        public bool IsValid { get; set; }

        public string ValidationMessage { get; set; }
    }
}