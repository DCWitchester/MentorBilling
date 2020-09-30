using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.SettingsComponents.Controllers
{
    public class DateTimeController
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the displayText for use on the component
        /// </summary>
        private String displayText { get; set; } = String.Empty;
        /// <summary>
        /// the date property of the controller
        /// </summary>
        private DateTime date { get; set; } = new DateTime();
        /// <summary>
        /// the time property of the controller
        /// </summary>
        private DateTime time { get; set; } = new DateTime();
#pragma warning restore IDE1006
        #endregion

        #region Callers
        /// <summary>
        /// the main caller for the Date property
        /// </summary>
        public DateTime Date 
        { 
            get => date;
            set => date = value; 
        }

        /// <summary>
        /// the main caller for the Time property
        /// </summary>
        public DateTime Time
        {
            get => time;
            set => time = value;
        }

        /// <summary>
        /// the main DateTime caller for the class (the true caller)
        /// </summary>
        public DateTime DateTime
        {
            get => new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            set => date = (time = value);
        }

        /// <summary>
        /// the main caller for the DisplayText
        /// </summary>
        public String DisplayText
        {
            get => displayText;
            set => displayText = value;
        }
        #endregion

        #region Initializers
        /// <summary>
        /// the main initialization for the Class with a string
        /// </summary>
        /// <param name="text">the text string parameter</param>
        public DateTimeController(String text)
        {
            DisplayText = text;
        }
        /// <summary>
        /// the main initialization for the Class with a parameter
        /// </summary>
        /// <param name="dt">the dateTime parameter</param>
        public DateTimeController(DateTime dt)
        {
            DateTime = dt;
        }
        /// <summary>
        /// the main initialization for the Class with both parameter
        /// </summary>
        /// <param name="dt">the dateTime parameter</param>
        /// <param name="text">the text string parameter</param>
        public DateTimeController(DateTime dt, String text)
        {
            DisplayText = text;
            DateTime = dt;
        }
        /// <summary>
        /// the main initialization for the Class with no parameters
        /// </summary>
        public DateTimeController() { }
        /// <summary>
        /// the main initialization for the class with Setting type parameter
        /// </summary>
        /// <param name="setting">the setting paramater</param>
        public DateTimeController(Setting setting)
        {
            ConsumeSetting(setting);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// this function will consume a setting object to retrieve needed settings
        /// </summary>
        /// <param name="setting">the given setting object to be consumed</param>
        void ConsumeSetting(Setting setting)
        {
            this.displayText = setting.SettingDisplay;
            this.DateTime = setting.GetDateTimeValue;
        }
        #endregion

    }
}
