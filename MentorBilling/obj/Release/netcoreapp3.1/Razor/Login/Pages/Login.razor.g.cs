#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "546eef49d854c7d569e44f330777e176afd131ca"
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
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Login</h1>\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddMarkupContent(2, "\r\n    \r\n    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(3);
            __builder.AddAttribute(4, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 9 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Login.razor"
                      PageController

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 9 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Login.razor"
                                                       e => ValidateLogin(true)

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(6, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 9 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Login.razor"
                                                                                                     e => ValidateLogin(false)

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(8, "\r\n        \r\n        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(9);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(10, "\r\n        \r\n        \r\n        ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "form-group");
                __builder2.AddMarkupContent(13, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(14, "<label class=\"col-form-label\">Nume Utilizator sau Email</label>\r\n            \r\n            ");
                __builder2.OpenElement(15, "div");
                __builder2.AddMarkupContent(16, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(17);
                __builder2.AddAttribute(18, "id", "tbUsername");
                __builder2.AddAttribute(19, "class", "form-control");
                __builder2.AddAttribute(20, "placeholder", "Nume Utilizator sau Email");
                __builder2.AddAttribute(21, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 19 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Login.razor"
                                                                                                                     PageController.Username

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Username = __value, PageController.Username))));
                __builder2.AddAttribute(23, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Username));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(24, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Login.Pages.Login.TypeInference.CreateValidationMessage_0(__builder2, 25, 26, 
#nullable restore
#line 21 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Login.razor"
                                          ()=>PageController.Username

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
                __builder2.AddAttribute(31, "class", "form-group");
                __builder2.AddMarkupContent(32, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(33, "<label class=\"col-form-label\">Parola</label>\r\n            \r\n            ");
                __builder2.OpenElement(34, "div");
                __builder2.AddMarkupContent(35, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(36);
                __builder2.AddAttribute(37, "class", "form-control");
                __builder2.AddAttribute(38, "type", "password");
                __builder2.AddAttribute(39, "placeholder", "Parola");
                __builder2.AddAttribute(40, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 30 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Login.razor"
                                                                                                  PageController.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(41, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Password = __value, PageController.Password))));
                __builder2.AddAttribute(42, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(43, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Login.Pages.Login.TypeInference.CreateValidationMessage_1(__builder2, 44, 45, 
#nullable restore
#line 32 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Login.razor"
                                          ()=>PageController.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(46, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(47, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(48, "\r\n        \r\n        ");
                __Blazor.MentorBilling.Login.Pages.Login.TypeInference.CreateValidationMessage_2(__builder2, 49, 50, 
#nullable restore
#line 36 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Login.razor"
                                  ()=>PageController.IsPasswordValid

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(51, "\r\n        ");
                __Blazor.MentorBilling.Login.Pages.Login.TypeInference.CreateValidationMessage_3(__builder2, 52, 53, 
#nullable restore
#line 37 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Login.razor"
                                  ()=>PageController.DoesUsernameExist

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(54, "\r\n        \r\n        ");
                __builder2.AddMarkupContent(55, "<div class=\"form-group text-center mb-0\">\r\n            <button type=\"submit\" class=\"btn btn-primary-validate\" id=\"BtnLogin\">Login</button>\r\n        </div>\r\n    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(56, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MentorBilling.Shared.LoginDisplay.LoginDisplayController LoginDisplayController { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MentorBilling.MainPage.DisplaySettings DisplaySettings { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MentorBilling.Messages.MessageDisplaySettings MessageDisplaySettings { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
namespace __Blazor.MentorBilling.Login.Pages.Login
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
