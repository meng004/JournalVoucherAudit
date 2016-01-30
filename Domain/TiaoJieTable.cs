using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JournalVoucherAudit.Domain
{
    public class TiaoJieTable
    {
        private IEnumerable<CaiWuItem> _CaiWus;
        private IEnumerable<GuoKuItem> _GuoKus;
        /// <summary>
        /// 调节表
        /// </summary>
        /// <param name="caiWus">财务不匹配数据</param>
        /// <param name="guoKus">国库不匹配数据</param>
        public TiaoJieTable(IEnumerable<CaiWuItem> caiWus, IEnumerable<GuoKuItem> guoKus)
        {
            _CaiWus = caiWus;
            _GuoKus = guoKus;
        }
        /// <summary>
        /// 调节表数据
        /// </summary>
        public IEnumerable<TiaoJieItem> Data
        {
            get
            {
                return Combine();
            }
        }
        /// <summary>
        /// 合并不匹配数据
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TiaoJieItem> Combine()
        {
            var tiaoJieBiao = new List<TiaoJieItem>();
            //取记录数
            var caiWuCount = _CaiWus.Count();
            var guoKuCount = _GuoKus.Count();

            //构造调节表记录
            //财务数据多于国库数据
            if (caiWuCount > guoKuCount)
            {
                //填充调节表
                for (int i = 0; i < caiWuCount; i++)
                {
                    //取财务
                    var caiWu = _CaiWus.ElementAt(i);
                    //创建调节表项目，填财务数据
                    var tiaoJie = new TiaoJieItem
                    {
                        CreditAmount = caiWu.CreditAmount,
                        Remark = caiWu.Remark,
                        VoucherDate = caiWu.VoucherDate,
                        VoucherNumber = caiWu.VoucherNumber
                    };
                    //填国库数据
                    if (i < guoKuCount)
                    {
                        var guoKu = _GuoKus.ElementAt(i);
                        tiaoJie.Amount = guoKu.Amount;
                        tiaoJie.CreateDate = guoKu.CreateDate;
                        tiaoJie.PaymentNumber = guoKu.PaymentNumber;
                        tiaoJie.RemarkReason = guoKu.RemarkReason;
                    }
                    tiaoJieBiao.Add(tiaoJie);
                }
            }
            else
            {
                for (int i = 0; i < guoKuCount; i++)
                {
                    //取国库
                    var guoKu = _GuoKus.ElementAt(i);

                    //创建调节表项目，填财务数据
                    var tiaoJie = new TiaoJieItem
                    {
                        Amount = guoKu.Amount,
                        CreateDate = guoKu.CreateDate,
                        PaymentNumber = guoKu.PaymentNumber,
                        RemarkReason = guoKu.RemarkReason
                    };
                    //填财务数据
                    if (i < caiWuCount)
                    {
                        //取财务
                        var caiWu = _CaiWus.ElementAt(i);
                        tiaoJie.CreditAmount = caiWu.CreditAmount;
                        tiaoJie.Remark = caiWu.Remark;
                        tiaoJie.VoucherDate = caiWu.VoucherDate;
                        tiaoJie.VoucherNumber = caiWu.VoucherNumber;
                    }
                    tiaoJieBiao.Add(tiaoJie);
                }
            }
            return tiaoJieBiao;
        }
    }
}
