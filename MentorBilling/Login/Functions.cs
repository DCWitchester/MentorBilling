using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous;
using MentorBilling.Settings.Subscriptions;
using Microsoft.AspNetCore.Razor.TagHelpers;
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
            //this function will log in the user to the controller
            Settings.UserSettings.LoggedInUser = user;
            //we then retrieve the sysadmin rights for the user
            Settings.UserSettings.HasSysadminRights = Database.DatabaseLink.UserFunctions.CheckAdministratorRights(user);
            //if the user HasSysadminRights we return for all other things are not necessary
            if (Settings.UserSettings.HasSysadminRights)
            {
                //we log in the user
                Settings.UserSettings.UserState = UserState.UserStates.loggedIn;
                Database.DatabaseLink.UserLog.LoginUser(user);
                return;
            }
            //if we reach this point we have an active user that is not a system admin
            //<=AKA NOT US
            //as such we now check if there is an active group
            Settings.UserSettings.UserGroup = Database.DatabaseLink.GroupFunctions.GetUserGroup(user);
            if(Settings.UserSettings.UserGroup == null)
            {
                //if the user is not part of an active group we check if he has an active subscription
                Settings.UserSettings.ActiveSubscription = Database.DatabaseLink.SubscriptionFunctions.GetSubscriptionForUser(user);
                if(Settings.UserSettings.ActiveSubscription.SubscriptionType == (Int64)SubscriptionSettings.Subscriptions.ActiveGroupSubscription)
                {

                }
            }


            Settings.UserSettings.ActiveSubscription = Database.DatabaseLink.SubscriptionFunctions.GetSubscriptionForUser(user);
            //Settings.UserSettings.HasSysadminRights = Database.DatabaseLink.UserFunctions.CheckAdministratorRights(user);
#warning TBD: Login Logic
        }
    }
}
