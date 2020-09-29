using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.Miscellaneous.ANAF;
using MentorBilling.ObjectStructures;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Controllers
{
    public class SellerController
    {

        /// <summary>
        /// the private fiscal code property
        /// </summary>
#pragma warning disable IDE1006 // Naming Styles
        private String fiscalCode { get; set; } = String.Empty;
#pragma warning restore IDE1006 // Naming Styles
        /// <summary>
        /// the name bound to the given Seller name TextBox
        /// </summary>
        [Required(ErrorMessage = "Numele firmei trebuie completat")]
        public String Name { get; set; } = String.Empty;

        /// <summary>
        /// the commercial registry number bound to a given text box
        /// </summary>
        [Required(ErrorMessage = "Numarul de inregistrare la registrul comertului este obligatoriu")]
        public String CommercialRegistryNumber { get; set; } = String.Empty;

        /// <summary>
        /// the commercial registry number bound to a given text box
        /// </summary>
        [Required(ErrorMessage = "Codul Fiscal(CUI/CIF) este obligatoriu")]
        public String FiscalCode 
        { 
            get =>  fiscalCode; 
            set => RetrieveAnafInfo(value); 
        }

        /// <summary>
        /// the joint stock bound to a given text box
        /// </summary>
        [Range(0, Double.MaxValue, ErrorMessage = "Capitalul Social nu poate fi negativ")]
        public Double JointStock { get; set; } = new Double();

        /// <summary>
        /// the Headquarters bound to a given text box
        /// </summary>
        [Required(ErrorMessage = "Adresa Sediului trebuie completata")]
        public String Headquarters { get; set; } = String.Empty;

        /// <summary>
        /// the BankAccounts List will have at least 1 element
        /// </summary>
        public List<BankAccountController> BankAccountControllers { get; set; } = new List<BankAccountController>() { new BankAccountController(new BankAccount()) };

        /// <summary>
        /// the LogoController will be bound to the Logo Component on the seller
        /// </summary>
        public LogoController LogoController { get; set; } = new LogoController();

        #region Additional Info
        /// <summary>
        /// the Website bound to the given text box
        /// </summary>
        public String Website { get; set; } = String.Empty;

        /// <summary>
        /// the Phone bound to the given text box
        /// </summary>
        public String Phone { get; set; } = String.Empty;

        /// <summary>
        /// the Email bound to the given text box
        /// </summary>
        public String Email { get; set; } = String.Empty;

        /// <summary>
        /// the Work Point bound to given text box
        /// </summary>
        public String WorkPoint { get; set; } = String.Empty;
        #endregion

        /// <summary>
        /// this controller will permit the disablement of the page editForm
        /// </summary>
        public Boolean DisableController { get; set; } = false;

        /// <summary>
        /// this funtion will devour a company returned from ANAF
        /// </summary>
        /// <param name="company">the company returned from the webservice</param>
        void DevourCompany(Company company)
        {
            //the only info that interests us is the company name
            this.Name = company.Name;
            //the FiscalCode with or without RO
            this.fiscalCode = (company.CompanyStatus.VAT_Applicable ? "RO" : "") + company.Cui;
            //and the headquarters
            this.Headquarters = company.Adress;
        }

        /// <summary>
        /// this function will be called by the valid on the Anaf
        /// </summary>
        /// <param name="fiscalCode">the fiscal code entered on the user side</param>
        public void RetrieveAnafInfo(String fiscalCode)
        {
            if (Miscellaneous.ElementCheck.VerifyCIF(fiscalCode))
                DevourCompany(
                    AnafGet.GetANAFCompany(fiscalCode)
                    );
            else this.fiscalCode = fiscalCode;
        }
    }
}
