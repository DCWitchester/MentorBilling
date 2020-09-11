using MentorBilling.ControllerService;
using MentorBilling.Login.UserControllers;
using MentorBilling.MiscellaneousPages.Controllers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.MiscellaneousPages
{
    public partial class ResetPassword
    {
        [Parameter]
        public String Account { get; set; }

        User User { get; set; } = new User();

        ResetPasswordController PageController { get; set; } = new ResetPasswordController();

        protected override async Task OnInitializedAsync()
        {

            await Task.Run(() => RetrieveUser());
        }

        Int64 RetrieveParameter()
        {
            Miscellaneous.Encryption encryption = new Miscellaneous.Encryption();
            return Convert.ToInt64(encryption.Decrypt(Account));
        }

        void RetrieveUser()
        {
            User = Database.DatabaseLink.UserFunctions.RetrieveUser(RetrieveParameter());
        }

        void ValidateForm(Boolean validInput)
        {
            if (validInput)
            {
                
            }
            else { }
        }
        
    }
}
