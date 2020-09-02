using MentorBilling.Database.DatabaseLink;
using MentorBilling.Login.UserControllers;
using System;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.Pages
{
    public partial class Register
    {
        /// <summary>
        /// the main Register Controller for the page
        /// </summary>
        private readonly RegisterController RegisterController = new RegisterController();

        /// <summary>
        /// this function validates errors not directly bound to fields
        /// </summary>
        private void FormCheck()
        {
            RegisterController.EmailAlreadyExists = UserFunctions.CheckEmail(RegisterController);
            RegisterController.UsernameAlreadyExists = UserFunctions.CheckUsername(RegisterController);
        }

        /// <summary>
        /// the main validation for the form
        /// </summary>
        /// <param name="valid">the state of the form</param>
        private async void FormValidate(Boolean valid)
        {
            if (valid)
            {
                User newUser = UserFunctions.RegisterUser(RegisterController);
#warning TBD
            }
            else
            {
                //we can't access the base html objects from c# so we need JavaScripts(Damn the elders of the Internet)
                await JSRuntime.InvokeVoidAsync("focusElement","tbSurname");
                //the call the StateHasChanged to force a page refresh
                this.StateHasChanged();
            }
        }
    }
}
