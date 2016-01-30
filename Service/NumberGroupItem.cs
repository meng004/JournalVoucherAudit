using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JournalVoucherAudit.Utility;

namespace JournalVoucherAudit.Service
{
    internal class NumberGroupItem 
    {
        public string Number { get; set; }
        public double Total { get; set; }
    }

    internal class NumberGroupItemEqualityComparer : IEqualityComparer<NumberGroupItem>
    {
        public bool Equals(NumberGroupItem x, NumberGroupItem y)
        {
            var numberIsEqual = x.Number == y.Number;
            var totalIsEqual = new DoubleHelpMethod().IsEqual(x.Total, y.Total);
            return numberIsEqual && totalIsEqual;
        }

        public int GetHashCode(NumberGroupItem obj)
        {
            return obj.Number.GetHashCode() + obj.Total.GetHashCode();
        }
    }
}
