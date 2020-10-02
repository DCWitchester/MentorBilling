using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.Database.DatabaseController;
using MentorBilling.Invoice.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink.Seller
{
    public class BankFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        public static void AddNewBankAccountForSeller(SellerController seller, BankAccountController bankAccountController )
        {
            String QueryCommand = "INSERT INTO ";
        }
    }
}
