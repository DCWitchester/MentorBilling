using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.AuxilliaryComponents.Controllers
{
    public class BankAccountController
    {
        /// <summary>
        /// the element Index from the parent list
        /// </summary>
        public Int32 ElementIndex { get; set; } = new Int32();
        /// <summary>
        /// this account bound to the text box element
        /// </summary>
        public String Account { get; set; } = String.Empty;
        /// <summary>
        /// the bank  bound to the text box element
        /// </summary>
        public String Bank { get; set; } = String.Empty;

        /// <summary>
        /// this function will validate only if the field has been completed
        /// </summary>
        [Range(typeof(bool), "true", "true", ErrorMessage = "Contul introdus nu reprezinta un IBAN Valid")]
        public Boolean IsAccountValid { get => Miscellaneous.ElementCheck.VerifyIBAN(Account) || (ElementIndex != 0 && String.IsNullOrWhiteSpace(Account)); }   
        
        /// <summary>
        /// this function will check that at least the first account has a value
        /// </summary>
        [Range(typeof(bool),"true","true", ErrorMessage = "Cel putin un cont bancar trebuie completat")]
        public Boolean IsAccountNeeded { get => String.IsNullOrWhiteSpace(Account) || ElementIndex != 0; }

        /// <summary>
        /// this function will check that at least the first bank has a value
        /// </summary>
        [Range(typeof(bool), "true", "true", ErrorMessage = "Cel putin o banca trebuie completat")]
        public Boolean IsBankNeeded { get => String.IsNullOrWhiteSpace(Bank) || ElementIndex != 0; }
    }
}
