using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class Judete
    {
        public Judete()
        {
            Cumparatoris = new HashSet<Cumparatori>();
        }

        public long Id { get; set; }
        public string CodJudet { get; set; }
        public string DenJudet { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<Cumparatori> Cumparatoris { get; set; }
    }
}
