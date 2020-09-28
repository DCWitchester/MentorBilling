using MentorBilling.ControllerService;
using MentorBilling.Database.DatabaseLink.UserSettings;
using MentorBilling.Messages;
using MentorBilling.Miscellaneous.Menu;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.Pages
{
    public partial class UserMenu
    {
        [Parameter]
        public InstanceController InstanceController { get; set; } = new InstanceController();

        /// <summary>
        /// the visibility of the menu
        /// </summary>
        Boolean IsMenuVisible { get; set; } = false;

        /// <summary>
        /// the display menu property
        /// </summary>
        void DisplayMenu()
        {
            IsMenuVisible = !IsMenuVisible;
        }

        /// <summary>
        /// the initialization of the page calls the update of the menu from the database
        /// </summary>
        /// <returns>the initialization task back to the component</returns>
        protected override async Task OnInitializedAsync()
        {
            //the update is done here and not at login for two main reasons
            //REASON 1 : It matters not that it is here for this component is called at the exact moment of the login
            //REASON 2 : The control is far better here than on the form
            await Task.Run(()=>MenuFunctions.UpdateLocalUserMenu(InstanceController.UserSettings.LoggedInUser, InstanceController.UserMenu));
        }

        void ExecuteMenuEvent(MenuItem menuItem)
        {
         //TODO: think about how to finish theevents on the button settings    
        }

        /// <summary>
        /// the main logout Action on the button click
        /// </summary>
        void LogOut()
        {
            //the main functionality is on the logout page
            MessageDisplay.CallLogoutWarning(InstanceController.MessageDisplaySettings);
        }
    }
}
