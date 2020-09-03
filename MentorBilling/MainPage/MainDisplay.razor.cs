using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MentorBilling.MainPage
{
    public partial class MainDisplay
    {
        protected override void OnInitialized()
        {
            DisplaySettings.OnChange += OnMyChangeHandler;
            base.OnInitialized();
        }
        public void Dispose()
        {
            DisplaySettings.OnChange -= OnMyChangeHandler;
        }

        private async void OnMyChangeHandler()
        {
            await InvokeAsync(() => StateHasChanged());
        }
    }
}
