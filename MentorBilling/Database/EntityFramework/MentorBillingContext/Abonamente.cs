using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class Abonamente
    {
        public Abonamente()
        {
            AbonamenteUtilizatoris = new HashSet<AbonamenteUtilizatori>();
        }

        public long Id { get; set; }
        public string Denumire { get; set; }
        public double ValoareLunara { get; set; }
        public string Explicatii { get; set; }
        public int PerioadaPlata { get; set; }
        public int DimensiuneMaximaGrup { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<AbonamenteUtilizatori> AbonamenteUtilizatoris { get; set; }
    }
}
