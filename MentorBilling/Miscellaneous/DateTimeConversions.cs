using System;

namespace MentorBilling.Miscellaneous
{
    public class DateTimeConversions
    {
        /// <summary>
        /// this function will get the first day of a given month
        /// </summary>
        /// <param name="dateTime">the given DateTime</param>
        /// <returns>a new DateTime</returns>
        public static DateTime GetFirstDayOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
        /// <summary>
        /// this function will get the last day of a given month
        /// </summary>
        /// <param name="dateTime">the given DateTime</param>
        /// <returns>a new DateTime</returns>
        public static DateTime GetLastDayOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month + 1, 1).AddDays(-1);
        }
    }
}
