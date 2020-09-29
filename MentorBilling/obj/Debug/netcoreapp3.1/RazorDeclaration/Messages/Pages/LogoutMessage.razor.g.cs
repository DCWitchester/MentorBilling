#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\Messages\Pages\LogoutMessage.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8ca5455ccad4d97177ed8a65de575ff51fbb2cf"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace MentorBilling.Messages.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using MentorBilling;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using MentorBilling.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\MentorBilling\MBilling\MentorBilling\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
    public partial class LogoutMessage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "F:\MentorBilling\MBilling\MentorBilling\Messages\Pages\LogoutMessage.razor"
       
    [Parameter]
    public MentorBilling.ControllerService.InstanceController InstanceController { get; set; }

    /// <summary>
    /// this function will call the logout event on the page
    /// </summary>
    public void ContinueLogout()
    {
        LeaveError();
        Login.Functions.Logout(InstanceController);
    }

    /// <summary>
    /// the abandon on the messge
    /// </summary>
    public void LeaveError()
    {
        //hide the error messages
        MessageDisplay.CallMain(InstanceController.MessageDisplaySettings);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591