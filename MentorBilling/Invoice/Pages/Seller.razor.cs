using MentorBilling.AuxilliaryComponents.DisplayControllers;
using MentorBilling.ControllerService;
using MentorBilling.Extensions;
using MentorBilling.Invoice.Controllers;
using MentorBilling.Invoice.DisplayControllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Linq;

namespace MentorBilling.Invoice.Pages
{
    public partial class Seller
    {
        /// <summary>
        /// the page controller received as a parameter
        /// </summary>
        [Parameter]
        public SellerController PageController { get; set; }

        /// <summary>
        /// the Instance Controller to grant access to all global elements
        /// </summary>
        [Parameter]
        public InstanceController InstanceController { get; set; }

        /// <summary>
        /// the bank account display controller
        /// </summary>
        readonly BankAccountDisplayController BankAccountDisplayController = new BankAccountDisplayController();

        /// <summary>
        /// the main Display Controller for the seller element
        /// </summary>
        readonly SellerDisplayController SellerDisplayController = new SellerDisplayController();

        /// <summary>
        /// the main form reference bound to the editContext
        /// </summary>
        private EditForm SellerForm { get; set; } = new EditForm();

        /// <summary>
        /// the main validation of the page controller
        /// </summary>
        /// <param name="ControllerState">the state of the controller</param>
        void ValidateLogin(Boolean ControllerState)
        {
            //we force the valid of the bankAccountControllers
            BankAccountDisplayController.RefreshPage();
            if (ControllerState)
            {
                PageController.SetBaseLogoFromController();
            }
            //TODO: Validation Logic For the Seller Control
        }

        /// <summary>
        /// this function will add a new bank account to the list
        /// </summary>
        void AddBankAccount()
        {
            PageController.BankAccountControllers.Add(new AuxilliaryComponents.Controllers.BankAccountController(new ObjectStructures.BankAccount(), PageController.BankAccountControllers.Count()));
            EditContext = new EditContext(PageController);
        }

         

        #region EditContext        
        /// <summary>
        /// the main editContext on the Page
        /// </summary>
        private EditContext EditContext { get; set; }

        /// <summary>
        /// the main initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            PageController.SetControllerFromLogo();
            EditContext = new EditContext(PageController);
            SellerDisplayController.OnChange += OnMyChangeHandler;
            base.OnInitialized();
        }

        /// <summary>
        /// the  main handler for the state change
        /// </summary>
        private async void OnMyChangeHandler()
        {
            AddBankAccount();
            await InvokeAsync(() => StateHasChanged());
        }

        /// <summary>
        /// this function will force the submit on the form
        /// </summary>
        private async void SubmitForm()
        {
            await SellerForm.SubmitAsync();
        }
        #endregion EditContext
    }
}
