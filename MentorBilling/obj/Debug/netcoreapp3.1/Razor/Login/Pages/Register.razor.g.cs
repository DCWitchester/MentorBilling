#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7c00ad507a6c58a6de1db8644f0876d7ae441d2"
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
    public partial class Register : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Inregistrare</h1>\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddMarkupContent(2, "\r\n    \r\n    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(3);
            __builder.AddAttribute(4, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 6 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                      RegisterController

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 6 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                                           e => FormValidate(true)

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(6, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 6 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                                                                                        e=>FormValidate(false)

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
                __builder2.AddMarkupContent(14, "<label class=\"col-form-label\">Nume</label>\r\n            \r\n            ");
                __builder2.OpenElement(15, "div");
                __builder2.AddMarkupContent(16, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(17);
                __builder2.AddAttribute(18, "class", "form-control");
                __builder2.AddAttribute(19, "id", "tbSurname");
                __builder2.AddAttribute(20, "placeholder", "Nume");
                __builder2.AddAttribute(21, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 16 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                                                                               RegisterController.Surname

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterController.Surname = __value, RegisterController.Surname))));
                __builder2.AddAttribute(23, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterController.Surname));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(24, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(25, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(26, "\r\n        \r\n        ");
                __builder2.OpenElement(27, "div");
                __builder2.AddAttribute(28, "class", "form-group");
                __builder2.AddMarkupContent(29, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(30, "<label class=\"col-form-label\">Prenume</label>\r\n            \r\n            ");
                __builder2.OpenElement(31, "div");
                __builder2.AddMarkupContent(32, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(33);
                __builder2.AddAttribute(34, "class", "form-control");
                __builder2.AddAttribute(35, "placeholder", "Prenume");
                __builder2.AddAttribute(36, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                                                                   RegisterController.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(37, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterController.Name = __value, RegisterController.Name))));
                __builder2.AddAttribute(38, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterController.Name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(39, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(40, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(41, "\r\n        \r\n        ");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "form-group");
                __builder2.AddMarkupContent(44, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(45, "<label class=\"col-form-label\">Email</label>\r\n            \r\n            ");
                __builder2.OpenElement(46, "div");
                __builder2.AddMarkupContent(47, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(48);
                __builder2.AddAttribute(49, "class", "form-control");
                __builder2.AddAttribute(50, "placeholder", "Email");
                __builder2.AddAttribute(51, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 34 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                                                                 RegisterController.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(52, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterController.Email = __value, RegisterController.Email))));
                __builder2.AddAttribute(53, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterController.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(54, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Login.Pages.Register.TypeInference.CreateValidationMessage_0(__builder2, 55, 56, 
#nullable restore
#line 36 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                          ()=>RegisterController.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(57, "\r\n                ");
                __Blazor.MentorBilling.Login.Pages.Register.TypeInference.CreateValidationMessage_1(__builder2, 58, 59, 
#nullable restore
#line 37 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                          ()=>RegisterController.EmailAlreadyExists

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(60, "\r\n                ");
                __Blazor.MentorBilling.Login.Pages.Register.TypeInference.CreateValidationMessage_2(__builder2, 61, 62, 
#nullable restore
#line 38 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                          ()=>RegisterController.IsEmailValid

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(63, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(64, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(65, "\r\n        \r\n        ");
                __builder2.OpenElement(66, "div");
                __builder2.AddAttribute(67, "class", "form-group");
                __builder2.AddMarkupContent(68, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(69, "<label class=\"col-form-label\">Nume Utilizator</label>\r\n            \r\n            ");
                __builder2.OpenElement(70, "div");
                __builder2.AddMarkupContent(71, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(72);
                __builder2.AddAttribute(73, "class", "form-control");
                __builder2.AddAttribute(74, "placeholder", "Nume Utilizator");
                __builder2.AddAttribute(75, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 47 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                                                                           RegisterController.Username

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(76, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterController.Username = __value, RegisterController.Username))));
                __builder2.AddAttribute(77, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterController.Username));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(78, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Login.Pages.Register.TypeInference.CreateValidationMessage_3(__builder2, 79, 80, 
#nullable restore
#line 49 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                          ()=>RegisterController.Username

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(81, "\r\n                ");
                __Blazor.MentorBilling.Login.Pages.Register.TypeInference.CreateValidationMessage_4(__builder2, 82, 83, 
#nullable restore
#line 50 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                          ()=>RegisterController.UsernameAlreadyExists

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(84, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(85, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(86, "\r\n        \r\n        ");
                __builder2.OpenElement(87, "div");
                __builder2.AddAttribute(88, "class", "form-group");
                __builder2.AddMarkupContent(89, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(90, "<label class=\"col-form-label\">Parola</label>\r\n            \r\n            ");
                __builder2.OpenElement(91, "div");
                __builder2.AddMarkupContent(92, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(93);
                __builder2.AddAttribute(94, "class", "form-control");
                __builder2.AddAttribute(95, "type", "password");
                __builder2.AddAttribute(96, "placeholder", "Parola");
                __builder2.AddAttribute(97, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 59 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                                                                                  RegisterController.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(98, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterController.Password = __value, RegisterController.Password))));
                __builder2.AddAttribute(99, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterController.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(100, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Login.Pages.Register.TypeInference.CreateValidationMessage_5(__builder2, 101, 102, 
#nullable restore
#line 61 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                          ()=>RegisterController.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(103, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(104, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(105, "\r\n        \r\n        ");
                __builder2.OpenElement(106, "div");
                __builder2.AddAttribute(107, "class", "form-group");
                __builder2.AddMarkupContent(108, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(109, "<label class=\"col-form-label\">Reintroduceti Parola</label>\r\n            \r\n            ");
                __builder2.OpenElement(110, "div");
                __builder2.AddMarkupContent(111, "\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(112);
                __builder2.AddAttribute(113, "class", "form-control");
                __builder2.AddAttribute(114, "type", "password");
                __builder2.AddAttribute(115, "placeholder", "Reintroduceti Parola");
                __builder2.AddAttribute(116, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 70 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                                                                                                RegisterController.PasswordMatch

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(117, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => RegisterController.PasswordMatch = __value, RegisterController.PasswordMatch))));
                __builder2.AddAttribute(118, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => RegisterController.PasswordMatch));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(119, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Login.Pages.Register.TypeInference.CreateValidationMessage_6(__builder2, 120, 121, 
#nullable restore
#line 72 "F:\MentorBilling\MBilling\MentorBilling\Login\Pages\Register.razor"
                                          ()=>RegisterController.DoPasswordsMatch

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(122, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(123, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(124, "\r\n        \r\n        ");
                __builder2.AddMarkupContent(125, "<div class=\"form-group text-center mb-0\">\r\n            <button type=\"submit\" class=\"btn btn-primary-validate\" id=\"BtnLogin\">Inregistrare</button>\r\n        </div>\r\n    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(126, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
namespace __Blazor.MentorBilling.Login.Pages.Register
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
        public static void CreateValidationMessage_4<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_5<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_6<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
