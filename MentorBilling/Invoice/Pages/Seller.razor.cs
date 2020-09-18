using MentorBilling.AuxilliaryComponents.DisplayControllers;
using MentorBilling.Invoice.Controllers;
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

        void ValidateLogin(Boolean ControllerState)
        {
            BankAccountDisplayController.RefreshPage();
        }

        void AddBankAccount()
        {
            PageController.BankAccountControllers.Add(new AuxilliaryComponents.Controllers.BankAccountController(new ObjectStructures.BankAccount()));
            EditContext = new EditContext(PageController);
        }

        void GetAnafCompany()
        {
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
        }

    }
}
