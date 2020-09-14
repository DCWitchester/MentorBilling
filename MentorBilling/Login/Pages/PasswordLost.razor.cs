using MentorBilling.ControllerService;
using MentorBilling.Database.DatabaseLink;
using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous.Emails;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MentorBilling.Login.Pages
{
    public partial class PasswordLost
    {
        /// <summary>
        /// the main page Controller
        /// </summary>
        readonly PasswordLostController PageController = new PasswordLostController();

        [Parameter]
        public InstanceController InstanceController { get; set; }

        //the onAfterRenderAsync is raised after every form refresh
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //we can't access the base html objects from c# so we need JavaScripts(Damn the elders of the Internet)
                await JSRuntime.InvokeVoidAsync("focusElement", "tbEmail");
            }
        }

        void ValidateForm(Boolean validInput)
        {
            if (validInput)
            {
                Email.SendPasswordResetEmail(UserFunctions.RetrieveUser(PageController.Email));
                MainPage.ComponentDisplay.CallMain(InstanceController.DisplaySettings);
            }
        }
    }
}
