using System;

namespace MentorBilling.Miscellaneous
{
    public class SpecialConversions
    {
        /// <summary>
        /// this function will convert the given string fiscal code to an integer
        /// </summary>
        /// <param name="FiscalCode">the given fiscal code</param>
        /// <returns>the integer value retrieved from the string</returns>
        public static Int32 GetIntegerOfFiscalCode(String FiscalCode)
        {
            return Convert.ToInt32(FiscalCode.Replace('R', ' ').Replace('O', ' '));
        }

        /// <summary>
        /// this function will convert the given string fiscal code to an integer
        /// </summary>
        /// <param name="value">the given string value</param>
        /// <returns>a valid integer</returns>
        public static Int32 GetIntegerOfString(String value)
        {
            return Int32.TryParse(value, out Int32 result) ? result : 0;
        }
    }
}
