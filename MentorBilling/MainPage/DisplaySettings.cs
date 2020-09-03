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

        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on the page refresh
        /// </summary>
        public event Action OnChange;

        /// <summary>
        /// the main function for the component Page Change
        /// </summary>
        /// <param name="newPage">the page that should be displayed</param>
        public void ChangePage(ComponentDisplay.Components newPage)
        {
            //we alter the component display
            PageComponents = newPage;
            //then we notify the change on the action
            NotifyStateChanged();
        }

        /// <summary>
        /// this function will invoke the OnChange Event for the form
        /// </summary>
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
