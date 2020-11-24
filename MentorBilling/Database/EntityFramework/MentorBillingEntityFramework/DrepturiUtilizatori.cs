using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class DrepturiUtilizatori
    {
        public long Id { get; set; }
        public long UtilizatorId { get; set; }
        public long DreptId { get; set; }
        public string ValoareDrept { get; set; }
        public bool? Activ { get; set; }

        public virtual Drepturi Drept { get; set; }
        public virtual Utilizatori Utilizator { get; set; }
    }
}
