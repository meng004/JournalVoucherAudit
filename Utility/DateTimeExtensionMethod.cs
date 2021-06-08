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
            var lastDayOfMonth = date.AddDays(1 - date.Day).AddMonths(1).AddDays(-1);
            return lastDayOfMonth;
        }
    }
}
