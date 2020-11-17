using MentorBilling.ControllerService;
using MentorBilling.Extensions;
using MentorBilling.Invoice.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace MentorBilling.Invoice.Pages
{
    public partial class InvoiceHeader
    {
        #region Parameter Settings
        /// <summary>
        /// The Page Controller
        /// </summary>
        [Parameter]
        public InvoiceHeaderController PageController { get; set; }

        /// <summary>
        /// the Instance Controller for the program
        /// </summary>
        [Parameter]
        public InstanceController InstanceController { get; set; }
        #endregion

        #region Page Reference Objects
        /// <summary>
        /// the main editContext for the form Display
        /// </summary>
        private EditContext EditContext { get; set; }

        /// <summary>
        /// the main link to the razor form
        /// </summary>
        private EditForm InvoiceHeaderForm { get; set; } = new EditForm();
        #endregion

        #region Edit Context
        /// <summary>
        /// the main initialization of the form
        /// </summary>
        protected override void OnInitialized()
        {
            EditContext = new EditContext(PageController);
            PageController.OnChange += StateHasChanged;
            base.OnInitialized();
        }

        /// <summary>
        /// the submition of the form
        /// </summary>
        private async void SubmitForm()
        {
            await InvoiceHeaderForm.SubmitAsync();
        }
        #endregion

        #region Form Validation
        void ValidateForm(Boolean ControllerState)
        {
            //TODO: The validation for the Invoice Header Form
        }
        #endregion

        #region Functionality
        /// <summary>
        /// this function will change the value on the element click
        /// </summary>
        void ChangeCheckValue()
        {
            PageController.VATatCollection = !PageController.VATatCollection;
        }
        #endregion
    }
}
