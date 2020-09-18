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
        public String FiscalCode { get; set; } = String.Empty;

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

        public void DevourCompany(Company company)
        {
            this.Name = company.Name;
            this.FiscalCode = (company.CompanyStatus.VAT_Applicable ? "RO" : "") + company.Cui;
            this.Headquarters = company.Adress;
        }
    }
}
