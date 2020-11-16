using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Extensions
{
    /// <summary>
    /// this class will contain base functionality extensions for the program
    /// </summary>
    public static class FunctionalityExtensions
    {
        /// <summary>
        /// the base comparer containing the end points
        /// </summary>
        /// <typeparam name="T">the parameter type</typeparam>
        /// <param name="item">the item to be checked</param>
        /// <param name="start">the start item</param>
        /// <param name="end">the end item</param>
        /// <returns></returns>
        public static Boolean IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                && Comparer<T>.Default.Compare(item, end) <= 0;
        }

        /// <summary>
        /// the base comparer that won't contain the end points
        /// </summary>
        /// <typeparam name="T">the parameter type</typeparam>
        /// <param name="item">the item to be checked</param>
        /// <param name="start">the start item</param>
        /// <param name="end">the end item</param>
        /// <returns></returns>
        public static Boolean IsInBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) > 0
                && Comparer<T>.Default.Compare(item, end) < 0;
        }
    }
}
