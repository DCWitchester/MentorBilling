#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountiesPicker.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "060e9313f4106f6f78111ae83483ca2691f74c52"
// <auto-generated/>
#pragma warning disable 1591
namespace MentorBilling.AuxilliaryComponents.Pages
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
    public partial class CountiesPicker : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "EditContext", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Forms.EditContext>(
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountiesPicker.razor"
                                      EditContext

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(3, "\r\n    \r\n    ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(4);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(5, "\r\n    \r\n    ");
                __builder2.OpenElement(6, "div");
                __builder2.AddAttribute(7, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(8, "\r\n        \r\n        ");
                __builder2.AddMarkupContent(9, "<label class=\"col-sm-3 col-form-label\">Judetul:</label>\r\n        ");
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "class", "col-sm-9");
                __builder2.AddMarkupContent(12, "\r\n            \r\n            ");
                __Blazor.MentorBilling.AuxilliaryComponents.Pages.CountiesPicker.TypeInference.CreateInputSelect_0(__builder2, 13, 14, 
#nullable restore
#line 13 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountiesPicker.razor"
                                        PageController.SelectedCounty

#line default
#line hidden
#nullable disable
                , 15, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.SelectedCounty = __value, PageController.SelectedCounty)), 16, () => PageController.SelectedCounty, 17, (__builder3) => {
                    __builder3.AddMarkupContent(18, "\r\n                \r\n");
#nullable restore
#line 15 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountiesPicker.razor"
                 foreach (var county in PageController.counties)
                {

#line default
#line hidden
#nullable disable
                    __builder3.AddContent(19, "                    ");
                    __builder3.OpenElement(20, "option");
                    __builder3.AddAttribute(21, "value", 
#nullable restore
#line 17 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountiesPicker.razor"
                                    county

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddContent(22, 
#nullable restore
#line 17 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountiesPicker.razor"
                                             county.DisplayName

#line default
#line hidden
#nullable disable
                    );
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(23, "\r\n");
#nullable restore
#line 18 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountiesPicker.razor"
                }

#line default
#line hidden
#nullable disable
                    __builder3.AddContent(24, "            ");
                }
                );
                __builder2.AddMarkupContent(25, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(26, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(27, "\r\n");
            }
            ));
            __builder.AddComponentReferenceCapture(28, (__value) => {
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountiesPicker.razor"
                MyForm = (Microsoft.AspNetCore.Components.Forms.EditForm)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
namespace __Blazor.MentorBilling.AuxilliaryComponents.Pages.CountiesPicker
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputSelect_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg1, int __seq2, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg2, int __seq3, global::Microsoft.AspNetCore.Components.RenderFragment __arg3)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ValueChanged", __arg1);
        __builder.AddAttribute(__seq2, "ValueExpression", __arg2);
        __builder.AddAttribute(__seq3, "ChildContent", __arg3);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591