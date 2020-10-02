using MentorBilling.SettingsComponents.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MentorBilling.Settings.SettingTypes;

namespace MentorBilling.SettingsComponents
{
    public class Setting
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the base id property for the class
        /// </summary>
        private Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the base Display String property for the class
        /// </summary>
        private String settingDisplay { get; set; } = String.Empty;
        /// <summary>
        /// the base data type for the object
        /// </summary>
        private SettingDataTypes dataType { get; set; } = SettingDataTypes.type_void;
        /// <summary>
        /// the base value as an object to not determine the type
        /// </summary>
        private Object settingValue { get; set; } = new Object();
#pragma warning restore IDE1006
        #endregion

        #region Callers
        /// <summary>
        /// the main caller for the ID property
        /// </summary>
        public Int64 ID
        {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// the main caller for the SettingDisplay property
        /// </summary>
        public String SettingDisplay
        {
            get => settingDisplay;
            set => settingDisplay = value;
        }

        /// <summary>
        /// the main caller for the DataType property
        /// </summary>
        public SettingDataTypes DataTypes
        {
            get => dataType;
            set => dataType = value; 
        }

        /// <summary>
        /// the main caller for the value property
        /// </summary>
        public Object Value
        {
            get => settingValue;
            set => settingValue = value;
        }
        #endregion

        #region Specific Callers
        /// <summary>
        /// the specific caller for getting the value as a string
        /// </summary>
        public String GetStringValue => (String)settingValue;
        /// <summary>
        /// the specific caller for getting the value as a integer
        /// </summary>
        public Int32 GetIntegerValue => Int32.Parse(settingValue.ToString());
        /// <summary>
        /// the specific caller for getting the value as a double 
        /// </summary>
        public Double GetDoubleValue => Double.Parse(settingValue.ToString());
        /// <summary>
        /// the specific caller for getting the value as a boolean
        /// </summary>
        public Boolean GetBooleanValue => Boolean.Parse(settingValue.ToString());
        /// <summary>
        /// the specific caller for getting the value as a datetime
        /// </summary>
        public DateTime GetDateTimeValue => DateTime.Parse(settingValue.ToString());

        /// <summary>
        /// this function will use the specific callers to return the dynamic type value based on the DataTypeValue
        /// </summary>
        /// <returns>the dynamic object value</returns>
        public dynamic GetSpecificValue()
        {
            //we return on the switch
            return dataType switch
            {
                SettingDataTypes.type_void      => null,
                SettingDataTypes.type_string    => GetStringValue,
                SettingDataTypes.type_boolean   => GetBooleanValue,
                SettingDataTypes.type_date      => GetDateTimeValue,
                SettingDataTypes.type_datetime  => GetDateTimeValue,
                SettingDataTypes.type_double    => GetDoubleValue,
                SettingDataTypes.type_int       => GetIntegerValue,
                SettingDataTypes.type_time      => GetDateTimeValue,
                _ => null
            };
        }
        #endregion

        #region ControllerCasts
        /// <summary>
        /// this function will return a DateTimeController for the current setting
        /// </summary>
        /// <returns>the DateTimeController for the current property</returns>
        public DateTimeController GetDateTimeController() => new DateTimeController(GetDateTimeValue, settingDisplay);
        #endregion
    }
}
