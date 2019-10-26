using JournalVoucherAudit.Domain;
using System.Collections.Generic;
using System.Linq;

namespace JournalVoucherAudit.Service
{
    public class AmountWithCountAuditForCaiWu : CaiWuAuditBase
    {
        public AmountWithCountAuditForCaiWu(AuditBase<CaiWuItem> preAudit) : base(preAudit) { }


        /// <summary>
        /// 取财务数据
        /// 金额与记录数与国库相等
        /// </summary>
        /// <returns></returns>
        internal override IList<CaiWuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按金额与记录数分组
            var caiWuGroup = caiWus.GroupBy(c => c.CreditAmount).Select(g => new AmountGroupItem { Amount = g.Key, Count = g.Count() }).ToList();
            var guoKuGroup = guoKus.GroupBy(c => c.Amount).Select(g => new AmountGroupItem { Amount = g.Key, Count = g.Count() }).ToList();

            //交集,取金额与记录数相等的数据项
            var amountAndCountAreEqual = caiWuGroup.Intersect(guoKuGroup, new AmountCountEqualityComparer()).ToList();
            //取财务对应数据
            var result = caiWus.Where(c => amountAndCountAreEqual.Select(a => a.Amount).Contains(c.CreditAmount)).ToList();

            //返回
            return result;
        }

    }
}