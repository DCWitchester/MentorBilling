#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38217b35e7c55b9b4a28e6fb97455ead203a3c6b"
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
    public partial class Buyer : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "style", "position:relative; z-index:-1");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(2);
            __builder.AddAttribute(3, "EditContext", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.Forms.EditContext>(
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                            EditContext

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                        (()=>ValidateForm(true))

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(5, "OnInvalidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                                   (()=>ValidateForm(false))

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(6, "onfocusout", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.FocusEventArgs>(this, 
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                                                                           SubmitForm

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(8);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(9, "\r\n        \r\n        \r\n        ");
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(12, "<label class=\"col-sm-3 col-form-label\">Cumparator</label>\r\n            \r\n            ");
                __builder2.OpenElement(13, "div");
                __builder2.AddAttribute(14, "class", "col-sm-9");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(15);
                __builder2.AddAttribute(16, "class", "form-control");
                __builder2.AddAttribute(17, "placeholder", "Denumire Cumparator");
                __builder2.AddAttribute(18, "disabled", 
#nullable restore
#line 14 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                                                PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(19, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 14 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                PageController.Name

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Name = __value, PageController.Name))));
                __builder2.AddAttribute(21, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Name));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(22, "\r\n                \r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Buyer.TypeInference.CreateValidationMessage_0(__builder2, 23, 24, 
#nullable restore
#line 16 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                          ()=>PageController.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(25, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(26, "div");
                __builder2.AddAttribute(27, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(28, "<label class=\"col-sm-3 col-form-label\">Nr.ord.Reg.Com/an:</label>\r\n            \r\n            ");
                __builder2.OpenElement(29, "div");
                __builder2.AddAttribute(30, "class", "col-sm-9");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(31);
                __builder2.AddAttribute(32, "class", "form-control");
                __builder2.AddAttribute(33, "placeholder", "Numar Ordine Registru Comert");
                __builder2.AddAttribute(34, "disabled", 
#nullable restore
#line 28 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                                                                             PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(35, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 28 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                         PageController.CommercialRegistryNumber

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(36, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.CommercialRegistryNumber = __value, PageController.CommercialRegistryNumber))));
                __builder2.AddAttribute(37, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.CommercialRegistryNumber));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(38, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(39, "div");
                __builder2.AddAttribute(40, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(41, "<label class=\"col-sm-3 col-form-label\">Cod fiscal:</label>\r\n            \r\n            ");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "col-sm-9");
                __builder2.AddAttribute(44, "style", "z-index : 1");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(45);
                __builder2.AddAttribute(46, "class", "form-control");
                __builder2.AddAttribute(47, "placeholder", "Cod de identificare fiscala");
                __builder2.AddAttribute(48, "disabled", 
#nullable restore
#line 40 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                                                              PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(49, "onfocusout", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.FocusEventArgs>(this, 
#nullable restore
#line 40 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                                                                                                             CheckCompanyInactivity

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(50, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 40 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                        PageController.FiscalCode

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(51, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.FiscalCode = __value, PageController.FiscalCode))));
                __builder2.AddAttribute(52, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.FiscalCode));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(53, "\r\n                ");
                __Blazor.MentorBilling.Invoice.Pages.Buyer.TypeInference.CreateValidationMessage_1(__builder2, 54, 55, 
#nullable restore
#line 41 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                          ()=>PageController.IsFiscalCodeValid

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(56, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(57, "div");
                __builder2.AddAttribute(58, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(59, "<label class=\"col-sm-3 col-form-label\">Sediul:</label>\r\n            \r\n            ");
                __builder2.OpenElement(60, "div");
                __builder2.AddAttribute(61, "class", "col-sm-9");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(62);
                __builder2.AddAttribute(63, "class", "form-control");
                __builder2.AddAttribute(64, "placeholder", "Adresa sediu");
                __builder2.AddAttribute(65, "disabled", 
#nullable restore
#line 53 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                                                 PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(66, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 53 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                         PageController.Headquarters

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(67, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.Headquarters = __value, PageController.Headquarters))));
                __builder2.AddAttribute(68, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.Headquarters));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(69, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(70, "div");
                __builder2.AddAttribute(71, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(72, "<label class=\"col-sm-3 col-form-label\">Email:</label>\r\n            \r\n            ");
                __builder2.OpenElement(73, "div");
                __builder2.AddAttribute(74, "class", "col-sm-9");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(75);
                __builder2.AddAttribute(76, "class", "form-control");
                __builder2.AddAttribute(77, "placeholder", "Adresa de mail");
                __builder2.AddAttribute(78, "disabled", 
#nullable restore
#line 65 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                                                      PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(79, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 65 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                           PageController.DeliveryAddress

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(80, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.DeliveryAddress = __value, PageController.DeliveryAddress))));
                __builder2.AddAttribute(81, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.DeliveryAddress));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(82, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(83, "div");
                __builder2.OpenComponent<MentorBilling.AuxilliaryComponents.Pages.CountriesPicker>(84);
                __builder2.AddAttribute(85, "PageController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.AuxilliaryComponents.Controllers.CountriesController>(
#nullable restore
#line 73 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                        PageController.CountriesController

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(86, "InstanceController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.ControllerService.InstanceController>(
#nullable restore
#line 74 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                            InstanceController

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(87, "DisplayController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.AuxilliaryComponents.DisplayControllers.CountryCountyDisplayController>(
#nullable restore
#line 75 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                         (PageController.CountryCountyDisplayController)

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(88, "\r\n            ");
                __Blazor.MentorBilling.Invoice.Pages.Buyer.TypeInference.CreateValidationMessage_2(__builder2, 89, 90, 
#nullable restore
#line 76 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                      ()=>PageController.IsCountryNeeded

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(91, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(92, "div");
                __builder2.OpenComponent<MentorBilling.AuxilliaryComponents.Pages.CountiesPicker>(93);
                __builder2.AddAttribute(94, "PageController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.AuxilliaryComponents.Controllers.CountiesController>(
#nullable restore
#line 83 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                       PageController.CountiesController

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(95, "InstanceController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.ControllerService.InstanceController>(
#nullable restore
#line 84 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                           InstanceController

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(96, "DisplayController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.AuxilliaryComponents.DisplayControllers.CountryCountyDisplayController>(
#nullable restore
#line 85 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                          PageController.CountryCountyDisplayController

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(97, "\r\n            ");
                __Blazor.MentorBilling.Invoice.Pages.Buyer.TypeInference.CreateValidationMessage_3(__builder2, 98, 99, 
#nullable restore
#line 86 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                      ()=>PageController.IsCountyNeeded

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(100, "\r\n        \r\n        \r\n        ");
                __builder2.OpenElement(101, "div");
                __builder2.OpenComponent<MentorBilling.AuxilliaryComponents.Pages.BankAccount>(102);
                __builder2.AddAttribute(103, "PageController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.AuxilliaryComponents.Controllers.BankAccountController>(
#nullable restore
#line 91 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                    PageController.BankAccountController

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(104, "\r\n        \r\n        \r\n        \r\n        ");
                __builder2.OpenElement(105, "div");
                __builder2.AddAttribute(106, "class", "form-group row mb-1");
                __builder2.AddMarkupContent(107, "<label class=\"col-sm-3 col-form-label\">Punct Lucru:</label>\r\n            \r\n            ");
                __builder2.OpenElement(108, "div");
                __builder2.AddAttribute(109, "class", "col-sm-9");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(110);
                __builder2.AddAttribute(111, "class", "form-control");
                __builder2.AddAttribute(112, "placeholder", "Adresa punctului de lucru\\livrare");
                __builder2.AddAttribute(113, "disabled", 
#nullable restore
#line 102 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                                                                         PageController.DisableController

#line default
#line hidden
#nullable disable
                );
                __builder2.AddAttribute(114, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 102 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                                                                                                              PageController.DeliveryAddress

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(115, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => PageController.DeliveryAddress = __value, PageController.DeliveryAddress))));
                __builder2.AddAttribute(116, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => PageController.DeliveryAddress));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.AddComponentReferenceCapture(117, (__value) => {
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\Invoice\Pages\Buyer.razor"
                    BuyerForm = (Microsoft.AspNetCore.Components.Forms.EditForm)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
namespace __Blazor.MentorBilling.Invoice.Pages.Buyer
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