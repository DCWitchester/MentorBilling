using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class Utilizatori
    {
        public Utilizatori()
        {
            AbonamenteUtilizatori = new HashSet<AbonamenteUtilizatori>();
            CoteTvaUtilizatori = new HashSet<CoteTvaUtilizatori>();
            Cumparatori = new HashSet<Cumparatori>();
            Delegati = new HashSet<Delegati>();
            DrepturiUtilizatori = new HashSet<DrepturiUtilizatori>();
            FacturaCreator = new HashSet<Factura>();
            FacturaUtilizator = new HashSet<Factura>();
            Furnizori = new HashSet<Furnizori>();
            GrupuriUtilizatori = new HashSet<GrupuriUtilizatori>();
            Grupuri = new HashSet<Grupuri>();
            LogActiuni = new HashSet<LogActiuni>();
            LogUtilizatori = new HashSet<LogUtilizatori>();
            MeniuUtilizator = new HashSet<MeniuUtilizator>();
            PlajeDocumente = new HashSet<PlajeDocumente>();
            Produse = new HashSet<Produse>();
            SetariUtilizatori = new HashSet<SetariUtilizatori>();
            UtilizatoriLastUsed = new HashSet<UtilizatoriLastUsed>();
            UtilizatoriPlaje = new HashSet<UtilizatoriPlaje>();
        }

        public long Id { get; set; }
        public string NumeUtilizator { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string ParolaAutogenerata { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public bool Sysadmin { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<AbonamenteUtilizatori> AbonamenteUtilizatori { get; set; }
        public virtual ICollection<CoteTvaUtilizatori> CoteTvaUtilizatori { get; set; }
        public virtual ICollection<Cumparatori> Cumparatori { get; set; }
        public virtual ICollection<Delegati> Delegati { get; set; }
        public virtual ICollection<DrepturiUtilizatori> DrepturiUtilizatori { get; set; }
        public virtual ICollection<Factura> FacturaCreator { get; set; }
        public virtual ICollection<Factura> FacturaUtilizator { get; set; }
        public virtual ICollection<Furnizori> Furnizori { get; set; }
        public virtual ICollection<GrupuriUtilizatori> GrupuriUtilizatori { get; set; }
        public virtual ICollection<Grupuri> Grupuri { get; set; }
        public virtual ICollection<LogActiuni> LogActiuni { get; set; }
        public virtual ICollection<LogUtilizatori> LogUtilizatori { get; set; }
        public virtual ICollection<MeniuUtilizator> MeniuUtilizator { get; set; }
        public virtual ICollection<PlajeDocumente> PlajeDocumente { get; set; }
        public virtual ICollection<Produse> Produse { get; set; }
        public virtual ICollection<SetariUtilizatori> SetariUtilizatori { get; set; }
        public virtual ICollection<UtilizatoriLastUsed> UtilizatoriLastUsed { get; set; }
        public virtual ICollection<UtilizatoriPlaje> UtilizatoriPlaje { get; set; }
    }
}
