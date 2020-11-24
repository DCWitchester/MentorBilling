using MentorBilling.ControllerService;
using MentorBilling.SettingsComponents.Controllers;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentorBilling.SettingsComponents.Pages
{
    public partial class SettingsPage
    {
        /// <summary>
        /// the Instance Controller for the page instance
        /// </summary>
        [Parameter]
        public InstanceController InstanceController { get; set; }

        /// <summary>
        /// the General Component Controllers for the page
        /// </summary>
        List<GeneralComponentController> GeneralComponentControllers { get; set; }

        /// <summary>
        /// the initial override of the page initialization
        /// </summary>
        /// <returns>the base Task</returns>
        protected override Task OnInitializedAsync()
        {
            using Database.EntityFramework.DatabaseLink.UserSettings.UserSettings userSettings = new Database.EntityFramework.DatabaseLink.UserSettings.UserSettings();
            GeneralComponentControllers = userSettings.RetrieveDisplayElementSettingsForUser(InstanceController.UserSettings.LoggedInUser);
            return base.OnInitializedAsync();
        }

    }
}
