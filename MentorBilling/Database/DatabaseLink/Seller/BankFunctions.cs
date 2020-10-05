using MentorBilling.Database.DatabaseController;
using MentorBilling.ObjectStructures;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MentorBilling.Database.DatabaseLink.Seller
{
    public class BankFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        #region Select Functions
        /// <summary>
        /// this function will retrieve the complete list of viable bank accounts for a given seller
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <returns>the valid bank account list</returns>
        public static List<BankAccount> GetBankAccountsForSeller(ObjectStructures.Invoice.Seller seller) 
        {
            //the select query
            String QueryCommand = "SELECT * " +
                                    "FROM seller.conturi_bancare_furnizori " +
                                    "WHERE furnizor_id = :p_seller_id and activ";
            //the query parameters
            NpgsqlParameter QueryParameter = new NpgsqlParameter(":p_seller_id", seller.ID);
            //if the connection fails to open we return a null list
            if (!PgSqlConnection.OpenConnection()) return null;
            //we retrieve the query result into a DataTable
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //we close the connection before leaving the method
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //then check if the result contains any elements
            if (result != null && result.Rows.Count > 0)
                //if there are valid elements we cast the dataTable to the structure
                return result.AsEnumerable().Select(row => new BankAccount
                {
                    ID = row.Field<Int32>("ID"),
                    Bank = row.Field<String>("BANCA"),
                    Account = row.Field<String>("CONT")
                }).ToList();
            //else we return null
            else return null;
        }

        /// <summary>
        /// this function will retrieve the last used bank account for the given user
        /// </summary>
        /// <param name="user">the last used bank Account</param>
        /// <returns>the last used Bank Account</returns>
        public static BankAccount GetLastUsedBank(Login.UserControllers.User user)
        {
            //we generate the select command for the query 
            String QueryCommand = "SELECT * " +
                                    "FROM seller.conturi_bancare_furnizori AS cbf " +
                                    "LEFT JOIN seller.utilizatori_last_used AS ulu " +
                                        "ON ulu.conturi_bancare_last_used == cbf.id " +
                                    "WHERE ulu.utilizator_id = :p_user_id AND ulu.activ";
            //and set the query parameters
            NpgsqlParameter QueryParameter = new NpgsqlParameter(":p_user_id", user.ID);
            //we attempt to open the connection
            if (!PgSqlConnection.OpenConnection()) return null;
            //if we manage we return the results to a dataTable
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //we check if the result is empty or not
            if (result != null && result.Rows.Count > 0)
                //if not we convert the result to my object list
                return result.AsEnumerable().Select(row => new BankAccount
                {
                    ID = row.Field<Int32>("ID"),
                    Bank = row.Field<String>("BANCA"),
                    Account = row.Field<String>("CONT")
                }).First();
            //else we return the null object
            else return null;
        }
        #endregion Select Functions

        #region Insert Functions
        /// <summary>
        /// this function will add a bew bank account for the given seller to the database
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <param name="bankAccount">the new bank account</param>
        public static void AddNewBankAccountForSeller(ObjectStructures.Invoice.Seller seller, BankAccount bankAccount )
        {
            #region ActionLog
            //we generate the log action
            String LogAction = $"Adaugat un nou cont bancar la banca {bankAccount.Bank} pentru societatea {seller.Name}";
            //and the log command
            String LogCommand = "INSERT INTO seller.conturi_bancare_furnizori(furnizor_id,cont,banca) " +
                                    $"VALUES({seller.ID}, {bankAccount.Account}, {bankAccount.Bank}) " +
                                    "ON CONFLICT(cont) " +
                                    $"DO UPDATE SET banca= {bankAccount.Bank} RETURNING id";
            //before retriving the ip
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //we get the insert command for the bank account
            String QueryCommand = "INSERT INTO seller.conturi_bancare_furnizori(furnizor_id,cont,banca) " +
                                    "VALUES(:p_seller_id, :p_account, :p_bank) " +
                                    "ON CONFLICT(cont) " +
                                    "DO UPDATE SET banca= :p_bank, activ = true" +
                                    "RETURNING id";
            //and set the parameters
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(":p_seller_id",seller.ID),
                new NpgsqlParameter(":p_account",bankAccount.Account),
                new NpgsqlParameter(":p_bank",bankAccount.Bank)
            };
            //we check if we can open the connection
            if (!PgSqlConnection.OpenConnection()) return;
            //and if we can we execute the query
            bankAccount.ID = (Int32)PgSqlConnection.ExecuteScalar(QueryCommand, QueryParameters);
            //log it on the same connection
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            //before closing the connection
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
            //we generate the log Action
            String LogAction = $"Adaugat un nou cont bancar la banca {bankAccount.Bank} pentru societatea {seller.Name}";
            //we also generate the command
            String LogCommand = "INSERT INTO seller.conturi_bancare_furnizori(furnizor_id,cont,banca) " +
                                    $"VALUES({seller.ID}, {bankAccount.Account}, {bankAccount.Bank}) " +
                                    "ON CONFLICT(cont) " +
                                    $"DO UPDATE SET banca= {bankAccount.Bank} RETURNING id";
            //and get the instance IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //we generate the query command string
            String QueryCommand = "INSERT INTO seller.conturi_bancare_furnizori(furnizor_id,cont,banca) " +
                                    "VALUES(:p_seller_id, :p_account, :p_bank) " +
                                    "ON CONFLICT(cont) " +
                                    "DO UPDATE SET banca= :p_bank, activ = true " +
                                    "RETURNING id";
            //and then set the parameters for the query
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(":p_seller_id",seller.ID),
                new NpgsqlParameter(":p_account",bankAccount.Account),
                new NpgsqlParameter(":p_bank",bankAccount.Bank)
            };
            //we execute the command returning the ID over an already active connection
            bankAccount.ID = (Int32)posgreSqlConnection.ExecuteScalar(QueryCommand, QueryParameters);
            //and log the command
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
        }

        /// <summary>
        /// this function will add an entire list of bank accounts to the given seller
        /// </summary>
        /// <param name="seller">the given seller</param>
        /// <param name="bankAccounts">the list of bank account</param>
        public static void AddBankAccountsForSeller(ObjectStructures.Invoice.Seller seller, List<BankAccount> bankAccounts)
        {
            //we attemp to open the connection
            if (!PgSqlConnection.OpenConnection()) return;
            //before iterating the element is the bankAccounts list
            foreach(BankAccount bankAccount in bankAccounts)
            {
                //and call the insert function with the active connection
                AddNewBankAccountForSeller(seller, bankAccount, PgSqlConnection);
            }
            //once all is done we close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }
        #endregion Insert Functions

        #region Update Functions
        /// <summary>
        /// this function will update a givent bank account based on the ID
        /// </summary>
        /// <param name="bankAccount">the bank account</param>
        public static void UpdateBankAccountByID(BankAccount bankAccount)
        {
            #region ActionLog
            //we initialy generate the action log and command
            String LogAction = $"S-a actualizat contul bancar cu ID: {bankAccount.ID}";
            String LogCommand = "UPDATE seller.conturi_bancare_furnizori " +
                                    $"SET cont = {bankAccount.Account}, banca = {bankAccount.Bank} " +
                                    $"WHERE id = {bankAccount.ID}";
            //before retrieving the ip of the current instance
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //we generate the query command
            String QueryCommand = "UPDATE seller.conturi_bancare_furnizori " +
                                    "SET cont = :p_account, banca = :p_bank, activ = true " +
                                    "WHERE id = :p_id";
            //and set the needed parameters
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(":p_id",bankAccount.ID),
                new NpgsqlParameter(":p_account",bankAccount.Account),
                new NpgsqlParameter(":p_bank",bankAccount.Bank)
            };
            //before checking if the connection is valid
            if (!PgSqlConnection.OpenConnection()) return;
            //we then execute the uodate command
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
            //and log the action
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            //before closing the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will update a bank account 
        /// </summary>
        /// <param name="bankAccount">the given bank account</param>
        public static void UpdateBankAccountByAccount(BankAccount bankAccount)
        {
            #region ActionLog
            //we initialy generate the action log and command
            String LogAction = $"S-a actualizat contul bancar cu ID: {bankAccount.ID}";
            String LogCommand = "UPDATE seller.conturi_bancare_furnizori " +
                                    $"SET banca = {bankAccount.Bank} " +
                                    $"WHERE cont = {bankAccount.Account}";
            //before retrieving the ip of the current instance
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //we generate the query command
            String QueryCommand = "UPDATE seller.conturi_bancare_furnizori " +
                                    "SET banca = :p_bank, activ = true " +
                                    "WHERE cont = :p_account";
            //and set the query parameters.
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(":p_account",bankAccount.Account),
                new NpgsqlParameter(":p_bank",bankAccount.Bank)
            };
            //before checking if we can open the connection
            if (!PgSqlConnection.OpenConnection()) return;
            //we execute the non-query
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
            //and log the action
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            //before closing the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }
        #endregion  Update Functions
    }
}
