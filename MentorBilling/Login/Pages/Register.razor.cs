using MentorBilling.Database.DatabaseLink;
using MentorBilling.Login.UserControllers;
using System;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorBilling.Messages;
using MentorBilling.Miscellaneous;

namespace MentorBilling.Login.Pages
{
    public partial class Register
    {
        //the onAfterRenderAsync is raised after every form refresh
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
                //we can't access the base html objects from c# so we need JavaScripts(Damn the elders of the Internet)
                await JSRuntime.InvokeVoidAsync("focusElement", "tbSurname");
        }
        /// <summary>
        /// the main Register Controller for the page
        /// </summary>
        private readonly RegisterController RegisterController = new RegisterController();
  
        /// <summary>
        /// the main validation for the form
        /// </summary>
        /// <param name="valid">the state of the form</param>
        private async void FormValidate(Boolean valid)
        {
            if (valid)
            {
                //if the registerController has been validated
                //we register the controller to the database retrieving the newly created user
                User newUser = UserFunctions.RegisterUser(RegisterController);
                //if the creation of the user has failed we call the database connection error
                if (newUser == null)
                {
                    MessageDisplay.CallDatabaseError(MessageDisplaySettings);
                    //we return so as not to continue code execution
                    return;
                }
                //seeing as we now have our user we need to initialize the new Subscription for it
                if (!SubscriptionFunctions.GenerateInactiveSubscription(newUser))
                {
                    //if we fail we call error
                    MessageDisplay.CallDatabaseError(MessageDisplaySettings);
                    //we return so as not to continue code execution
                    return;
                }
                //if this point has been reached a new user has been created and we need to send an activation Link
                //as such we need to send them a link to activate the email;
                //Miscellaneous

#warning TBD
            }
            else
            {
                String x = "";
                //we can't access the base html objects from c# so we need JavaScripts(Damn the elders of the Internet)
                await JSRuntime.InvokeVoidAsync("focusElement","tbSurname");
                //the call the StateHasChanged to force a page refresh
                this.StateHasChanged();
            }
        }
    }
}
