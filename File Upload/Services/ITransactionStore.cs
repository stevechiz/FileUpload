﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace File_Upload.Services
{
    public interface ITransactionStore
    {
        bool Save(Models.ImportRecord record);
    }
}
