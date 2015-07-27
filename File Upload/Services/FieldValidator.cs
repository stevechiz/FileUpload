using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace File_Upload.Services
{
    public class FieldValidator: IFieldValidator
    {

        public FieldValidator(IIsoCurrencyCodeChecker isoCurrencyCodeChecker)
        {

        }

        public bool Validate(Models.ImportRecord record)
        {
            bool returnValue = true;



            return returnValue;

        }
    }
}