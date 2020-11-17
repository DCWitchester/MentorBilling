using System;
using System.Linq;

namespace MentorBilling.Miscellaneous
{
    public class ElementCheck
    {
        /// <summary>
        /// this function verifies if a fiscal code is valid or not -- Romanian standard for now
        /// </summary>
        /// <param name="CIF"> Fiscal code as string</param>
        /// <returns>the validity of the given</returns>
        public static Boolean VerifyCIF(String CIF)
        {
            String testKey = "235712357";
            //Verify and remove fiscal atribute 'Rxxxxxxxx' or 'ROxxxxxxxxxx'
            CIF = CIF.Trim().ToUpper().ToString().Replace(" ", "").Replace("R", "").Replace("O", "").Replace("-", "");
            //If lenght is less than two or greater than ten the number fails 
            if (CIF.Length < 2 || CIF.Length > 10) return false;
            //Verify if our Fiscal Code is trully a number and if the numeric lenght equals its lenght before being cast as a number
            if (!Int32.TryParse(CIF, out Int32 valueResult)) return false;
            if (valueResult.ToString().Length != CIF.Length) return false;
            //we retrieve the last key to use as a control character and remove it from the fiscal code
            Int32 controlKey = Int32.Parse(CIF[^1..]);
            CIF = CIF[0..^1];
            Int32 controlSum = 0;
            // we calculate the control sum as the  multiple of the fiscal codes characters taken in reverse with the test keys characters
            for (int i = 0; i < CIF.Length; i++) controlSum += Int32.Parse(CIF.Substring(CIF.Length - (i + 1), 1)) * Int32.Parse(testKey.Substring(i, 1));
            // we calculate the control sum as its multiple by 10 and mod 11 followed by 10 and we verify if it equals the control key.
            controlSum = ((controlSum * 10) % 11) % 10;
            return (controlSum == controlKey);
        }
        /// <summary>
        /// this function verifies wether a CNP is valid or not
        /// </summary>
        /// <param name="CNP"> the person code as string </param>
        /// <returns>the validity of the CNP</returns>
        public static Boolean VerifyCNP(String CNP)
        {
            //CNP STRUCTURE: S Y Y M M D D J J N N N C
            // S: Sex
            // Y: Year
            // M: Month
            // D: Day
            // J: Judet
            // N & C control characters
            //control key for the sum element
            Int32[] key = new Int32[13] { 2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9, 0 };
            //we trim the CNP to remove all unneded spaces
            CNP = CNP.Trim();
            //Declare an initial sum
            Int32 sum = 0;
            //If the lenght is diferent than 13 the CNP fails
            if (CNP.Length != 13) return false;
            //We verify weather the month and day are correct
            if (!Enumerable.Range(1, 12).Contains(Convert.ToInt32(CNP.Substring(3, 2))) || !Enumerable.Range(1, 31).Contains(Convert.ToInt32(CNP.Substring(5, 2)))) return false;
            //we calculate the control sum
            for (int i = 0; i < CNP.Length; i++) sum += Convert.ToInt32(CNP[i]) * key[i];
            //we comapre the contol sum with either the contol character or with 10
            return (new Int32[2] { 10, CNP[12] }).Contains(sum - (sum / 11) * 11);
        }
        /// <summary>
        /// this function verifies wether the banc IBAN is valid
        /// </summary>
        /// <param name="IBAN">the given IBAN</param>
        /// <returns>the validity of the IBAN</returns>
        public static Boolean VerifyIBAN(String IBAN)
        {
            //we remove all spaces without and within the String
            IBAN = IBAN.Trim().Replace(" ", "");
            //if the String is empty we return false
            if (IBAN.Equals("") || Char.IsDigit(IBAN[0])) return false;
            //if the lenght isn't 24 we return false
            if (IBAN.Length != 24) return false;
            String codsn = "";
            //No ideea <= took from DAN
            IBAN = IBAN.Substring(4, 20).ToUpper() + IBAN.Substring(0, 4);
            //we pass through each character : <= ERROR will be used to return false when the character is neither letter nor Digit
            foreach (char c in IBAN) codsn += Char.IsDigit(c) ? c.ToString() : Char.IsLetter(c) ? (Convert.ToInt16(c) - 55).ToString() : "ERROR";
            //If the string contains ERROR we return false
            if (IBAN.Contains("ERROR")) return false;
            int rest = 0;
            //we calculate the rest variable 
            foreach (char c in IBAN) rest = (rest * 10 + Convert.ToInt16(c)) % 97;
            //if it differs from one the IBAN is wrong.
            return (rest != 1);
        }
    }
}
