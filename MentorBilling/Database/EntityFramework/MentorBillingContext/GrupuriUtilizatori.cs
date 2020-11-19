using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class GrupuriUtilizatori
    {
        public long Id { get; set; }
        public long GrupId { get; set; }
        public long UtilizatorId { get; set; }
        public bool? Activ { get; set; }

        public virtual Grupuri Grup { get; set; }
        public virtual Utilizatori Utilizator { get; set; }
    }
}
