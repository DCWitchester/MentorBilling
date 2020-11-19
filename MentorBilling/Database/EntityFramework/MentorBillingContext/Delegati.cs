using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class Delegati
    {
        public Delegati()
        {
            DateExpedities = new HashSet<DateExpeditie>();
            UtilizatoriLastUseds = new HashSet<UtilizatoriLastUsed>();
        }

        public long Id { get; set; }
        public string Denumire { get; set; }
        public string SerieBuletin { get; set; }
        public string NumarBuletin { get; set; }
        public string EliberatorBuletin { get; set; }
        public string MijlocTransport { get; set; }
        public string NumarMijlocTranspot { get; set; }
        public long UtilizatorId { get; set; }
        public bool? Activ { get; set; }

        public virtual Utilizatori Utilizator { get; set; }
        public virtual ICollection<DateExpeditie> DateExpedities { get; set; }
        public virtual ICollection<UtilizatoriLastUsed> UtilizatoriLastUseds { get; set; }
    }
}
