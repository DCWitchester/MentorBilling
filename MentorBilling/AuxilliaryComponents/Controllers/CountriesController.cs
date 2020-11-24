using MentorBilling.ObjectStructures.Auxilliary;
using System.Collections.Generic;

namespace MentorBilling.AuxilliaryComponents.Controllers
{
    public class CountriesController
    {
        /// <summary>
        /// the countries list to be bound to 
        /// </summary>
        public List<Country> countries;

        /// <summary>
        /// the selected Country object linked to the interface
        /// </summary>
        public Country SelectedCountry { get; set; } = new Country();

        /// <summary>
        /// the initialization of the countries will also retrieve the list from the database
        /// </summary>
        public CountriesController() 
        {
            using Database.EntityFramework.DatabaseLink.GlossaryFunctions glossaryFunctions = new Database.EntityFramework.DatabaseLink.GlossaryFunctions();
            countries = glossaryFunctions.GetCountries();
        }
    }
}
