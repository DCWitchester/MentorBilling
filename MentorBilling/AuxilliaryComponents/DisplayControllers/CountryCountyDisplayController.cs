using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.AuxilliaryComponents.DisplayControllers
{
    public class CountryCountyDisplayController
    {
#pragma warning disable IDE1006 //Naming Styles
        /// <summary>
        /// the property containing the is CountyNeeded Value
        /// </summary>
        private Boolean isCountyNeeded { get; set; } = false;
#pragma warning restore IDE1006 //Naming Styles

        /// <summary>
        /// the main caller for isCountyNeeded property
        /// </summary>
        public Boolean IsCountyNeeded
        {
            get => isCountyNeeded;
        }

        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on the page refresh
        /// </summary>
        public event Action OnChange;

        /// <summary>
        /// this function will call the Message for Display
        /// </summary>
        /// <param name="isCountryRomania">wether the selected country is romania or not </param>
        public void ChangeCountry(Boolean isCountryRomania)
        {
            if (isCountyNeeded != isCountryRomania)
            {
                isCountyNeeded = isCountryRomania;
                NotifyStateChanged();
            }
        }

        /// <summary>
        /// this function will invoke the OnChange Event for the form
        /// </summary>
        public void NotifyStateChanged() => OnChange?.Invoke();
    }
}
