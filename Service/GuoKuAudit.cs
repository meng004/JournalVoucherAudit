﻿using JournalVoucherAudit.Domain;
using JournalVoucherAudit.Utility;
using System.Collections.Generic;

namespace JournalVoucherAudit.Service
{

    public class GuoKuAudit
    {
        /// <summary>
        /// 审计策略队列
        /// </summary>
        private readonly AuditBase<GuoKuItem> _audit;
        /// <summary>
        /// 加载审计策略
        /// </summary>
        public GuoKuAudit(ActiveRule rule)
        {
            
            //调用顺序为创建顺序相反，4-3-2-1
            //1默认策略
            _audit = new NormalAuditForGuoKu();
            //2金额绝对值与金额合计，同金额多次支付
            //_audit = new AbsWithAmountForGuoKu(_audit);
            if((rule & ActiveRule.AbsWithAmount)!=0)
                _audit = new AbsWithAmountForGuoKu(_audit);
            //3凭证号与总金额匹配，同凭证多笔支付
            //_audit = new NumberWithAmountAuditForGuoKu(_audit);
            if ((rule & ActiveRule.NumberWithAmount) != 0)
                _audit = new NumberWithAmountAuditForGuoKu(_audit);
            //4金额与记录数匹配
            // _audit = new AmountWithCountAuditForGuoKu(_audit);
            if ((rule & ActiveRule.AmountWithCount) != 0)
                _audit = new AmountWithCountAuditForGuoKu(_audit);
        }

        /// <summary>
        /// 审计国库
        /// </summary>
        /// <param name="caiWus"></param>
        /// <param name="guoKus"></param>
        /// <returns></returns>
        public IList<GuoKuItem> Audit(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //执行审计
            var result = _audit.Filter(caiWus, guoKus);

            return result.Item2;
        }
    }
}