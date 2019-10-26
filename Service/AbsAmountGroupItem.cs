using JournalVoucherAudit.Utility;
using System.Collections.Generic;

namespace JournalVoucherAudit.Service
{
    internal class AbsAmountGroupItem
    {
        public double AbsAmount { get; set; }
        public double Total { get; set; }
    }

    /// <summary>
    /// 相等比较器
    /// 比较金额与合计
    /// </summary>
    internal class AbsAmountEqualityComparer : IEqualityComparer<AbsAmountGroupItem>
    {
        public bool Equals(AbsAmountGroupItem x, AbsAmountGroupItem y)
        {
            //金额相等
            var keyIsEqual = new DoubleHelpMethod().IsEqual(x.AbsAmount, y.AbsAmount);
            //合计相等
            var countIsEqual = new DoubleHelpMethod().IsEqual(x.Total, y.Total);
            return keyIsEqual && countIsEqual;
        }

        public int GetHashCode(AbsAmountGroupItem obj)
        {
            return obj.AbsAmount.GetHashCode() + obj.Total.GetHashCode();
        }
    }

}