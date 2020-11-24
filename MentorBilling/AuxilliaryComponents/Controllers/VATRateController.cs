using MentorBilling.ObjectStructures.Auxilliary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.AuxilliaryComponents.Controllers
{
    public class VATRateController
    {
        /// <summary>
        /// the complete list of VAT Rates
        /// </summary>
        public List<VATRate> VATRates;

        /// <summary>
        /// the selected VAT Rate Object Linked to the interface
        /// </summary>
        public VATRate SelectedVATRate { get; set; } = new VATRate();

        /// <summary>
        /// the instantiation of the VAT Rates will also retrieve the list from the database
        /// </summary>
        public VATRateController()
        {
            using Database.EntityFramework.DatabaseLink.GlossaryFunctions glossaryFunctions = new Database.EntityFramework.DatabaseLink.GlossaryFunctions();
            glossaryFunctions.GetVatRates();

        }
    }
}
