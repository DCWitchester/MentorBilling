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
            String QueryCommand = "SELECT * FROM seller.furnizori WHERE utilizator_id = :p_user_id AND activ";
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_user_id", user.ID);
            if (!PgSqlConnection.OpenConnection()) return null;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            if (result != null && result.Rows.Count > 0)
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
            String QueryCommand = "SELECT sigla FROM seller.furnizori WHERE id = :p_seller AND activ";
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_seller", seller.ID);
            if(!PgSqlConnection.OpenConnection()) return null;
            Byte[] value = (Byte[])PgSqlConnection.ExecuteScalar(QueryCommand, QueryParameter);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            return new Logo(value);
        }

        /// <summary>
        /// this function will retrieve a seller by a given id
        /// </summary>
        /// <param name="id">the given id</param>
        /// <returns>the seller retrived from the database</returns>
        public static ObjectStructures.Invoice.Seller GetSellerByID(Int32 id)
        {
            String QueryCommand = "SELECT * FROM seller.furnizori WHERE id = :p_seller AND activ";
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_seller", id);
            if (!PgSqlConnection.OpenConnection()) return null;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            if (result != null && result.Rows.Count > 0)
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
        /// this function will retrieve a seller by a given fiscal code
        /// </summary>
        /// <param name="fiscalCode">the given fiscal code</param>
        /// <returns>the seller retrieved from the database</returns>
        public static ObjectStructures.Invoice.Seller GetSellerByFiscalCode(String fiscalCode)
        {
            String QueryCommand = "SELECT * FROM seller.furnizori WHERE cod_fiscal = :p_seller_fiscal_code AND activ";
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_seller_fiscal_code", fiscalCode);
            if (!PgSqlConnection.OpenConnection()) return null;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            if (result != null && result.Rows.Count > 0)
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
        /// this function will retrieve the last seller used by the current user
        /// </summary>
        /// <param name="user">the current user</param>
        /// <returns>the last used seller object</returns>
        public static ObjectStructures.Invoice.Seller GetLastUsedSeller(User user)
        {
            String QueryCommand = "SELECT seller.* " +
                                    "FROM seller.furnizori " +
                                    "RIGHT JOIN seller.utilizatori_last_used " +
                                    "ON furnizori.id = utilizatori_last_used.furnizori_last_used " +
                                    "WHERE utilizatori_last_used.utilizator_id = :p_user_id AND utilizatori_last_used.activ";
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_user_id",user.ID);
            if (!PgSqlConnection.OpenConnection()) return null;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            if (result != null && result.Rows.Count > 0)
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
            String QueryCommand = "SELECT * FROM seller.furnizori WHERE id = :p_seller";
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_seller", seller.ID);
            if (!PgSqlConnection.OpenConnection()) return;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            if (result != null && result.Rows.Count > 0)
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                seller = new ObjectStructures.Invoice.Seller
#pragma warning restore IDE0059 // Unnecessary assignment of a value
                {
                    ID = result.Rows[0].Field<Int32>("ID"),
                    Name = result.Rows[0].Field<String>("DENUMIRE"),
                    CommercialRegistryNumber = result.Rows[0].Field<String>("NR_REGISTRU_COMERT"),
                    FiscalCode = result.Rows[0].Field<String>("COD_FISCAL"),
                    Headquarters = result.Rows[0].Field<String>("SEDIUL"),
                    WorkPoint = result.Rows[0].Field<String>("PUNCT_LUCRU"),
                    Phone = result.Rows[0].Field<String>("TELEFON"),
                    Email = result.Rows[0].Field<String>("EMAIL"),
                    Logo = new Logo(result.Rows[0].Field<Byte[]>("SIGLA"))
                };
        }

        /// <summary>
        /// this function will update the given seller with its database info using its fiscal
        /// </summary>
        /// <param name="seller">the given seller</param>
        public static void UpdateLocalSellerByFiscalCode(ObjectStructures.Invoice.Seller seller)
        {
            String QueryCommand = "SELECT * FROM seller.furnizori WHERE cod_fiscal = :p_seller_fiscal_code";
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_seller_fiscal_code", seller.FiscalCode);
            if (!PgSqlConnection.OpenConnection()) return;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            if (result != null && result.Rows.Count > 0)
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                seller = new ObjectStructures.Invoice.Seller
#pragma warning restore IDE0059 // Unnecessary assignment of a value
                {
                    ID = result.Rows[0].Field<Int32>("ID"),
                    Name = result.Rows[0].Field<String>("DENUMIRE"),
                    CommercialRegistryNumber = result.Rows[0].Field<String>("NR_REGISTRU_COMERT"),
                    FiscalCode = result.Rows[0].Field<String>("COD_FISCAL"),
                    Headquarters = result.Rows[0].Field<String>("SEDIUL"),
                    WorkPoint = result.Rows[0].Field<String>("PUNCT_LUCRU"),
                    Phone = result.Rows[0].Field<String>("TELEFON"),
                    Email = result.Rows[0].Field<String>("EMAIL"),
                    Logo = new Logo(result.Rows[0].Field<Byte[]>("SIGLA"))
                };
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
            String LogAction = $"S-a adaugat o noua firma cu denumirea {seller.Name} pentru utilizatorul {user.ID}";
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
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
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
                    ParameterName = "p_sigil",
                    NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea,
                    Value = seller.Logo.LogoBase
                },
                new NpgsqlParameter("p_user_id",user.ID)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            seller.ID = (Int32)PgSqlConnection.ExecuteScalar(QueryCommand,QueryParameters);
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
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
            String LogAction = $"S-a adaugat/modificat logo-ul la societatea cu denumirea {seller.Name}";
            String LogCommand = $"UPDATE seller.furnizori SET sigla = {logo.LogoBase.Take(10)} WHERE id = {seller.ID}";
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            String QueryCommand = "UPDATE seller.furnizori SET sigla = :p_sigil WHERE id = :p_seller_id";
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_seller_id",seller.ID),
                new NpgsqlParameter()
                {
                    ParameterName = "p_sigil",
                    NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea,
                    Value = logo.LogoBase
                }
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// update a given seller by id
        /// </summary>
        /// <param name="seller">the given seller</param>
        public static void UpdateSellerByID(ObjectStructures.Invoice.Seller seller)
        {
            #region ActionLog
            String LogAction = $"S-au actualizat datele societatii cu denumirea {seller.Name}";
            String LogCommand = "UPDATE seller.furnizori " +
                                    $"SET denumire = {seller.Name}, " +
                                        $"nr_registru_comert = {seller.CommercialRegistryNumber}, " +
                                        $"capital_social = {seller.JointStock}, " +
                                        $"sediul = {seller.Headquarters}, " +
                                        $"punct_lucru = {seller.WorkPoint}, " +
                                        $"telefon = {seller.Phone}, " +
                                        $"email = {seller.Email}, " +
                                      $"WHERE id = {seller.ID}";
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            String QueryCommand = "UPDATE seller.furnizori " +
                                    "SET denumire = :p_name, " +
                                        "nr_registru_comert = :p_registry, " +
                                        "capital_social = :p_joint_stock, " +
                                        "sediul = :p_headquarters, " +
                                        "punct_lucru = :p_adress, " +
                                        "telefon = :p_phone, " +
                                        "email = :p_email, " +
                                      "WHERE id = :p_seller_id";
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_name",seller.Name),
                new NpgsqlParameter("p_registry",seller.CommercialRegistryNumber),
                new NpgsqlParameter("p_joint_stock",seller.JointStock),
                new NpgsqlParameter("p_headquarters",seller.Headquarters),
                new NpgsqlParameter("p_adress",seller.WorkPoint),
                new NpgsqlParameter("p_phone",seller.Phone),
                new NpgsqlParameter("p_email",seller.Email),
                new NpgsqlParameter("p_seller_id",seller.ID)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// update a given seller by its fiscal code
        /// </summary>
        /// <param name="seller">the given seller</param>
        public static void UpdateSellerByFiscalCode(ObjectStructures.Invoice.Seller seller)
        {
            #region ActionLog
            String LogAction = $"S-au actualizat datele societatii cu denumirea {seller.Name}";
            String LogCommand = "UPDATE seller.furnizori " +
                                    $"SET denumire = {seller.Name}, " +
                                        $"nr_registru_comert = {seller.CommercialRegistryNumber}, " +
                                        $"capital_social = {seller.JointStock}, " +
                                        $"sediul = {seller.Headquarters}, " +
                                        $"punct_lucru = {seller.WorkPoint}, " +
                                        $"telefon = {seller.Phone}, " +
                                        $"email = {seller.Email}, " +
                                      $"WHERE cod_fiscal = {seller.FiscalCode}";
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            String QueryCommand = "UPDATE seller.furnizori " +
                                    "SET denumire = :p_name, " +
                                        "nr_registru_comert = :p_registry, " +
                                        "capital_social = :p_joint_stock, " +
                                        "sediul = :p_headquarters, " +
                                        "punct_lucru = :p_adress, " +
                                        "telefon = :p_phone, " +
                                        "email = :p_email, " +
                                      "WHERE cod_fiscal = :p_fiscal_code";
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("p_name",seller.Name),
                new NpgsqlParameter("p_registry",seller.CommercialRegistryNumber),
                new NpgsqlParameter("p_fiscal_code",seller.FiscalCode),
                new NpgsqlParameter("p_joint_stock",seller.JointStock),
                new NpgsqlParameter("p_headquarters",seller.Headquarters),
                new NpgsqlParameter("p_adress",seller.WorkPoint),
                new NpgsqlParameter("p_phone",seller.Phone),
                new NpgsqlParameter("p_email",seller.Email)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
            ActionLog.LogAction(LogAction, LogCommand, IP, PgSqlConnection);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        #endregion 
    }
}
