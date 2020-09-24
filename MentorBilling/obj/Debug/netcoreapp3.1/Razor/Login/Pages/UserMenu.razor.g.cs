#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\UserMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "117941c0ac8742c4d8f23caaa71c578ef3d101ad"
// <auto-generated/>
#pragma warning disable 1591
namespace MentorBilling.Login.Pages
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
    public partial class UserMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\">\r\n\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "dropdown");
            __builder.AddAttribute(3, "style", "margin-right: 15px");
            __builder.AddMarkupContent(4, "\r\n    \r\n    ");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "data-toggle", "dropdown");
            __builder.AddAttribute(7, "class", "btn-primary-login");
            __builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 6 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\UserMenu.razor"
                                                                       DisplayMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(9, " Meniu <i class=\"fa fa-home\"></i>");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n    ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "dropdown-menu" + " " + (
#nullable restore
#line 7 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\UserMenu.razor"
                                IsMenuVisible? "show" : ""

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "style", "margin-right:15px");
            __builder.AddMarkupContent(14, "\r\n        ");
            __builder.OpenElement(15, "div");
            __builder.AddAttribute(16, "class", "dropdown-item");
            __builder.AddAttribute(17, "style", "text-align:center");
            __builder.AddMarkupContent(18, "\r\n            Sunteti logat ca <br>\r\n            ");
            __builder.OpenElement(19, "b");
            __builder.AddContent(20, " ");
            __builder.AddContent(21, 
#nullable restore
#line 10 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\UserMenu.razor"
                  InstanceController.UserSettings.LoggedInUser.DisplayName

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(22, " ");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n        <div class=\"dropdown-divider\"></div>\r\n");
#nullable restore
#line 13 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\UserMenu.razor"
         foreach (var element in InstanceController.UserMenu.UserMenu)
        {
            if (element.IsActive)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(25, "                ");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "dropdown-item");
            __builder.AddAttribute(28, "style", "text-align:center;");
            __builder.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\UserMenu.razor"
                                                                                (() => ExecuteMenuEvent(element))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(30, "\r\n                    ");
            __builder.AddContent(31, 
#nullable restore
#line 18 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\UserMenu.razor"
                     element.MenuDisplay

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(32, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n");
#nullable restore
#line 20 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\UserMenu.razor"
            }
            else
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(34, "                ");
            __builder.OpenElement(35, "div");
            __builder.AddAttribute(36, "class", "dropdown-item");
            __builder.AddAttribute(37, "style", "text-align:center; color:darkgrey; pointer-events: none;");
            __builder.AddMarkupContent(38, "\r\n                    ");
            __builder.AddContent(39, 
#nullable restore
#line 24 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\UserMenu.razor"
                     element.MenuDisplay

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(40, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n");
#nullable restore
#line 26 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\UserMenu.razor"
            }
        }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(42, "        <div class=\"dropdown-divider\"></div>\r\n        ");
            __builder.AddMarkupContent(43, "<div class=\"dropdown-item\" style=\"text-align:center;\">Logout</div>\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
