using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;

namespace File_Upload.Tests
{
    [TestClass]
    public class FileUploadTests
    {

        [TestMethod]
        public void LoadExcelFile_ReturnsRecords()
        {
            var fileParser = new File_Upload.Services.ExcelFileParser();

            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string xmlFileName = Path.Combine(assemblyFolder, "..\\..\\TestFiles\\Transactions.xlsx");

            var stream = new System.IO.FileStream(xmlFileName, System.IO.FileMode.Open);

            fileParser.GetRows(stream);
        }



    }
}
