using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Invoice.Details
{
    public class InvoiceDetails : Product 
    {
        #region
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the id property for the object
        /// </summary>
        protected new Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the quantity property for the object
        /// </summary>
        protected Double quantity { get; set; } = new Double();
        /// <summary>
        /// the unitary price for the object
        /// </summary>
        protected new Double pricePerUnit { get; set; } = new Double();
        /// <summary>
        /// the discount for the object
        /// </summary>
        protected Double discount { get; set; } = new Double();
#pragma warning restore IDE1006 // Naming Styles
        #endregion
    }
}
