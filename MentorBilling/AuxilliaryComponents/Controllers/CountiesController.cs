using MentorBilling.ObjectStructures.Auxilliary;
using System.Collections.Generic;

namespace MentorBilling.AuxilliaryComponents.Controllers
{
    public class CountiesController
    {
        /// <summary>
        /// the complete counties list
        /// </summary>
        public List<County> counties;

        /// <summary>
        /// the selected County object linked to the interface
        /// </summary>
        public County SelectedCounty { get; set; } = new County();

        /// <summary>
        /// the initialization of the counties will also retrieve the list from the database
        /// </summary>
        public CountiesController()
        {
            using Database.EntityFramework.DatabaseLink.GlossaryFunctions glossaryFunctions = new Database.EntityFramework.DatabaseLink.GlossaryFunctions();
            this.counties = glossaryFunctions.GetCounties();
        }
    }
}
