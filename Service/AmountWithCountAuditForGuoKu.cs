using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Domain;

namespace JournalVoucherAudit.Service
{
    public class AmountWithCountAuditForGuoKu : GuoKuAuditBase
    {
        public AmountWithCountAuditForGuoKu(AuditBase<GuoKuItem> preAudit) : base(preAudit) { }

        /// <summary>
        /// 取国库数据
        /// 金额与记录数与财务相等
        /// </summary>
        /// <returns></returns>
        internal override IList<GuoKuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按金额与记录数分组
            var caiWuGroup = caiWus.GroupBy(c => c.CreditAmount).Select(g => new AmountGroupItem { Amount = g.Key, Count = g.Count() }).ToList();
            var guoKuGroup = guoKus.GroupBy(c => c.Amount).Select(g => new AmountGroupItem { Amount = g.Key, Count = g.Count() }).ToList();

            //交集,取金额与记录数相等的数据项
            var amountAndCountAreEqual = caiWuGroup.Intersect(guoKuGroup, new AmountCountEqualityComparer()).ToList();
            //取国库对应数据
            var result = guoKus.Where(c => amountAndCountAreEqual.Select(a => a.Amount).Contains(c.Amount)).ToList();

            //返回
            return result;
        }


    }
}