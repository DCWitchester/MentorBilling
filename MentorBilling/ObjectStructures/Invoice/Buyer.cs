using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Invoice
{
    public class Buyer
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the id property
        /// </summary>
        private Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the partnerCode property
        /// </summary>
        private String partnerCode { get; set; } = String.Empty;
        /// <summary>
        /// the name property
        /// </summary>
        private String name { get; set; } = String.Empty;
        /// <summary>
        /// the commercial registry number property
        /// </summary>
        private String commercialRegistryNumber { get; set; } = String.Empty;
        /// <summary>
        /// the fiscal code property
        /// </summary>
        private String fiscalCode { get; set; } = String.Empty;
        /// <summary>
        /// the headquarters property
        /// </summary>
        private String headquarters { get; set; } = String.Empty;
        /// <summary>
        /// the country ID property
        /// </summary>
        private Int64 country { get; set; } = new Int64();
        /// <summary>
        /// the county ID property
        /// </summary>
        private Int64 county { get; set; } = new Int64();
#pragma warning disable IDE1006
        #endregion

        #region Callers
        /// <summary>
        /// the main caller for the ID property
        /// </summary>
        public Int64 ID
        { 
            get => id;
            set => id = value;
        }
        /// <summary>
        /// the main caller for the partner code property
        /// </summary>
        public String PartnerCode
        {
            get => partnerCode;
            set => partnerCode = value;
        }

        /// <summary>
        /// the main caller for the name property
        /// </summary>
        public String Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// the main caller for the commercial registry number property
        /// </summary>
        public String CommercialRegistryNumber
        {
            get => commercialRegistryNumber;
            set => commercialRegistryNumber = value;
        }

        /// <summary>
        /// the main caller for the fiscal code property 
        /// </summary>
        public String FiscalCode
        {
            get => fiscalCode;
            set => fiscalCode = value;
        }

        /// <summary>
        /// the main caller for the headquarters property
        /// </summary>
        public String Headquarters
        {
            get => headquarters;
            set => headquarters = value;
        }

        /// <summary>
        /// the main caller for the country
        /// </summary>
        public Int64 Country
        {
            get => country;
            set => country = value;
        }

        /// <summary>
        /// the main caller for the county
        /// </summary>
        public Int64 County
        {
            get => county;
            set => county = value;
        }
        #endregion
    }
}
