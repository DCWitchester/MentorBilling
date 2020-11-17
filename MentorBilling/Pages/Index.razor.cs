using MentorBilling.ControllerService;

namespace MentorBilling.Pages
{
    public partial class Index
    {
        readonly InstanceController InstanceController = new InstanceController();
        #region DisplayController
        /// <summary>
        /// the main initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            InstanceController.MessageDisplaySettings.OnChange += OnMyChangeHandler;
            base.OnInitialized();
        }
        /// <summary>
        /// the dispose of the page
        /// </summary>
        public void Dispose()
        {
            InstanceController.MessageDisplaySettings.OnChange -= OnMyChangeHandler;
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
