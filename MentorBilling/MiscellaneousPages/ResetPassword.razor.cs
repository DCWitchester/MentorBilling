using MentorBilling.Database.EntityFramework.DatabaseLink;
using MentorBilling.Login.UserControllers;
using MentorBilling.MiscellaneousPages.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace MentorBilling.MiscellaneousPages
{
    public partial class ResetPassword
    {
        /// <summary>
        /// the Account Parameter
        /// </summary>
        [Parameter]
        public String Account { get; set; }

        /// <summary>
        /// the central user structure
        /// </summary>
        User User { get; set; } = new User();

        /// <summary>
        /// the main error message display
        /// </summary>
        Boolean ErrorMessage { get; set; } = false;

        /// <summary>
        /// the main page display controller
        /// </summary>
        Boolean PasswordReset { get; set; } = false;

        /// <summary>
        /// the PageController linked to the EditModel
        /// </summary>
        ResetPasswordController PageController { get; set; } = new ResetPasswordController();

        protected override async Task OnInitializedAsync()
        {

            await Task.Run(() => RetrieveUser());
        }

        //the onAfterRenderAsync is raised after every form refresh
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                //we can't access the base html objects from c# so we need JavaScripts(Damn the elders of the Internet)
                await JSRuntime.InvokeVoidAsync("focusElement", "tbPassword");
            }
        }

        /// <summary>
        /// this function will retrieve and Decrypt the Paramater
        /// </summary>
        /// <returns>the User ID</returns>
        Int64 RetrieveParameter()
        {
            Miscellaneous.Encryption encryption = new Miscellaneous.Encryption();
            return Convert.ToInt64(encryption.Decrypt(Account));
        }

        /// <summary>
        /// this function will retrieve the user based on the user id
        /// </summary>
        void RetrieveUser()
        {
            using UserFunctions userFunctions = new UserFunctions();
            User = userFunctions.RetrieveUser(RetrieveParameter());
        }

        /// <summary>
        /// the main validation procedure for the account
        /// </summary>
        /// <param name="validInput">the validation result on the model</param>
        void ValidateForm(Boolean validInput)
        {
            if (validInput)
            {
                using UserFunctions userFunctions = new UserFunctions();
                if (!userFunctions.UpdatePassword(User, PageController)) ErrorMessage = true;
                else
                {
                    myNavigationManager.NavigateTo("/");
                }
            }
        }
        
    }
}
