using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class CoteTva
    {
        public CoteTva()
        {
            CoteTvaUtilizatoris = new HashSet<CoteTvaUtilizatori>();
            Produses = new HashSet<Produse>();
        }

        public long Id { get; set; }
        public string Cota { get; set; }
        public decimal Tva { get; set; }
        public string IndiceCasaMarcat { get; set; }
        public string Cod { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<CoteTvaUtilizatori> CoteTvaUtilizatoris { get; set; }
        public virtual ICollection<Produse> Produses { get; set; }
    }
}
