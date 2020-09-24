using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous.Menu;
using Npgsql;
using System;
using System.Data;
using System.Linq;

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

        public static void GenerateSpecificMenuSettingForUser(User user, MenuItem menuItem)
        {
            String QueryCommand = "INSERT INTO settings.setari_utilizator(utilizator_id,plaje)";
        }
        
    }
}
