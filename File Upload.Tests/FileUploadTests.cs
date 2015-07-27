using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.IO;
using Moq;
using File_Upload.Services;

namespace File_Upload.Tests
{
    [TestClass]
    public class FileUploadTests
    {

        [TestMethod]
        public void LoadExcelFile_ReturnsRecords()
        {
            var validator = new Mock<IFieldValidator>();
            validator.Setup(m => m.Validate(It.IsAny<Models.ImportRecord>())).Returns(true);

            var transactionStore = new Mock<ITransactionStore>();
            transactionStore.Setup(m => m.Save(It.IsAny<Models.ImportRecord>())).Returns(true);

            var fileParser = new File_Upload.Services.ExcelFileImporter(validator.Object, transactionStore.Object);

            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileName = Path.Combine(assemblyFolder, "..\\..\\TestFiles\\Transactions.xlsx");

            

	

            MemoryStream inMemoryCopy = new MemoryStream();
            using (FileStream fs = File.OpenRead(fileName))
            {
              fs.CopyTo(inMemoryCopy);
            }

            //var stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);

            bool result = fileParser.ProcessFile(inMemoryCopy);

            Assert.IsTrue(result);
            Assert.AreEqual(fileParser.NumberImported, 4);
            Assert.AreEqual(fileParser.NumberProcessed, 4);
            Assert.AreEqual(fileParser.NumberFailed, 0);


        }



    }
}
