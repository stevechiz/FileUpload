﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace File_Upload.Services
{
    public interface IFieldValidator
    {
        bool Validate(Models.ImportRecord record);
    }
}
