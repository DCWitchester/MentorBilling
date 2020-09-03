using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Shared
{
    public partial class MainLayout
    {
        protected override void OnInitialized()
        {
            MessageDisplaySettings.OnChange += OnMyChangeHandler;
            base.OnInitialized();
        }
        public void Dispose()
        {
            MessageDisplaySettings.OnChange -= OnMyChangeHandler;
        }

        private async void OnMyChangeHandler()
        {
            await InvokeAsync(() => StateHasChanged());
        }
    }
}
