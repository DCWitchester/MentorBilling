using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Miscellaneous
{
    public class BankFunctions
    {
        public static String GetCodeFromIBAN(String IBAN)
        {
            return IBAN.Substring(4, 4);
        }
    }
}
