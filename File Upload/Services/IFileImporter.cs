using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace File_Upload.Services
{
    public interface IFileImporter
    {

        int NumberImported { get; set; }

        int NumberProcessed { get; set; }

        int NumberSkipped { get; set; }

        int NumberFailed { get; set; }

        List<string> FailedRecords { get; set; }

        bool ProcessFile(FileStream inputFile);
    }
}
