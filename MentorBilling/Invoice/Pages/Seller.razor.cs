using MentorBilling.AuxilliaryComponents.DisplayControllers;
using MentorBilling.Invoice.Controllers;
using MentorBilling.Invoice.DisplayControllers;
using MentorBilling.Miscellaneous.ANAF;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Pages
{
    public partial class Seller
    {
        /// <summary>
        /// the page controller received as a parameter
        /// </summary>
        [Parameter]
        public SellerController PageController { get; set; } = new SellerController();

        /// <summary>
        /// the bank account display controller
        /// </summary>
        BankAccountDisplayController BankAccountDisplayController = new BankAccountDisplayController();

        /// <summary>
        /// the main Display Controller for the seller element
        /// </summary>
        SellerDisplayController SellerDisplayController = new SellerDisplayController();

        /// <summary>
        /// the main validation of the page controller
        /// </summary>
        /// <param name="ControllerState">the state of the controller</param>
        void ValidateLogin(Boolean ControllerState)
        {
            //we force the valid of the bankAccountControllers
            BankAccountDisplayController.RefreshPage();
        }

        /// <summary>
        /// this function will add a new bank account to the list
        /// </summary>
        void AddBankAccount()
        {
            PageController.BankAccountControllers.Add(new AuxilliaryComponents.Controllers.BankAccountController(new ObjectStructures.BankAccount()));
            EditContext = new EditContext(PageController);
        }

        /// <summary>
        /// this function will get the company info from ANAF
        /// </summary>
        void GetAnafCompany()
        {
            if(Miscellaneous.ElementCheck.VerifyCIF(PageController.FiscalCode))
                PageController.DevourCompany(
                    AnafGet.GetANAFCompany(PageController.FiscalCode)
                    );
        }

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
            SellerDisplayController.OnChange += OnMyChangeHandler;
        }

        /// <summary>
        /// the  main handler for the state change
        /// </summary>
        private async void OnMyChangeHandler()
        {
            AddBankAccount();
            await InvokeAsync(() => StateHasChanged());
        }

    }
}
