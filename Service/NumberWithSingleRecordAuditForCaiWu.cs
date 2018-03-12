﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Domain;

namespace JournalVoucherAudit.Service
{
    public class NumberWithSingleRecordAuditForCaiWu : CaiWuAuditBase
    {
        public NumberWithSingleRecordAuditForCaiWu(AuditBase<CaiWuItem> preAudit) : base(preAudit)
        {
        }

        internal override IList<CaiWuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            //按凭证号分组，取记录数等于1的数据
            var caiWuGroup =
                caiWus.GroupBy(c => c.GetNumber())
                    .Where(g => g.Count() == 1)
                    .Select(w => new NumberGroupItem { Number = w.Key, Total = w.Sum(i => i.CreditAmount) });
            var guoKuGroup =
                guoKus.GroupBy(c => c.GetNumber())
                    .Where(g => g.Count() == 1)
                    .Select(w => new NumberGroupItem { Number = w.Key, Total = w.Sum(i => i.Amount) });
            //比较凭证号与金额
            var numberAndAmountAreEqualWithSingleRecord =
                caiWuGroup.Intersect(guoKuGroup, new NumberGroupItemEqualityComparer()).ToList();
            //去除结果
            var result =
                caiWus.Where(c => numberAndAmountAreEqualWithSingleRecord.Select(n => n.Number).Contains(c.GetNumber()))
                    .ToList();
            return result;
        }
    }
}