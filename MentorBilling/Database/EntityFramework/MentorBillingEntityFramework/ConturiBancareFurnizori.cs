using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class ConturiBancareFurnizori
    {
        public ConturiBancareFurnizori()
        {
            UtilizatoriLastUsed = new HashSet<UtilizatoriLastUsed>();
        }

        public long Id { get; set; }
        public long FurnizorId { get; set; }
        public string Cont { get; set; }
        public string Banca { get; set; }
        public bool? Activ { get; set; }

        public virtual Furnizori Furnizor { get; set; }
        public virtual ICollection<UtilizatoriLastUsed> UtilizatoriLastUsed { get; set; }
    }
}
