#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac2f0c30945870c7f9a076ed2abcb9c02a71095d"
// <auto-generated/>
#pragma warning disable 1591
namespace MentorBilling.MainPage
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
    public partial class MainDisplay : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 1 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
 switch (InstanceController.DisplaySettings.PageComponents)
{
    case ComponentDisplay.Components.login:
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(0, "            ");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "center-screen");
            __builder.AddMarkupContent(3, "\r\n                ");
            __builder.OpenComponent<MentorBilling.Login.Pages.Login>(4);
            __builder.AddAttribute(5, "InstanceController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.ControllerService.InstanceController>(
#nullable restore
#line 6 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
                                                                      InstanceController

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(6, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n");
#nullable restore
#line 8 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
            break;
        }
    case ComponentDisplay.Components.register:
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(8, "            ");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "center-screen");
            __builder.AddMarkupContent(11, "\r\n                ");
            __builder.OpenComponent<MentorBilling.Login.Pages.Register>(12);
            __builder.AddAttribute(13, "InstanceController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.ControllerService.InstanceController>(
#nullable restore
#line 13 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
                                                                         InstanceController

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(14, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n");
#nullable restore
#line 15 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
            break;
        }
    case ComponentDisplay.Components.passwordLost:
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(16, "            ");
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "center-screen");
            __builder.AddMarkupContent(19, "\r\n                ");
            __builder.OpenComponent<MentorBilling.Login.Pages.PasswordLost>(20);
            __builder.AddAttribute(21, "InstanceController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.ControllerService.InstanceController>(
#nullable restore
#line 20 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
                                                                             InstanceController

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(22, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n");
#nullable restore
#line 22 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
            break;
        }
    case ComponentDisplay.Components.settings:
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(24, "            ");
            __builder.OpenElement(25, "div");
            __builder.AddMarkupContent(26, "\r\n                ");
            __builder.OpenComponent<MentorBilling.SettingsComponents.Pages.SettingsPage>(27);
            __builder.AddAttribute(28, "InstanceController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.ControllerService.InstanceController>(
#nullable restore
#line 27 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
                                                                                          InstanceController

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(29, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n");
#nullable restore
#line 29 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
            break;
        }
    default:
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(31, "            ");
            __builder.OpenComponent<MentorBilling.Invoice.Pages.Invoice>(32);
            __builder.AddAttribute(33, "InstanceController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.ControllerService.InstanceController>(
#nullable restore
#line 33 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
                                                                      InstanceController

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(34, "PageController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.Invoice.Controllers.InvoiceController>(
#nullable restore
#line 34 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
                                                                   InstanceController.InvoiceController

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(35, "\r\n");
#nullable restore
#line 35 "F:\MentorBilling\MBilling\MentorBilling\MainPage\MainDisplay.razor"
            break;
        }
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
