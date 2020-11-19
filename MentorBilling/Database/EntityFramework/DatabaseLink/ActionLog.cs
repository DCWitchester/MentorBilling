using System;
using MentorBilling.Database.EntityFramework.MentorBillingEntityFramework;
using MentorBilling.Login.UserControllers;

namespace MentorBilling.Database.EntityFramework.DatabaseLink
{

    public class ActionLog
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the property controller for the insert
        /// </summary>
        protected LogActiuni logActiuni { get;set;}
#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// this function will log a given action
        /// </summary>
        /// <param name="Action">the given action</param>
        public LogActiuni LogAction(String Action)
        {
            logActiuni = new LogActiuni()
            {
                Actiune = Action
            };
            return logActiuni;
        }

        /// <summary>
        /// this function will log a given action to a specific IP Adress
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the ip adress</param>
        public LogActiuni LogAction(String Action, String IP)
        {
            logActiuni = new LogActiuni()
            {
                Actiune = Action,
                IpActiune = IP
            };
            return logActiuni;
        }

        /// <summary>
        /// this function will log a given action to a specific IP Adress with the database command
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the ip adress</param>
        /// <param name="Command">the database command</param>
        public LogActiuni LogAction(String Action, String IP, String Command)
        {
            logActiuni = new LogActiuni()
            {
                Actiune = Action,
                IpActiune = IP,
                Comanda = Command
            };
            return logActiuni;
        }

        /// <summary>
        /// this function will log a given action to a specific user
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="User">the specific user</param>
        public LogActiuni LogAction(String Action, User User)
        {
            logActiuni = new LogActiuni()
            {
                Actiune = Action,
                UtilizatorId = User.ID
            };
            return logActiuni;
        }

        /// <summary>
        /// this fucntion will log a given action to a specific user with the database command
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="User">the specific user</param>
        /// <param name="Command">the database command</param>
        public LogActiuni LogAction(String Action, User User, String Command)
        {
            logActiuni = new LogActiuni()
            {
                Actiune = Action,
                UtilizatorId = User.ID,
                Comanda = Command
            };
            return logActiuni;
        }

        /// <summary>
        /// this function will log a given action to a specific user on a specific ip adress
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the specific ip adress</param>
        /// <param name="User">the specific user</param>
        public LogActiuni LogAction(String Action, String IP, User User)
        {
            logActiuni = new LogActiuni()
            {
                Actiune = Action,
                IpActiune = IP,
                UtilizatorId = User.ID
            };
            return logActiuni;
        }

        /// <summary>
        /// this function will log a given action to a specific user on a specific ip adress the database command
        /// </summary>
        /// <param name="Action">the given action</param>
        /// <param name="IP">the specific ip adress</param>
        /// <param name="User">the specific user</param>
        /// <param name="Command">the database command</param>
        public LogActiuni LogAction(String Action, String IP, User User, String Command)
        {
            logActiuni = new LogActiuni()
            {
                Actiune = Action,
                IpActiune = IP,
                UtilizatorId = User.ID,
                Comanda = Command
            };
            return logActiuni;
        }
    }
}
