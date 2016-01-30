using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Domain;

namespace JournalVoucherAudit.Service
{
    public class NumberWithAmountAuditForCaiWu : CaiWuAuditBase
    {
        public NumberWithAmountAuditForCaiWu(AuditBase<CaiWuItem> preAudit) : base(preAudit) { }

        internal override IList<CaiWuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按凭证号与总金额分组
            var caiWuGroup = caiWus.GroupBy(c => c.GetNumber()).Select(g => new NumberGroupItem { Number = g.Key, Total = g.Sum(i => i.CreditAmount) }).ToList();
            var guoKuGroup = guoKus.GroupBy(c => c.GetNumber()).Select(g => new NumberGroupItem { Number = g.Key, Total = g.Sum(i => i.Amount) }).ToList();

            //交集，取凭证号与总金额相同
            var numberAndAmountAreEqual = caiWuGroup.Intersect(guoKuGroup, new NumberGroupItemEqualityComparer()).ToList();
            //取财务中对应记录
            var result = caiWus.Where(c => numberAndAmountAreEqual.Select(n => n.Number).Contains(c.GetNumber())).ToList();
            return result;
        }

    }
}