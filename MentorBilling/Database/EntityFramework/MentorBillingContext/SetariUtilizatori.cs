using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class SetariUtilizatori
    {
        public long Id { get; set; }
        public long UtilizatorId { get; set; }
        public long SetareId { get; set; }
        public string ValoareSetare { get; set; }
        public bool? Activ { get; set; }

        public virtual Setari Setare { get; set; }
        public virtual Utilizatori Utilizator { get; set; }
    }
}
