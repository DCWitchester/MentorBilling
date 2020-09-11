﻿using MentorBilling.ControllerService;
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
        public static void Login(User user,InstanceController instanceController)
        {
            //this function will log in the user to the controller
            instanceController.UserSettings.LoggedInUser = user;
            //we then retrieve the sysadmin rights for the user
            instanceController.UserSettings.HasSysadminRights = Database.DatabaseLink.UserFunctions.CheckAdministratorRights(user);
            //if the user HasSysadminRights we return for all other things are not necessary
            if (instanceController.UserSettings.HasSysadminRights)
            {
                //we log in the user
                instanceController.UserSettings.UserState = UserState.UserStates.loggedIn;
                UserState.CallLoggedIn(instanceController.LoginDisplayController);
                Database.DatabaseLink.UserLog.LoginUser(user);
                return;
            }
            //if we reach this point we have an active user that is not a system admin
            //<=AKA NOT US
            //as such we now check if there is an active group
            instanceController.UserSettings.UserGroup = Database.DatabaseLink.GroupFunctions.GetUserGroup(user);
            if(instanceController.UserSettings.UserGroup == null)
            {
                //if the user is not part of an active group we check if he has an active subscription
                instanceController.UserSettings.ActiveSubscription = Database.DatabaseLink.SubscriptionFunctions.GetSubscriptionForUser(user);
                //if the active subscription is by chance a group subscription that has no group or the active subscription is invalid
                if(instanceController.UserSettings.ActiveSubscription.SubscriptionType == (Int64)SubscriptionSettings.Subscriptions.ActiveGroupSubscription 
                    || !instanceController.UserSettings.ActiveSubscription.IsSubscriptionValid) 
                {
                    //we force to activate a subscription
                    MessageDisplay.CallSubscriptionError(instanceController.MessageDisplaySettings);
                    return;
                }
                Database.DatabaseLink.UserLog.LoginUser(user);
                SetPagesToMain(instanceController);
                return;
            }
            //if we reach this point the the user is part of a group
            //so we retrieve his active subscription from the administrator
            instanceController.UserSettings.ActiveSubscription = Database.DatabaseLink.SubscriptionFunctions.GetSubscriptionForUser(instanceController.UserSettings.UserGroup.Administrator);
            //and one final check 
            if (!instanceController.UserSettings.ActiveSubscription.IsSubscriptionValid)
            {
                //we force to activate a subscription
                MessageDisplay.CallSubscriptionError(instanceController.MessageDisplaySettings);
                return;
            }
            //now all we have to do is be happy for the user is logged in
            Database.DatabaseLink.UserLog.LoginUser(user);
            //oh and set the pages
            SetPagesToMain(instanceController);
            //at this point the login is done
        }
        /// <summary>
        /// this function will set all controllers to their main functionality
        /// </summary>
        /// <param name="controllers">the controllers</param>
        public static void SetPagesToMain(InstanceController controllers)
        {
            MessageDisplay.CallMain(controllers.MessageDisplaySettings);
            UserState.CallLoggedIn(controllers.LoginDisplayController);
            MainPage.ComponentDisplay.CallMain(controllers.DisplaySettings);
        }
    }
}
