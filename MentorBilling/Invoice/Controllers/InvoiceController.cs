using MentorBilling.Invoice.DisplayControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Controllers
{
    public class InvoiceController
    {
        /// <summary>
        /// the Seller Controller for the Object
        /// </summary>
        public SellerController SellerController { get; set; } = new SellerController();

        /// <summary>
        /// the Buyer Controller for the Object
        /// </summary>
        public BuyerController BuyerController { get; set; } = new BuyerController();

    }
}
