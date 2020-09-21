using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.Database.DatabaseController;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink
{
    public class GlossaryFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        public static void GetBankOfAccount(BankAccountController bankAccountController)
        {
            String queryCommand = "SELECT denumire FROM glossary.institutii_bancare WHERE cod_iban = :p_iban ";
            NpgsqlParameter queryParameters = new NpgsqlParameter("p_iban", MentorBilling.Miscellaneous.BankFunctions.GetCodeFromIBAN(bankAccountController.Account));
            if (!PgSqlConnection.OpenConnection()) return;
            bankAccountController.Bank = PgSqlConnection.ExecuteScalar(queryCommand, queryParameters).ToString();
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }
    }
}
