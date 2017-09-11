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
        /// 审计策略队列
        /// </summary>
        private readonly AuditBase<CaiWuItem> _audit;

        /// <summary>
        /// 加载审计策略
        /// </summary>
        public CaiWuAudit()
        {
            //调用顺序为创建顺序相反，4-3-2-1
            //1默认策略
            _audit = new NormalAuditForCaiWu();
            //2金额绝对值与金额合计
            _audit = new AbsWithAmountForCaiWu(_audit);
            //3凭证号与总金额匹配
            _audit = new NumberWithAmountAuditForCaiWu(_audit);
            //4金额与记录数匹配
            _audit = new AmountWithCountAuditForCaiWu(_audit);
        }

        /// <summary>
        /// 审计财务数据项
        /// </summary>
        public IList<CaiWuItem> Audit(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        { 
            //执行审计
            var result = _audit.Filter(caiWus, guoKus);
            //转换为可排序列表
            var sort = new SortableBindingList<CaiWuItem>(result.Item1);
            return sort;
        }
    }
}