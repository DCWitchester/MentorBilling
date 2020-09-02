using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous;
using MentorBilling.ObjectStructures;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Settings
{
    /// <summary>
    /// the central settings for the user
    /// </summary>
    public class UserSettings
    {
        /// <summary>
        /// the main user that has been Logged IN
        /// </summary>
        public static User LoggedInUser { get; set; } = new User();
        /// <summary>
        /// the main user state for the program
        /// </summary>
        public static UserState.UserStates UserState = Miscellaneous.UserState.UserStates.loggedOut;
        /// <summary>
        /// the active subscription for the current user
        /// </summary>
        public static Subscription ActiveSubscription { get; set; } = new Subscription();
        /// <summary>
        /// does the currently logged in user have sysadmin rights
        /// </summary>
        public static Boolean HasSysadminRights { get; set; } = false;
    }
}
