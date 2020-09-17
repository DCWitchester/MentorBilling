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

namespace MentorBilling.AuxilliaryComponents.Pages
{
    public partial class BankAccount
    {
        [Parameter]
        public BankAccountController PageController { get; set; }

        [Parameter]
        public BankAccountDisplayController BankAccountDisplayController { get; set; }

        private EditForm myForm { get; set; }
        //public EditForm myForm { get; set; }
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
            SubmitHandler();
            await InvokeAsync(() => StateHasChanged());
        }

        private EditContext EditContext { get; set; }

        private async void SubmitHandler()
        {
            await myForm.SubmitAsync();
            //await JSRuntime.InvokeVoidAsync("SubmitForm", "BankForm");
            String s = "";
        }

        
    }
}
