#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\MiscellaneousPages\ValidateAccount.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3fe4c7e2eeb6f9b759937932e68c3ffa1d5aace7"
// <auto-generated/>
#pragma warning disable 1591
namespace MentorBilling.MiscellaneousPages
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/validateAccount")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/validateAccount/{account}")]
    public partial class ValidateAccount : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\MiscellaneousPages\ValidateAccount.razor"
 if (ErrorMessage)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", "dark_cover");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "overlay");
            __builder.OpenComponent<MentorBilling.Messages.Pages.DatabaseConnectionError>(4);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 11 "F:\MentorBilling\MBilling\MentorBilling\MiscellaneousPages\ValidateAccount.razor"
}

#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "div");
            __builder.OpenElement(6, "p");
            __builder.AddMarkupContent(7, "\r\n        Buna ziua ");
            __builder.AddContent(8, 
#nullable restore
#line 15 "F:\MentorBilling\MBilling\MentorBilling\MiscellaneousPages\ValidateAccount.razor"
                    User.DisplayName

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(9, ",\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n    ");
            __builder.AddMarkupContent(11, "<p>\r\n        Va multumim ca v-ati activat contul Mentor si va dorim o zi buna in continuare.\r\n    </p>");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
