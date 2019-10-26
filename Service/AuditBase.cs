using JournalVoucherAudit.Domain;
using System;
using System.Collections.Generic;

namespace JournalVoucherAudit.Service
{
    public abstract class AuditBase<T>
    {
        protected AuditBase<T> PreAudit;

        internal abstract IList<T> GetSpecialItems(IList<CaiWuItem> caiWus, IList<GuoKuItem> guoKus);

        /// <summary>
        /// 筛选数据项
        /// </summary>
        public abstract Tuple<IList<CaiWuItem>, IList<GuoKuItem>> Filter(IList<CaiWuItem> caiWus,
            IList<GuoKuItem> guoKus);

    }
}