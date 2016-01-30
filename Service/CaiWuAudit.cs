using JournalVoucherAudit.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Utility;

namespace JournalVoucherAudit.Service
{
    public class CaiWuAudit
    {
        /// <summary>
        /// 审计财务数据项
        /// </summary>
        public IList<CaiWuItem> Audit(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按顺序调用审计策略
            var normal = new NormalAuditForCaiWu();
            var amountWithCount = new AmountWithCountAuditForCaiWu(normal);
            var numberWithAmount = new NumberWithAmountAuditForCaiWu(amountWithCount);
            //执行审计
            var result = numberWithAmount.Filter(caiWus, guoKus);
            //转换为可排序列表
            var sort = new SortableBindingList<CaiWuItem>(result.Item1);
            return sort;
        }
    }
}