using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class UtilizatoriPlaje
    {
        public long Id { get; set; }
        public long PlajeDocumentId { get; set; }
        public long UtilizatorId { get; set; }
        public bool? Activ { get; set; }

        public virtual PlajeDocumente PlajeDocument { get; set; }
        public virtual Utilizatori Utilizator { get; set; }
    }
}
