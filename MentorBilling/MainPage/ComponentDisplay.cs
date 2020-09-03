using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.MainPage
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
            register = 2

        }
        /// <summary>
        /// this function will redirect you to the login page
        /// </summary>
        public static void CallLogin(DisplaySettings displaySettings)
        {
            displaySettings.ChangePage(Components.login);
        }
        /// <summary>
        /// this function will redirect you to the registe page
        /// </summary>
        public static void CallRegister(DisplaySettings displaySettings)
        {
            displaySettings.ChangePage(Components.register);
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
