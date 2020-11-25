using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.ControllerService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.AuxilliaryComponents.Pages
{
    public partial class VATRatePicker
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
        public VATRateController PageController { get; set; }
        /// <summary>
        /// the display will dictate the existance of the label object
        /// </summary>
        [Parameter]
        public Boolean DisplayLabel { get; set; } = false;
        #endregion

        #region Form Binding
        /// <summary>
        /// the edit context bound to the page
        /// </summary>
        private EditContext EditContext { get; set; }

        protected override void OnInitialized()
        {
            EditContext = new EditContext(PageController);
            base.OnInitialized();
        }
        #endregion

        #region Functionality
        private void SelectElement(String selectedVATRate)
        {
            if (selectedVATRate.Trim().Length >= 2)
                PageController.SelectedVATRate = PageController.VATRates.Where(vatRate => selectedVATRate.Contains(vatRate.DisplayCode)).FirstOrDefault();
            else
            {
                //TODO once default VAT setting has been made
            }
                
        }
        #endregion
    }
}
