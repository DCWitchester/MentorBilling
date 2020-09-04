using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Shared.LoginDisplay
{
    public partial class LoginDisplay
    {
        #region DisplayController
        /// <summary>
        /// the main initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            DisplaySettings.OnChange += OnMyChangeHandler;
            base.OnInitialized();
        }
        /// <summary>
        /// the dispose of the page
        /// </summary>
        public void Dispose()
        {
            DisplaySettings.OnChange -= OnMyChangeHandler;
        }
        /// <summary>
        /// the  main handler for the state change
        /// </summary>
        private async void OnMyChangeHandler()
        {
            await InvokeAsync(() => StateHasChanged());
        }
        #endregion
        /// <summary>
        /// the main Login Click for the page
        /// </summary>
        private void LoginClick()
        {
            MainPage.ComponentDisplay.CallLogin(DisplaySettings);
        }
        /// <summary>
        /// the main Register Click on the page
        /// </summary>
        private void RegisterClick()
        {
            MainPage.ComponentDisplay.CallRegister(DisplaySettings);
        }
    }
}
