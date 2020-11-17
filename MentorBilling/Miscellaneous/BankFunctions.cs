using System;

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
