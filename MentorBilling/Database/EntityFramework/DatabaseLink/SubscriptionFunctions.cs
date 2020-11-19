using MentorBilling.Database.EntityFramework.MentorBillingEntityFramework;
using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous;
using MentorBilling.ObjectStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.EntityFramework.DatabaseLink
{
    /// <summary>
    /// this function generates the initial subscription for an account
    /// </summary>
    /// <param name="user">the newly created user</param>
    /// <returns>the state of the command</returns>
    public class SubscriptionFunctions : MentorBillingContext
    {
        #region Subscription - User Link
        /// <summary>
        /// this function generates the initial subscription for an account
        /// </summary>
        /// <param name="user">the newly created user</param>
        /// <returns>the state of the command</returns>
        public void GenerateInactiveSubscription(User user)
        {
            #region Action Log
            String Action = "Initializat abonamentul inactiv pentru utilizatorul " + user.Email;
            String Command = String.Format("INSERT INTO users.abonamente_utilizatori(utilizator_id, abonament_id) " +
                                                "VALUES({0},{1})", user.ID, (Int64)Settings.Subscriptions.SubscriptionSettings.Subscriptions.InactiveSubscription);
            String IP = IPFunctions.GetWANIp();
            #endregion
            //we will add a new item to the list
            base.AbonamenteUtilizatori.Add(new AbonamenteUtilizatori()
            {
                UtilizatorId = user.ID,
                AbonamentId = (Int64)Settings.Subscriptions.SubscriptionSettings.Subscriptions.InactiveSubscription
            });
            //and log the action
            base.LogActiuni.Add(ActionLog.LogAction(Action, IP, Command));
            //and save the changes to the database
            base.SaveChanges();
        }

        /// <summary>
        /// this function will activate the trial subscription for an account
        /// </summary>
        /// <param name="user">the user for which the trial will activate</param>
        /// <returns>the state of the command</returns>
        public void ActivateTrialSubscription(User user)
        {
            //we prepare the action log
            #region Action Log
            //set the action
            String Action = "Activat abonamentul de trial pentru utilizatorul " + user.Email;
            //retrieve the IP
            String IP = IPFunctions.GetWANIp();
            //then format the command
            String Command = String.Format("UPDATE users.abonamente_utilizatori " +
                                    "SET abonament_id = {0}" +
                                    " ultima_plata = {1} " +
                                    "WHERE utilizator_id = {2} AND abonament_id = {3}",
                                    (Int64)Settings.Subscriptions.SubscriptionSettings.Subscriptions.ActiveTrialSubscription,
                                    DateTime.Now,
                                    user.ID,
                                    (Int64)Settings.Subscriptions.SubscriptionSettings.Subscriptions.InactiveSubscription
                                    );
            #endregion
            //then we will update the user subscription
            base.AbonamenteUtilizatori.Where(element => element.UtilizatorId == user.ID
                                                && element.AbonamentId == (Int64)Settings.Subscriptions.SubscriptionSettings.Subscriptions.InactiveSubscription)
                                        .ToList()
                                        .ForEach(element => {
                                            element.AbonamentId = (Int64)Settings.Subscriptions.SubscriptionSettings.Subscriptions.ActiveTrialSubscription;
                                            element.UltimaPlata = DateTime.Now;
                                        });
            //and log the action
            base.LogActiuni.Add(ActionLog.LogAction(Action, IP, Command));
            base.SaveChanges();
        }
        #endregion

        #region Login
        /// <summary>
        /// this function will retrieve a given users active subscription
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>the active subscription</returns>
        public Subscription GetSubscriptionForUser(User user)
        {
            List<Subscription> Subscriptions = (from au in base.AbonamenteUtilizatori
                                                join a in Abonamente on au.AbonamentId equals a.Id
                                                where au.UtilizatorId == user.ID && (au.Activ ?? false)
                                                select new Subscription()
                                                {
                                                    ID = au.Id,
                                                    Name = a.Denumire,
                                                    MonthlyFee = au.ValoareLunara,
                                                    SubscriptionType = a.Id,
                                                    Explanations = a.Explicatii,
                                                    LastPayment = au.UltimaPlata,
                                                    ActivePeriod = au.PerioadaActiva
                                                }).ToList();
            return Subscriptions.FirstOrDefault();
        }
        #endregion
    }
}
