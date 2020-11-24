using MentorBilling.ControllerService;
using MentorBilling.Login.UserControllers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace MentorBilling.Login.Pages
{
    public partial class Login
    {
        /// <summary>
        /// the InstanceController for the Page to Make controll
        /// </summary>
        [Parameter] public InstanceController InstanceController { get; set; }
        //the Page Controller for the Page
        readonly LoginController PageController = new LoginController();

        //the onAfterRenderAsync is raised after every form refresh
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //we can't access the base html objects from c# so we need JavaScripts(Damn the elders of the Internet)
                await JSRuntime.InvokeVoidAsync("focusElement", "tbUsername");
            }
        }

        /// <summary>
        /// the main validation for the for the page
        /// </summary>
        /// <param name="ControllerState">the controller state</param>
        void ValidateLogin(Boolean ControllerState)
        {
            //if the controller state is valid
            if (ControllerState)
            {
                using Database.EntityFramework.DatabaseLink.UserFunctions userFunctions = new Database.EntityFramework.DatabaseLink.UserFunctions();
                //we retrieve the logged in user
                User loggedUser =  userFunctions.RetrieveUser(PageController);
                //then login the user
                Functions.Login(loggedUser, InstanceController);
            }

        }

        /// <summary>
        /// this function will call the page for the email reset
        /// </summary>
        void ResetPassword()
        {
            MainPage.ComponentDisplay.CallLostPassword(InstanceController.DisplaySettings);
        }
    }
}
