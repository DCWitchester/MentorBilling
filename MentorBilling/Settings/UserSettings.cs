using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous;
using MentorBilling.ObjectStructures;
using System;

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
        public User LoggedInUser { get; set; } = new User();
        /// <summary>
        /// the main user state for the program
        /// </summary>
        public UserState.UserStates UserState = Miscellaneous.UserState.UserStates.loggedOut;
        /// <summary>
        /// the main group for the user
        /// </summary>
        public Group UserGroup { get; set; } = new Group();
        /// <summary>
        /// the active subscription for the current user
        /// </summary>
        public Subscription ActiveSubscription { get; set; } = new Subscription();
        /// <summary>
        /// does the currently logged in user have sysadmin rights
        /// </summary>
        public Boolean HasSysadminRights { get; set; } = false;
    }
}
