using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.Miscellaneous.ANAF;
using MentorBilling.ObjectStructures;
using MentorBilling.ObjectStructures.Invoice;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Controllers
{
    public class SellerController : Seller
    {
        /// <summary>
        /// the name bound to the given Seller name TextBox
        /// </summary>
        [Required(ErrorMessage = "Numele firmei trebuie completat")]
        public new String Name 
        { 
            get => base.Name;
            set => base.Name = value; 
        }

        /// <summary>
        /// the commercial registry number bound to a given text box
        /// </summary>
        [Required(ErrorMessage = "Numarul de inregistrare la registrul comertului este obligatoriu")]
        public new String CommercialRegistryNumber 
        { 
            get => base.CommercialRegistryNumber; 
            set => base.CommercialRegistryNumber = value; 
        }

        /// <summary>
        /// the commercial registry number bound to a given text box
        /// </summary>
        [Required(ErrorMessage = "Codul Fiscal(CUI/CIF) este obligatoriu")]
        public new String FiscalCode 
        { 
            get =>  base.FiscalCode; 
            set => RetrieveAnafInfo(value); 
        }

        /// <summary>
        /// the joint stock bound to a given text box
        /// </summary>
        [Range(0, Double.MaxValue, ErrorMessage = "Capitalul Social nu poate fi negativ")]
        public new Double JointStock 
        { 
            get => base.JointStock; 
            set => base.JointStock = value; 
        }

        /// <summary>
        /// the Headquarters bound to a given text box
        /// </summary>
        [Required(ErrorMessage = "Adresa Sediului trebuie completata")]
        public new String Headquarters 
        {
            get => base.Headquarters; 
            set => base.Headquarters = value; 
        }

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
        public new String Website 
        { 
            get => base.Website; 
            set => base.Website = value; 
        }

        /// <summary>
        /// the Phone bound to the given text box
        /// </summary>
        public new String Phone 
        { 
            get => base.Phone; 
            set => base.Phone = value; 
        }

        /// <summary>
        /// the Email bound to the given text box
        /// </summary>
        public new String Email 
        { 
            get => base.Email; 
            set => base.Email = value; 
        }

        /// <summary>
        /// the Work Point bound to given text box
        /// </summary>
        public new String WorkPoint 
        { 
            get => base.WorkPoint; 
            set => base.WorkPoint = value; 
        }
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
            base.FiscalCode = (company.CompanyStatus.VAT_Applicable ? "RO" : "") + company.Cui;
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
            else base.FiscalCode = fiscalCode;
        }
    }
}
