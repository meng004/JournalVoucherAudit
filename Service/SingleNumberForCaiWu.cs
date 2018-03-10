using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Domain;
using JournalVoucherAudit.Service;

namespace JournalVoucherAudit.Service
{
    public class SingleNumberForCaiWu : CaiWuAuditBase
    {
        public SingleNumberForCaiWu(AuditBase<CaiWuItem> preAudit) : base(preAudit)
        {
        }

        internal override IList<CaiWuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按凭证号与金额分组
            var caiWuGroup = caiWus.GroupBy(c => new { Number = c.GetNumber(), Amount = c.CreditAmount }).Select(g => new NumberGroupItem { Number = g.Key.Number, Total = g.Key.Amount }).ToList();
            var guoKuGroup = guoKus.GroupBy(c => new { Number = c.GetNumber(), Amount = c.Amount }).Select(g => new NumberGroupItem { Number = g.Key.Number, Total = g.Key.Amount }).ToList();

            //交集，取凭证号与总金额相同
            var numberAndAmountAreEqual = caiWuGroup.Intersect(guoKuGroup, new NumberGroupItemEqualityComparer()).ToList();
            //取财务中对应记录
            var result = caiWus.Where(c => numberAndAmountAreEqual.Select(n => n.Number).Contains(c.GetNumber())).ToList();
            return result;
        }
    }
}
