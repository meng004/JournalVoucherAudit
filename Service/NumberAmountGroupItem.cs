using JournalVoucherAudit.Utility;
using System.Collections.Generic;

namespace JournalVoucherAudit.Service
{
    internal class NumberAmountGroupItem
    {
        public string Number { get; set; }
        public double Amount { get; set; }
        public int Count { get; set; }
    }

    internal class NumberAmountGroupItemEqualityComparer : IEqualityComparer<NumberAmountGroupItem>
    {
        public bool Equals(NumberAmountGroupItem x, NumberAmountGroupItem y)
        {
            var numberIsEqual = (x.Number == y.Number);
            var amountIsEqual = new DoubleHelpMethod().IsEqual(x.Amount, y.Amount);
            var countIsEqual = (x.Count == y.Count);
            return numberIsEqual && amountIsEqual && countIsEqual;
        }

        public int GetHashCode(NumberAmountGroupItem obj)
        {
            return obj.Number.GetHashCode() + obj.Amount.GetHashCode() + obj.Count.GetHashCode();
        }
    }
}
