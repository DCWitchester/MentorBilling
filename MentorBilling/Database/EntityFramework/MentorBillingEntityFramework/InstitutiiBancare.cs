using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class InstitutiiBancare
    {
        public long Id { get; set; }
        public string Denumire { get; set; }
        public string CodSwift { get; set; }
        public string CodIban { get; set; }
    }
}
