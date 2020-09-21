using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.AuxilliaryComponents.DisplayControllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MentorBilling.Extensions;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorBilling.Invoice.Controllers;
using MentorBilling.Invoice.DisplayControllers;

namespace MentorBilling.AuxilliaryComponents.Pages
{
    public partial class BankAccount
    {
        /// <summary>
        /// the main Page Controller
        /// </summary>
        [Parameter]
        public BankAccountController PageController { get; set; }

        /// <summary>
        /// the Main Display Controller for the given page <= used for a page refresh
        /// </summary>
        [Parameter]
        public BankAccountDisplayController BankAccountDisplayController { get; set; }

        /// <summary>
        /// the Main Seller Display controller that will link the page to the parent
        /// </summary>
        [Parameter]
        public SellerDisplayController SellerDisplayController { get; set; }

        [Parameter]
        public Boolean LastItem { get; set; } = false;

        /// <summary>
        /// the edit form reference used for page refresh
        /// </summary>
        private EditForm MyForm { get; set; }

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
            //we add the Change Handler
            BankAccountDisplayController.OnChange += OnMyChangeHandler;
            base.OnInitialized();
        }

        /// <summary>
        /// the dispose of the page
        /// </summary>
        public void Dispose()
        {
            BankAccountDisplayController.OnChange -= OnMyChangeHandler;
        }

        /// <summary>
        /// the  main handler for the state change
        /// </summary>
        private async void OnMyChangeHandler()
        {
            //we force the submision 
            await MyForm.SubmitAsync();
        }

        private void GetBankOfAccount(ChangeEventArgs e)
        {
            String s = "";
            Database.DatabaseLink.GlossaryFunctions.GetBankOfAccount(PageController);
        }
    }
}
