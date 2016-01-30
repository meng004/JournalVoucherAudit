using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Utility;

namespace JournalVoucherAudit.Service
{
    internal class AmountGroupItem 
    {
        public double Amount { get; set; }
        public int Count { get; set; }
    }
    /// <summary>
    /// 相等比较器
    /// 比较金额与记录数量
    /// </summary>
    internal class AmountCountEqualityComparer : IEqualityComparer<AmountGroupItem>
    {
        public bool Equals(AmountGroupItem x, AmountGroupItem y)
        {
            //金额相等
            var keyIsEqual = new DoubleHelpMethod().IsEqual(x.Amount, y.Amount);
            //记录数相等
            var countIsEqual = x.Count == y.Count;
            return keyIsEqual && countIsEqual;
        }

        public int GetHashCode(AmountGroupItem obj)
        {
            return obj.Amount.GetHashCode() + obj.Count.GetHashCode();
        }
    }

    internal class AmountEqualityComparer : IEqualityComparer<AmountGroupItem>
    {
        public bool Equals(AmountGroupItem x, AmountGroupItem y)
        {
            //金额相等
            var keyIsEqual = new DoubleHelpMethod().IsEqual(x.Amount, y.Amount);
            return keyIsEqual;
        }

        public int GetHashCode(AmountGroupItem obj)
        {
            return obj.Amount.GetHashCode();
        }
    }
}
