using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class Produse
    {
        public Produse()
        {
            FacturaDetalii = new HashSet<FacturaDetalii>();
        }

        public long Id { get; set; }
        public string CodProdus { get; set; }
        public string Denumire { get; set; }
        public string UnitateMasura { get; set; }
        public double PretUnitar { get; set; }
        public long CotaTvaId { get; set; }
        public long UtilizatorId { get; set; }
        public bool? Activ { get; set; }

        public virtual CoteTva CotaTva { get; set; }
        public virtual Utilizatori Utilizator { get; set; }
        public virtual ICollection<FacturaDetalii> FacturaDetalii { get; set; }
    }
}
