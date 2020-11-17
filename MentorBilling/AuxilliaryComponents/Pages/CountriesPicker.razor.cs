using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.AuxilliaryComponents.DisplayControllers;
using MentorBilling.ControllerService;
using MentorBilling.ObjectStructures.Auxilliary;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Linq;

namespace MentorBilling.AuxilliaryComponents.Pages
{
    public partial class CountriesPicker
    {
        #region Form Parameters
        /// <summary>
        /// the instance controller for the user instance
        /// </summary>
        [Parameter]
        public InstanceController InstanceController { get; set; }
        /// <summary>
        /// the page controller linked to the razor
        /// </summary>
        [Parameter]
        public CountriesController PageController { get; set; }
        /// <summary>
        /// the display controller that links the county and country pickers
        /// </summary>
        [Parameter]
        public CountryCountyDisplayController DisplayController { get; set; }
        #endregion

        #region Form Binding
#pragma warning disable IDE0052
        /// <summary>
        /// the edit form reference used for page refresh
        /// </summary>
        private EditForm MyForm { get; set; }
#pragma warning restore IDE0052

        /// <summary>
        /// the main editContext on the Page
        /// </summary>
        private EditContext EditContext { get; set; }

        /// <summary>
        /// the main initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            EditContext = new EditContext(PageController);
            base.OnInitialized();
        }
        #endregion

        #region Functionality

        /// <summary>
        /// this function will set the selected Country on Element Click
        /// </summary>
        /// <param name="selectedCountry">received the options country value</param>
        private void SelectElement(String selectedCountry)
        {
            if (selectedCountry.Trim().Length >= 2)
                PageController.SelectedCountry = PageController.countries.Where(country => country.CountryCodeISO2 == selectedCountry.Substring(0,2)).FirstOrDefault();
            else
                PageController.SelectedCountry = PageController.countries.Where(country => country.ID == 0).FirstOrDefault();
            //after setting the selected country we also change the display value on the county
            DisplayController.ChangeCountry(PageController.SelectedCountry.IsCountryRomania);
        }
        #region Deprecated
#pragma warning disable IDE0051
        /// <summary>
        /// this function will evaluate the country picker on the lost focus of the controller
        /// </summary>
        private void EvaluateCountryPicker()
        {
            if (PageController.SelectedCountry.CountryCodeISO2.Length >= 2)
                PageController.SelectedCountry = PageController.countries.Where(country => country.CountryCodeISO2 == PageController.SelectedCountry.CountryCodeISO2.Substring(0, 2)).FirstOrDefault();
            else
                PageController.SelectedCountry = PageController.countries.Where(country => country.ID == 0).FirstOrDefault();
        }
        /// <summary>
        /// this function will reset the picker value on the controllers got focus
        /// </summary>
        private void ResetPicker()
        {
            PageController.SelectedCountry = new Country();
        }
        /// <summary>
        /// this function will set the selected Country on Element Click
        /// </summary>
        /// <param name="selectedCountry">received the options country value</param>
        private void SelectElement(Country selectedCountry)
        {
            PageController.SelectedCountry = selectedCountry;
        }
#pragma warning restore IDE0051
        #endregion
        #endregion
    }
}
