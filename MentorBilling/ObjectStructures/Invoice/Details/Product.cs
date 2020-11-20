using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Invoice.Details
{
    public class Product
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the id property for the object
        /// </summary>
        protected Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the code property for the object
        /// </summary>
        protected String productCode { get; set; } = String.Empty;
        /// <summary>
        /// the name property for the object
        /// </summary>
        protected String name { get; set; } = String.Empty;
        /// <summary>
        /// the measurement unit for the object
        /// </summary>
        protected String unitOfMeasure { get; set; } = String.Empty;
        /// <summary>
        /// the price of an individual 
        /// </summary>
        protected Double pricePerUnit { get; set; } = new Double();
        /// <summary>
        /// the vat link for the object
        /// </summary>
        protected Int64 vatRate { get; set; } = new Int64();
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Callers
        /// <summary>
        /// the caller for the id property
        /// </summary>
        public Int64 ID 
        { 
            get => id; 
            set => id = value; 
        }
        /// <summary>
        /// the caller for the product Code property
        /// </summary>
        public String ProductCode
        {
            get => productCode;
            set => productCode = value;
        }
        /// <summary>
        /// the caller for the name property
        /// </summary>
        public String Name
        {
            get => name;
            set => name = value;
        }
        /// <summary>
        /// the caller for the unit of measure property
        /// </summary>
        public String UnitOfMeasure
        {
            get => unitOfMeasure;
            set => unitOfMeasure = value;
        }
        /// <summary>
        /// the caller for the price per unit property
        /// </summary>
        public Double PricePerUnit
        {
            get => pricePerUnit;
            set => pricePerUnit = value;
        }
        /// <summary>
        /// the caller for the vat rate property
        /// </summary>
        public Int64 VATRate
        {
            get => vatRate; 
            set => vatRate = value;
        }
        #endregion
    }
}
