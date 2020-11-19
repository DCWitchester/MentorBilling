using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class Setari
    {
        public Setari()
        {
            SetariUtilizatoris = new HashSet<SetariUtilizatori>();
        }

        public long Id { get; set; }
        public string Setare { get; set; }
        public int TipDateSetare { get; set; }
        public int TipInputSetare { get; set; }
        public string ValoareInitiala { get; set; }
        public string Placeholder { get; set; }
        public string Tooltip { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<SetariUtilizatori> SetariUtilizatoris { get; set; }
    }
}
