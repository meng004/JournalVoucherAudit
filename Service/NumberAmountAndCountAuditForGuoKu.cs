using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Domain;
using JournalVoucherAudit.Utility;

namespace JournalVoucherAudit.Service
{
    /// <summary>
    /// 凭证号、金额、支付笔数均相同
    /// </summary>
    public class NumberAmountAndCountAuditForGuoKu : GuoKuAuditBase
    {
        public NumberAmountAndCountAuditForGuoKu(AuditBase<GuoKuItem> preAudit) : base(preAudit)
        {
        }

        internal override IList<GuoKuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按凭证号与总金额分组
            var caiWuGroup =
                caiWus.GroupBy(c => new { c.Number, c.CreditAmount})
                .Select(g => new NumberAmountGroupItem
                {
                    Number = g.Key.Number,
                    Amount = g.Key.CreditAmount,
                    Count = g.Count()
                }).ToList();
            var guoKuGroup =
                guoKus.GroupBy(c => new { c.Number, c.Amount })
                .Select(g => new NumberAmountGroupItem
                {
                    Number = g.Key.Number,
                    Amount = g.Key.Amount,
                    Count = g.Count()
                }).ToList();
            //比较凭证号与总金额
            var numberAndAmountAreEqual = caiWuGroup.Intersect(guoKuGroup, new NumberAmountGroupItemEqualityComparer()).ToList();
            //取国库中对应记录
            var help = new DoubleHelpMethod();
            //取凭证号与支付金额相同的记录
            var result = guoKus.Where(c => numberAndAmountAreEqual.Exists(n => n.Number == c.Number &&
                                                                               help.IsEqual(n.Amount, c.Amount)
                                                                               ))
                               .ToList();
            return result;
        }
    }
}
