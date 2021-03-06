﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingEntityFramework
{
    public partial class Factura
    {
        public Factura()
        {
            DateExpeditie = new HashSet<DateExpeditie>();
            FacturaDetalii = new HashSet<FacturaDetalii>();
        }

        public long Id { get; set; }
        public string SerieDocument { get; set; }
        public int NumarDocumet { get; set; }
        public DateTime DataDocument { get; set; }
        public int NumarAviz { get; set; }
        public long UtilizatorId { get; set; }
        public long CreatorId { get; set; }
        public bool TvaIncasare { get; set; }
        public double TotalValoare { get; set; }
        public double TotalTva { get; set; }
        public bool? Activ { get; set; }
        public long FurnizorId { get; set; }
        public long CumparatorId { get; set; }

        public virtual Utilizatori Creator { get; set; }
        public virtual Cumparatori Cumparator { get; set; }
        public virtual Furnizori Furnizor { get; set; }
        public virtual Utilizatori Utilizator { get; set; }
        public virtual ICollection<DateExpeditie> DateExpeditie { get; set; }
        public virtual ICollection<FacturaDetalii> FacturaDetalii { get; set; }
    }
}
