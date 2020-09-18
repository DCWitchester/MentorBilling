using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Miscellaneous.ANAF
{
    /// <summary>
    /// the error class for the current structure
    /// </summary>
    public class Error
    {
        /// <summary>
        /// the error code
        /// </summary>
        public String code;
        /// <summary>
        /// the error message
        /// </summary>
        public String message;

        /// <summary>
        /// the form caller with two parameters
        /// </summary>
        /// <param name="code">the main element code</param>
        /// <param name="message">the main element message</param>
        public Error(String code, String message)
        {
            this.code = code;
            this.message = message;
        }
    }
}
