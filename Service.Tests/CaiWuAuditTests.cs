using Microsoft.VisualStudio.TestTools.UnitTesting;
using JournalVoucherAudit.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Domain;

namespace JournalVoucherAudit.Service.Tests
{
    /// <summary>
    /// 按凭证号、金额、支付笔数匹配，
    /// 三个条件，每个条件两种状态
    /// 共8条测试用例
    /// </summary>
    [TestClass()]
    public class CaiWuAuditTests
    {
        /// <summary>
        /// 财务审计类
        /// </summary>
        CaiWuAudit _audit;
        /// <summary>
        /// 数据筛选规则
        /// </summary>
        private ActiveRule _rule;
        /// <summary>
        /// 财务数据
        /// </summary>
        IList<CaiWuItem> _caiWus;
        /// <summary>
        /// 国库数据
        /// </summary>
        IList<GuoKuItem> _guoKus;

        [TestInitialize]
        public void Init()
        {
            //规则
            _rule = ActiveRule.NumberAmountAndCount;
            //审计类
            _audit = new CaiWuAudit(_rule);
            //财务
            _caiWus = new List<CaiWuItem>()
            {
                new CaiWuItem { VoucherNumber="J02936", CreditAmount=400, VoucherDate="2019-06-20", Remark="付方会龙研究生论文答辩费" },
                new CaiWuItem { VoucherNumber="J02936", CreditAmount=400, VoucherDate="2019-06-20", Remark="付胡立平研究生论文答辩费" },
                new CaiWuItem { VoucherNumber="J02936", CreditAmount=600, VoucherDate="2019-06-20", Remark="付蒋最明研究生论文答辩费" },
                new CaiWuItem { VoucherNumber="J02936", CreditAmount=600, VoucherDate="2019-06-20", Remark="付吴翔研究生论文答辩费" },
                new CaiWuItem { VoucherNumber="J02936", CreditAmount=600, VoucherDate="2019-06-20", Remark="付杨志英研究生论文答辩费" },
                new CaiWuItem { VoucherNumber="J02936", CreditAmount=800, VoucherDate="2019-06-20", Remark="付卿文衡研究生论文答辩费" },
                new CaiWuItem { VoucherNumber="J02936", CreditAmount=960, VoucherDate="2019-06-20", Remark="付尹卫国研究生论文答辩费" },
                new CaiWuItem { VoucherNumber="J00077", CreditAmount=600, VoucherDate="2019-06-03", Remark="周青芝等2人报长沙旅差费" }
            };
            //国库
            _guoKus = new List<GuoKuItem>()
            {
                new GuoKuItem { PaymentNumber="19211052605", Amount=400, CreateDate="2019-06-25", RemarkReason="补助2936＃"},
                 new GuoKuItem { PaymentNumber="19211052602", Amount=400, CreateDate="2019-06-25", RemarkReason="补助2936＃"},
                 new GuoKuItem { PaymentNumber="19211052607", Amount=600, CreateDate="2019-06-25", RemarkReason="补助2936＃"},
                 new GuoKuItem { PaymentNumber="19211052604", Amount=600, CreateDate="2019-06-25", RemarkReason="补助2936＃"},
                 new GuoKuItem { PaymentNumber="19211052603", Amount=600, CreateDate="2019-06-25", RemarkReason="补助2936＃"},
                 new GuoKuItem { PaymentNumber="19211052601", Amount=800, CreateDate="2019-06-25", RemarkReason="补助2936＃"},
                 new GuoKuItem { PaymentNumber="19211052600", Amount=960, CreateDate="2019-06-25", RemarkReason="补助2936＃"},
                 new GuoKuItem { PaymentNumber="19210964927", Amount=3620, CreateDate="2019-06-05", RemarkReason="李健报差旅费81＃"}

            };
        }

        /// <summary>
        /// 凭证号、金额、支付笔数相同，返回记录数量等于1
        /// </summary>
        [TestMethod()]
        public void AuditTest_NumberAmountAndCountAreEqual_ReturnOne()
        {
            //arrange

            //act
            var result = _audit.Audit(_caiWus, _guoKus);
            //assert
            Assert.AreEqual(1, result.Count);
        }

        /// <summary>
        /// 凭证号、金额相同，支付笔数不同，返回记录数量等于4
        /// </summary>
        [TestMethod()]
        public void AuditTest_CountNotEqual_ReturnFour()
        {
            //arrange  
            //从国库中删除一条金额凭证号2936、金额600的记录         
            _guoKus.RemoveAt(2);
            //act
            var result = _audit.Audit(_caiWus, _guoKus);
            //assert
            Assert.AreEqual(4, result.Count);
        }

        /// <summary>
        /// 凭证号、支付笔数相同，金额不同，返回记录数量等于3
        /// </summary>
        [TestMethod()]
        public void AuditTest_AmountNotEqual_ReturnThree()
        {
            //arrange  
            //将国库中原金额400修改为1000，
            _guoKus.ElementAt(0).Amount = 1000;
            _guoKus.ElementAt(1).Amount = 1000;
            //act
            var result = _audit.Audit(_caiWus, _guoKus);
            //assert
            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// 凭证号相同，支付笔数、金额不同，返回记录数量等于3
        /// </summary>
        [TestMethod()]
        public void AuditTest_AmountAndCountNotEqual_ReturnThree()
        {
            //arrange  
            //将国库中原金额400修改为1000，
            //删除一条
            _guoKus.ElementAt(0).Amount = 1000;
            _guoKus.RemoveAt(1);
            //act
            var result = _audit.Audit(_caiWus, _guoKus);
            //assert
            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// 支付笔数、金额相同，凭证号不同，返回记录数量等于3
        /// </summary>
        [TestMethod()]
        public void AuditTest_NumberNotEqual_ReturnThree()
        {
            //arrange  
            //将国库中原凭证号“补助2936＃”、金额400修改为“补助2938＃”，
            _guoKus.ElementAt(0).RemarkReason = "补助2938＃";
            _guoKus.ElementAt(1).RemarkReason = "补助2938＃";
            //act
            var result = _audit.Audit(_caiWus, _guoKus);
            //assert
            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// 金额相同，凭证号、支付笔数不同，返回记录数量等于3
        /// </summary>
        [TestMethod()]
        public void AuditTest_NumberAmountNotEqual_ReturnThree()
        {
            //arrange  
            //将国库中原凭证号“补助2936＃”、金额400修改为“补助2938＃”，
            _guoKus.ElementAt(0).RemarkReason = "补助2938＃";
            _guoKus.RemoveAt(1);
            //act
            var result = _audit.Audit(_caiWus, _guoKus);
            //assert
            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// 支付笔数相同，凭证号、金额不同，返回记录数量等于3
        /// </summary>
        [TestMethod()]
        public void AuditTest_NumberAndCountNotEqual_ReturnThree()
        {
            //arrange  
            //将国库中原凭证号“补助2936＃”、金额400修改为“补助2938＃”、1000，
            _guoKus.RemoveAt(0);
            _guoKus.RemoveAt(0);
            _guoKus.Add(new GuoKuItem { PaymentNumber = "19211052601", Amount = 1000, CreateDate = "2019-06-25", RemarkReason = "补助2938＃" });
            _guoKus.Add(new GuoKuItem { PaymentNumber = "19211052602", Amount = 1000, CreateDate = "2019-06-25", RemarkReason = "补助2938＃" });
            _guoKus.Add(new GuoKuItem { PaymentNumber = "19211052603", Amount = 1000, CreateDate = "2019-06-25", RemarkReason = "补助2938＃" });
            //act
            var result = _audit.Audit(_caiWus, _guoKus);
            //assert
            Assert.AreEqual(3, result.Count);
        }

        /// <summary>
        /// 凭证号、金额、支付笔数不同，返回记录数量等于3
        /// </summary>
        [TestMethod()]
        public void AuditTest_NumberAmountAndCountNotEqual_ReturnThree()
        {
            //arrange  
            //将国库中原凭证号“补助2936＃”、金额400修改为“补助2938＃”、1000，
            _guoKus.RemoveAt(0);
            _guoKus.RemoveAt(0);
            _guoKus.Add(new GuoKuItem { PaymentNumber = "19211052601", Amount = 1000, CreateDate = "2019-06-25", RemarkReason = "补助2938＃" });

            //act
            var result = _audit.Audit(_caiWus, _guoKus);
            //assert
            Assert.AreEqual(3, result.Count);
        }
    }
}