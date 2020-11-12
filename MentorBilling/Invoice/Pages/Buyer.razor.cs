using MentorBilling.ControllerService;
using MentorBilling.Invoice.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MentorBilling.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Pages
{
    public partial class Buyer
    {
        #region Main Control
        /// <summary>
        /// the page controller received as a parameter
        /// </summary>
        [Parameter]
        public BuyerController PageController { get; set; }

        /// <summary>
        /// the Instance Controller to grant access to all global elements
        /// </summary>
        [Parameter]
        public InstanceController InstanceController { get; set; }

        /// <summary>
        /// the main form reference bound to the editContext
        /// </summary>
        private EditForm BuyerForm { get; set; } = new EditForm();
        #endregion

        String TooltipValue = "L1" + Environment.NewLine + "L2";

        #region Edit Context
        /// <summary>
        /// the main editContext bound to the formDisplay
        /// </summary>
        private EditContext EditContext { get; set; }

        /// <summary>
        /// the main initialization of the form
        /// </summary>
        protected override void OnInitialized()
        {
            PageController.SetControllerValuesFromBase();
            EditContext = new EditContext(PageController);
            base.OnInitialized();
        }

        /// <summary>
        /// this function will force the submit on the form
        /// </summary>
        private async void SubmitForm()
        {
            PageController.SetBaseValuesFromController();
            await BuyerForm.SubmitAsync();
        }
        #endregion

        #region Form Validation
        void ValidateLogin(Boolean ControllerState)
        {
            //TODO: The Validation Login Form the Buyer
        }
        #endregion
    }
}
