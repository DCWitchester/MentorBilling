using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures
{
    public class BankAccount
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the id property of the BankAccount Structure
        /// </summary>
        private Int64 id { get; set; } = new Int64();

        /// <summary>
        /// the Account property
        /// </summary>
        private String account { get; set; } = String.Empty;

        /// <summary>
        /// the linked Bank property
        /// </summary>
        private String bank { get; set; } = String.Empty;
#pragma warning restore IDE1006
        #endregion

        #region Callers
        /// <summary>
        /// the main caller for the id property
        /// </summary>
        public Int64 ID 
        {
            get => id; 
            set => id = value; 
        }

        /// <summary>
        /// the main caller for the account property
        /// </summary>
        public String Account
        {
            get => account;
            set => account = value;
        }

        /// <summary>
        /// the main caller for the bank property
        /// </summary>
        public String Bank
        {
            get => bank;
            set => bank = value;
        }
        #endregion

        #region Miscellaneous
        /// <summary>
        /// the value porperty for the entire object
        /// </summary>
        public BankAccount Value
        {
            get => this;
            set => ConsumeBankAccount(value);
        }

        /// <summary>
        /// this function will consume a given bank account and give it to this object
        /// </summary>
        /// <param name="Value">the given value</param>
        public void ConsumeBankAccount(BankAccount Value)
        {
            this.account = Value.account;
            this.id = Value.ID;
            this.bank = Value.bank;
        }
        #endregion
    }
}
