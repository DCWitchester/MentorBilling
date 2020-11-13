using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.AuxilliaryComponents.DisplayControllers;
using MentorBilling.ControllerService;
using MentorBilling.Miscellaneous.ANAF;
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
            set => RetrieveAnafInfo(value);
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

        /// <summary>
        /// the Secondary Address bound to the given TextBox
        /// </summary>
        public new String DeliveryAddress
        {
            get => base.DeliveryAddress;
            set => base.DeliveryAddress = value;
        }

        /// <summary>
        /// the Email Address bound to the given TextBox
        /// </summary>
        public new String Email
        {
            get => base.Email;
            set => base.Email = value;
        }
        #endregion

        #region Auxilliary Components (with Controllers)
        /// <summary>
        /// the country list used for the display of the Input Select
        /// </summary>
        public CountriesController CountriesController { get; set; } = new CountriesController();

        /// <summary>
        /// the county list used for the display for the Input Select
        /// </summary>
        public CountiesController CountiesController { get; set; } = new CountiesController();

        /// <summary>
        /// the bankAccount Controller linked to the specific controller type
        /// </summary>
        public BankAccountController BankAccountController { get; set; } = new BankAccountController();
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
        [Range(typeof(bool),"false","false", ErrorMessage = "Atentie daca CIF-ul sau CNP-ul nu este completat trebuie completata tara si dupa caz judetul")]
        public Boolean IsCountryNeeded
        {
            get => String.IsNullOrWhiteSpace(FiscalCode) && base.Country.Equals(0);
        }

        /// <summary>
        /// this function will check if the county is needed
        /// </summary>
        [Range(typeof(bool),"false","false",ErrorMessage = "Atentie daca CIF-ul sau CNP-ul nu iar tara completata este Romania judetul trebuie completat")]
        public Boolean IsCountyNeeded
        {
            get => String.IsNullOrWhiteSpace(FiscalCode) && CountriesController.SelectedCountry.IsCountryRomania && base.County.Equals(0);
        }
        #endregion

        #region Functionality
        /// <summary>
        /// this function will return the base component of the controller
        /// </summary>
        /// <returns>the Buyer Component Base</returns>
        public Buyer RetrieveBuyerOfController()
        {
            return base.Value;
        }

        /// <summary>
        /// this function will set the base values from the auxilliary controllers
        /// </summary>
        public void SetBaseValuesFromController()
        {
            SetCountryFromController();
            SetCountyFromController();
        }

        /// <summary>
        /// this function will set the controllers values from base components
        /// </summary>
        public void SetControllerValuesFromBase()
        {
            SetControllerValueFromCountry();
            SetControllerValueFromCounty();
        }
        /// <summary>
        /// this function will be called by the valid on the Fiscal Code TextBox
        /// </summary>
        /// <param name="fiscalCode">the fiscal code entered oin the user side</param>
        public void RetrieveAnafInfo(String fiscalCode)
        {
            if (Miscellaneous.ElementCheck.VerifyCIF(fiscalCode))
            {
                //we get sone info from anaf
                DevourCompany(AnafGet.GetANAFCompany(fiscalCode));
                //and some from our own database
                GetRegistryNumber();
            }
            else base.FiscalCode = fiscalCode;
        }

        #region Auxilliary Functionality
        /// <summary>
        /// this function will set the country from the controller
        /// </summary>
        void SetCountryFromController()
        {
            if (CountriesController.SelectedCountry.ID > 0) Country = CountriesController.SelectedCountry.ID;
        }

        /// <summary>
        /// this function will set the controllers selected country from the base country
        /// </summary>
        void SetControllerValueFromCountry()
        {
            if (Country > 0) CountriesController.SelectedCountry = CountriesController.countries.Where(country => country.ID == Country).FirstOrDefault();
        }

        /// <summary>
        /// this function will set the county from the controller
        /// </summary>
        void SetCountyFromController()
        {
            if (CountiesController.SelectedCounty.ID > 0) County = CountiesController.SelectedCounty.ID;
        }

        /// <summary>
        /// this function will set the controller from the base county 
        /// </summary>
        void SetControllerValueFromCounty()
        {
            if (County > 0) CountiesController.SelectedCounty = CountiesController.counties.Where(county => county.ID == County).FirstOrDefault();
        }

        /// <summary>
        /// this function will retrieve the commercial RegistryNumber of a Firm
        /// </summary>
        void GetRegistryNumber()
        {
            this.CommercialRegistryNumber = Database.DatabaseLink.Auxilliary.JuridicalEntity.GetRegistryNumberForFiscalCode(
                                                Miscellaneous.SpecialConversions.GetIntegerOfFiscalCode(this.FiscalCode)
                                                );
        }

        /// <summary>
        /// this function will consume a given company and set the needed settings
        /// </summary>
        /// <param name="company">the given company</param>
        void DevourCompany(Company company)
        {
            //the only infor that interest us is the company name
            this.Name = company.Name;
            //the fical code with or without RO
            base.FiscalCode = (company.CompanyStatus.VAT_Applicable ? "RO" : "") + company.Cui;
            //and the address
            this.Headquarters = company.Address;
            //and wether the company is active or not
            this.IsCompanyActive = company.CompanyStatus.Inactiv;
        }

        #endregion Auxilliary Functionality

        #endregion

        #region Auxilliary Display Settings
        /// <summary>
        /// this controller will permit the disablement of the page editForm
        /// </summary>
        public Boolean DisableController { get; set; } = false;
        #endregion

        #region Auxilliary Properties
        /// <summary>
        /// this controller will permit the display messagefor active company
        /// </summary>
        public Boolean IsCompanyActive { get; set; } = true;
        #endregion

        #region DisplayControllers
        /// <summary>
        /// the display controller to be linked to the child objects
        /// </summary>
        public CountryCountyDisplayController CountryCountyDisplayController { get; set; } = new CountryCountyDisplayController();
        #endregion
    }
}
