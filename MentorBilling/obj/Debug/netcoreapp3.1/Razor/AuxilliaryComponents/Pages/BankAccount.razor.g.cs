#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\BankAccount.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b71391c3968fa167b513c08e72d1e647ff38824"
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
    public partial class BankAccount : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddMarkupContent(1, "\r\n    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(2);
            __builder.AddAttribute(3, "EditContext", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Forms.EditContext>(
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\BankAccount.razor"
                                          EditContext

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(5, "\r\n        \r\n        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(6);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(7, "\r\n        \r\n        ");
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(10, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(11, "<label class=\"col-sm-3 col-form-label\">Contul:</label>\r\n            \r\n            ");
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", "col-sm-9");
                __builder2.AddMarkupContent(14, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(15);
                __builder2.AddAttribute(16, "class", "form-control");
                __builder2.AddAttribute(17, "placeholder", "Contul");
                __builder2.AddAttribute(18, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\BankAccount.razor"
                                                                                   PageController.Account

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Account = __value, PageController.Account))));
                __builder2.AddAttribute(20, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Account));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(21, "\r\n                \r\n                ");
                __Blazor.MentorBilling.AuxilliaryComponents.Pages.BankAccount.TypeInference.CreateValidationMessage_0(__builder2, 22, 23, 
#nullable restore
#line 16 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\BankAccount.razor"
                                          ()=>PageController.IsAccountNeeded

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(24, "\r\n                ");
                __Blazor.MentorBilling.AuxilliaryComponents.Pages.BankAccount.TypeInference.CreateValidationMessage_1(__builder2, 25, 26, 
#nullable restore
#line 17 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\BankAccount.razor"
                                          ()=>PageController.IsAccountValid

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(27, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(29, "\r\n        \r\n        ");
                __builder2.OpenElement(30, "div");
                __builder2.AddAttribute(31, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(32, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(33, "<label class=\"col-sm-3 col-form-label\">Banca:</label>\r\n            \r\n            ");
                __builder2.OpenElement(34, "div");
                __builder2.AddAttribute(35, "class", "col-sm-8");
                __builder2.AddMarkupContent(36, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(37);
                __builder2.AddAttribute(38, "class", "form-control");
                __builder2.AddAttribute(39, "placeholder", "Banca");
                __builder2.AddAttribute(40, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 27 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\BankAccount.razor"
                                                                                  PageController.Bank

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(41, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Bank = __value, PageController.Bank))));
                __builder2.AddAttribute(42, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Bank));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(43, "\r\n                \r\n                ");
                __Blazor.MentorBilling.AuxilliaryComponents.Pages.BankAccount.TypeInference.CreateValidationMessage_2(__builder2, 44, 45, 
#nullable restore
#line 29 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\BankAccount.razor"
                                          ()=>PageController.IsBankNeeded

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(46, "\r\n                ");
                __Blazor.MentorBilling.AuxilliaryComponents.Pages.BankAccount.TypeInference.CreateValidationMessage_3(__builder2, 47, 48, 
#nullable restore
#line 30 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\BankAccount.razor"
                                          ()=>PageController.IsAccountFilledIn

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(49, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(50, "\r\n            ");
                __builder2.OpenElement(51, "div");
                __builder2.AddAttribute(52, "style", "justify-content: flex-end; display: flex; margin-top:5px;");
                __builder2.AddMarkupContent(53, "\r\n                ");
                __builder2.OpenElement(54, "button");
                __builder2.AddAttribute(55, "class", "plus-button--small");
                __builder2.AddAttribute(56, "type", "button");
                __builder2.AddAttribute(57, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 33 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\BankAccount.razor"
                                                                           (() => SellerDisplayController.RefreshPage())

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseElement();
                __builder2.AddMarkupContent(58, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(59, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(60, "\r\n    ");
            }
            ));
            __builder.AddComponentReferenceCapture(61, (__value) => {
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\AuxilliaryComponents\Pages\BankAccount.razor"
                    MyForm = (Microsoft.AspNetCore.Components.Forms.EditForm)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(62, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
namespace __Blazor.MentorBilling.AuxilliaryComponents.Pages.BankAccount
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_2<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
