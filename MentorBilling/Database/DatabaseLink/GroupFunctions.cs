using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using MentorBilling.ObjectStructures;
using Npgsql;
using System;
using System.Data;

namespace MentorBilling.Database.DatabaseLink
{
    public class GroupFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PostgreSqlConnection PgSqlConnection = new PostgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        /// <summary>
        /// this function will retrieve the group to which the user is part of
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>the Group</returns>
        public static Group GetUserGroup(User user)
        {
            String queryCommand = "SELECT g.id AS id, g.denumire AS name, u.id AS admin_id," +
                                    "u.nume_utilizator AS admin_username, u.nume AS admin_surname, " +
                                    "u.prenume AS admin_name " +
                                    "FROM users.grupuri_utilizatori AS gu " +
                                    "LEFT JOIN users.grupuri AS g ON gu.grup_id = g.id " +
                                    "LEFT JOIN users.utilizatori AS u ON u.id = g.administrator_grup " +
                                    "WHERE gu.utilizator_id = :p_user_id AND gu.activ AND g.activ";
            NpgsqlParameter queryParameter = new NpgsqlParameter("p_user_id", user.ID);
            if (!PgSqlConnection.OpenConnection()) return null;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(queryCommand, queryParameter);
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            if (result != null && result.Rows.Count > 0)
                return new Group
                {
                    ID = (Int64)result.Rows[0]["ID"],
                    Name = result.Rows[0]["NAME"].ToString(),
                    Administrator = new User
                    {
                        ID = (Int64)result.Rows[0]["ADMIN_ID"],
                        Username = result.Rows[0]["ADMIN_USERNAME"].ToString(),
                        Surname = result.Rows[0]["ADMIN_SURNAME"].ToString(),
                        Name = result.Rows[0]["ADMIN_NAME"].ToString()
                    }
                };
            else return null;
        }

    }
}
