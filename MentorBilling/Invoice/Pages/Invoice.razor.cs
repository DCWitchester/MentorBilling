using MentorBilling.ControllerService;
using MentorBilling.Invoice.Controllers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Pages
{
    public partial class Invoice
    {
        /// <summary>
        /// the instance controller for the program
        /// </summary>
        [Parameter]
        public InstanceController InstanceController { get; set; } = new InstanceController();

        /// <summary>
        /// the pageController for the invoice
        /// </summary>
        [Parameter]
        public InvoiceController PageController { get; set; } = new InvoiceController();
    }
}
