using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using MentorBilling.ObjectStructures.Auxilliary;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MentorBilling.Database.DatabaseLink.Seller
{
    public class SellerFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

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
            String QueryCommand = "INSERT INTO seller.furnizori(denumire,nr_registru_comert,cod_fiscal,capital_social,sediul,punct_lucru,telefon,email,utilizator_id) " +
                                    "VALUES(:p_name,:p_registry,:p_fiscal_code,:p_joint_stock,:p_headquarters,:p_adress,:p_phone,:p_email,:p_user_id) " +
                                    "ON CONFLICT(cod_fiscal) " +
                                    "DO UPDATE SET denumire = :p_name, " +
                                        "nr_registru_comert = :p_registry, " +
                                        "capital_social = :p_joint_stock, " +
                                        "sediul = :p_headquarters, " +
                                        "punct_lucru = :p_adress, " +
                                        "telefon = :p_phone, " +
                                        "email = :p_email, " +
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
