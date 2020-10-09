using MentorBilling.ObjectStructures.Auxilliary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            this.counties = Database.DatabaseLink.GlossaryFunctions.GetCounties();
        }
    }
}
