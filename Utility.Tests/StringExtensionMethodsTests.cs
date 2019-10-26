using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace JournalVoucherAudit.Utility.Tests
{
    [TestClass]
    public class StringExtensionMethodsTests
    {
        [TestMethod]
        public void ToDbc_材料款1380()
        {
            //arrange
            var expect = "材料款１３８０＃";
            var original = "材料款1380#";
            //act
            var actual = original.ToDbc();
            //assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void ToSbc_材料款1380()
        {
            //arrange
            var original = "材料款１３８０＃";
            var expect = "材料款1380#";
            //act
            var actual = original.ToSbc();
            //assert
            Assert.AreEqual(expect, actual);
        }

        [TestMethod]
        public void GetNumber_材料款1380()
        {
            //arrange
            var original = "材料款1380#";
            var expect = "1380";
            //act
            var actual = original.GetNumber();
            //assert
            Assert.AreEqual(expect, actual);
        }


        [TestMethod]
        public void GetNumber_材料款001380()
        {
            //arrange
            var original = "材料款001380#";
            var expect = "001380";
            //act
            var actual = original.GetNumber();
            //assert
            Assert.AreEqual(expect, actual);
        }

    }
}
