using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class CoteTva
    {
        public CoteTva()
        {
            CoteTvaUtilizatori = new HashSet<CoteTvaUtilizatori>();
            Produse = new HashSet<Produse>();
        }

        public long Id { get; set; }
        public string Cota { get; set; }
        public decimal Tva { get; set; }
        public string IndiceCasaMarcat { get; set; }
        public string Cod { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<CoteTvaUtilizatori> CoteTvaUtilizatori { get; set; }
        public virtual ICollection<Produse> Produse { get; set; }
    }
}
