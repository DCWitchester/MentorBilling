using MentorBilling.AuxilliaryComponents.DisplayControllers;
using MentorBilling.Invoice.Controllers;
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
        [Parameter]
        public SellerController PageController { get; set; } = new SellerController();


        BankAccountDisplayController BankAccountDisplayController = new BankAccountDisplayController();

        void ValidateLogin(Boolean ControllerState)
        {
            BankAccountDisplayController.RefreshPage();
        }

        void ValidateChildren() 
        {
            BankAccountDisplayController.RefreshPage();
        }
    }
}
