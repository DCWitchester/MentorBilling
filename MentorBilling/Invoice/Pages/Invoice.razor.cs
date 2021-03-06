﻿using MentorBilling.ControllerService;
using MentorBilling.Invoice.Controllers;
using Microsoft.AspNetCore.Components;

namespace MentorBilling.Invoice.Pages
{
    public partial class Invoice
    {
        /// <summary>
        /// the instance controller for the program
        /// </summary>
        [Parameter]
        public InstanceController InstanceController { get; set; }

        /// <summary>
        /// the pageController for the invoice
        /// </summary>
        [Parameter]
        public InvoiceController PageController { get; set; }
    }
}
