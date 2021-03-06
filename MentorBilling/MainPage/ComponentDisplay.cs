﻿namespace MentorBilling.MainPage
{
    public class ComponentDisplay
    {
        /// <summary>
        /// this enum will be used for the MainPage Display
        /// </summary>
        public enum Components
        {
            //the main page will be empty
            none = 0,
            //the main page will display the login page
            login = 1,
            //the main page will display the register page
            register = 2,
            //the main page will display the subscriptions
            subscriptions = 3,
            //the main page will display the password reset
            passwordLost = 4,
            //the main page will display the settings page
            settings =  5,

        }
        /// <summary>
        /// this function will redirect you to the login page
        /// </summary>
        public static void CallLogin(DisplaySettings displaySettings)
        {
            displaySettings.ChangePage(Components.login);
        }
        /// <summary>
        /// this function will redirect you to the register page
        /// </summary>
        public static void CallRegister(DisplaySettings displaySettings)
        {
            displaySettings.ChangePage(Components.register);
        }
        /// <summary>
        /// this function will redirect you to the subscription page
        /// </summary>
        public static void CallSubscription(DisplaySettings displaySettings)
        {
            displaySettings.ChangePage(Components.subscriptions);
        }
        /// <summary>
        /// this function will redirect you to the lostPassword page
        /// </summary>
        public static void CallLostPassword(DisplaySettings displaySettings)
        {
            displaySettings.ChangePage(Components.passwordLost);
        }
        /// <summary>
        /// this function will redirect you to the settings page
        /// </summary>
        public static void CallSettings(DisplaySettings displaySettings)
        {
            displaySettings.ChangePage(Components.settings);
        }
        /// <summary>
        /// this function will redirect you back to the main page
        /// </summary>
        public static void CallMain(DisplaySettings displaySettings)
        {
            displaySettings.ChangePage(Components.none);
        }
    }
}
