using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class ClaseDrepturi
    {
        public long Id { get; set; }
        public long DreptId { get; set; }
        public long ClasaId { get; set; }
        public string ValoareDrept { get; set; }
        public bool? Activ { get; set; }

        public virtual ClaseDrepturiPredefinite Clasa { get; set; }
        public virtual Drepturi Drept { get; set; }
    }
}
