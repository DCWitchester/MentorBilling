using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class Drepturi
    {
        public Drepturi()
        {
            ClaseDrepturis = new HashSet<ClaseDrepturi>();
            DrepturiUtilizatoris = new HashSet<DrepturiUtilizatori>();
        }

        public long Id { get; set; }
        public string Drept { get; set; }
        public int TipDrept { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<ClaseDrepturi> ClaseDrepturis { get; set; }
        public virtual ICollection<DrepturiUtilizatori> DrepturiUtilizatoris { get; set; }
    }
}
