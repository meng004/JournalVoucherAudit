﻿using JournalVoucherAudit.Domain;
using System;
using System.Collections.Generic;

namespace JournalVoucherAudit.Service
{
    public class DefaultAuditForGuoKu : AuditBase<GuoKuItem>
    {
        public override Tuple<IList<CaiWuItem>, IList<GuoKuItem>> Filter(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            return new Tuple<IList<CaiWuItem>, IList<GuoKuItem>>(caiWus, guoKus);
        }

        internal override IList<GuoKuItem> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus)
        {
            return guoKus;
        }
    }
}