using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JournalVoucherAudit.Utility.Tests
{
    [TestClass]
    public class DateTimeExtensionMethodTests
    {
        [TestMethod]
        public void LastDayOfMonth_Feb_Return28()
        {
            //arrange
            var date = new DateTime(2021, 2, 1);
            //act
            var lastday = date.LastDayOfMonth();
            //assert
            Assert.AreEqual(28, lastday.Day);
        }

        [TestMethod]
        public void LastDayOfMonth_July_Return31()
        {
            //arrange
            var date = new DateTime(2021, 7, 1);
            //act
            var lastday = date.LastDayOfMonth();
            //assert
            Assert.AreEqual(31, lastday.Day);
        }

        [TestMethod]
        public void LastDayOfMonth_August_Return31()
        {
            //arrange
            var date = new DateTime(2021, 8, 1);
            //act
            var lastday = date.LastDayOfMonth();
            //assert
            Assert.AreEqual(31, lastday.Day);
        }
    }
}
