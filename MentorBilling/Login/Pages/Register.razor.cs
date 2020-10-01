using MentorBilling.Database.DatabaseLink;
using MentorBilling.Login.UserControllers;
using System;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorBilling.Messages;
using MentorBilling.Miscellaneous;
using MentorBilling.MainPage;
using Microsoft.AspNetCore.Components;
using MentorBilling.ControllerService;
using MentorBilling.Database.DatabaseController;

namespace MentorBilling.Login.Pages
{
    public partial class Register
    {
        [Parameter] public InstanceController InstanceController { get; set; }
        //the onAfterRenderAsync is raised after every form refresh
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //we can't access the base html objects from c# so we need JavaScripts(Damn the elders of the Internet)
                await JSRuntime.InvokeVoidAsync("focusElement", "tbSurname");
            }
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
                    MessageDisplay.CallDatabaseError(InstanceController.MessageDisplaySettings);
                    //we return so as not to continue code execution
                    return;
                }
                //seeing as we now have our user we need to initialize the new Subscription for it
                if (!SubscriptionFunctions.GenerateInactiveSubscription(newUser))
                {
                    //if we fail we call error
                    MessageDisplay.CallDatabaseError(InstanceController.MessageDisplaySettings);
                    //we return so as not to continue code execution
                    return;
                }
                //if this point has been reached a new user has been created and we need to send an activation Link
                //as such we need to send them a link to activate the email;
                Miscellaneous.Emails.Email.SendValidationEmail(newUser);
                //not that the pesky things are done we must login
                //though before we do that we will leave the register page
                ComponentDisplay.CallMain(InstanceController.DisplaySettings);
                #region Menu Generation
                //we deactivate the initial menu settings
                InstanceController.UserMenu.DeactivateMenu();
                //then insert the initial settings
                Database.DatabaseLink.UserSettings.UserSettings.GenerateInitialUserSettings(newUser);
                Database.DatabaseLink.UserSettings.MenuFunctions.GenerateMenuSettingsForUser(newUser, InstanceController.UserMenu.UserMenu);
                #endregion
                //now we also Login the user
                Functions.Login(newUser, InstanceController);
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
