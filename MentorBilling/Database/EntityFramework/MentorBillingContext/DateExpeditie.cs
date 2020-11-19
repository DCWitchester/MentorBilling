using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class DateExpeditie
    {
        public long Id { get; set; }
        public long FacturaId { get; set; }
        public long DelegatId { get; set; }
        public DateTime DataExpediere { get; set; }
        public bool? Activ { get; set; }

        public virtual Delegati Delegat { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
