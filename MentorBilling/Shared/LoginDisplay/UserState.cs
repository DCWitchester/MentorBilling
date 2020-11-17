using MentorBilling.Shared.LoginDisplay;

namespace MentorBilling.Miscellaneous
{
    public class UserState
    {
        /// <summary>
        /// the main enum for the LoginDisplay Controller
        /// </summary>
        public enum UserStates
        {
            loggingIn = 0,
            loggedOut = 1,
            loggedIn = 2
        }

        /// <summary>
        /// the main caller for the loggingIn Display
        /// </summary>
        /// <param name="loginDisplayController"></param>
        public static void CallLoggingIn(LoginDisplayController loginDisplayController)
        {
            loginDisplayController.ChangeMessageType(UserStates.loggingIn);
        }
        /// <summary>
        /// the main caller for the loggedOut Display
        /// </summary>
        /// <param name="loginDisplayController"></param>
        public static void CallLoggedOut(LoginDisplayController loginDisplayController)
        {
            loginDisplayController.ChangeMessageType(UserStates.loggedOut);
        }
        /// <summary>
        /// the main caller for the loggedIn Display
        /// </summary>
        /// <param name="loginDisplayController"></param>
        public static void CallLoggedIn(LoginDisplayController loginDisplayController)
        {
            loginDisplayController.ChangeMessageType(UserStates.loggedIn);
        }
    }
}
