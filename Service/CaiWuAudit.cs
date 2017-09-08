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
            //调用顺序为创建顺序相反，3-2-1
            //1默认策略
            var normal = new NormalAuditForCaiWu();
            //2金额绝对值与金额合计
            var absAmount = new AbsWithAmountForCaiWu(normal);
            //3凭证号与总金额匹配
            var numberWithAmount = new NumberWithAmountAuditForCaiWu(absAmount);
            //4金额与记录数匹配
            var amountWithCount = new AmountWithCountAuditForCaiWu(numberWithAmount);
          
            //执行审计
            var result = amountWithCount.Filter(caiWus, guoKus);
            //转换为可排序列表
            var sort = new SortableBindingList<CaiWuItem>(result.Item1);
            return sort;
        }
    }
}