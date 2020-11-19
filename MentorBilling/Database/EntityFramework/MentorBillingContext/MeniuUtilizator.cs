using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class MeniuUtilizator
    {
        public long Id { get; set; }
        public long UtilizatorId { get; set; }
        public int InregistrareMeniu { get; set; }
        public bool? Activ { get; set; }

        public virtual Utilizatori Utilizator { get; set; }
    }
}
