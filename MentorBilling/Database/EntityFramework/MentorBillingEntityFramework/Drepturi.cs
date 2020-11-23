using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class Drepturi
    {
        public Drepturi()
        {
            ClaseDrepturi = new HashSet<ClaseDrepturi>();
            DrepturiUtilizatori = new HashSet<DrepturiUtilizatori>();
        }

        public long Id { get; set; }
        public string Drept { get; set; }
        public int TipDrept { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<ClaseDrepturi> ClaseDrepturi { get; set; }
        public virtual ICollection<DrepturiUtilizatori> DrepturiUtilizatori { get; set; }
    }
}
