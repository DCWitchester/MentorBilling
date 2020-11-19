using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class ConturiBancareFurnizori
    {
        public ConturiBancareFurnizori()
        {
            UtilizatoriLastUseds = new HashSet<UtilizatoriLastUsed>();
        }

        public long Id { get; set; }
        public long FurnizorId { get; set; }
        public string Cont { get; set; }
        public string Banca { get; set; }
        public bool? Activ { get; set; }

        public virtual Furnizori Furnizor { get; set; }
        public virtual ICollection<UtilizatoriLastUsed> UtilizatoriLastUseds { get; set; }
    }
}
