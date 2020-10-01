using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MentorBilling.Settings.SettingTypes;

namespace MentorBilling.SettingsComponents.Controllers
{
    public class GeneralComponentController : Setting
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the base input type for the object
        /// </summary>
        private SettingInputTypes inputType { get; set; } = SettingInputTypes.type_void;
        /// <summary>
        /// the base placeholder property for display
        /// </summary>
        private String placeholder { get; set; } = String.Empty;
        /// <summary>
        /// the base tooltip property for display
        /// </summary>
        private String tooltip { get; set; } = String.Empty;
#pragma warning restore IDE1006
        #endregion

        #region Callers
        /// <summary>
        /// the main caller for the InputType property
        /// </summary>
        public SettingInputTypes InputTypes
        {
            get => inputType;
            set => inputType = value;
        }
        /// <summary>
        /// the main caller for the placeholder property
        /// </summary>
        public String Placeholder
        {
            get => placeholder;
            set => placeholder = value;
        }
        /// <summary>
        /// the main caller for the tooltip property
        /// </summary>
        public String Tooltip
        {
            get => tooltip;
            set => tooltip = value;
        }
        #endregion

        #region Auxilliary Functions
        /// <summary>
        /// this function will return the input type string based on the enum
        /// </summary>
        /// <returns>the Input String</returns>
        public String GetInputType()
        {
            return InputTypes switch
            {
                SettingInputTypes.type_checkbox => "checkbox",
                SettingInputTypes.type_date => "date",
                SettingInputTypes.type_datetime => "datetime",
                SettingInputTypes.type_time => "time",
                SettingInputTypes.type_text => "text",
                SettingInputTypes.type_number => "number",
                _ => ""
            };
        }
        #endregion

        #region Object Bindings
        /// <summary>
        /// the property binding for objects needing String Values
        /// </summary>
        public String StringValue
        {
            get => base.GetStringValue;
            set => base.Value = value;
        }
        /// <summary>
        /// the property binding for objects needing Integer Values
        /// </summary>
        public Int32 IntegerValue
        {
            get => base.GetIntegerValue;
            set => base.Value = value;
        }
        /// <summary>
        /// the property binding for objects needing Double Values
        /// </summary>
        public Double DoubleValue
        {
            get => base.GetDoubleValue;
            set => base.Value = value;
        }
        /// <summary>
        /// the property binding for the objects needing Boolean Values
        /// </summary>
        public Boolean BooleanValue
        {
            get => base.GetBooleanValue;
            set => base.Value = value;
        }
        /// <summary>
        /// the property binding for the object property
        /// </summary>
        public DateTime DateTimeValue
        {
            get => base.GetDateTimeValue;
            set => base.Value = value;
        }
        #endregion
    }
}
