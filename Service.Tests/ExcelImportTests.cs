using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JournalVoucherAudit.Domain;

namespace JournalVoucherAudit.Service.Tests
{
    [TestClass]
    public class ExcelImportTests
    {
        [TestMethod]
        public void ReadExcel_CaiWuExcel_ReturnDataTable()
        {
            //arrange
            var filePath = @"D:\Codes\10月对账\10月财务\1.XLS";
            var excelImport = new Import(filePath, 4);
            //act
            var actual = excelImport.ReadCaiWu<CaiWuItem>();
            //assert
            Assert.IsTrue(actual.Count() > 1);
        }

        [TestMethod]
        public void ReadExcel_GuoKuExcel_ReturnDataTable()
        {
            //arrange
            var filePath = @"D:\Codes\10月对账\10月国库\1.XLS";
            var excelImport = new Import(filePath, 1);
            //act
            var actual = excelImport.ReadGuoKu<GuoKuItem>();
            
            //assert
            Assert.IsTrue(actual.Count() > 1);
        }
    }
}
