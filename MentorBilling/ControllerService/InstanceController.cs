using MentorBilling.Invoice.Controllers;
using MentorBilling.MainPage;
using MentorBilling.Messages;
using MentorBilling.Miscellaneous.Menu;
using MentorBilling.Settings;
using MentorBilling.SettingsComponents;
using MentorBilling.Shared.LoginDisplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ControllerService
{
    /// <summary>
    /// this class is the main backbone of the program beiing passed down from the initial page through all components
    /// </summary>
    public class InstanceController
    {
        #region Global Controllers
        /// <summary>
        /// the DisplaySettings Controller for the main page
        /// </summary>
        public DisplaySettings DisplaySettings { get; set; } = new DisplaySettings();
        /// <summary>
        /// the MessageDisplaySettings Controller for the Messages
        /// </summary>
        public MessageDisplaySettings MessageDisplaySettings { get; set; } = new MessageDisplaySettings();
        /// <summary>
        /// the LoginDisplay Controller for the Login Display
        /// </summary>
        public LoginDisplayController LoginDisplayController { get; set; } = new LoginDisplayController();
        #endregion

        #region Specific Controller
        /// <summary>
        /// the main value for the InvoiceController(Will Controll the Invoice)
        /// </summary>
        public InvoiceController InvoiceController { get; set; } = new InvoiceController();
        #endregion

        #region Specific Settings
        /// <summary>
        /// the main value for the UserSettingsController
        /// </summary>
        public UserSettings UserSettings { get; set; } = new UserSettings();
        /// <summary>
        /// the user menu linked to the userSettings
        /// </summary>
        public Menu UserMenu { get; set; } = new Menu();
        /// <summary>
        /// the main settings for the current users for the program: Will be retrieved on login
        /// </summary>
        public InstanceSettings InstanceSettings { get; set; } = new InstanceSettings();
        #endregion

        #region Controller Functions
        /// <summary>
        /// this function will retrieve the settings for the current user
        /// </summary>
        public void RetrieveUserSettings()
        {
            this.InstanceSettings.ConsumeSettings(Database.DatabaseLink.UserSettings.UserSettings.RetrieveSettingsListForUser(this.GetControlUser()));
        }

        /// <summary>
        /// this function will retrieve the in control user (based on the existance of a group)
        /// </summary>
        /// <returns>the in-control user</returns>
        public Login.UserControllers.User GetControlUser()
        {
            if (UserSettings.UserGroup == null) return UserSettings.LoggedInUser;
            else return UserSettings.UserGroup.Administrator;
        }
        #endregion
    }
}
