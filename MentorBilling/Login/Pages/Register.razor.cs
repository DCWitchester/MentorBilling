using MentorBilling.Database.DatabaseLink;
using MentorBilling.Login.UserControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.Pages
{
    public partial class Register
    {
        private RegisterController RegisterController = new RegisterController();
        
        private void FormCheck()
        {
            RegisterController.EmailAlreadyExists = UserFunctions.CheckEmail(RegisterController);
            RegisterController.UsernameAlreadyExists = UserFunctions.CheckUsername(RegisterController);
            String x = "";
        }

        private void FormValidate(Boolean valid)
        {
            String x = "";
        }
    }
}
