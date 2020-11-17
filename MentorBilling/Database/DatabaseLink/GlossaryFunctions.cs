using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.Database.DatabaseController;
using MentorBilling.ObjectStructures.Auxilliary;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MentorBilling.Database.DatabaseLink
{
    public class GlossaryFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PostgreSqlConnection PgSqlConnection = new PostgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        /// <summary>
        /// this function will retrive the bank name from the glossary tables based upon the given bank account
        /// </summary>
        /// <param name="bankAccountController">the bank account controller</param>
        public static void GetBankOfAccount(BankAccountController bankAccountController)
        {
            String queryCommand = "SELECT denumire FROM glossary.institutii_bancare WHERE cod_iban = :p_iban ";
            NpgsqlParameter queryParameters = new NpgsqlParameter("p_iban", MentorBilling.Miscellaneous.BankFunctions.GetCodeFromIBAN(bankAccountController.Account));
            if (!PgSqlConnection.OpenConnection()) return;
            bankAccountController.Bank = PgSqlConnection.ExecuteScalar(queryCommand, queryParameters).ToString();
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }
        
        /// <summary>
        /// this function will retrieve the complete list of countries from the database glossary
        /// </summary>
        /// <returns>the country list</returns>
        public static List<Country> GetCountries()
        {
            String QueryCommand = "SELECT * FROM glossary.tari WHERE activ ";
            if (!PgSqlConnection.OpenConnection()) return null;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand);
            if (result != null && result.Rows.Count > 0)
                return result.AsEnumerable().Select(row => new Country()
                {
                    ID = row.Field<Int64>("ID"),
                    CountryCodeISO2 = row.Field<String>("COD_TARA_ISO2"),
                    CountryCodeISO3 = row.Field<String>("COD_TARA_ISO3"),
                    CountryCodeM49 = row.Field<String>("COD_TARA_ISO_M49"),
                    EnglishName = row.Field<String>("DEN_TARA_EN"),
                    RomanianName = row.Field<String>("DEN_TARA_RO")
                }).ToList();
            else return null;
        }

        /// <summary>
        /// this function will retrieve the complete list countries from the database glossary
        /// </summary>
        /// <returns>the county list</returns>
        public static List<County> GetCounties()
        {
            String QueryCommand = "SELECT * FROM glossary.judete WHERE activ ";
            if (!PgSqlConnection.OpenConnection()) return null;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand);
            if (result != null && result.Rows.Count > 0)
                return result.AsEnumerable().Select(row => new County()
                {
                    ID = row.Field<Int64>("ID"),
                    CountyCode = row.Field<String>("COD_JUDET"),
                    CountyName = row.Field<String>("DEN_JUDET")
                }).ToList();
            else return null;
        }
    }
}
