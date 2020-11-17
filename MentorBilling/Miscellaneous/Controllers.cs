using MentorBilling.MainPage;
using MentorBilling.Messages;
using MentorBilling.Shared.LoginDisplay;

namespace MentorBilling.Miscellaneous
{
    /// <summary>
    /// this controller is used for passing the controllers from the page to the classes
    /// </summary>
    public class Controllers
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
    }
}
