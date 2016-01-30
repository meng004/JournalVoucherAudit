using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Domain;

namespace JournalVoucherAudit.Service
{
    public class NumberWithAmountAuditForGuoKu : GuoKuAuditBase
    {
 
        public NumberWithAmountAuditForGuoKu(AuditBase<GuoKuItem> preAudit) : base(preAudit) { }

        internal override IList<GuoKuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按凭证号与总金额分组
            var caiWuGroup = caiWus.GroupBy(c => c.GetNumber()).Select(g => new NumberGroupItem { Number = g.Key, Total = g.Sum(i => i.CreditAmount) }).ToList();
            var guoKuGroup = guoKus.GroupBy(c => c.GetNumber()).Select(g => new NumberGroupItem { Number = g.Key, Total = g.Sum(i => i.Amount) }).ToList();
            //比较凭证号与总金额
            var numberAndAmountAreEqual = caiWuGroup.Intersect(guoKuGroup, new NumberGroupItemEqualityComparer()).ToList();
            //根据凭证号与总金额比较结果，取出记录
            var result = guoKus.Where(c => numberAndAmountAreEqual.Select(n => n.Number).Contains(c.GetNumber())).ToList();
            return result;
        }

    }
}