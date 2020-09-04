using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Shared
{
    public partial class MainLayout
    {
        #region DisplayController
        /// <summary>
        /// the main initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            MessageDisplaySettings.OnChange += OnMyChangeHandler;
            base.OnInitialized();
        }
        /// <summary>
        /// the dispose of the page
        /// </summary>
        public void Dispose()
        {
            MessageDisplaySettings.OnChange -= OnMyChangeHandler;
        }
        /// <summary>
        /// the  main handler for the state change
        /// </summary>
        private async void OnMyChangeHandler()
        {
            await InvokeAsync(() => StateHasChanged());
        }
        #endregion
    }
}
