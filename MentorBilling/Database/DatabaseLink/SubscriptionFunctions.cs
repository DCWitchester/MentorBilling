using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink
{
    public class SubscriptionFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        #region Subscription - User Link
        /// <summary>
        /// this function generates the initial subscription for an account
        /// </summary>
        /// <param name="user">the newly created user</param>
        /// <returns>the state of the command</returns>
        public static Boolean GenerateInactiveSubscription(User user)
        {
            //we get the subscription id for the inactive subscription
            Int64 currentSubsciptionID = (Int64)Settings.Subscriptions.SubscriptionSettings.Subscriptions.InactiveSubscription;
            #region Action Log
            String Action = "Initializat abonamentul inactiv pentru utilizatorul "+user.Email;
            String Command = String.Format("INSERT INTO users.abonamente_utilizatori(utilizator_id, abonament_id) " +
                                                "VALUES({0},{1})", user.ID, currentSubsciptionID);
            String IP = IPFunctions.GetWANIp();
            #endregion
            //we create the command for the query
            String queryCommand = "INSERT INTO users.abonamente_utilizatori(utilizator_id,abonament_id) " +
                                    "VALUES(:p_user_id,:p_subscription_id)";
            //set the values of the parameters
            NpgsqlParameter[] queryParameters =
            {
                new NpgsqlParameter("p_user_id",user.ID),
                new NpgsqlParameter("p_abonament_id",currentSubsciptionID)
            };
            //if the connection fails we return false
            if (PgSqlConnection.OpenConnection()) return false;
            //else we execute the command
            PgSqlConnection.ExecuteNonQuery(queryCommand, queryParameters);
            //and return true
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //we also log the action
            ActionLog.LogAction(Action, IP, Command);
            return true;
        }
        public static Boolean ActivateSubscription(User user)
        {

        }
        #endregion
    }
}
