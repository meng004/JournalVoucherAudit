using System;

namespace JournalVoucherAudit.Utility
{
    public static class DateTimeExtensionMethod
    {
        /// <summary>
        /// 当月最后一日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime date)
        {

            var nextMonth = new DateTime(date.Year, date.Month + 1, 1);
            var lastDayOfMonth = nextMonth.AddDays(-1);
            return lastDayOfMonth;
        }
    }
}
