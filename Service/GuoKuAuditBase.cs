using JournalVoucherAudit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JournalVoucherAudit.Service
{
    public abstract class GuoKuAuditBase : AuditBase<GuoKuItem>
    {
        protected GuoKuAuditBase(AuditBase<GuoKuItem> preAudit)
        {
            PreAudit = preAudit;
        }


        /// <summary>
        /// 从数据源中去除匹配项
        /// 金额与记录数相等
        /// </summary>
        /// <returns></returns>
        public override Tuple<IList<CaiWuItem>, IList<GuoKuItem>> Filter(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //取前一个审计结果
            var preResult = PreAudit.Filter(caiWus, guoKus);
            var preCaiWus = preResult.Item1;
            var preGuoKus = preResult.Item2;

            //取金额与记录数相等的财务数据项
            var specialItems = GetSpecialItems(preCaiWus, preGuoKus);
            //从国库列表中去除
            var guoKu = preGuoKus.Except(specialItems).ToList();
            //从财务列表中去除
            //var equalInCaiWus = preCaiWus.Where(t => specialItems.Select(a => a.Amount).Contains(t.CreditAmount)).ToList();
            //var caiWu = preCaiWus.Except(equalInCaiWus).ToList();
            //返回
            return new Tuple<IList<CaiWuItem>, IList<GuoKuItem>>(preCaiWus, guoKu);
        }

    }
}