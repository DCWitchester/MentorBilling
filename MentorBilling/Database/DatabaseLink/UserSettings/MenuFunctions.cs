using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous.Menu;
using Npgsql;
using System;
using System.Collections.Generic;
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
            #region ActionLog
            //we format the log action for the element
            String logAction = String.Format("S-a generat setarea specifica pentru inregistrare {0} din meniu pentru utilizatorul {1}", 
                                        menuItem.MenuDisplay, 
                                        user.DisplayName);
            //we generate the log Command
            String logCommand = String.Format("INSERT INTO settings.meniu_utilizator(utilizator_id, inregistrare_meniu, activ) " +
                                    "VALUES({0},{1},{2})",
                                    user.ID,
                                    menuItem.MenuItemID,
                                    menuItem.IsActive);
            //we generate the Computer IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
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
            ActionLog.LogAction(logAction, IP, user, PgSqlConnection);
            //and as always never forget to close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will generate the menu setting for a given user with one query
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="menuItems">the complete list of menu items</param>
        public static void GenerateMenuSettingsForUser(User user, List<MenuItem> menuItems)
        {
            #region ActionLog
            //the specific log action
            String logAction = String.Format("S-au generat setarile generale din meniu pentru utilizatorul {0}",
                                        user.ID);
            //we generate the log Command
            String logCommand = String.Empty;
            //we generate the Computer IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //we initialize an empty command
            String queryCommand = String.Empty;
            //and an empty parameter list
            List<NpgsqlParameter>  queryParameters = new List<NpgsqlParameter>();
            //then foreach element in the list
            foreach(MenuItem element in menuItems)
            {
                #region ActionLog
                //we generate the log command for each inser command
                logCommand += String.Format("INSERT INTO settings.meniu_utilizator(utilizator_id, inregistrare_meniu, activ) " +
                                    "VALUES({0},{1},{2});"+Environment.NewLine,
                                    user.ID,
                                    element.MenuItemID,
                                    element.IsActive);
                #endregion
                //we add a specific insert command for the element 
                queryCommand += "INSERT INTO settings.meniu_utilizator(utilizator_id,inregistrare_meniu,activ) " +
                                    String.Format("VALUES(:p_user_id_{0},:p_record_id_{0},:p_activ_{0});"+Environment.NewLine, element.MenuItemID);
                //then we generate the specific parameter lists for the newly added command
                NpgsqlParameter[] commadParameters =
                {
                    new NpgsqlParameter(String.Format("p_user_id_{0}",element.MenuItemID),user.ID),
                    new NpgsqlParameter(String.Format("p_record_id_{0}",element.MenuItemID),element.MenuItemID),
                    new NpgsqlParameter(String.Format("p_activ",element.MenuItemID),element.IsActive)
                };
                //once that is done we add the newly created parameters to the list
                queryParameters.AddRange(commadParameters);
            }
            //if we are unable to connect to the server we abandon execution
            if (!PgSqlConnection.OpenConnection()) return;
            //else we call the execution of the procedure
            PgSqlConnection.ExecuteScalar(queryCommand, queryParameters);
            //we will log the multi-insert
            ActionLog.LogAction(logAction, IP, user, logCommand, PgSqlConnection);
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
            #region ActionLog
            //the main log display
            String logAction = $"S-a actualizat starea setari {menuItem.MenuDisplay} pentru utilizatorul {user.DisplayName}";
            String logCommand = $"UPDATE settings.meniu_utilizator SET activ = {menuItem.IsActive} " +
                                    $"WHERE utilizator_id = {user.ID} AND inregistrare_meniu = {menuItem.MenuItemID}";
            //the local element IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
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
            //we also log the current action
            ActionLog.LogAction(logAction, IP, user, logCommand, PgSqlConnection);
            //lets have happy functions without forgetting to close the 
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will update a given specific menu item into the database 
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="menuItem">the specific menu item</param>
        public static void UpdateMenuSettingForUser(User user, List<MenuItem> menuItems)
        {
            #region ActionLog
            //the main log display
            String logAction = $"S-a actualizat starea setarilor pentru utilizatorul {user.DisplayName}";
            String logCommand = String.Empty;
            
            //the local element IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            String queryCommand = String.Empty;
            List<NpgsqlParameter> queryParameters = new List<NpgsqlParameter>();
            foreach (MenuItem menuItem in menuItems)
            {
                #region ActionLog
                logCommand += $"UPDATE settings.meniu_utilizator SET activ = {menuItem.IsActive} " +
                                    $"WHERE utilizator_id = {user.ID} AND inregistrare_meniu = {menuItem.MenuItemID};";
                #endregion
                //the update command for the query
                queryCommand += String.Format("UPDATE settings.meniu_utilizator SET activ = :p_activ_{0} ",
                                                menuItem.MenuItemID) +
                                        String.Format("WHERE utilizator_id = :p_user_id_{0} AND inregistrare_meniu = :p_record_id_{0};"+Environment.NewLine,
                                                        menuItem.MenuItemID);
                //we instantiate the query parameter
                NpgsqlParameter[] commandParameters =
                {
                    new NpgsqlParameter(
                        String.Format("p_user_id_{0}",menuItem.MenuItemID)
                        ,user.ID),
                    new NpgsqlParameter(
                        String.Format("p_record_id_{0}",menuItem.MenuItemID)
                        ,menuItem.MenuItemID),
                    new NpgsqlParameter(
                        String.Format("p_activ_{0}",menuItem.MenuItemID)
                        ,menuItem.IsActive)
                };
                queryParameters.AddRange(commandParameters);
            }
            //if we are unable to connect to the server we abandon execution
            if (!PgSqlConnection.OpenConnection()) return;
            //else we call the execution of the procedure
            PgSqlConnection.ExecuteScalar(queryCommand, queryParameters);
            //we also log the current action
            ActionLog.LogAction(logAction, IP, user, logCommand, PgSqlConnection);
            //lets have happy functions without forgetting to close the 
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

    }
}
