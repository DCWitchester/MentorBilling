using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MentorBilling.Login
{
    public class Functions
    {
        public static void Login(User user,Controllers controllers)
        {
            Settings.UserSettings.LoggedInUser = user;
            Settings.UserSettings.UserState = Miscellaneous.UserState.UserStates.loggedIn;
            Settings.UserSettings.ActiveSubscription = Database.DatabaseLink.SubscriptionFunctions.GetSubscriptionForUser(user);
            Settings.UserSettings.HasSysadminRights = Database.DatabaseLink.UserFunctions.CheckAdministratorRights(user);
#warning TBD: Login Logic
        }
    }
}
