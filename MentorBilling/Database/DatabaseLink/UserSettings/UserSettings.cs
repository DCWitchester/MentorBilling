using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
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
            String QueryCommand = "INSERT INTO setari_utilizatori(utilizator_id, setare_id, valoare_setare) " +
                                    "SELECT :p_user_id, id, valoare_initiala FROM setari";
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
    }
}
