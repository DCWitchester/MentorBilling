﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class PlajeDocumente
    {
        public PlajeDocumente()
        {
            UtilizatoriPlajes = new HashSet<UtilizatoriPlaje>();
        }

        public long Id { get; set; }
        public int ValoareInitiala { get; set; }
        public int ValoareFinala { get; set; }
        public int ValoareCurenta { get; set; }
        public string Serie { get; set; }
        public int TipDocument { get; set; }
        public long CreatorPlaja { get; set; }
        public bool? Activ { get; set; }

        public virtual Utilizatori CreatorPlajaNavigation { get; set; }
        public virtual ICollection<UtilizatoriPlaje> UtilizatoriPlajes { get; set; }
    }
}
