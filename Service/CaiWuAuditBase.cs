using JournalVoucherAudit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JournalVoucherAudit.Service
{
    public abstract class CaiWuAuditBase : AuditBase<CaiWuItem>
    {
        private AuditBase<CaiWuItem> _PreAudit;

        public CaiWuAuditBase(AuditBase<CaiWuItem> preAudit)
        {
            _PreAudit = preAudit;
        }

        /// <summary>
        /// 从数据源中去除匹配项
        /// 金额与记录数相等
        /// </summary>
        /// <returns></returns>
        public override Tuple<IList<CaiWuItem>, IList<GuoKuItem>> Filter(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //取前一个审计结果
            var preResult = _PreAudit.Filter(caiWus, guoKus);
            var preCaiWus = preResult.Item1;
            var preGuoKus = preResult.Item2;

            //取金额与记录数相等的财务数据项
            var amountAndCountAreEqual = GetSpecialItems(preCaiWus, preGuoKus);
            //从财务列表中去除
            var caiWu = preCaiWus.Except(amountAndCountAreEqual).ToList();
            //从国库列表中去除
            var equalInGuoKus = preGuoKus.Where(t => amountAndCountAreEqual.Select(a => a.CreditAmount).Contains(t.Amount)).ToList();
            var guoKu = preGuoKus.Except(equalInGuoKus).ToList();
            //返回
            return new Tuple<IList<CaiWuItem>, IList<GuoKuItem>>(caiWu, guoKu);
        }
    }
}