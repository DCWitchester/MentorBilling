#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb220e7550a2425458fa20d25c1dcfd613da18cf"
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
            __builder.AddAttribute(6, "onfocusout", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.FocusEventArgs>(this, 
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                                                               SubmitForm

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(8, "\r\n        ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(9);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(10, "\r\n        \r\n        ");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "style", "display:flex; align-content:center; align-items:center; text-align:center;");
                __builder2.AddMarkupContent(13, "\r\n            ");
                __builder2.OpenComponent<MentorBilling.Invoice.Pages.Logo>(14);
                __builder2.AddAttribute(15, "PageController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.Invoice.Controllers.LogoController>(
#nullable restore
#line 8 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                  PageController.LogoController

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(17, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(18, "div");
                __builder2.AddAttribute(19, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(20, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(21, "<label class=\"col-sm-3 col-form-label\">Furnizor:</label>\r\n            \r\n            ");
                __builder2.OpenElement(22, "div");
                __builder2.AddAttribute(23, "class", "col-sm-9");
                __builder2.AddMarkupContent(24, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(25);
                __builder2.AddAttribute(26, "class", "form-control");
                __builder2.AddAttribute(27, "placeholder", "Denumire Furnizor");
                __builder2.AddAttribute(28, "disabled", 
#nullable restore
#line 19 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                              PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(29, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 19 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                              PageController.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(30, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Name = __value, PageController.Name))));
                __builder2.AddAttribute(31, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(32, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateValidationMessage_0(__builder2, 33, 34, 
#nullable restore
#line 21 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                          ()=>PageController.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(35, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(36, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(37, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(38, "div");
                __builder2.AddAttribute(39, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(40, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(41, "<label class=\"col-sm-3 col-form-label\">Nr.ord.Reg.Com/an:</label>\r\n            \r\n            ");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "col-sm-9");
                __builder2.AddMarkupContent(44, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(45);
                __builder2.AddAttribute(46, "class", "form-control");
                __builder2.AddAttribute(47, "placeholder", "Numar Ordine Registru Comert");
                __builder2.AddAttribute(48, "disabled", 
#nullable restore
#line 33 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                                                             PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(49, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 33 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                         PageController.CommercialRegistryNumber

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(50, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.CommercialRegistryNumber = __value, PageController.CommercialRegistryNumber))));
                __builder2.AddAttribute(51, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.CommercialRegistryNumber));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(52, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateValidationMessage_1(__builder2, 53, 54, 
#nullable restore
#line 35 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                          ()=>PageController.CommercialRegistryNumber

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(55, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(56, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(57, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(58, "div");
                __builder2.AddAttribute(59, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(60, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(61, "<label class=\"col-sm-3 col-form-label\">Cod fiscal:</label>\r\n            \r\n            ");
                __builder2.OpenElement(62, "div");
                __builder2.AddAttribute(63, "class", "col-sm-9");
                __builder2.AddMarkupContent(64, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(65);
                __builder2.AddAttribute(66, "class", "form-control");
                __builder2.AddAttribute(67, "placeholder", "Cod de identificare fiscala");
                __builder2.AddAttribute(68, "disabled", 
#nullable restore
#line 47 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                                              PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(69, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 47 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                        PageController.FiscalCode

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(70, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.FiscalCode = __value, PageController.FiscalCode))));
                __builder2.AddAttribute(71, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.FiscalCode));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(72, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateValidationMessage_2(__builder2, 73, 74, 
#nullable restore
#line 49 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                          ()=>PageController.FiscalCode

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(75, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(76, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(77, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(78, "div");
                __builder2.AddAttribute(79, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(80, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(81, "<label class=\"col-sm-3 col-form-label\">Capital Social:</label>\r\n            \r\n            ");
                __builder2.OpenElement(82, "div");
                __builder2.AddAttribute(83, "class", "col-sm-9");
                __builder2.AddMarkupContent(84, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateInputNumber_3(__builder2, 85, 86, "form-control", 87, "Capital Social", 88, 
#nullable restore
#line 61 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                                   PageController.DisableController

#line default
#line hidden
#nullable disable
                , 89, 
#nullable restore
#line 61 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                             PageController.JointStock

#line default
#line hidden
#nullable disable
                , 90, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.JointStock = __value, PageController.JointStock)), 91, () => PageController.JointStock);
                __builder2.AddMarkupContent(92, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateValidationMessage_4(__builder2, 93, 94, 
#nullable restore
#line 63 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                          ()=>PageController.JointStock

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(95, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(96, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(97, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(98, "div");
                __builder2.AddAttribute(99, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(100, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(101, "<label class=\"col-sm-3 col-form-label\">Sediul:</label>\r\n            \r\n            ");
                __builder2.OpenElement(102, "div");
                __builder2.AddAttribute(103, "class", "col-sm-9");
                __builder2.AddMarkupContent(104, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(105);
                __builder2.AddAttribute(106, "class", "form-control");
                __builder2.AddAttribute(107, "placeholder", "Sediul");
                __builder2.AddAttribute(108, "disabled", 
#nullable restore
#line 75 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                           PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(109, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 75 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                   PageController.Headquarters

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(110, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Headquarters = __value, PageController.Headquarters))));
                __builder2.AddAttribute(111, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Headquarters));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(112, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Seller.TypeInference.CreateValidationMessage_5(__builder2, 113, 114, 
#nullable restore
#line 77 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                          ()=>PageController.Headquarters

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(115, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(116, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(117, "\r\n        \r\n        \r\n        ");
                __builder2.OpenElement(118, "div");
                __builder2.AddMarkupContent(119, "\r\n");
#nullable restore
#line 83 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
             foreach (var element in PageController.BankAccountControllers)
            {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(120, "                \r\n                ");
                __builder2.OpenComponent<MentorBilling.AuxilliaryComponents.Pages.BankAccount>(121);
                __builder2.AddAttribute(122, "PageController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.AuxilliaryComponents.Controllers.BankAccountController>(
#nullable restore
#line 86 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                        element

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(123, "BankAccountDisplayController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.AuxilliaryComponents.DisplayControllers.BankAccountDisplayController>(
#nullable restore
#line 87 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                     BankAccountDisplayController

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(124, "SellerDisplayController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.Invoice.DisplayControllers.SellerDisplayController>(
#nullable restore
#line 88 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                SellerDisplayController

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(125, "LastItem", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 89 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                  element==PageController.BankAccountControllers.Last()

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(126, "\r\n");
#nullable restore
#line 90 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
            }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(127, "        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(128, "\r\n        \r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(129, "div");
                __builder2.AddAttribute(130, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(131, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(132, "<label class=\"col-sm-3 col-form-label\">Website:</label>\r\n            \r\n            ");
                __builder2.OpenElement(133, "div");
                __builder2.AddAttribute(134, "class", "col-sm-4");
                __builder2.AddMarkupContent(135, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(136);
                __builder2.AddAttribute(137, "class", "form-control");
                __builder2.AddAttribute(138, "placeholder", "Website");
                __builder2.AddAttribute(139, "disabled", 
#nullable restore
#line 102 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                       PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(140, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 102 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                    PageController.Website

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(141, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Website = __value, PageController.Website))));
                __builder2.AddAttribute(142, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Website));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(143, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(144, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(145, "<label class=\"col-sm-1 col-form-label\">Telefon:</label>\r\n            \r\n            ");
                __builder2.OpenElement(146, "div");
                __builder2.AddAttribute(147, "class", "col-sm-4");
                __builder2.AddMarkupContent(148, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(149);
                __builder2.AddAttribute(150, "class", "form-control");
                __builder2.AddAttribute(151, "placeholder", "Telefon");
                __builder2.AddAttribute(152, "disabled", 
#nullable restore
#line 109 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                     PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(153, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 109 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                    PageController.Phone

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(154, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Phone = __value, PageController.Phone))));
                __builder2.AddAttribute(155, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Phone));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(156, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(157, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(158, "\r\n        \r\n        \r\n        ");
                __builder2.OpenElement(159, "div");
                __builder2.AddAttribute(160, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(161, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(162, "<label class=\"col-sm-3 col-form-label\">Mail:</label>\r\n            \r\n            ");
                __builder2.OpenElement(163, "div");
                __builder2.AddAttribute(164, "class", "col-sm-9");
                __builder2.AddMarkupContent(165, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(166);
                __builder2.AddAttribute(167, "class", "form-control");
                __builder2.AddAttribute(168, "placeholder", "Mail");
                __builder2.AddAttribute(169, "disabled", 
#nullable restore
#line 120 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                  PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(170, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 120 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                 PageController.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(171, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Email = __value, PageController.Email))));
                __builder2.AddAttribute(172, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(173, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(174, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(175, "\r\n        \r\n        \r\n        ");
                __builder2.OpenElement(176, "div");
                __builder2.AddAttribute(177, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(178, "\r\n            \r\n            ");
                __builder2.AddMarkupContent(179, "<label class=\"col-sm-3 col-form-label\">Punct Lucru:</label>\r\n            \r\n            ");
                __builder2.OpenElement(180, "div");
                __builder2.AddAttribute(181, "class", "col-sm-9");
                __builder2.AddMarkupContent(182, "\r\n                \r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(183);
                __builder2.AddAttribute(184, "class", "form-control");
                __builder2.AddAttribute(185, "placeholder", "Punct de lucru");
                __builder2.AddAttribute(186, "disabled", 
#nullable restore
#line 131 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                                                                PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(187, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 131 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                                                                                           PageController.WorkPoint

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(188, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.WorkPoint = __value, PageController.WorkPoint))));
                __builder2.AddAttribute(189, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.WorkPoint));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(190, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(191, "\r\n        ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(192, "\r\n        \r\n        \r\n    ");
            }
            ));
            __builder.AddComponentReferenceCapture(193, (__value) => {
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Seller.razor"
                    SellerForm = (Microsoft.AspNetCore.Components.Forms.EditForm)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(194, "\r\n");
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
        public static void CreateInputNumber_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, System.Object __arg0, int __seq1, System.Object __arg1, int __seq2, System.Object __arg2, int __seq3, TValue __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg4, int __seq5, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg5)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.InputNumber<TValue>>(seq);
        __builder.AddAttribute(__seq0, "class", __arg0);
        __builder.AddAttribute(__seq1, "placeholder", __arg1);
        __builder.AddAttribute(__seq2, "disabled", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.AddAttribute(__seq5, "ValueExpression", __arg5);
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
