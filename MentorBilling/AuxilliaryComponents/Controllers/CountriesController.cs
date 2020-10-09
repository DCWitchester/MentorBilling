using MentorBilling.ObjectStructures.Auxilliary;
using Microsoft.JSInterop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            countries = Database.DatabaseLink.GlossaryFunctions.GetCountries();
        }
    }
}
