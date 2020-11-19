using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class Utilizatori
    {
        public Utilizatori()
        {
            AbonamenteUtilizatoris = new HashSet<AbonamenteUtilizatori>();
            CoteTvaUtilizatoris = new HashSet<CoteTvaUtilizatori>();
            Cumparatoris = new HashSet<Cumparatori>();
            Delegatis = new HashSet<Delegati>();
            DrepturiUtilizatoris = new HashSet<DrepturiUtilizatori>();
            FacturaCreators = new HashSet<Factura>();
            FacturaUtilizators = new HashSet<Factura>();
            Furnizoris = new HashSet<Furnizori>();
            GrupuriUtilizatoris = new HashSet<GrupuriUtilizatori>();
            Grupuris = new HashSet<Grupuri>();
            LogActiunis = new HashSet<LogActiuni>();
            LogUtilizatoris = new HashSet<LogUtilizatori>();
            MeniuUtilizators = new HashSet<MeniuUtilizator>();
            PlajeDocumentes = new HashSet<PlajeDocumente>();
            Produses = new HashSet<Produse>();
            SetariUtilizatoris = new HashSet<SetariUtilizatori>();
            UtilizatoriLastUseds = new HashSet<UtilizatoriLastUsed>();
            UtilizatoriPlajes = new HashSet<UtilizatoriPlaje>();
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

        public virtual ICollection<AbonamenteUtilizatori> AbonamenteUtilizatoris { get; set; }
        public virtual ICollection<CoteTvaUtilizatori> CoteTvaUtilizatoris { get; set; }
        public virtual ICollection<Cumparatori> Cumparatoris { get; set; }
        public virtual ICollection<Delegati> Delegatis { get; set; }
        public virtual ICollection<DrepturiUtilizatori> DrepturiUtilizatoris { get; set; }
        public virtual ICollection<Factura> FacturaCreators { get; set; }
        public virtual ICollection<Factura> FacturaUtilizators { get; set; }
        public virtual ICollection<Furnizori> Furnizoris { get; set; }
        public virtual ICollection<GrupuriUtilizatori> GrupuriUtilizatoris { get; set; }
        public virtual ICollection<Grupuri> Grupuris { get; set; }
        public virtual ICollection<LogActiuni> LogActiunis { get; set; }
        public virtual ICollection<LogUtilizatori> LogUtilizatoris { get; set; }
        public virtual ICollection<MeniuUtilizator> MeniuUtilizators { get; set; }
        public virtual ICollection<PlajeDocumente> PlajeDocumentes { get; set; }
        public virtual ICollection<Produse> Produses { get; set; }
        public virtual ICollection<SetariUtilizatori> SetariUtilizatoris { get; set; }
        public virtual ICollection<UtilizatoriLastUsed> UtilizatoriLastUseds { get; set; }
        public virtual ICollection<UtilizatoriPlaje> UtilizatoriPlajes { get; set; }
    }
}
