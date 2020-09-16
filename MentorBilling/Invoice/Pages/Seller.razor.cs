using MentorBilling.Invoice.Controllers;
using Microsoft.AspNetCore.Components;
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
    }
}
