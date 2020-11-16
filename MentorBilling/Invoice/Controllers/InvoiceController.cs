using MentorBilling.Invoice.DisplayControllers;
using MentorBilling.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Controllers
{
    public class InvoiceController
    {
        #region Settings Link
        public InstanceSettings instanceSettings;
        #endregion

        #region Controllers
        /// <summary>
        /// the Seller Controller for the Invoice
        /// </summary>
        public SellerController SellerController { get; set; } = new SellerController();

        /// <summary>
        /// the Buyer Controller for the Invoice
        /// </summary>
        public BuyerController BuyerController { get; set; } = new BuyerController();

        /// <summary>
        /// the Invoice Header Controller for the Invoice
        /// </summary>
        public InvoiceHeaderController InvoiceHeaderController { get; set; }
        #endregion

        #region Functionality
        /// <summary>
        /// this function will override the needed controllers with their parametrized versions
        /// </summary>
        void InitializeControllers()
        {
            InvoiceHeaderController = new InvoiceHeaderController(instanceSettings);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// the main constructor for the invoice controller
        /// </summary>
        public InvoiceController() 
        {
            InitializeControllers();
        }

        /// <summary>
        /// the main constructor for the invoice controller that receives the settings from the parent
        /// </summary>
        /// <param name="settings">the main settings</param>
        public InvoiceController(InstanceSettings settings)
        {
            instanceSettings = settings;
        }
        #endregion
    }
}
