using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class AbonamenteUtilizatori
    {
        public long Id { get; set; }
        public long UtilizatorId { get; set; }
        public long AbonamentId { get; set; }
        public double ValoareLunara { get; set; }
        public DateTime UltimaPlata { get; set; }
        public int PerioadaActiva { get; set; }
        public int DimensiuneMaximaGrup { get; set; }
        public bool? Activ { get; set; }

        public virtual Abonamente Abonament { get; set; }
        public virtual Utilizatori Utilizator { get; set; }
    }
}
