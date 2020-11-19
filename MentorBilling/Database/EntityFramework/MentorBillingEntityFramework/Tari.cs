using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class Tari
    {
        public Tari()
        {
            Cumparatoris = new HashSet<Cumparatori>();
        }

        public long Id { get; set; }
        public string CodTaraIso2 { get; set; }
        public string CodTaraIso3 { get; set; }
        public string CodTaraIsoM49 { get; set; }
        public string DenTaraRo { get; set; }
        public string DenTaraEn { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<Cumparatori> Cumparatoris { get; set; }
    }
}
