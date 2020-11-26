using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Invoice.Details
{
    public class InvoiceDetails : Product 
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the id property for the object
        /// </summary>
        protected new Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the quantity property for the object
        /// </summary>
        protected Double quantity { get; set; } = new Double();
        /// <summary>
        /// the unitary price for the object
        /// </summary>
        protected new Double pricePerUnit { get; set; } = new Double();
        /// <summary>
        /// the discount for the object
        /// </summary>
        protected Double discount { get; set; } = new Double();
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Callers 
        #region This
        /// <summary>
        /// the caller for the ID property
        /// </summary>
        public new Int64 ID 
        { 
            get => id ; 
            set => id = value; 
        }
        /// <summary>
        /// the caller for the quantity proeperty
        /// </summary>
        public Double Quantity 
        { 
            get => quantity;
            set => quantity = value;
        }
        /// <summary>
        /// the caller for the unitary price property
        /// </summary>
        public new Double PricePerUnit
        {
            get => pricePerUnit;
            set => pricePerUnit = value;
        }
        /// <summary>
        /// the caller for the discount property
        /// </summary>
        public Double Discount
        {
            get => discount;
            set => discount = value;
        }
        #endregion
        #region Base
        /// <summary>
        /// the caller for the products id property
        /// </summary>
        public Int64 ProductID
        {
            get => base.id;
            set => base.id = value;
        }
        /// <summary>
        /// the caller for the products product code property 
        /// </summary>
        public new String ProductCode
        {
            get => base.productCode;
            set => base.productCode = value;
        }
        /// <summary>
        /// the caller for the products name property
        /// </summary>
        public String ProductName
        {
            get => base.name;
            set => base.name = value;
        }
        /// <summary>
        /// the caller for the products measure unit property
        /// </summary>
        public String ProductUnitOfMeasure
        {
            get => base.unitOfMeasure;
            set => base.unitOfMeasure = value;
        }
        /// <summary>
        /// the caller for the products price per unit property
        /// </summary>
        public Double ProductPricePerUnit
        {
            get => base.pricePerUnit;
            set => base.pricePerUnit = value;
        }
        /// <summary>
        /// the caller for the products VAT Rate property
        /// </summary>
        public Int64 ProductVATRate
        {
            get => base.vatRate;
            set => base.vatRate = value;
        }
        /// <summary>
        /// the caller for the base value of the object
        /// </summary>
        public Product ProductValue
        {
            get => base.Value;
        }
        /// <summary>
        /// the caller for the value of this object
        /// </summary>
        public new InvoiceDetails Value
        {
            get => this;
        }
        #endregion
        #endregion

    }
}
