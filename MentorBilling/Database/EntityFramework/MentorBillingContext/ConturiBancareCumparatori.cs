using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class ConturiBancareCumparatori
    {
        public long Id { get; set; }
        public long CumparatoriId { get; set; }
        public string Cont { get; set; }
        public string Banca { get; set; }
        public bool? Activ { get; set; }

        public virtual Cumparatori Cumparatori { get; set; }
    }
}
