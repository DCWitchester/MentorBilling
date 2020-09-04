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
            //we can't access the base html objects from c# so we need JavaScripts(Damn the elders of the Internet)
            await JSRuntime.InvokeVoidAsync("focusElement", "tbUsername");
        }

        void ValidateLogin()
        {
#warning TBD FormValidate
        }
    }
}
