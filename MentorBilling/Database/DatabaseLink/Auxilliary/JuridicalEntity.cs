using MentorBilling.Database.DatabaseController;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink.Auxilliary
{
    public class JuridicalEntity
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.JuridicalEntityConnectionSettings);

        /// <summary>
        /// this function will retrieve the registy number based on the given fiscal code
        /// </summary>
        /// <param name="FiscalCode">the given fiscal code</param>
        /// <returns>the registry number linked to the given fiscal code</returns>
        public static String GetRegistryNumberForFiscalCode(Int32 FiscalCode)
        {
            //the query select command
            String QueryCommand = "SELECT cod_inmatriculare_registru_comert FROM fiscal_entity.entitati_fiscale WHERE cod_fiscal = :p_fiscal_code";
            //the query parameters
            NpgsqlParameter QueryParameters = new NpgsqlParameter(":p_fiscal_code",FiscalCode);
            //we check if we are able to open a connection
            if (!PgSqlConnection.OpenConnection()) return String.Empty;
            //the result value as a string
            String result = PgSqlConnection.ExecuteScalar(QueryCommand, QueryParameters).ToString();
            //never ever kids forget to close a connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //and finally return the result
            return result;
        }
    }
}
 