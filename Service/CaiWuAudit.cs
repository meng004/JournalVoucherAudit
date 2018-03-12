using JournalVoucherAudit.Domain;
using System.Collections.Generic;

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
        public CaiWuAudit(ActiveRule rule)
        {
            //调用顺序为创建顺序相反，4-3-2-1
            //1默认策略
            _audit = new NormalAuditForCaiWu();
            //2金额绝对值与金额合计
            if ((rule & ActiveRule.AbsWithAmount) != 0)
                _audit = new AbsWithAmountForCaiWu(_audit);
            //3凭证号与总金额匹配
            if ((rule & ActiveRule.NumberWithAmount) != 0)
                _audit = new NumberWithAmountAuditForCaiWu(_audit);
            //单条记录凭证号与金额匹配
            if ((rule & ActiveRule.NumberWithSingleRecord) != 0)
            {
                _audit = new NumberWithSingleRecordAuditForCaiWu(_audit);
            }
            //4金额与记录数匹配

            if ((rule & ActiveRule.AmountWithCount) != 0)
                _audit = new AmountWithCountAuditForCaiWu(_audit);
        }

        /// <summary>
        /// 审计财务数据项
        /// </summary>
        public IList<CaiWuItem> Audit(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //执行审计
            var result = _audit.Filter(caiWus, guoKus);

            return result.Item1;
        }
    }
}