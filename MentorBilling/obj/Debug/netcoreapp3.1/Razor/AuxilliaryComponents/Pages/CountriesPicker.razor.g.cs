#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fd8388c504b6e914612f1faac40183f91b452e89"
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
    public partial class CountriesPicker : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "EditContext", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Forms.EditContext>(
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor"
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
                __builder2.AddMarkupContent(9, "<label class=\"col-sm-3 col-form-label\">Tara:</label>\r\n        ");
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "class", "col-sm-9");
                __builder2.AddAttribute(12, "style", "height:inherit; text-align:center; display:flex;");
                __builder2.AddMarkupContent(13, "\r\n            \r\n\r\n            ");
                __Blazor.MentorBilling.AuxilliaryComponents.Pages.CountriesPicker.TypeInference.CreateInputSelect_0(__builder2, 14, 15, 
#nullable restore
#line 14 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor"
                                            ()=>PageController.SelectedCountry.DefaultCode

#line default
#line hidden
#nullable disable
                , 16, 
#nullable restore
#line 15 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor"
                                  PageController.SelectedCountry.DefaultCode

#line default
#line hidden
#nullable disable
                , 17, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 16 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor"
                                         (String value) => SelectElement(value)

#line default
#line hidden
#nullable disable
                ), 18, "height:inherit; width:inherit; margin-bottom:5px; text-align:center;", 19, (__builder3) => {
                    __builder3.AddMarkupContent(20, "\r\n                \r\n");
#nullable restore
#line 19 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor"
                 foreach (var country in PageController.countries)
                {

#line default
#line hidden
#nullable disable
                    __builder3.AddContent(21, "                    ");
                    __builder3.OpenElement(22, "option");
                    __builder3.AddAttribute(23, "value", 
#nullable restore
#line 21 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor"
                                     country.DefaultCode

#line default
#line hidden
#nullable disable
                    );
                    __builder3.AddAttribute(24, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor"
                                                                       ()=>SelectElement(country)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(25, 
#nullable restore
#line 21 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor"
                                                                                                     country.GetDisplayNameForSettings(InstanceController.InstanceSettings)

#line default
#line hidden
#nullable disable
                    );
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(26, "\r\n");
#nullable restore
#line 22 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor"
                }

#line default
#line hidden
#nullable disable
                    __builder3.AddContent(27, "            ");
                }
                );
                __builder2.AddMarkupContent(28, "\r\n\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(29, "\r\n    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(30, "\r\n");
            }
            ));
            __builder.AddComponentReferenceCapture(31, (__value) => {
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\CountriesPicker.razor"
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
namespace __Blazor.MentorBilling.AuxilliaryComponents.Pages.CountriesPicker
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateInputSelect_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg2, int __seq3, System.Object __arg3, int __seq4, global::Microsoft.AspNetCore.Components.RenderFragment __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>>(seq);
        __builder.AddAttribute(__seq0, "ValueExpression", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ValueChanged", __arg2);
        __builder.AddAttribute(__seq3, "style", __arg3);
        __builder.AddAttribute(__seq4, "ChildContent", __arg4);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
