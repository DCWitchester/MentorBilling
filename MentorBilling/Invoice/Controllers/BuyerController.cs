using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.ObjectStructures.Invoice;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Controllers
{
    public class BuyerController : Buyer
    {
        #region Primary Properties
        /// <summary>
        /// the name bound to the given Buyer name TextBox
        /// </summary>
        [Required(ErrorMessage = "Numele cumparatorului trebuie completat")]
        public new String Name
        {
            get => base.Name;
            set => base.Name = value;
        }

        /// <summary>
        /// the commercial registry number bound to the given TextBox
        /// </summary>
        public new String CommercialRegistryNumber
        {
            get => base.CommercialRegistryNumber;
            set => base.CommercialRegistryNumber = value;
        }

        /// <summary>
        /// the fiscal code bound to the given TextBox
        /// </summary>
        public new String FiscalCode
        {
            get => base.FiscalCode;
            set => base.FiscalCode = value;
        }

        /// <summary>
        /// the company headquarters bound to the given TextBox
        /// </summary>
        public new String Headquarters
        {
            get => base.Headquarters;
            set => base.Headquarters = value;
        }

        /// <summary>
        /// the country id bound to the given Input Select
        /// </summary>
        public new Int64 Country
        {
            get => base.Country;
            set => base.Country = value;
        }

        /// <summary>
        /// the county id bound to the given Input Select
        /// </summary>
        public new Int64 County
        {
            get => base.County;
            set => base.County = value;
        }
        #endregion

        #region Auxilliary Components
        /// <summary>
        /// the country list used for the display of the Input Select
        /// </summary>
        public CountriesController CountriesController { get; set; } = new CountriesController();

        /// <summary>
        /// the county list used for the display for the Input Select
        /// </summary>
        public CountiesController CountiesController { get; set; } = new CountiesController();
        #endregion

        #region Additional Checks
        /// <summary>
        /// this function will check the validity of the fiscal code
        /// </summary>
        [Range(typeof(bool), "true", "true", ErrorMessage = "Codul fiscal introdus nu este valid")]
        public Boolean IsFiscalCodeValid
        {
            get => Miscellaneous.ElementCheck.VerifyCIF(FiscalCode) ||
                Miscellaneous.ElementCheck.VerifyCNP(FiscalCode) ||
                String.IsNullOrWhiteSpace(FiscalCode);
        }

        /// <summary>
        /// this function will check if the country needs 
        /// </summary>
        [Range(typeof(bool),"true","true", ErrorMessage = "Atentie daca CIF-ul sau CNP-ul nu este completat trebuie completata tara si dupa caz judetul")]
        public Boolean IsCountryNeeded
        {
            get => String.IsNullOrWhiteSpace(FiscalCode) && base.Country.Equals(0);
        }

        /// <summary>
        /// this function will check if the county is needed
        /// </summary>
        public Boolean IsCountyNeeded
        {
            get => String.IsNullOrWhiteSpace(FiscalCode) && CountriesController.SelectedCountry.IsCountryRomania && base.County.Equals(0);
        }
        #endregion
    }
}
