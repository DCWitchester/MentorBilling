using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class LogUtilizatori
    {
        public long Id { get; set; }
        public long UtilizatorId { get; set; }
        public string IpLogare { get; set; }
        public DateTime OraLogare { get; set; }
        public bool Logged { get; set; }
        public string DateLogare { get; set; }

        public virtual Utilizatori Utilizator { get; set; }
    }
}
