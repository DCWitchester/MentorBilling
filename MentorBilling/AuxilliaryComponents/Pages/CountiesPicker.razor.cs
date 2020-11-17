using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.AuxilliaryComponents.DisplayControllers;
using MentorBilling.ControllerService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Linq;

namespace MentorBilling.AuxilliaryComponents.Pages
{
    public partial class CountiesPicker
    {
        #region Form Parameters
        /// <summary>
        /// the instance controller for the user instance
        /// </summary>
        [Parameter]
        public InstanceController InstanceController { get; set; }
        /// <summary>
        /// the page controller linked to the razor component
        /// </summary>
        [Parameter]
        public CountiesController PageController { get; set; }
        /// <summary>
        /// the display controller that links the county and country pickers
        /// </summary>
        [Parameter]
        public CountryCountyDisplayController DisplayController { get; set; }

        #endregion
        #region Form Binding
        private EditForm myForm;
        #endregion

        #region Form Binding
        /// <summary>
        /// the editform reference to the razor controller
        /// </summary>
        private EditForm GetMyForm()
        {
            return myForm;
        }
        #endregion

        #region Form Binding
        /// <summary>
        /// the editform reference to the razor controller
        /// </summary>
        private void SetMyForm(EditForm value)
        {
            myForm = value;
        }

        /// <summary>
        /// the edit context bound to the page
        /// </summary>
        private EditContext EditContext { get; set; }

        /// <summary>
        /// the main initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            EditContext = new EditContext(PageController);
            DisplayController.OnChange += OnMyChangeHandler;
            base.OnInitialized();
        }
        /// <summary>
        /// the dispose of the page
        /// </summary>
        public void Dispose()
        {
            InstanceController.DisplaySettings.OnChange -= OnMyChangeHandler;
        }
        #endregion

        #region Functionality
        /// <summary>
        /// this function will select the county on the element click
        /// </summary>
        /// <param name="selectedCounty">receive country option</param>
        private void SelectedElement(String selectedCounty)
        {
            if (selectedCounty.Trim().Length >= 2)
                PageController.SelectedCounty = PageController.counties.Where(county => county.CountyCode == selectedCounty.Substring(0, 2)).FirstOrDefault();
            else
                PageController.SelectedCounty = PageController.counties.Where(county => county.ID == 0).FirstOrDefault();
        }

        /// <summary>
        /// the main handler for the state changed remote event
        /// </summary>
        private async void OnMyChangeHandler()
        {
            await InvokeAsync(() => StateHasChanged());
        }
        #endregion
    }
}
