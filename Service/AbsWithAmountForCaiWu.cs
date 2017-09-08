using System;
using System.Collections.Generic;
using System.Linq;
using JournalVoucherAudit.Domain;

namespace JournalVoucherAudit.Service
{
    internal class AbsWithAmountForCaiWu : CaiWuAuditBase
    {
        public AbsWithAmountForCaiWu(AuditBase<CaiWuItem> preAudit) : base(preAudit){}

        internal override IList<CaiWuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按金额的绝对值分组，取合计
            var caiWuGroup = caiWus.GroupBy(c => Math.Abs(c.CreditAmount)).Select(g => new AbsAmountGroupItem { AbsAmount = g.Key, Total = g.Sum(i => i.CreditAmount) }).ToList();
            var guoKuGroup = guoKus.GroupBy(c => Math.Abs(c.Amount)).Select(g => new AbsAmountGroupItem { AbsAmount = g.Key, Total = g.Sum(i => i.Amount) }).ToList();
            //金额绝对值相同且合计也相同
            var absAndAmountAreEqual = caiWuGroup.Intersect(guoKuGroup, new AbsAmountEqualityComparer()).ToList();
            //根据金额绝对值与合计的比较结果，取出记录
            var result = caiWus.Where(c => absAndAmountAreEqual.Select(n => n.AbsAmount).Contains(Math.Abs(c.CreditAmount))).ToList();
            return result;
        }
    }
}