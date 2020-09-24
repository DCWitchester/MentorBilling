using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous.Menu;
using Npgsql;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace MentorBilling.Database.DatabaseLink.UserSettings
{
    public class MenuFunctions
    {
        /// <summary>
        /// the main Database connection for this class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        /// <summary>
        /// this function will update the local menu with the settings from the database server for the specific user
        /// </summary>
        /// <param name="user">the specific user</param>
        /// <param name="menu">the instance menu</param>
        public static void UpdateLocalUserMenu(User user, Menu menu)
        {
            //we write the sqlQuery
            String QueryCommand = "SELECT * FROM settings.meniu_utilizator WHERE utilizator_id = :p_user_id";
            //we instantiate the query parameter
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_user_id",user.ID);
            //if we are unable to connect to the server we abandon execution
            if (!PgSqlConnection.OpenConnection()) return;
            //we then retrieve the dataTable
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //let us not be morons and close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //we check if the result has values
            if (result != null && result.Rows.Count > 0) 
            {
                //we iterate the menu items
                foreach (MenuItem menuItem in menu.UserMenu)
                {
                    //and set their active values
                    menuItem.IsActive = result.AsEnumerable()
                                                .Where(r => r.Field<Int32>("ID") == menuItem.MenuItemID)
                                                .Select(r => r.Field<Boolean>("ACTIV"))
                                                .FirstOrDefault();

                }
            }
        }

        /// <summary>
        /// this function will create a new registry in the database for specific user settings
        /// </summary>
        /// <param name="user">the specific user</param>
        /// <param name="menuItem">the menu item</param>
        public static void GenerateSpecificMenuSettingForUser(User user, MenuItem menuItem)
        {
            //we write the sqlQuery
            String queryCommand = "INSERT INTO settings.meniu_utilizator(utilizator_id,inregistrare_meniu,activ) " +
                                    "VALUES(:p_user_id,:p_record_id,:p_activ)";
            //we instantiate the query parameter
            NpgsqlParameter[] queryParameters =
            {
                new NpgsqlParameter("p_user_id",user.ID),
                new NpgsqlParameter("p_record_id",menuItem.MenuItemID),
                new NpgsqlParameter("p_activ",menuItem.IsActive)
            };
            //if we are unable to connect to the server we abandon execution
            if (!PgSqlConnection.OpenConnection()) return;
            //else we call the execution of the procedure
            PgSqlConnection.ExecuteScalar(queryCommand, queryParameters);
            //and as always never forget to close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will update a given specific menu item into the database 
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="menuItem">the specific menu item</param>
        public static void UpdateSpecificMenuSettingForUser(User user, MenuItem menuItem)
        {
            //the update command for the query
            String queryCommand = "UPDATE settings.meniu_utilizator SET activ = :p_activ " +
                                    "WHERE utilizator_id = :p_user_id AND inregistrare_meniu = :p_record_id";
            //we instantiate the query parameter
            NpgsqlParameter[] queryParameters =
            {
                new NpgsqlParameter("p_user_id",user.ID),
                new NpgsqlParameter("p_record_id",menuItem.MenuItemID),
                new NpgsqlParameter("p_activ",menuItem.IsActive)
            };
            //if we are unable to connect to the server we abandon execution
            if (!PgSqlConnection.OpenConnection()) return;
            //else we call the execution of the procedure
            PgSqlConnection.ExecuteScalar(queryCommand, queryParameters);
            //lets have happy functions without forgetting to close the 
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }
        
    }
}
