#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a96ba7b2b7893ca1851872131a806c0f0fa6e35"
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
    public partial class Seller : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddMarkupContent(1, "\r\n    ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(2);
            __builder.AddAttribute(3, "EditContext", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Forms.EditContext>(
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                           EditContext

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                         ()=>ValidateLogin(true)

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(5, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                    (()=>ValidateLogin(false))

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(6, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(7, "\r\n        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(8);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(9, "\r\n        \r\n        ");
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(12, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(13, "<label class=\"col-sm-3 col-form-label\">Furnizor:</label>\r\n            \r\n            ");
                __builder2.OpenElement(14, "div");
                __builder2.AddAttribute(15, "class", "col-sm-9");
                __builder2.AddMarkupContent(16, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(17);
                __builder2.AddAttribute(18, "class", "form-control");
                __builder2.AddAttribute(19, "placeholder", "Denumire Furnizor");
                __builder2.AddAttribute(20, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 13 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                              PageController.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(21, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Name = __value, PageController.Name))));
                __builder2.AddAttribute(22, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(23, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateValidationMessage_0(__builder2, 24, 25, 
#nullable restore
#line 15 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                          ()=>PageController.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(26, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(27, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(28, "\r\n        \r\n        ");
                __builder2.OpenElement(29, "div");
                __builder2.AddAttribute(30, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(31, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(32, "<label class=\"col-sm-3 col-form-label\">Nr.ord.Reg.Com/an:</label>\r\n            \r\n            ");
                __builder2.OpenElement(33, "div");
                __builder2.AddAttribute(34, "class", "col-sm-9");
                __builder2.AddMarkupContent(35, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(36);
                __builder2.AddAttribute(37, "class", "form-control");
                __builder2.AddAttribute(38, "placeholder", "Numar Ordine Registru Comert");
                __builder2.AddAttribute(39, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 25 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                         PageController.CommercialRegistryNumber

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.CommercialRegistryNumber = __value, PageController.CommercialRegistryNumber))));
                __builder2.AddAttribute(41, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.CommercialRegistryNumber));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(42, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateValidationMessage_1(__builder2, 43, 44, 
#nullable restore
#line 27 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                          ()=>PageController.CommercialRegistryNumber

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(45, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(46, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(47, "\r\n        \r\n        ");
                __builder2.OpenElement(48, "div");
                __builder2.AddAttribute(49, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(50, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(51, "<label class=\"col-sm-3 col-form-label\">Cod fiscal:</label>\r\n            \r\n            ");
                __builder2.OpenElement(52, "div");
                __builder2.AddAttribute(53, "class", "col-sm-6");
                __builder2.AddMarkupContent(54, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(55);
                __builder2.AddAttribute(56, "class", "form-control");
                __builder2.AddAttribute(57, "placeholder", "Cod de identificare fiscala");
                __builder2.AddAttribute(58, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 37 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                        PageController.FiscalCode

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(59, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.FiscalCode = __value, PageController.FiscalCode))));
                __builder2.AddAttribute(60, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.FiscalCode));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(61, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateValidationMessage_2(__builder2, 62, 63, 
#nullable restore
#line 39 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                          ()=>PageController.FiscalCode

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(64, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(65, "\r\n            ");
                __builder2.OpenElement(66, "div");
                __builder2.AddAttribute(67, "class", "col-sm-3");
                __builder2.AddMarkupContent(68, "\r\n                ");
                __builder2.OpenElement(69, "button");
                __builder2.AddAttribute(70, "class", "btn-primary-auxilliary");
                __builder2.AddAttribute(71, "style", "margin-top:5px; margin-bottom:0px;");
                __builder2.AddAttribute(72, "type", "button");
                __builder2.AddAttribute(73, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 42 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                           GetAnafCompany

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddContent(74, "Preluare Online");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(75, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(76, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(77, "\r\n        \r\n        ");
                __builder2.OpenElement(78, "div");
                __builder2.AddAttribute(79, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(80, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(81, "<label class=\"col-sm-3 col-form-label\">Capital Social:</label>\r\n            \r\n            ");
                __builder2.OpenElement(82, "div");
                __builder2.AddAttribute(83, "class", "col-sm-9");
                __builder2.AddMarkupContent(84, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateInputNumber_3(__builder2, 85, 86, "form-control", 87, "Capital Social", 88, 
#nullable restore
#line 52 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                             PageController.JointStock

#line default
#line hidden
#nullable disable
                , 89, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.JointStock = __value, PageController.JointStock)), 90, () => PageController.JointStock);
                __builder2.AddMarkupContent(91, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateValidationMessage_4(__builder2, 92, 93, 
#nullable restore
#line 54 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                          ()=>PageController.JointStock

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(94, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(95, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(96, "\r\n        \r\n        ");
                __builder2.OpenElement(97, "div");
                __builder2.AddAttribute(98, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(99, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(100, "<label class=\"col-sm-3 col-form-label\">Sediul:</label>\r\n            \r\n            ");
                __builder2.OpenElement(101, "div");
                __builder2.AddAttribute(102, "class", "col-sm-9");
                __builder2.AddMarkupContent(103, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(104);
                __builder2.AddAttribute(105, "class", "form-control");
                __builder2.AddAttribute(106, "placeholder", "Sediul");
                __builder2.AddAttribute(107, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 64 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                   PageController.Headquarters

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(108, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Headquarters = __value, PageController.Headquarters))));
                __builder2.AddAttribute(109, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Headquarters));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(110, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateValidationMessage_5(__builder2, 111, 112, 
#nullable restore
#line 66 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                          ()=>PageController.Headquarters

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(113, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(114, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(115, "\r\n        ");
                __builder2.OpenElement(116, "div");
                __builder2.AddMarkupContent(117, "\r\n");
#nullable restore
#line 70 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
             foreach (var element in PageController.BankAccountControllers)
            {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(118, "                ");
                __builder2.OpenComponent<MentorBilling.AuxilliaryComponents.Pages.BankAccount>(119);
                __builder2.AddAttribute(120, "PageController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.AuxilliaryComponents.Controllers.BankAccountController>(
#nullable restore
#line 72 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                        element.SetElementIndex(PageController.BankAccountControllers.IndexOf(element))

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(121, "BankAccountDisplayController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.AuxilliaryComponents.DisplayControllers.BankAccountDisplayController>(
#nullable restore
#line 73 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                     BankAccountDisplayController

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(122, "SellerDisplayController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.Invoice.DisplayControllers.SellerDisplayController>(
#nullable restore
#line 74 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                SellerDisplayController

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(123, "LastItem", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 75 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                  element==PageController.BankAccountControllers.Last()

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(124, "\r\n");
#nullable restore
#line 76 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
            }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(125, "        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(126, "\r\n        <button type=\"submit\"></button>\r\n    ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(127, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
namespace __Blazor.MentorBilling.Invoice.Pages.Seller
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
        public static void CreateInputNumber_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, TValue __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg3, int __seq4, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg4)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "placeholder", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.AddAttribute(__seq4, "ValueExpression", __arg4);
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
    }
}
#pragma warning restore 1591
