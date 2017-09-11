using JournalVoucherAudit.Domain;
using JournalVoucherAudit.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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