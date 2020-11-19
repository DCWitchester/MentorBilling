using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Invoice
{
    public class Product
    {
#pragma warning disable IDE1006 // Naming Styles
        protected Int64 id { get; set; } = new Int64();
        protected String productCode { get; set; } = String.Empty;
        protected String productName { get; set; } = String.Empty;
        protected String unitOfMeasure { get; set; } = String.Empty;
        protected Double pricePerUnit { get; set; } = new Double();
#pragma warning restore IDE1006 // Naming Styles

    }
}