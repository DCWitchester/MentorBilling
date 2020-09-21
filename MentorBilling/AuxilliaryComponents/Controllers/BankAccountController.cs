using MentorBilling.ObjectStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.AuxilliaryComponents.Controllers
{
    public class BankAccountController
    {
        /// <summary>
        /// the main property for the Bank Account
        /// </summary>
        private BankAccount BankAccount {get;set;} 

        /// <summary>
        /// the initializer for the bank account with both the index and the bank Account
        /// </summary>
        /// <param name="bankAccount">the BankAccount</param>
        /// <param name="elementIndex">the element index</param>
        public BankAccountController(BankAccount bankAccount, Int32 elementIndex)
        {
            BankAccount = bankAccount;
            ElementIndex = elementIndex;
        }

        /// <summary>
        /// this function will initiallize the controller with only the bankAccount
        /// </summary>
        /// <param name="bankAccount">the bankAccoun</param>
        public BankAccountController(BankAccount bankAccount)
        {
            BankAccount = bankAccount;
        }

        /// <summary>
        /// the element Index from the parent list
        /// </summary>
        public Int32 ElementIndex { get; set; } = new Int32();
        
        /// <summary>
        /// this account bound to the text box element
        /// </summary>
        public String Account 
        { 
            get => BankAccount.Account;
            set => BankAccount.Account = UpdateAccountAndBank(value);
        }
        /// <summary>
        /// the bank  bound to the text box element
        /// </summary>
        public String Bank 
        { 
            get => BankAccount.Bank; 
            set => BankAccount.Bank = value; 
        }

        /// <summary>
        /// this function will add the element index to the element and return it
        /// </summary>
        /// <param name="elementIndex">the elementIndex</param>
        /// <returns>itself</returns>
        public BankAccountController SetElementIndex(Int32 elementIndex)
        {
            ElementIndex = elementIndex;
            return this;
        }

        /// <summary>
        /// this function will validate only if the field has been completed
        /// </summary>
        [Range(typeof(bool), "true", "true", ErrorMessage = "Contul introdus nu reprezinta un IBAN Valid")]
        public Boolean IsAccountValid 
        { 
            get => Miscellaneous.ElementCheck.VerifyIBAN(Account) 
                || String.IsNullOrWhiteSpace(Account); 
        }   
        
        /// <summary>
        /// this function will check that at least the first account has a value
        /// </summary>
        [Range(typeof(bool),"false","false", ErrorMessage = "Cel putin un cont bancar trebuie completat")]
        public Boolean IsAccountNeeded 
        { 
            get => 
                String.IsNullOrWhiteSpace(Account) 
                || ElementIndex != 0; 
        }

        /// <summary>
        /// this function will check that at least the first bank has a value
        /// </summary>
        [Range(typeof(bool), "false", "false", ErrorMessage = "Cel putin o banca trebuie completat")]
        public Boolean IsBankNeeded 
        { 
            get => 
                String.IsNullOrWhiteSpace(Bank) || 
                ElementIndex != 0; 
        }

        /// <summary>
        /// this function will check that if a valid IBAN was entered you should also enter the bank
        /// </summary>
        [Range(typeof(bool), "false", "false", ErrorMessage = "Banca trebuie completata daca ati introdus un IBAN Valid")]
        public Boolean IsAccountFilledIn 
        { 
            get => 
                Miscellaneous.ElementCheck.VerifyIBAN(Account); 
        }
        
        /// <summary>
        /// this function will update the the bank for the given account
        /// </summary>
        /// <param name="Value">the value returned from the input text</param>
        /// <returns>the value of the input text</returns>
        private String UpdateAccountAndBank(String Value)
        {
            this.BankAccount.Account = Value;
            if (Miscellaneous.ElementCheck.VerifyIBAN(Value))
            {
                Database.DatabaseLink.GlossaryFunctions.GetBankOfAccount(this);
            }
            return Value;
        }
    }
}
