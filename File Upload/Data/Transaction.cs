using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace File_Upload.Data
{
    public class Transaction
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Account { get; set; }

        public string Description { get; set; }

        public string CurrencyCode { get; set; }

        public decimal Amount { get; set; }
    }
}