using MentorBilling.Login.UserControllers;
using MentorBilling.Messages;
using MentorBilling.Miscellaneous;
using MentorBilling.Settings.Subscriptions;
using MentorBilling.Shared.LoginDisplay;
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
                UserState.CallLoggedIn(controllers.LoginDisplayController);
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
                //if the active subscription is by chance a group subscription that has no group or the active subscription is invalid
                if(Settings.UserSettings.ActiveSubscription.SubscriptionType == (Int64)SubscriptionSettings.Subscriptions.ActiveGroupSubscription 
                    || !Settings.UserSettings.ActiveSubscription.IsSubscriptionValid) 
                {
                    //we force to activate a subscription
                    MessageDisplay.CallSubscriptionError(controllers.MessageDisplaySettings);
                    return;
                }
                Database.DatabaseLink.UserLog.LoginUser(user);
                SetPagesToMain(controllers);
                return;
            }
            //if we reach this point the the user is part of a group
            //so we retrieve his active subscription from the administrator
            Settings.UserSettings.ActiveSubscription = Database.DatabaseLink.SubscriptionFunctions.GetSubscriptionForUser(Settings.UserSettings.UserGroup.Administrator);
            //and one final check 
            if (!Settings.UserSettings.ActiveSubscription.IsSubscriptionValid)
            {
                //we force to activate a subscription
                MessageDisplay.CallSubscriptionError(controllers.MessageDisplaySettings);
                return;
            }
            //now all we have to do is be happy for the user is logged in
            Database.DatabaseLink.UserLog.LoginUser(user);
            //oh and set the pages
            SetPagesToMain(controllers);
            //at this point the login is done
        }
        /// <summary>
        /// this function will set all controllers to their main functionality
        /// </summary>
        /// <param name="controllers">the controllers</param>
        public static void SetPagesToMain(Controllers controllers)
        {
            MessageDisplay.CallMain(controllers.MessageDisplaySettings);
            UserState.CallLoggedIn(controllers.LoginDisplayController);
            MainPage.ComponentDisplay.CallMain(controllers.DisplaySettings);
        }
    }
}
