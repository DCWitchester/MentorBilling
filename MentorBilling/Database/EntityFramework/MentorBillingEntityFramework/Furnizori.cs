using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class Furnizori
    {
        public Furnizori()
        {
            ConturiBancareFurnizori = new HashSet<ConturiBancareFurnizori>();
            Factura = new HashSet<Factura>();
            UtilizatoriLastUsed = new HashSet<UtilizatoriLastUsed>();
        }

        public long Id { get; set; }
        public string Denumire { get; set; }
        public string NrRegistruComert { get; set; }
        public string CodFiscal { get; set; }
        public double CapitalSocial { get; set; }
        public string Sediul { get; set; }
        public string PunctLucru { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public byte[] Sigla { get; set; }
        public long UtilizatorId { get; set; }
        public bool? Activ { get; set; }

        public virtual Utilizatori Utilizator { get; set; }
        public virtual ICollection<ConturiBancareFurnizori> ConturiBancareFurnizori { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<UtilizatoriLastUsed> UtilizatoriLastUsed { get; set; }
    }
}
