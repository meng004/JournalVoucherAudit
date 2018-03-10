using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Domain;

namespace JournalVoucherAudit.Service
{
    /// <summary>
    /// 同金额多次支付
    /// </summary>
    public class AbsWithAmountForGuoKu : GuoKuAuditBase
    {
        public AbsWithAmountForGuoKu(AuditBase<GuoKuItem> preAudit) : base(preAudit){}

        /// <summary>
        /// 按金额的绝对值分组
        /// 取金额合计相同的记录
        /// </summary>
        /// <param name="caiWus"></param>
        /// <param name="guoKus"></param>
        /// <returns></returns>
        internal override IList<GuoKuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按金额的绝对值分组，取合计
            var caiWuGroup = caiWus.GroupBy(c => Math.Abs(c.CreditAmount)).Select(g => new AbsAmountGroupItem { AbsAmount = g.Key, Total = g.Sum(i => i.CreditAmount) }).ToList();
            var guoKuGroup = guoKus.GroupBy(c => Math.Abs(c.Amount)).Select(g => new AbsAmountGroupItem { AbsAmount = g.Key, Total = g.Sum(i => i.Amount) }).ToList();
            //金额绝对值相同且合计也相同
            var absAndAmountAreEqual = caiWuGroup.Intersect(guoKuGroup, new AbsAmountEqualityComparer()).ToList();
            //根据金额绝对值与合计的比较结果，取出记录
            var result = guoKus.Where(c => absAndAmountAreEqual.Select(n => n.AbsAmount).Contains(Math.Abs(c.Amount))).ToList();
            return result;
        }
    }
}
