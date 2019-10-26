using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JournalVoucherAudit.Domain.Tests
{
    [TestClass]
    public class CompareServiceTests
    {
        [TestMethod]
        public void Equals_NumberIsEqualAmountIsEqual_ReturnTrue()
        {
            //arrange
            var compare = new CompareService();
            var caiWu = new CaiWuItem
            {
                CreditAmount = 4800.6d,
                VoucherNumber = "Z01380",
                VoucherDate = "2015-10-26",
                Remark = "付福州迈新生物技术开发有限公司科研材料款"
            };
            var guoKu = new GuoKuItem
            {
                Amount = 4800.6d,
                CreateDate = "2015-10-29",
                PaymentNumber = "1516671935",
                RemarkReason = "材料款１３８０＃"
            };
            //act
            var actual = compare.Equals(caiWu, guoKu);
            //assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Equals_NumberNotEqualAmountNotEqual_ReturnFalse()
        {
            //arrange
            var compare = new CompareService();
            var caiWu = new CaiWuItem
            {
                CreditAmount = 4800.7d,
                VoucherNumber = "Z01381",
                VoucherDate = "2015-10-26",
                Remark = "付福州迈新生物技术开发有限公司科研材料款"
            };
            var guoKu = new GuoKuItem
            {
                Amount = 4800.6d,
                CreateDate = "2015-10-29",
                PaymentNumber = "1516671935",
                RemarkReason = "材料款１３８０＃"
            };
            //act
            var actual = compare.Equals(caiWu, guoKu);
            //assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Equals_NumberIsEqualAmountNotEqual_ReturnFalse()
        {
            //arrange
            var compare = new CompareService();
            var caiWu = new CaiWuItem
            {
                CreditAmount = 4800.7d,
                VoucherNumber = "Z01380",
                VoucherDate = "2015-10-26",
                Remark = "付福州迈新生物技术开发有限公司科研材料款"
            };
            var guoKu = new GuoKuItem
            {
                Amount = 4800.6d,
                CreateDate = "2015-10-29",
                PaymentNumber = "1516671935",
                RemarkReason = "材料款１３８０＃"
            };
            //act
            var actual = compare.Equals(caiWu, guoKu);
            //assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Equals_NumberNotEqualAmountIsEqual_ReturnFalse()
        {
            //arrange
            var compare = new CompareService();
            var caiWu = new CaiWuItem
            {
                CreditAmount = 4800.6d,
                VoucherNumber = "Z01381",
                VoucherDate = "2015-10-26",
                Remark = "付福州迈新生物技术开发有限公司科研材料款"
            };
            var guoKu = new GuoKuItem
            {
                Amount = 4800.6d,
                CreateDate = "2015-10-29",
                PaymentNumber = "1516671935",
                RemarkReason = "材料款１３８０＃"
            };
            //act
            var actual = compare.Equals(caiWu, guoKu);
            //assert
            Assert.AreEqual(false, actual);
        }


    }
}
