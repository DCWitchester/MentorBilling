using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class ClaseDrepturiPredefinite
    {
        public ClaseDrepturiPredefinite()
        {
            ClaseDrepturis = new HashSet<ClaseDrepturi>();
        }

        public long Id { get; set; }
        public string Denumire { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<ClaseDrepturi> ClaseDrepturis { get; set; }
    }
}
