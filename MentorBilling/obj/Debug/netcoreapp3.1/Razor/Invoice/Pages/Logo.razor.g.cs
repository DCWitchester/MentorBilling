#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Logo.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dac270ff85cbce10dcc6c4f14908fc3240cbcbef"
// <auto-generated/>
#pragma warning disable 1591
namespace MentorBilling.Invoice.Pages
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
    public partial class Logo : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Logo.razor"
 if (PageController.LogoBase == null || PageController.LogoBase.Length < 1)
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "drag-drop-zone");
            __builder.AddAttribute(2, "style", "width:100%");
            __builder.OpenComponent<BlazorInputFile.InputFile>(3);
            __builder.AddAttribute(4, "OnChange", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<BlazorInputFile.IFileListEntry[]>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<BlazorInputFile.IFileListEntry[]>(this, 
#nullable restore
#line 8 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Logo.razor"
                                             SelectLogo

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(5, "id", "inputFile");
            __builder.CloseComponent();
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.AddContent(7, 
#nullable restore
#line 9 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Logo.razor"
         Status

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
#nullable restore
#line 11 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Logo.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "style", "padding: 2rem; display: flex; align-items: center; justify-content: center; font-size: 1rem;");
            __builder.OpenElement(10, "img");
            __builder.AddAttribute(11, "src", 
#nullable restore
#line 16 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Logo.razor"
                   PageController.Logo

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(12, "height", 
#nullable restore
#line 16 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Logo.razor"
                                                  ImageDimensions.Height

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(13, "width", 
#nullable restore
#line 16 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Logo.razor"
                                                                                    ImageDimensions.Width

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(14, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Logo.razor"
                                                                                                                      ResetSelected

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 18 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Logo.razor"
    
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime jsRuntime { get; set; }
    }
}
#pragma warning restore 1591
