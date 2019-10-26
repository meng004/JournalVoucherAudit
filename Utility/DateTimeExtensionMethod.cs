using System;

namespace JournalVoucherAudit.Utility
{
    public static class DateTimeExtensionMethod
    {
        /// <summary>
        /// 当月第一日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            return firstDayOfMonth;
        }
        /// <summary>
        /// 当月最后一日
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime date)
        {
            var firstDayOfMonth = FirstDayOfMonth(date);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            return lastDayOfMonth;
        }
    }
}
