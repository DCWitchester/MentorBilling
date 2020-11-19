using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class LogActiuni
    {
        public long Id { get; set; }
        public string IpActiune { get; set; }
        public DateTime OraActiune { get; set; }
        public string Actiune { get; set; }
        public string Comanda { get; set; }
        public long UtilizatorId { get; set; }

        public virtual Utilizatori Utilizator { get; set; }
    }
}
