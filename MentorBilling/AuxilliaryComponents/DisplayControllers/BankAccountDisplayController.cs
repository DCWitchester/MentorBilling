﻿using System;

namespace MentorBilling.AuxilliaryComponents.DisplayControllers
{
    public class BankAccountDisplayController
    {
        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on the page refresh
        /// </summary>
        public event Action OnChange;

        /// <summary>
        /// the main function for the page refresh
        /// </summary>
        public void RefreshPage()
        {
            NotifyStateChanged();
        }

        /// <summary>
        /// this function will invoke the OnChange Event for the form
        /// </summary>
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
