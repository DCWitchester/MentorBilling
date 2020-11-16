using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ControllerService
{
    public class ControllerLink
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the base property value
        /// </summary>
        private Object value { get; set; } = String.Empty;
#pragma warning restore IDE1006 // Naming Styles

        #region Setters
        /// <summary>
        /// the main setter for the value
        /// </summary>
        public Object Value
        {
            set => SetValue(value);
        }
        #endregion

        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on page refresh
        /// </summary>
        public event Action OnChange;



        #region Specific Value
        /// <summary>
        /// the specific caller for getting the value as a string
        /// </summary>
        public String GetStringValue => (String)value;
        /// <summary>
        /// the specific caller for getting the value as a integer
        /// </summary>
        public Int32 GetIntegerValue => Int32.Parse(value.ToString());
        /// <summary>
        /// the specific caller for getting the value as a double 
        /// </summary>
        public Double GetDoubleValue => Double.Parse(value.ToString());
        /// <summary>
        /// the specific caller for getting the value as a boolean
        /// </summary>
        public Boolean GetBooleanValue => Boolean.Parse(value.ToString());
        /// <summary>
        /// the specific caller for getting the value as a datetime
        /// </summary>
        public DateTime GetDateTimeValue => DateTime.Parse(value.ToString());
        #endregion

        #region Functionality
        /// <summary>
        /// this function will set the base value for the
        /// </summary>
        /// <param name="value"></param>
        private void SetValue(Object value)
        {
            this.value = value;
            NotifyStateChanged();
        }

        /// <summary>
        /// this function will invoke the OnChange Event for the class
        /// </summary>
        private void NotifyStateChanged() => OnChange?.Invoke();
        #endregion Functionality
    }
}
