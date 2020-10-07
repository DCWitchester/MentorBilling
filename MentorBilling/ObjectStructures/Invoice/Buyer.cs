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
        private Int64 id { get; set; } = new Int64();

        private String partnerCode { get; set; } = String.Empty;

        private String name { get; set; } = String.Empty;

        private String commercialRegistryNumber { get; set; } = String.Empty;

        private String fiscalCode { get; set; } = String.Empty;

        private String headquarters { get; set; } = String.Empty;

        private Int64 country { get; set; } = new Int64();

        private Int64 county { get; set; } = new Int64();
#pragma warning disable IDE1006
        #endregion

        #region Callers
        public Int64 ID
        { 
            get => id;
            set => id = value;
        }

        public String PartnerCode
        {
            get => partnerCode;
            set => partnerCode = value;
        }

        public String Name
        {
            get => name;
            set => name = value;
        }

        public String CommercialRegistryNumber
        {
            get => commercialRegistryNumber;
            set => commercialRegistryNumber = value;
        }

        public String FiscalCode
        {
            get => fiscalCode;
            set => fiscalCode = value;
        }

        public String Headquarters
        {
            get => headquarters;
            set => headquarters = value;
        }

        public Int64 Country
        {
            get => country;
            set => country = value;
        }

        public Int64 County
        {
            get => county;
            set => county = value;
        }
        #endregion
    }
}
