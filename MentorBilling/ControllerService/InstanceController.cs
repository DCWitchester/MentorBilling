using MentorBilling.MainPage;
using MentorBilling.Messages;
using MentorBilling.Settings;
using MentorBilling.Shared.LoginDisplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ControllerService
{
    public class InstanceController
    {
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
        /// <summary>
        /// the main value for the UserSettingsController
        /// </summary>
        public UserSettings UserSettings { get; set; } = new UserSettings();
    }
}
