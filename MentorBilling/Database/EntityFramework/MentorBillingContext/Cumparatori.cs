using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class Cumparatori
    {
        public Cumparatori()
        {
            ConturiBancareCumparatoris = new HashSet<ConturiBancareCumparatori>();
            Facturas = new HashSet<Factura>();
        }

        public long Id { get; set; }
        public string CodPartener { get; set; }
        public string Denumire { get; set; }
        public string NrRegistruComert { get; set; }
        public string CodFiscal { get; set; }
        public string Sediul { get; set; }
        public long Tara { get; set; }
        public long Judetul { get; set; }
        public long UtilizatorId { get; set; }
        public bool? Activ { get; set; }
        public string AdresaLivrare { get; set; }
        public string Email { get; set; }

        public virtual Judete JudetulNavigation { get; set; }
        public virtual Tari TaraNavigation { get; set; }
        public virtual Utilizatori Utilizator { get; set; }
        public virtual ICollection<ConturiBancareCumparatori> ConturiBancareCumparatoris { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
