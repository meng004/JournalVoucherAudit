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
            //调用顺序为创建顺序相反，4-3-2-1
            //1默认策略
            var normal = new NormalAuditForGuoKu();
            //2金额绝对值与金额合计
            var absAmount=new AbsWithAmountForGuoKu(normal);
            //3凭证号与总金额匹配
            var numberWithAmount = new NumberWithAmountAuditForGuoKu(absAmount);
            //4金额与记录数匹配
            var amountWithCount = new AmountWithCountAuditForGuoKu(numberWithAmount);
            
            //执行审计
            var result = amountWithCount.Filter(caiWus, guoKus);
            //转换为可排序列表
            var sort = new SortableBindingList<GuoKuItem>(result.Item2);
            return sort;
        }
    }
}