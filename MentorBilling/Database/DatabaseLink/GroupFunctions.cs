using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using Npgsql;
using System;

namespace MentorBilling.Database.DatabaseLink
{
    public class GroupFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        public static void GetUserGroup(User user)
        {
            String queryCommand = "SELECT g.id AS id, g.denumire AS name, u.id AS admin_id," +
                                    "u.nume_utilizator AS admin_username, u.nume AS admin_surname" +
                                    "u.prenume AS admin_name " +
                                    "FROM grupuri_utilizatori AS gu " +
                                    "LEFT JOIN grupuri AS g ON gu.grup_id = g.id " +
                                    "LEFT JOIN utilizatori AS u ON u.id = g.administrator_grup " +
                                    "WHERE gu.utilizator_id = :p_user_id";
            NpgsqlParameter queryParameter = new NpgsqlParameter("p_user_id", user.ID);
        }
    }
}
