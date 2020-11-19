using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class FacturaDetalii
    {
        public long Id { get; set; }
        public long ProdusId { get; set; }
        public long FacturaId { get; set; }
        public double Cantitate { get; set; }
        public double PretUnitar { get; set; }
        public double Discount { get; set; }
        public bool? Activ { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Produse Produs { get; set; }
    }
}
