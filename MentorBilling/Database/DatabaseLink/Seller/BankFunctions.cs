using MentorBilling.Database.DatabaseController;
using MentorBilling.ObjectStructures;
using Npgsql;
using System;
using System.Collections.Generic;

namespace MentorBilling.Database.DatabaseLink.Seller
{
    public class BankFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        /// <summary>
        /// this function will add a bew bank account for the given seller to the database
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <param name="bankAccount">the new bank account</param>
        public static void AddNewBankAccountForSeller(ObjectStructures.Invoice.Seller seller, BankAccount bankAccount )
        {
            #region ActionLog
            String LogAction = $"Adaugat un nou cont bancar la banca {bankAccount.Bank} pentru societatea {seller.Name}";
            String LogCommand = "INSERT INTO seller.conturi_bancare_furnizori(furnizor_id,cont,banca) " +
                                    $"VALUES({seller.ID}, {bankAccount.Account}, {bankAccount.Bank}) " +
                                    "ON CONFLICT(cont) " +
                                    $"DO UPDATE SET banca= {bankAccount.Bank} RETURNING id";
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            String QueryCommand = "INSERT INTO seller.conturi_bancare_furnizori(furnizor_id,cont,banca) " +
                                    "VALUES(:p_seller_id, :p_account, :p_bank) " +
                                    "ON CONFLICT(cont) " +
                                    "DO UPDATE SET banca= :p_bank RETURNING id";
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(":p_seller_id",seller.ID),
                new NpgsqlParameter(":p_account",bankAccount.Account),
                new NpgsqlParameter(":p_bank",bankAccount.Bank)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            bankAccount.ID = (Int32)PgSqlConnection.ExecuteScalar(QueryCommand, QueryParameters);
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will add a new bank account to a given seller by piggy-backing on an already active connection
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <param name="bankAccount">the bank account controller</param>
        /// <param name="posgreSqlConnection">the active connection</param>
        public static void AddNewBankAccountForSeller(ObjectStructures.Invoice.Seller seller, BankAccount bankAccount, PosgreSqlConnection posgreSqlConnection)
        {
            #region ActionLog
            String LogAction = $"Adaugat un nou cont bancar la banca {bankAccount.Bank} pentru societatea {seller.Name}";
            String LogCommand = "INSERT INTO seller.conturi_bancare_furnizori(furnizor_id,cont,banca) " +
                                    $"VALUES({seller.ID}, {bankAccount.Account}, {bankAccount.Bank}) " +
                                    "ON CONFLICT(cont) " +
                                    $"DO UPDATE SET banca= {bankAccount.Bank} RETURNING id";
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            String QueryCommand = "INSERT INTO seller.conturi_bancare_furnizori(furnizor_id,cont,banca) " +
                                    "VALUES(:p_seller_id, :p_account, :p_bank) " +
                                    "ON CONFLICT(cont) " +
                                    "DO UPDATE SET banca= :p_bank RETURNING id";
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(":p_seller_id",seller.ID),
                new NpgsqlParameter(":p_account",bankAccount.Account),
                new NpgsqlParameter(":p_bank",bankAccount.Bank)
            };
            bankAccount.ID = (Int32)posgreSqlConnection.ExecuteScalar(QueryCommand, QueryParameters);
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will add an entire list of bank accounts to the given seller
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <param name="bankAccounts">the list of bank account</param>
        public static void AddBankAccountsForSeller(ObjectStructures.Invoice.Seller seller, List<BankAccount> bankAccounts)
        {
            if (!PgSqlConnection.OpenConnection()) return;
            foreach(BankAccount bankAccount in bankAccounts)
            {
                AddNewBankAccountForSeller(seller, bankAccount, PgSqlConnection);
            }
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will update a givent bank account based on the ID
        /// </summary>
        /// <param name="bankAccount">the bank account</param>
        public static void UpdateBankAccountByID(BankAccount bankAccount)
        {
            #region ActionLog
            String LogAction = $"S-a actualizat contul bancar cu ID: {bankAccount.ID}";
            String LogCommand = "UPDATE seller.conturi_bancare_furnizori " +
                                    $"SET cont = {bankAccount.Account}, banca = {bankAccount.Bank} " +
                                    $"WHERE id = {bankAccount.ID}";
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            String QueryCommand = "UPDATE seller.conturi_bancare_furnizori " +
                                    "SET cont = :p_account, banca = :p_bank " +
                                    "WHERE id = :p_id";
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(":p_id",bankAccount.ID),
                new NpgsqlParameter(":p_account",bankAccount.Account),
                new NpgsqlParameter(":p_bank",bankAccount.Bank)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will update a bank account 
        /// </summary>
        /// <param name="bankAccount">the given bank account</param>
        public static void UpdateBankAccountByAccount(BankAccount bankAccount)
        {
             #region ActionLog
            String LogAction = $"S-a actualizat contul bancar cu ID: {bankAccount.ID}";
            String LogCommand = "UPDATE seller.conturi_bancare_furnizori " +
                                    $"SET banca = {bankAccount.Bank} " +
                                    $"WHERE cont = {bankAccount.Account}";
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            String QueryCommand = "UPDATE seller.conturi_bancare_furnizori " +
                                    "SET banca = :p_bank " +
                                    "WHERE cont = :p_account";
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(":p_account",bankAccount.Account),
                new NpgsqlParameter(":p_bank",bankAccount.Bank)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }
    }
}
