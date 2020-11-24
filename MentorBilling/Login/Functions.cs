using MentorBilling.ControllerService;
using MentorBilling.Login.UserControllers;
using MentorBilling.Messages;
using MentorBilling.Miscellaneous;
using MentorBilling.Settings.Subscriptions;
using System;


namespace MentorBilling.Login
{
    public class Functions
    {
        /// <summary>
        /// this function will login the given user to the instance controller
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="instanceController">the current instance controller</param>
        public static void Login(User user,InstanceController instanceController)
        {
            using Database.EntityFramework.DatabaseLink.UserLog userLog = new Database.EntityFramework.DatabaseLink.UserLog();
            //this function will log in the user to the controller
            instanceController.UserSettings.LoggedInUser = user;
            //we then retrieve the sysadmin rights for the user
            {
                using Database.EntityFramework.DatabaseLink.UserFunctions userFunctions = new Database.EntityFramework.DatabaseLink.UserFunctions();
                instanceController.UserSettings.HasSysadminRights = userFunctions.CheckAdministratorRights(user);
            }
            //if the user HasSysadminRights we return for all other things are not necessary
            if (instanceController.UserSettings.HasSysadminRights)
            {
                //we log in the user
                instanceController.UserSettings.UserState = UserState.UserStates.loggedIn;
                UserState.CallLoggedIn(instanceController.LoginDisplayController);
                //using Database.EntityFramework.DatabaseLink.UserLog UserLog = new Database.EntityFramework.DatabaseLink.UserLog();
                userLog.LoginUser(user);
                return;
            }
            //if we reach this point we have an active user that is not a system admin
            //<=AKA NOT US
            //as such we now check if there is an active group
            {
                using Database.EntityFramework.DatabaseLink.GroupFunctions groupFunctions = new Database.EntityFramework.DatabaseLink.GroupFunctions();
                instanceController.UserSettings.UserGroup = groupFunctions.GetUserGroup(user);
            }
            if(instanceController.UserSettings.UserGroup == null)
            {
                {
                    using Database.EntityFramework.DatabaseLink.SubscriptionFunctions subscriptionFunctions = new Database.EntityFramework.DatabaseLink.SubscriptionFunctions();
                    //if the user is not part of an active group we check if he has an active subscription
                    instanceController.UserSettings.ActiveSubscription = subscriptionFunctions.GetSubscriptionForUser(user);
                }
                //if the active subscription is by chance a group subscription that has no group or the active subscription is invalid
                if(instanceController.UserSettings.ActiveSubscription.SubscriptionType == (Int64)SubscriptionSettings.Subscriptions.ActiveGroupSubscription 
                    || !instanceController.UserSettings.ActiveSubscription.IsSubscriptionValid) 
                {
                    //we force to activate a subscription
                    MessageDisplay.CallSubscriptionError(instanceController.MessageDisplaySettings);
                    return;
                }
                //using Database.EntityFramework.DatabaseLink.UserLog userLog = new Database.EntityFramework.DatabaseLink.UserLog();
                userLog.LoginUser(user);
                SetPagesToMain(instanceController);
                return;
            }
            //if we reach this point the the user is part of a group
            //so we retrieve his active subscription from the administrator
            {
                using Database.EntityFramework.DatabaseLink.SubscriptionFunctions subscriptionFunctions = new Database.EntityFramework.DatabaseLink.SubscriptionFunctions();
                instanceController.UserSettings.ActiveSubscription = subscriptionFunctions.GetSubscriptionForUser(instanceController.UserSettings.UserGroup.Administrator);
            }
            //and one final check 
            if (!instanceController.UserSettings.ActiveSubscription.IsSubscriptionValid)
            {
                //we force to activate a subscription
                MessageDisplay.CallSubscriptionError(instanceController.MessageDisplaySettings);
                return;
            }
            //now all we have to do is be happy for the user is logged in
            userLog.LoginUser(user);
            //we also need to retrieve the software setting specific to the current user
            instanceController.RetrieveUserSettings();
            //oh and set the pages
            SetPagesToMain(instanceController);
            //at this point the login is done
        }

        public static void Logout(InstanceController instanceController)
        {
            //we first reinstantiate the user to delete existing settings
            instanceController.UserSettings = new Settings.UserSettings();
            //then return the display to the initial state
            //we remove the controllers
            instanceController.InvoiceController = new Invoice.Controllers.InvoiceController();
            //we will return to the main page if the user is in the settings page for example
            instanceController.DisplaySettings.ChangePage(MainPage.ComponentDisplay.Components.none);
            //we will also set login display to the default state
            instanceController.LoginDisplayController.ChangeMessageType(instanceController.UserSettings.UserState);
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
