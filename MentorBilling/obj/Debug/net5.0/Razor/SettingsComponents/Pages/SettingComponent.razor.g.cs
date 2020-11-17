#pragma checksum "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "230f764a6fc4fb98a57d5ecd579ca3386627ff33"
// <auto-generated/>
#pragma warning disable 1591
namespace MentorBilling.SettingsComponents.Pages
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
    public partial class SettingComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 1 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
 if (PageController.InputTypes == Settings.SettingTypes.SettingInputTypes.type_datetime)
{

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<MentorBilling.SettingsComponents.Pages.DateTimePicker>(0);
            __builder.AddAttribute(1, "PageController", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MentorBilling.SettingsComponents.Controllers.DateTimeController>(
#nullable restore
#line 3 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                      PageController.GetDateTimeController()

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
#nullable restore
#line 4 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "form-group row mb-1");
            __builder.OpenElement(4, "label");
            __builder.AddAttribute(5, "class", "col-sm-3 col-form-label");
            __builder.AddContent(6, 
#nullable restore
#line 9 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                  PageController.SettingDisplay

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n        \r\n        ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "col-sm-9");
#nullable restore
#line 13 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
             switch (PageController.InputTypes)
            {
                case Settings.SettingTypes.SettingInputTypes.type_checkbox:

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     if (String.IsNullOrWhiteSpace(PageController.Tooltip))
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(10, "input");
            __builder.AddAttribute(11, "class", "form-control");
            __builder.AddAttribute(12, "type", 
#nullable restore
#line 21 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(13, "placeholder", 
#nullable restore
#line 21 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(14, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 22 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.BooleanValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.BooleanValue = __value, PageController.BooleanValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 23 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(16, "input");
            __builder.AddAttribute(17, "class", "form-control");
            __builder.AddAttribute(18, "type", 
#nullable restore
#line 29 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(19, "placeholder", 
#nullable restore
#line 29 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(20, "data-toggle", "tooltip");
            __builder.AddAttribute(21, "title", 
#nullable restore
#line 31 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                              PageController.Tooltip

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(22, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 30 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.BooleanValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(23, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.BooleanValue = __value, PageController.BooleanValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 32 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     
                    break;
                case Settings.SettingTypes.SettingInputTypes.type_date:

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     if (String.IsNullOrWhiteSpace(PageController.Tooltip))
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(24, "input");
            __builder.AddAttribute(25, "class", "form-control");
            __builder.AddAttribute(26, "type", 
#nullable restore
#line 40 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(27, "placeholder", 
#nullable restore
#line 40 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(28, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 41 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.DateTimeValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(29, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.DateTimeValue = __value, PageController.DateTimeValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 42 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(30, "input");
            __builder.AddAttribute(31, "class", "form-control");
            __builder.AddAttribute(32, "type", 
#nullable restore
#line 48 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(33, "placeholder", 
#nullable restore
#line 48 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(34, "data-toggle", "tooltip");
            __builder.AddAttribute(35, "title", 
#nullable restore
#line 50 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                              PageController.Tooltip

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(36, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 49 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.DateTimeValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(37, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.DateTimeValue = __value, PageController.DateTimeValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 51 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     
                    break;
                case Settings.SettingTypes.SettingInputTypes.type_number:

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     if (PageController.DataTypes == Settings.SettingTypes.SettingDataTypes.type_int)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                         if (String.IsNullOrWhiteSpace(PageController.Tooltip))
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(38, "input");
            __builder.AddAttribute(39, "class", "form-control");
            __builder.AddAttribute(40, "type", 
#nullable restore
#line 62 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(41, "placeholder", 
#nullable restore
#line 62 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                               PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(42, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 63 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                  PageController.IntegerValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(43, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.IntegerValue = __value, PageController.IntegerValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 64 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(44, "input");
            __builder.AddAttribute(45, "class", "form-control");
            __builder.AddAttribute(46, "type", 
#nullable restore
#line 70 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(47, "placeholder", 
#nullable restore
#line 70 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                               PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(48, "data-toggle", "tooltip");
            __builder.AddAttribute(49, "title", 
#nullable restore
#line 72 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                  PageController.Tooltip

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(50, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 71 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                  PageController.IntegerValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(51, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.IntegerValue = __value, PageController.IntegerValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 73 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                         
                    }
                    else if (PageController.DataTypes == Settings.SettingTypes.SettingDataTypes.type_double)
                    {

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                         if (String.IsNullOrWhiteSpace(PageController.Tooltip))
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(52, "input");
            __builder.AddAttribute(53, "class", "form-control");
            __builder.AddAttribute(54, "type", 
#nullable restore
#line 82 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(55, "placeholder", 
#nullable restore
#line 82 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                               PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(56, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 83 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                  PageController.DoubleValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(57, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.DoubleValue = __value, PageController.DoubleValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 84 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(58, "input");
            __builder.AddAttribute(59, "class", "form-control");
            __builder.AddAttribute(60, "type", 
#nullable restore
#line 90 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(61, "placeholder", 
#nullable restore
#line 90 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                               PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(62, "data-toggle", "tooltip");
            __builder.AddAttribute(63, "title", 
#nullable restore
#line 92 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                  PageController.Tooltip

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(64, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 91 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                  PageController.DoubleValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(65, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.DoubleValue = __value, PageController.DoubleValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 93 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                         
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     
                    break;
                case Settings.SettingTypes.SettingInputTypes.type_text:

#line default
#line hidden
#nullable disable
#nullable restore
#line 98 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     if (String.IsNullOrWhiteSpace(PageController.Tooltip))
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(66, "input");
            __builder.AddAttribute(67, "class", "form-control");
            __builder.AddAttribute(68, "type", 
#nullable restore
#line 102 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(69, "placeholder", 
#nullable restore
#line 102 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(70, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 103 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.StringValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(71, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.StringValue = __value, PageController.StringValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 104 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(72, "input");
            __builder.AddAttribute(73, "class", "form-control");
            __builder.AddAttribute(74, "type", 
#nullable restore
#line 110 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(75, "placeholder", 
#nullable restore
#line 110 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(76, "data-toggle", "tooltip");
            __builder.AddAttribute(77, "title", 
#nullable restore
#line 112 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                              PageController.Tooltip

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(78, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 111 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.StringValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(79, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.StringValue = __value, PageController.StringValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 113 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 113 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     
                    break;
                case Settings.SettingTypes.SettingInputTypes.type_time:

#line default
#line hidden
#nullable disable
#nullable restore
#line 117 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     if (String.IsNullOrWhiteSpace(PageController.Tooltip))
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(80, "input");
            __builder.AddAttribute(81, "class", "form-control");
            __builder.AddAttribute(82, "type", 
#nullable restore
#line 121 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(83, "placeholder", 
#nullable restore
#line 121 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(84, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 122 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.DateTimeValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(85, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.DateTimeValue = __value, PageController.DateTimeValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 123 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(86, "input");
            __builder.AddAttribute(87, "class", "form-control");
            __builder.AddAttribute(88, "type", 
#nullable restore
#line 129 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(89, "placeholder", 
#nullable restore
#line 129 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(90, "data-toggle", "tooltip");
            __builder.AddAttribute(91, "title", 
#nullable restore
#line 131 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                              PageController.Tooltip

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(92, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 130 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.DateTimeValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(93, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.DateTimeValue = __value, PageController.DateTimeValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 132 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 132 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     
                    break;
                case Settings.SettingTypes.SettingInputTypes.type_void:

#line default
#line hidden
#nullable disable
#nullable restore
#line 136 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     if (String.IsNullOrWhiteSpace(PageController.Tooltip))
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(94, "input");
            __builder.AddAttribute(95, "class", "form-control");
            __builder.AddAttribute(96, "type", 
#nullable restore
#line 140 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(97, "placeholder", 
#nullable restore
#line 140 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(98, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 141 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.StringValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(99, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.StringValue = __value, PageController.StringValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 142 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(100, "input");
            __builder.AddAttribute(101, "class", "form-control");
            __builder.AddAttribute(102, "type", 
#nullable restore
#line 148 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(103, "placeholder", 
#nullable restore
#line 148 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(104, "data-toggle", "tooltip");
            __builder.AddAttribute(105, "title", 
#nullable restore
#line 150 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                              PageController.Tooltip

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(106, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 149 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.StringValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(107, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.StringValue = __value, PageController.StringValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 151 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 151 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     
                    break;
                default:

#line default
#line hidden
#nullable disable
#nullable restore
#line 155 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     if (String.IsNullOrWhiteSpace(PageController.Tooltip))
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(108, "input");
            __builder.AddAttribute(109, "class", "form-control");
            __builder.AddAttribute(110, "type", 
#nullable restore
#line 159 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(111, "placeholder", 
#nullable restore
#line 159 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(112, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 160 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.StringValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(113, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.StringValue = __value, PageController.StringValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 161 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(114, "input");
            __builder.AddAttribute(115, "class", "form-control");
            __builder.AddAttribute(116, "type", 
#nullable restore
#line 167 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                            PageController.GetInputType()

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(117, "placeholder", 
#nullable restore
#line 167 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                                                                           PageController.Placeholder

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(118, "data-toggle", "tooltip");
            __builder.AddAttribute(119, "title", 
#nullable restore
#line 169 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                                              PageController.Tooltip

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(120, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 168 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                                              PageController.StringValue

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(121, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => PageController.StringValue = __value, PageController.StringValue));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
#nullable restore
#line 170 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 170 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
                     
                    break;
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 175 "F:\MentorBilling\MBilling\MentorBilling\SettingsComponents\Pages\SettingComponent.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591