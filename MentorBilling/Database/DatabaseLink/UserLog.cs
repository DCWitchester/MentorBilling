using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using Npgsql;
using System;

namespace MentorBilling.Database.DatabaseLink
{
    public class UserLog
    {
        /// <summary>
        /// the main Database connection for this class
        /// </summary>
        static readonly PostgreSqlConnection PgSqlConnection = new PostgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        /// <summary>
        /// this function will login a given user in the log
        /// </summary>
        /// <param name="user">the user</param>
        /// <returns>the state of the query</returns>
        public static Boolean LoginUser(User user)
        {
            String queryCommand = "INSERT INTO log.log_utilizatori(utilizator_id,logged) " +
                                    "VALUES(:p_user_id,:p_logged)";
            NpgsqlParameter[] queryParameters =
            {
                new NpgsqlParameter("p_user_id",user.ID),
                new NpgsqlParameter("p_logged",true)
            };
            if (!PgSqlConnection.OpenConnection()) return false;
            PgSqlConnection.ExecuteNonQuery(queryCommand, queryParameters);
            return Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }
    }
}
