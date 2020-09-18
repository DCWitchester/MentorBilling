using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Miscellaneous.ANAF
{
    /// <summary>
    /// this will contain all status items for a company
    /// </summary>
    public class CompanyStatus
    {
        public Boolean VAT_Applicable   { get; set; }
        public Boolean VAT_Buyout       { get; set; }
        public Boolean VAT_Split        { get; set; }
        public Boolean Inactiv          { get; set; }
    }
}
