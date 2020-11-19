using System;
using System.Collections.Generic;

#nullable disable

namespace MentorBilling.Database.EntityFramework.MentorBillingContext
{
    public partial class UtilizatoriLastUsed
    {
        public long Id { get; set; }
        public long UtilizatorId { get; set; }
        public long FurnizoriLastUsed { get; set; }
        public long ConturiBancareLastUsed { get; set; }
        public long DelegatiLastUsed { get; set; }
        public bool? Activ { get; set; }

        public virtual ConturiBancareFurnizori ConturiBancareLastUsedNavigation { get; set; }
        public virtual Delegati DelegatiLastUsedNavigation { get; set; }
        public virtual Furnizori FurnizoriLastUsedNavigation { get; set; }
        public virtual Utilizatori Utilizator { get; set; }
    }
}
