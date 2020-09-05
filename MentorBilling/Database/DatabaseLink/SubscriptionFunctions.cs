﻿using MentorBilling.Database.DatabaseController;
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
            //we also log the action on the same connection
            ActionLog.LogAction(Action, IP, Command, PgSqlConnection);
            //and return true
            return Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }

        /// <summary>
        /// this function will activate the trial subscription for an account
        /// </summary>
        /// <param name="user">the user for which the trial will activate</param>
        /// <returns>the state of the command</returns>
        public static Boolean ActivateTrialSubscription(User user)
        {
            //this function can only ocur when a client has an inactive subscription
            //we get the ID for the inactive subscription
            Int64 currentSubscriptionID = (Int64)Settings.Subscriptions.SubscriptionSettings.Subscriptions.InactiveSubscription;
            //then the ID for the trial subscription
            Int64 newSubscriptionID = (Int64)Settings.Subscriptions.SubscriptionSettings.Subscriptions.ActiveTrialSubscription;
            //we prepare the action log
            #region Action Log
            //set the action
            String Action = "Activat abonamentul de trial pentru utilizatorul " + user.Email;
            //retrieve the IP
            String IP = IPFunctions.GetWANIp();
            //then format the command
            String command = String.Format("UPDATE users.abonamente_utilizatori " +
                                    "SET abonament_id = {0}" +
                                    " ultima_plata = {1} " +
                                    "WHERE utilizator_id = {2} AND abonament_id = {3}",
                                    newSubscriptionID,
                                    DateTime.Now,
                                    user.ID,
                                    currentSubscriptionID
                                    );
            #endregion
            //we set the queryCommand
            String queryCommand = "UPDATE users.abonamente_utilizatori " +
                                    "SET abonament_id = :p_new_subscription," +
                                    " ultima_plata = :p_new_date " +
                                    "WHERE utilizator_id = :p_user_id AND abonament_id = :p_old_subscription";
            //and initialize the parameters
            NpgsqlParameter[] queryParameters =
            {
                new NpgsqlParameter("p_new_subscription",newSubscriptionID),
                new NpgsqlParameter("p_old_subscription",currentSubscriptionID),
                new NpgsqlParameter("p_user_id",user.ID),
                new NpgsqlParameter("p_new_date",DateTime.Now)
            };
            //if we fail to open the connection we return false;
            if (!PgSqlConnection.OpenConnection()) return false;
            //if not we execute the command with the attached parameters
            PgSqlConnection.ExecuteNonQuery(queryCommand, queryParameters);
            //and log the action on the same connection
            ActionLog.LogAction(Action, IP, command, PgSqlConnection);
            //before returning true;
            return Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }
        #endregion
    }
}
