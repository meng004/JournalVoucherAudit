using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JournalVoucherAudit.Domain;
using System.Collections.Generic;

namespace JournalVoucherAudit.Service.Tests
{
    [TestClass]
    public class ExportTests
    {
        //string filename, Tuple<string, string, string> reportTitles, double caiWuTotal, double guoKuTotal, IEnumerable<TiaoJieItem> tiaoJieBiao
        string filename = "2021年2月-直接公共-财务国库对账单.xls";
        Tuple<string, string, string> reportTitles = new Tuple<string, string, string>("财政拨款收入_一般公共预算财政拨款", "经费拨款", "直接公共");
        double caiWuTotal = 10703;
        double guoKuTotal = 43570982.8;
        List<TiaoJieItem> items = new List<TiaoJieItem>();        

        /// <summary>
        /// 初始化
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            var item1 = new TiaoJieItem() { VoucherDate ="2021-02-08", VoucherNumber ="0001", Remark ="支付张三差旅费", CreditAmount =1233.5, CreateDate ="2021-02-28", PaymentNumber = "退22041612139722595", RemarkReason = "自定义账号不存在，退汇", Amount =-600};
            var item2 = new TiaoJieItem() { CreateDate ="2021-02-10", PaymentNumber = "退22041612139722595", RemarkReason = "账户名不符，退汇", Amount =-1500};
            var item3 = new TiaoJieItem() { CreateDate ="2021-02-11", PaymentNumber = "退22041612142405488", RemarkReason = "户名错", Amount =-13600};
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
        }
        [TestMethod]
        public void Save_ok()
        {
            //arrange
            var export = new Export();

            //act
            export.Save(filename, reportTitles, caiWuTotal, guoKuTotal, items);
            //assert           

        }
    }
}
