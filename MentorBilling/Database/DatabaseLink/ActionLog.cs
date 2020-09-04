using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink
{
    public class ActionLog
    {
        /// <summary>
        /// the main Database connection for this class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        /// <summary>
        /// this function will log a given action
        /// </summary>
        /// <param name="Action">the given action</param>
        public static void LogAction(String Action)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune) VALUES(:p_action)";
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_action",Action);
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameter);
        }
        /// <summary>
        /// this function will log a given action to a specific IP Adress
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the ip adress</param>
        public static void LogAction(String Action, String IP)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,ip_actiune) VALUES(:p_action,:p_ip)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action", Action),
                new NpgsqlParameter("p_ip",IP)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }
        /// <summary>
        /// this fucntion will log a given action to a specific user
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="User">the specific user</param>
        public static void LogAction(String Action,User User)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,utilizator_id) VALUES(:p_action,:p_user_id)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action",Action),
                new NpgsqlParameter("p_user_id",User.ID)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }
        /// <summary>
        /// this function will log a given action to a specific user on a specific ip adress
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the specific ip adress</param>
        /// <param name="User">the specific user</param>
        public static void LogAction(String Action, String IP, User User)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,ip_actiune,utilizator_id) VALUES(:p_action,:p_ip,:p_user_id)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action", Action),
                new NpgsqlParameter("p_ip",IP),
                new NpgsqlParameter("p_user_id",User.ID)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }
    }
}
