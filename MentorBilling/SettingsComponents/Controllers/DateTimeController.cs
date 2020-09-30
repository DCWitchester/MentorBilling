using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.SettingsComponents.Controllers
{
    public class DateTimeController
    {
        /// <summary>
        /// the date property of the controller
        /// </summary>
        private DateTime date { get; set; } = new DateTime();
        /// <summary>
        /// the time property of the controller
        /// </summary>
        private DateTime time { get; set; } = new DateTime();

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
        /// the main initialization for the Class with a parameter
        /// </summary>
        /// <param name="dt">the dateTime parameter</param>
        public DateTimeController(DateTime dt)
        {
            DateTime = dt;
        }

        /// <summary>
        /// the main initialization for the Class with no parameters
        /// </summary>
        public DateTimeController() { }
    }
}
