using JournalVoucherAudit.Domain;
using JournalVoucherAudit.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JournalVoucherAudit.Service
{
    public class GuoKuAudit
    {
        /// <summary>
        /// 审计国库
        /// </summary>
        /// <param name="caiWus"></param>
        /// <param name="guoKus"></param>
        /// <returns></returns>
        public IList<GuoKuItem> Audit(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按顺序调用审计策略
            var normal = new NormalAuditForGuoKu();
            var amountWithCount = new AmountWithCountAuditForGuoKu(normal);
            var numberWithAmount = new NumberWithAmountAuditForGuoKu(amountWithCount);            
            
            //执行审计
            var result = numberWithAmount.Filter(caiWus, guoKus);
            //转换为可排序列表
            var sort = new SortableBindingList<GuoKuItem>(result.Item2);
            return sort;
        }
    }
}