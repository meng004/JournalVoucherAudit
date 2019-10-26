using JournalVoucherAudit.Domain;
using System;
using System.Collections.Generic;

namespace JournalVoucherAudit.Service
{
    public class DefaultAuditForCaiWu : AuditBase<CaiWuItem>
    {
        public override Tuple<IList<CaiWuItem>, IList<GuoKuItem>> Filter(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            return new Tuple<IList<CaiWuItem>, IList<GuoKuItem>>(caiWus, guoKus);
        }

        internal override IList<CaiWuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            return caiWus;
        }
    }
}