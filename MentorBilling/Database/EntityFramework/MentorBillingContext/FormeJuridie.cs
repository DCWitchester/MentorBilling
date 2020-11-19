using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class FormeJuridie
    {
        public long Id { get; set; }
        public string Cod { get; set; }
        public string Denumire { get; set; }
    }
}
