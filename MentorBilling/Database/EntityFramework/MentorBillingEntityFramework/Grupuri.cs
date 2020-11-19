using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class Grupuri
    {
        public Grupuri()
        {
            GrupuriUtilizatoris = new HashSet<GrupuriUtilizatori>();
        }

        public long Id { get; set; }
        public string Denumire { get; set; }
        public long AdministratorGrup { get; set; }
        public bool? Activ { get; set; }

        public virtual Utilizatori AdministratorGrupNavigation { get; set; }
        public virtual ICollection<GrupuriUtilizatori> GrupuriUtilizatoris { get; set; }
    }
}
