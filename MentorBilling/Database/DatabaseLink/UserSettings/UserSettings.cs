using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using MentorBilling.SettingsComponents;
using MentorBilling.SettingsComponents.Controllers;
using Microsoft.AspNetCore.Builder;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink.UserSettings
{
    public class UserSettings
    {
        /// <summary>
        /// the main Database connection for this class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        /// <summary>
        /// this function will generate the Initial Settings for the user
        /// </summary>
        /// <param name="user">the given user</param>
        public static void GenerateInitialUserSettings(User user)
        {
            #region ActionLog
            //we format the log action for the element
            String logAction = $"S-au generat setarile initiale pentru utilizatorul {user.DisplayName}";
            //we generate the log Command
            String logCommand = "INSERT INTO setari_utilizatori(utilizator_id, setare_id, valoare_setare) " +
                                    $"SELECT {user.ID}, id, valoare_initiala FROM setari";
            //we generate the Computer IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //we write the sqlQuery
            String QueryCommand = "INSERT INTO settings.setari_utilizatori(utilizator_id, setare_id, valoare_setare) " +
                                    "SELECT :p_user_id, id, valoare_initiala FROM settings.setari";
            //we instantiate the query parameter
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_user_id", user.ID);
            //if we are unable to connect to the server we abandon execution
            if (!PgSqlConnection.OpenConnection()) return;
            //else we call the execution of the procedure
            PgSqlConnection.ExecuteNonQuery(QueryCommand, QueryParameter);
            //and log the action
            ActionLog.LogAction(logAction, IP, user, logCommand, PgSqlConnection);
            //and as always never forget to close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will update a solitary setting with the new setting value for a given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="setting">the setting</param>
        public static void UpdateSettingValueForUser(User user, Setting setting) 
        {
            #region Log Action
            //the specific log action
            String logAction = $"Actualizat valoarea setarii {setting.SettingDisplay} pentru utilizatorul {user.DisplayName}";
            //we generate the log Command
            String logCommand = "UPDATE setari_utilizatori " +
                                    $"SET valoare_setare = {setting.GetStringValue} " +
                                    $"WHERE utilizator_id = {user.ID} AND setare_id = {setting.ID}";
            //we generate the Computer IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //the update command for a single setting
            String QueryCommand = "UPDATE settings.setari_utilizatori " +
                                    "SET valoare_setare = :p_value " +
                                    "WHERE utilizator_id = :p_user_id AND setare_id = :p_setting_id";
            //the query parameters for a single setting
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(":p_value",setting.GetStringValue),
                new NpgsqlParameter(":p_user_id",user.ID),
                new NpgsqlParameter(":p_setting_id",setting.ID)
            };
            //if we are unable to connect to the server we abandon execution
            if (!PgSqlConnection.OpenConnection()) return;
            //else we call the execution of the procedure
            PgSqlConnection.ExecuteScalar(QueryCommand, QueryParameters);
            //we will log the multi-insert
            ActionLog.LogAction(logAction, IP, user, logCommand, PgSqlConnection);
            //and as always never forget to close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will update a complete settings list for a given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="settings">the complete settings list</param>
        public static void UpdateSettingsValueForUser(User user, List<Setting> settings)
        {
            #region Log Action
            //the specific log action
            String logAction = $"Actualizat valoarea tuturor setarilor pentru utilizatorul {user.DisplayName}";
            //we generate the log Command
            String logCommand = String.Empty;
            //we generate the Computer IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            //the update command for a single setting
            String QueryCommand = String.Empty;
            //the query parameters for a single setting
            List<NpgsqlParameter> QueryParameters = new List<NpgsqlParameter>();
            //we iterate the settings list to create our query
            foreach(Setting setting in settings)
            {
                #region Action Log
                //we generate the log command for each inser command
                logCommand += "UPDATE setari_utilizatori " +
                                    $"SET valoare_setare = {setting.Value} " +
                                    $"WHERE utilizator_id = {user.ID} AND setare_id = {setting.ID}";
                #endregion

                //the update command for a single setting
                QueryCommand += "UPDATE settings.setari_utilizatori " +
                                    String.Format("SET valoare_setare = :p_value_{0} ",setting.ID) +
                                    String.Format("WHERE utilizator_id = :p_user_id_{0} AND setare_id = :p_setting_id_{0}",setting.ID);
                //we add the query Parameters to the command
                QueryParameters.AddRange(new List<NpgsqlParameter>() 
                {
                    new NpgsqlParameter(String.Format("p_value_{0}",setting.ID),setting.GetStringValue),
                    new NpgsqlParameter(String.Format("p_user_id_{0}",setting.ID),user.ID),
                    new NpgsqlParameter(String.Format("p_setting_id_{0}",setting.ID),setting.ID)
                });
            }
            //if we are unable to connect to the server we abandon execution
            if (!PgSqlConnection.OpenConnection()) return;
            //else we call the execution of the procedure
            PgSqlConnection.ExecuteScalar(QueryCommand, QueryParameters);
            //we will log the multi-insert
            ActionLog.LogAction(logAction, IP, user, logCommand, PgSqlConnection);
            //and as always never forget to close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will retrieve the settings for a given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>a complete list of settings</returns>
        public static List<Setting> RetrieveSettingsListForUser(User user)
        {
            //the query command for the retrieval of the settings
            String QueryCommand = "SELECT s.id, s.setare, s.tip_date_setare, su.valoare_setare " +
                                    "FROM settings.setari_utilizatori AS su " +
                                    "LEFT JOIN settings.setari AS s " +
                                    "ON s.id = su.setare_id " +
                                    "WHERE su.utilizator_id = :p_user_id";
            //the query standalone parameter
            NpgsqlParameter QueryParameter = new NpgsqlParameter(":p_user_id", user.ID);
            //if we are unable to connect to the server we abandon execution
            if (!PgSqlConnection.OpenConnection()) return new List<Setting>();
            //else we call the execution of the procedure
            DataTable dt = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //and return the settings list
            return dt.AsEnumerable().Select(row => new Setting 
            {
                ID = row.Field<Int64>("ID"),
                DataTypes = (Settings.SettingTypes.SettingDataTypes)row.Field<Int32>("TIP_DATE_SETARE"),
                SettingDisplay = row.Field<String>("SETARE"),
                Value = row.Field<Object>("VALOARE_SETARE")
            }).ToList();
        }

        /// <summary>
        /// this function will retrieve the complete list of settings from the Settings page for they also contain the dispaly info
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>the complete list of settings + display info </returns>
        public static List<GeneralComponentController> RetrieveDisplayElementSettingsForUser(User user) 
        {
            //the query command for the retrieval of the settings
            String QueryCommand = "SELECT s.id, s.setare, s.tip_date_setare, su.valoare_setare, s.tip_input_setare, " +
                                    "s.placeholder, s.tooltip " +
                                    "FROM settings.setari_utilizatori AS su " +
                                    "LEFT JOIN settings.setari AS s " +
                                    "ON s.id = su.setare_id " +
                                    "WHERE su.utilizator_id = :p_user_id";
            //the query standalone parameter
            NpgsqlParameter QueryParameter = new NpgsqlParameter(":p_user_id", user.ID);
            //if we are unable to connect to the server we abandon execution
            if (!PgSqlConnection.OpenConnection()) return new List<GeneralComponentController>();
            //else we call the execution of the procedure
            DataTable dt = PgSqlConnection.ExecuteReaderToDataTable(QueryCommand, QueryParameter);
            //and close the connection 
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //we generate the settings list based on the data table
            return dt.AsEnumerable().Select(row => new GeneralComponentController
            {
                ID = row.Field<Int64>("ID"),
                DataTypes = (Settings.SettingTypes.SettingDataTypes)row.Field<Int32>("TIP_DATE_SETARE"),
                SettingDisplay = row.Field<String>("SETARE"),
                Value = row.Field<Object>("VALOARE_SETARE"),
                InputTypes = (Settings.SettingTypes.SettingInputTypes)row.Field<Int32>("TIP_INPUT_SETARE"),
                Placeholder = row.Field<String>("PLACEHOLDER"),
                Tooltip = row.Field<String>("TOOLTIP")
            }).ToList();
        }
    }
}
