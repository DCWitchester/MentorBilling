using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.MainPage
{
    public class DisplaySettings
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the property for the page Components
        /// </summary>
        private ComponentDisplay.Components pageComponents { get; set; } = ComponentDisplay.Components.register;
#pragma warning restore IDE1006 // Naming Styles
        /// <summary>
        /// the main caller for the pageComponents property
        /// </summary>
        public ComponentDisplay.Components PageComponents
        {
            get => pageComponents;
            set => pageComponents = value;
        }

        public event Action OnChange;


        public void ChangePage(ComponentDisplay.Components newPage)
        {
            PageComponents = newPage;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
