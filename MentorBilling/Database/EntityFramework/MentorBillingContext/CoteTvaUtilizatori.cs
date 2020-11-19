using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class CoteTvaUtilizatori
    {
        public long Id { get; set; }
        public string IndiceCasaMarcat { get; set; }
        public long UtilizatorId { get; set; }
        public long CotaTvaId { get; set; }
        public bool? Activ { get; set; }

        public virtual CoteTva CotaTva { get; set; }
        public virtual Utilizatori Utilizator { get; set; }
    }
}
