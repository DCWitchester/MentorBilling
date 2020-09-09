using MentorBilling.Login.UserControllers;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.Pages
{
    public partial class Login
    {
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
                //we retrieve the logged in user
                User loggedUser =  Database.DatabaseLink.UserFunctions.RetrieveUser(PageController);
                //then login the user
                Functions.Login(loggedUser, new Miscellaneous.Controllers {
                    DisplaySettings = DisplaySettings,
                    MessageDisplaySettings = MessageDisplaySettings,
                    LoginDisplayController = LoginDisplayController
                });
            }

        }
    }
}
