using MentorBilling.ControllerService;
using Microsoft.AspNetCore.Components;


namespace MentorBilling.Shared.LoginDisplay
{
    public partial class LoginDisplay
    {
        [Parameter] public InstanceController InstanceController { get; set;}
        #region DisplayController
        /// <summary>
        /// the main initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            InstanceController.DisplaySettings.OnChange += OnMyChangeHandler;
            base.OnInitialized();
        }
        /// <summary>
        /// the dispose of the page
        /// </summary>
        public void Dispose()
        {
            InstanceController.DisplaySettings.OnChange -= OnMyChangeHandler;
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
            MainPage.ComponentDisplay.CallLogin(InstanceController.DisplaySettings);
        }
        /// <summary>
        /// the main Register Click on the page
        /// </summary>
        private void RegisterClick()
        {
            MainPage.ComponentDisplay.CallRegister(InstanceController.DisplaySettings);
        }
    }
}
