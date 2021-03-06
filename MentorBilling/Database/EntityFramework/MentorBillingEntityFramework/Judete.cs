﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class Judete
    {
        public Judete()
        {
            Cumparatori = new HashSet<Cumparatori>();
        }

        public long Id { get; set; }
        public string CodJudet { get; set; }
        public string DenJudet { get; set; }
        public bool? Activ { get; set; }

        public virtual ICollection<Cumparatori> Cumparatori { get; set; }
    }
}
