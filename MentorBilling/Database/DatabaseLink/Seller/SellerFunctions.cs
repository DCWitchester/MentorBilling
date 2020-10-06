using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous.Emails;
using MentorBilling.ObjectStructures.Auxilliary;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MentorBilling.Database.DatabaseLink.Seller
{
    public class SellerFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        #region Select Functions
        /// <summary>
        /// this function will get a complete list of sellers for the given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>a list of sellers</returns>
        public static List<ObjectStructures.Invoice.Seller> GetSellersForUser(User user)
        {
            //we initialize the query select command
            String QueryCommand = "SELECT * FROM seller.furnizori WHERE utilizator_id = :p_user_id AND activ";
            //set the solo query parameter
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_user_id", user.ID);
            //if we fail to open the connection we return a null object
            if (!PgSqlConnection.OpenConnection()) return null;
            //if not we retrieve the query results into a DataTable
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //once that is done we close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //if the result contains at least one entry
            if (result != null && result.Rows.Count > 0)
                //we use linq select to transform the dataTable to a list of Seller objects
                return result.AsEnumerable().Select(row => new ObjectStructures.Invoice.Seller
                {
                    ID = row.Field<Int32>("ID"),
                    Name = row.Field<String>("DENUMIRE"),
                    CommercialRegistryNumber = row.Field<String>("NR_REGISTRU_COMERT"),
                    FiscalCode = row.Field<String>("COD_FISCAL"),
                    Headquarters = row.Field<String>("SEDIUL"),
                    WorkPoint = row.Field<String>("PUNCT_LUCRU"),
                    Phone = row.Field<String>("TELEFON"),
                    Email = row.Field<String>("EMAIL"),
                    Logo = new Logo(row.Field<Byte[]>("SIGLA"))
                }).ToList();
            else return null;
        }

        /// <summary>
        /// this function will retrieve the logo of a given seller
        /// </summary>
        /// <param name="seller">the logo</param>
        /// <returns>the logo object</returns>
        public static Logo GetLogoOfSeller(ObjectStructures.Invoice.Seller seller)
        {
            //the query select command
            String QueryCommand = "SELECT sigla FROM seller.furnizori WHERE id = :p_seller AND activ";
            //the query parameter
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_seller", seller.ID);
            //once we have the query command and parameters we check to see if we are able to open the connection
            if(!PgSqlConnection.OpenConnection()) return null;
            //we retrive the logo as a ByteArray
            Byte[] value = (Byte[])PgSqlConnection.ExecuteScalar(QueryCommand, QueryParameter);
            //we close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //and return a new Logo over the
            return new Logo(value);
        }

        /// <summary>
        /// this function will retrieve a seller by a given id
        /// </summary>
        /// <param name="id">the given id</param>
        /// <returns>the seller retrived from the database</returns>
        public static ObjectStructures.Invoice.Seller GetSellerByID(Int32 id)
        {
            //the select query command
            String QueryCommand = "SELECT * FROM seller.furnizori WHERE id = :p_seller AND activ";
            //and its sole parameter
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_seller", id);
            //we check the connection
            if (!PgSqlConnection.OpenConnection()) return null;
            //if the connection is active we atempt to retrive the viable sellers into a dataTable
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //we close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //then we check if we have at least one value
            //taking into account the structure we should also have at most one row
            if (result != null && result.Rows.Count > 0)
                //we do the same Select_Cast to get the seller object list but we only take the first element
                return result.AsEnumerable().Select(row => new ObjectStructures.Invoice.Seller
                {
                    ID = row.Field<Int32>("ID"),
                    Name = row.Field<String>("DENUMIRE"),
                    CommercialRegistryNumber = row.Field<String>("NR_REGISTRU_COMERT"),
                    FiscalCode = row.Field<String>("COD_FISCAL"),
                    Headquarters = row.Field<String>("SEDIUL"),
                    WorkPoint = row.Field<String>("PUNCT_LUCRU"),
                    Phone = row.Field<String>("TELEFON"),
                    Email = row.Field<String>("EMAIL"),
                    Logo = new Logo(row.Field<Byte[]>("SIGLA"))
                }).ToList().First();
            //if the result is empty we return a null object
            else return null;
        }

        /// <summary>
        /// this function will retrieve a seller by a given fiscal code
        /// </summary>
        /// <param name="fiscalCode">the given fiscal code</param>
        /// <returns>the seller retrieved from the database</returns>
        public static ObjectStructures.Invoice.Seller GetSellerByFiscalCode(String fiscalCode)
        {
            //the select command
            //seiing as cod_fiscal is a unique key for the seller.furnizori table the query should return at most one value
            String QueryCommand = "SELECT * FROM seller.furnizori WHERE cod_fiscal = :p_seller_fiscal_code AND activ";
            //the sole parameter for the query
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_seller_fiscal_code", fiscalCode);
            //we test the connection 
            if (!PgSqlConnection.OpenConnection()) return null;
            //and retrive the results into a dataTable
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //we close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //and check if there are any viable values in the dataTable
            if (result != null && result.Rows.Count > 0)
                //if there are we transform the dataTable to a list of seller objects and get the first element
                return result.AsEnumerable().Select(row => new ObjectStructures.Invoice.Seller
                {
                    ID = row.Field<Int32>("ID"),
                    Name = row.Field<String>("DENUMIRE"),
                    CommercialRegistryNumber = row.Field<String>("NR_REGISTRU_COMERT"),
                    FiscalCode = row.Field<String>("COD_FISCAL"),
                    Headquarters = row.Field<String>("SEDIUL"),
                    WorkPoint = row.Field<String>("PUNCT_LUCRU"),
                    Phone = row.Field<String>("TELEFON"),
                    Email = row.Field<String>("EMAIL"),
                    Logo = new Logo(row.Field<Byte[]>("SIGLA"))
                }).ToList().First();
            //else we return a null object
            else return null;
        }

        /// <summary>
        /// this function will retrieve the last seller used by the current user
        /// </summary>
        /// <param name="user">the current user</param>
        /// <returns>the last used seller object</returns>
        public static ObjectStructures.Invoice.Seller GetLastUsedSeller(User user)
        {
            //the select query command
            String QueryCommand = "SELECT seller.* " +
                                    "FROM seller.furnizori " +
                                    "RIGHT JOIN seller.utilizatori_last_used " +
                                    "ON furnizori.id = utilizatori_last_used.furnizori_last_used " +
                                    "WHERE utilizatori_last_used.utilizator_id = :p_user_id AND utilizatori_last_used.activ";
            //and the sole query parameters
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_user_id",user.ID);
            //we try to open the connection
            if (!PgSqlConnection.OpenConnection()) return null;
            //if we are able we execute the query returning the values to a DataTable
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //then close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //we check if the given list has any elements
            if (result != null && result.Rows.Count > 0)
                //if there are any results we convert the data table to the seller list and retrieve the first value
                return result.AsEnumerable().Select(row => new ObjectStructures.Invoice.Seller
                {
                    ID = row.Field<Int32>("ID"),
                    Name = row.Field<String>("DENUMIRE"),
                    CommercialRegistryNumber = row.Field<String>("NR_REGISTRU_COMERT"),
                    FiscalCode = row.Field<String>("COD_FISCAL"),
                    Headquarters = row.Field<String>("SEDIUL"),
                    WorkPoint = row.Field<String>("PUNCT_LUCRU"),
                    Phone = row.Field<String>("TELEFON"),
                    Email = row.Field<String>("EMAIL"),
                    Logo = new Logo(row.Field<Byte[]>("SIGLA"))
                }).ToList().First();
            else return null;
        }

        /// <summary>
        /// this function will update the given seller with its database info using its ID as a link
        /// </summary>
        /// <param name="seller">the given seller</param>
        public static void UpdateLocalSellerByID(ObjectStructures.Invoice.Seller seller)
        {
            //the select query command
            String QueryCommand = "SELECT * FROM seller.furnizori WHERE id = :p_seller";
            //the sole query parameter
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_seller", seller.ID);
            //we try to open the connection
            if (!PgSqlConnection.OpenConnection()) return;
            //then we will execute the query as a reader to the datatable
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //and close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //if the table has at least one viable result
            if (result != null && result.Rows.Count > 0)
            {
                seller.ID = result.Rows[0].Field<Int32>("ID");
                seller.Name = result.Rows[0].Field<String>("DENUMIRE");
                seller.CommercialRegistryNumber = result.Rows[0].Field<String>("NR_REGISTRU_COMERT");
                seller.FiscalCode = result.Rows[0].Field<String>("COD_FISCAL");
                seller.Headquarters = result.Rows[0].Field<String>("SEDIUL");
                seller.WorkPoint = result.Rows[0].Field<String>("PUNCT_LUCRU");
                seller.Phone = result.Rows[0].Field<String>("TELEFON");
                seller.Email = result.Rows[0].Field<String>("EMAIL");
                seller.Logo = new Logo(result.Rows[0].Field<Byte[]>("SIGLA"));
            }
        }

        /// <summary>
        /// this function will update the given seller with its database info using its fiscal
        /// </summary>
        /// <param name="seller">the given seller</param>
        public static void UpdateLocalSellerByFiscalCode(ObjectStructures.Invoice.Seller seller)
        {
            //the select query
            String QueryCommand = "SELECT * FROM seller.furnizori WHERE cod_fiscal = :p_seller_fiscal_code";
            //the sole parameter
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_seller_fiscal_code", seller.FiscalCode);
            //we check the connection
            if (!PgSqlConnection.OpenConnection()) return;
            //before returning the reader result to a dataTable
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //once we have the table we close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //we check if we have any viable values and if we do we update the given seller
            if (result != null && result.Rows.Count > 0) 
            {
                seller.ID = result.Rows[0].Field<Int32>("ID");
                seller.Name = result.Rows[0].Field<String>("DENUMIRE");
                seller.CommercialRegistryNumber = result.Rows[0].Field<String>("NR_REGISTRU_COMERT");
                seller.FiscalCode = result.Rows[0].Field<String>("COD_FISCAL");
                seller.Headquarters = result.Rows[0].Field<String>("SEDIUL");
                seller.WorkPoint = result.Rows[0].Field<String>("PUNCT_LUCRU");
                seller.Phone = result.Rows[0].Field<String>("TELEFON");
                seller.Email = result.Rows[0].Field<String>("EMAIL");
                seller.Logo = new Logo(result.Rows[0].Field<Byte[]>("SIGLA"));
            }
        }
        #endregion Select Functions

        #region Insert Functions
        /// <summary>
        /// this function will add a new seller to the database and link it to the given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="seller">the new seller</param>
        public static void AddSellerToUser(User user, ObjectStructures.Invoice.Seller seller)
        {
            #region ActionLog
            //the log action will contain an explanation of the command
            String LogAction = $"S-a adaugat o noua firma cu denumirea {seller.Name} pentru utilizatorul {user.ID}";
            //the formatted log command
            String LogCommand = "INSERT INTO seller.furnizori(denumire,nr_registru_comert,cod_fiscal,capital_social,sediul,punct_lucru,telefon,email,utilizator_id) " +
                                    $"VALUES({seller.Name},{seller.CommercialRegistryNumber},{seller.FiscalCode},{seller.JointStock},{seller.Headquarters},{seller.WorkPoint},{seller.Phone},{seller.Email},{user.ID}) " +
                                    "ON CONFLICT(cod_fiscal) " +
                                    $"DO UPDATE SET denumire = {seller.Name}, " +
                                        $"nr_registru_comert = {seller.CommercialRegistryNumber}, " +
                                        $"capital_social = {seller.JointStock}, " +
                                        $"sediul = {seller.Headquarters}, " +
                                        $"punct_lucru = {seller.WorkPoint}, " +
                                        $"telefon = {seller.Phone}, " +
                                        $"email = {seller.Email}, " +
                                        $"utilizator_id = {user.ID} " +
                                    "RETURNING id";
            //the instance IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //the insert query command
            //for any possible error we use the on conflict over the unique key
            String QueryCommand = "INSERT INTO seller.furnizori(denumire,nr_registru_comert,cod_fiscal,capital_social,sediul,punct_lucru,telefon,email,sigla,utilizator_id) " +
                                    "VALUES(:p_name,:p_registry,:p_fiscal_code,:p_joint_stock,:p_headquarters,:p_adress,:p_phone,:p_email,:p_logo,:p_user_id) " +
                                    "ON CONFLICT(cod_fiscal) " +
                                    "DO UPDATE SET denumire = :p_name, " +
                                        "nr_registru_comert = :p_registry, " +
                                        "capital_social = :p_joint_stock, " +
                                        "sediul = :p_headquarters, " +
                                        "punct_lucru = :p_adress, " +
                                        "telefon = :p_phone, " +
                                        "email = :p_email, " +
                                        "sigla = :p_logo, " +
                                        "utilizator_id = :p_user_id " +
                                    "RETURNING id";
            //we initialize the parameter list
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_name",seller.Name),
                new NpgsqlParameter("p_registry",seller.CommercialRegistryNumber),
                new NpgsqlParameter("p_fiscal_code",seller.FiscalCode),
                new NpgsqlParameter("p_joint_stock",seller.JointStock),
                new NpgsqlParameter("p_headquarters",seller.Headquarters),
                new NpgsqlParameter("p_adress",seller.WorkPoint),
                new NpgsqlParameter("p_phone",seller.Phone),
                new NpgsqlParameter("p_email",seller.Email),
                //the logo parameter is special for it needs the specific dataType cast
                //implicit cast doesn't queite work for ByteA
                new NpgsqlParameter()
                {
                    ParameterName = "p_logo",
                    NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea,
                    Value = seller.Logo.LogoBase
                },
                new NpgsqlParameter("p_user_id",user.ID)
            };
            //we check to see if we can open the connection
            if (!PgSqlConnection.OpenConnection()) return;
            //the execute the query as a scalar for we require the ID
            seller.ID = (Int32)PgSqlConnection.ExecuteScalar(QueryCommand,QueryParameters);
            //then we piggy-back the log on the same active connection
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            //and close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }
        #endregion Insert Functions

        #region Update Functions
        /// <summary>
        /// update the seller with the given logo
        /// </summary>
        /// <param name="logo">the given logo</param>
        /// <param name="seller">the seller</param>
        public static void AddLogoToSeller(Logo logo, ObjectStructures.Invoice.Seller seller)
        {
            #region Action Log
            //the log action detailing the event
            String LogAction = $"S-a adaugat/modificat logo-ul la societatea cu denumirea {seller.Name}";
            //the query formatted command
            String LogCommand = $"UPDATE seller.furnizori SET sigla = {logo.LogoBase.Take(10)} WHERE id = {seller.ID}";
            //the IP of the user instance
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //the update command
            String QueryCommand = "UPDATE seller.furnizori SET sigla = :p_logo WHERE id = :p_seller_id";
            //the command parameters
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_seller_id",seller.ID),
                new NpgsqlParameter()
                {
                    ParameterName = "p_logo",
                    NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea,
                    Value = logo.LogoBase
                }
            };
            //we check the connection
            if (!PgSqlConnection.OpenConnection()) return;
            //and execute the update command
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
            //before logging the command
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            //and closing the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// update a given seller by id
        /// </summary>
        /// <param name="seller">the given seller</param>
        public static void UpdateSellerByID(ObjectStructures.Invoice.Seller seller)
        {
            #region ActionLog
            //the log action detailing the event
            String LogAction = $"S-au actualizat datele societatii cu denumirea {seller.Name}";
            //the formatted log command
            //for safety reasons it does not contain the image
            String LogCommand = "UPDATE seller.furnizori " +
                                    $"SET denumire = {seller.Name}, " +
                                        $"nr_registru_comert = {seller.CommercialRegistryNumber}, " +
                                        $"capital_social = {seller.JointStock}, " +
                                        $"sediul = {seller.Headquarters}, " +
                                        $"punct_lucru = {seller.WorkPoint}, " +
                                        $"telefon = {seller.Phone}, " +
                                        $"email = {seller.Email}, " +
                                      $"WHERE id = {seller.ID}";
            //the ip of the instance user
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //the query update command string
            String QueryCommand = "UPDATE seller.furnizori " +
                                    "SET denumire = :p_name, " +
                                        "nr_registru_comert = :p_registry, " +
                                        "capital_social = :p_joint_stock, " +
                                        "sediul = :p_headquarters, " +
                                        "punct_lucru = :p_adress, " +
                                        "telefon = :p_phone, " +
                                        "email = :p_email, " +
                                        "sigla = :p_logo" +
                                      "WHERE id = :p_seller_id";
            //the complete list of query parameters
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_name",seller.Name),
                new NpgsqlParameter("p_registry",seller.CommercialRegistryNumber),
                new NpgsqlParameter("p_joint_stock",seller.JointStock),
                new NpgsqlParameter("p_headquarters",seller.Headquarters),
                new NpgsqlParameter("p_adress",seller.WorkPoint),
                new NpgsqlParameter("p_phone",seller.Phone),
                new NpgsqlParameter("p_email",seller.Email),
                new NpgsqlParameter("p_seller_id",seller.ID),
                new NpgsqlParameter()
                {
                    ParameterName = "p_logo",
                    NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea,
                    Value = seller.Logo.LogoBase
                }
            };
            //we check the connection 
            if (!PgSqlConnection.OpenConnection()) return;
            //and execute the non-query
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
            //then also log the action on the same query
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            //then close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// update a given seller by its fiscal code
        /// </summary>
        /// <param name="seller">the given seller</param>
        public static void UpdateSellerByFiscalCode(ObjectStructures.Invoice.Seller seller)
        {
            #region ActionLog
            //the log action detailing the command
            String LogAction = $"S-au actualizat datele societatii cu denumirea {seller.Name}";
            //the formatted query command
            String LogCommand = "UPDATE seller.furnizori " +
                                    $"SET denumire = {seller.Name}, " +
                                        $"nr_registru_comert = {seller.CommercialRegistryNumber}, " +
                                        $"capital_social = {seller.JointStock}, " +
                                        $"sediul = {seller.Headquarters}, " +
                                        $"punct_lucru = {seller.WorkPoint}, " +
                                        $"telefon = {seller.Phone}, " +
                                        $"email = {seller.Email}, " +
                                      $"WHERE cod_fiscal = {seller.FiscalCode}";
            //the instance ip adress
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //the query command
            String QueryCommand = "UPDATE seller.furnizori " +
                                    "SET denumire = :p_name, " +
                                        "nr_registru_comert = :p_registry, " +
                                        "capital_social = :p_joint_stock, " +
                                        "sediul = :p_headquarters, " +
                                        "punct_lucru = :p_adress, " +
                                        "telefon = :p_phone, " +
                                        "email = :p_email, " +
                                        "sigla = :p_logo " +
                                      "WHERE cod_fiscal = :p_fiscal_code";
            //the complete parameter list
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_name",seller.Name),
                new NpgsqlParameter("p_registry",seller.CommercialRegistryNumber),
                new NpgsqlParameter("p_fiscal_code",seller.FiscalCode),
                new NpgsqlParameter("p_joint_stock",seller.JointStock),
                new NpgsqlParameter("p_headquarters",seller.Headquarters),
                new NpgsqlParameter("p_adress",seller.WorkPoint),
                new NpgsqlParameter("p_phone",seller.Phone),
                new NpgsqlParameter("p_email",seller.Email),
                new NpgsqlParameter()
                {
                    ParameterName = "p_logo",
                    NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea,
                    Value = seller.Logo.LogoBase
                }
            };
            //we atempt to open the connection
            if (!PgSqlConnection.OpenConnection()) return;
            //execute the non query
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
            //log the event
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            //and close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        #endregion 
    }
}
