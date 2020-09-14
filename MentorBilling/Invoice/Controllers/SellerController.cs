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

        
    }
}
