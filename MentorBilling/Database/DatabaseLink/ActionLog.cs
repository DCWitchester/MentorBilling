using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using Npgsql;
using System;

namespace MentorBilling.Database.DatabaseLink
{
    public class ActionLog
    {
        /// <summary>
        /// the main Database connection for this class
        /// </summary>
        static readonly PostgreSqlConnection PgSqlConnection = new PostgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

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
        /// this function will log a given action
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="connection">the open connection received from the caller</param>
        public static void LogAction(String Action, PostgreSqlConnection connection)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune) VALUES(:p_action)";
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_action", Action);
            if (!(connection.connection.State == System.Data.ConnectionState.Open) && !connection.OpenConnection()) return;
            connection.ExecuteNonQuery(QueryCommand, QueryParameter);
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
        /// this function will log a given action to a specific IP Adress
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the ip adress</param>
        /// <param name="connection">the open connection received from the caller</param>
        public static void LogAction(String Action, String IP, PostgreSqlConnection connection)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,ip_actiune) VALUES(:p_action,:p_ip)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action", Action),
                new NpgsqlParameter("p_ip",IP)
            };
            if (!(connection.connection.State == System.Data.ConnectionState.Open) && !connection.OpenConnection()) return;
            connection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }

        /// <summary>
        /// this function will log a given action to a specific IP Adress with the database command
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the ip adress</param>
        /// <param name="Command">the database command</param>
        public static void LogAction(String Action, String IP, String Command)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,ip_actiune,comanda) VALUES(:p_action,:p_ip,:p_command)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action", Action),
                new NpgsqlParameter("p_ip",IP),
                new NpgsqlParameter("p_command",Command)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }

        /// <summary>
        /// this function will log a given action to a specific IP Adress with the database command
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the ip adress</param>
        /// <param name="Command">the database command</param>
        /// <param name="connection">the open connection received from the caller</param>
        public static void LogAction(String Action, String IP, String Command, PostgreSqlConnection connection)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,ip_actiune,comanda) VALUES(:p_action,:p_ip,:p_command)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action", Action),
                new NpgsqlParameter("p_ip",IP),
                new NpgsqlParameter("p_command",Command)
            };
            if (!(connection.connection.State == System.Data.ConnectionState.Open) && !connection.OpenConnection()) return;
            connection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }

        /// <summary>
        /// this function will log a given action to a specific user
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="User">the specific user</param>
        public static void LogAction(String Action, User User)
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
        /// this fucntion will log a given action to a specific user
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="User">the specific user</param>
        /// <param name="connection">the open connection received from the caller</param>
        public static void LogAction(String Action, User User, PostgreSqlConnection connection)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,utilizator_id) VALUES(:p_action,:p_user_id)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action",Action),
                new NpgsqlParameter("p_user_id",User.ID)
            };
            if (!(connection.connection.State == System.Data.ConnectionState.Open) && !connection.OpenConnection()) return;
            connection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }

        /// <summary>
        /// this fucntion will log a given action to a specific user with the database command
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="User">the specific user</param>
        /// <param name="Command">the database command</param>
        public static void LogAction(String Action, User User, String Command)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,utilizator_id,comanda) VALUES(:p_action,:p_user_id,:p_command)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action",Action),
                new NpgsqlParameter("p_user_id",User.ID),
                new NpgsqlParameter("p_command",Command)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }

        /// <summary>
        /// this fucntion will log a given action to a specific user with the database command
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="User">the specific user</param>
        /// <param name="Command">the database command</param>
        /// <param name="connection">the open connection received from the caller</param>
        public static void LogAction(String Action, User User, String Command, PostgreSqlConnection connection)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,utilizator_id,comanda) VALUES(:p_action,:p_user_id,:p_command)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action",Action),
                new NpgsqlParameter("p_user_id",User.ID),
                new NpgsqlParameter("p_command",Command)
            };
            if (!(connection.connection.State == System.Data.ConnectionState.Open) && !connection.OpenConnection()) return;
            connection.ExecuteNonQuery(QueryCommand, QueryParameters);
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

        /// <summary>
        /// this function will log a given action to a specific user on a specific ip adress
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the specific ip adress</param>
        /// <param name="User">the specific user</param>
        /// <param name="connection">the open connection received from the caller</param>
        public static void LogAction(String Action, String IP, User User, PostgreSqlConnection connection)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,ip_actiune,utilizator_id) VALUES(:p_action,:p_ip,:p_user_id)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action", Action),
                new NpgsqlParameter("p_ip",IP),
                new NpgsqlParameter("p_user_id",User.ID)
            };
            if (!(connection.connection.State == System.Data.ConnectionState.Open) && !connection.OpenConnection()) return;
            connection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }

        /// <summary>
        /// this function will log a given action to a specific user on a specific ip adress the database command
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the specific ip adress</param>
        /// <param name="User">the specific user</param>
        /// <param name="Command">the database command</param>
        public static void LogAction(String Action, String IP, User User, String Command)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,ip_actiune,utilizator_id,comanda) VALUES(:p_action,:p_ip,:p_user_id,:p_command)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action", Action),
                new NpgsqlParameter("p_ip",IP),
                new NpgsqlParameter("p_user_id",User.ID),
                new NpgsqlParameter("p_command",Command)
            };
            if (!PgSqlConnection.OpenConnection()) return;
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }

        /// <summary>
        /// this function will log a given action to a specific user on a specific ip adress the database command
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the specific ip adress</param>
        /// <param name="User">the specific user</param>
        /// <param name="Command">the database command</param>
        /// <param name="connection">the open connection received from the caller</param>
        public static void LogAction(String Action, String IP, User User, String Command, PostgreSqlConnection connection)
        {
            String QueryCommand = "INSERT INTO log.log_actiuni(actiune,ip_actiune,utilizator_id,comanda) VALUES(:p_action,:p_ip,:p_user_id,:p_command)";
            NpgsqlParameter[] QueryParameters =
            {
                new NpgsqlParameter("p_action", Action),
                new NpgsqlParameter("p_ip",IP),
                new NpgsqlParameter("p_user_id",User.ID),
                new NpgsqlParameter("p_command",Command)
            };
            if (!(connection.connection.State == System.Data.ConnectionState.Open) && !connection.OpenConnection()) return;
            connection.ExecuteNonQuery(QueryCommand, QueryParameters);
        }
    }
}
