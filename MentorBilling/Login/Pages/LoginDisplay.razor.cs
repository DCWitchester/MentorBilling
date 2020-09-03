using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.Pages
{
    public partial class LoginDisplay
    {
        private void LoginClick()
        {
            MainPage.ComponentDisplay.CallLogin(DisplaySettings);
        }
        private void RegisterClick()
        {
            MainPage.ComponentDisplay.CallRegister(DisplaySettings);
        }
    }
}
