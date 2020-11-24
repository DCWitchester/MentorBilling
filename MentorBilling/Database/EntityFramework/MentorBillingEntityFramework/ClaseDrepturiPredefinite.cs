using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class ClaseDrepturiPredefinite
    {
        public ClaseDrepturiPredefinite()
        {
            ClaseDrepturi = new HashSet<ClaseDrepturi>();
        }

        public long Id { get; set; }
        public string Denumire { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<ClaseDrepturi> ClaseDrepturi { get; set; }
    }
}
