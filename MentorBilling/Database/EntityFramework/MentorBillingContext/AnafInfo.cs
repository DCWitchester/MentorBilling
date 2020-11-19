using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class AnafInfo
    {
        public long Id { get; set; }
        public DateTime MomentInitial { get; set; }
        public DateTime? MomentFinal { get; set; }
        public string CodFiscal { get; set; }
        public string InfoFile { get; set; }
    }
}
