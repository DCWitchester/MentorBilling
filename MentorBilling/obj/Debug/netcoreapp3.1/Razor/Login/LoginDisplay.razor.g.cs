#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\Login\LoginDisplay.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49373e672fe1d5385468193f4c7bab1b0dd4c782"
// <auto-generated/>
#pragma warning disable 1591
namespace MentorBilling.Login
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
    public partial class LoginDisplay : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddMarkupContent(1, "\r\n");
#nullable restore
#line 5 "F:\MentorBilling\MBilling\MentorBilling\Login\LoginDisplay.razor"
     switch (Settings.UserSettings.UserState)
        {
            case Miscellaneous.UserState.UserStates.loggingIn:

#line default
#line hidden
#nullable disable
            __builder.AddContent(2, "                ");
            __builder.AddMarkupContent(3, "<div>\r\n                    <lable>...</lable>\r\n                </div>\r\n");
#nullable restore
#line 11 "F:\MentorBilling\MBilling\MentorBilling\Login\LoginDisplay.razor"
                break;
            case Miscellaneous.UserState.UserStates.loggedIn:

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, "                ");
            __builder.OpenElement(5, "div");
            __builder.AddMarkupContent(6, "\r\n                    ");
            __builder.OpenElement(7, "label");
            __builder.AddContent(8, "Bine ati venit ");
            __builder.AddContent(9, 
#nullable restore
#line 14 "F:\MentorBilling\MBilling\MentorBilling\Login\LoginDisplay.razor"
                                           Settings.UserSettings.LoggedInUser.DisplayName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n");
#nullable restore
#line 16 "F:\MentorBilling\MBilling\MentorBilling\Login\LoginDisplay.razor"
                break;
            case Miscellaneous.UserState.UserStates.loggedOut:

#line default
#line hidden
#nullable disable
            __builder.AddContent(12, "                ");
            __builder.AddMarkupContent(13, "<div>\r\n                    <button class=\"btn-primary-login\">Login</button>\r\n                    <button class=\"btn-primary-login\">Register</button>\r\n                </div>\r\n");
#nullable restore
#line 22 "F:\MentorBilling\MBilling\MentorBilling\Login\LoginDisplay.razor"
                break;
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider auth { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager Navigation { get; set; }
    }
}
#pragma warning restore 1591
