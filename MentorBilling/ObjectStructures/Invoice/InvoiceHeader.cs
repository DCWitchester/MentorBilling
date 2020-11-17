using System;

namespace MentorBilling.ObjectStructures.Invoice
{
    public class InvoiceHeader
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the id property
        /// </summary>
        protected Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the document series property
        /// </summary>
        protected String documentSeries { get; set; } = String.Empty;
        /// <summary>
        /// the document number property
        /// </summary>
        protected Int32 documentNumber { get; set; } = new Int32();
        /// <summary>
        /// the document date property
        /// </summary>
        protected DateTime documentDate { get; set; } = DateTime.Now;
        /// <summary>
        /// the delivery notice number property
        /// </summary>
        protected Int32 deliveryNoticeNumber { get; set; } = new Int32();
        /// <summary>
        /// the VAT at collection property
        /// </summary>
        protected Boolean vatAtCollection { get; set; } = new Boolean();
        /// <summary>
        /// the total value of the document property
        /// </summary>
        protected Double totalValue { get; set; } = new Double();
        /// <summary>
        /// the total VAT of the document property
        /// </summary>
        protected Double vatValue { get; set; } = new Double();
        #region Linked Properties
        /// <summary>
        /// the seller id property
        /// </summary>
        protected Int64 sellerID { get; set; } = new Int64();
        /// <summary>
        /// the buyer id property
        /// </summary>
        protected Int64 buyerID { get; set; } = new Int64();
        #endregion
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Callers
        /// <summary>
        /// the main caller for the id property
        /// </summary>
        public Int64 ID
        {
            get => id;
            set => id = value;
        }
        /// <summary>
        /// the main caller for the document series property
        /// </summary>
        public String DocumentSeries
        {
            get => documentSeries;
            set => documentSeries = value;
        }
        /// <summary>
        /// the main caller for the document number property
        /// </summary>
        public Int32 DocumentNumber
        {
            get => documentNumber;
            set => documentNumber = value;
        }
        public DateTime DocumentDate
        {
            get => documentDate;
            set => documentDate = value;
        }
        /// <summary>
        /// the main caller for the delivery notice number property
        /// </summary>
        public Int32 DeliveryNoticeNumber
        {
            get => deliveryNoticeNumber;
            set => deliveryNoticeNumber = value;
        }
        /// <summary>
        /// the main caller for the VAT at Collection property
        /// </summary>
        public Boolean VATatCollection
        {
            get => vatAtCollection; 
            set => vatAtCollection = value;
        }
        /// <summary>
        /// the main caller for the total value property
        /// </summary>
        public Double TotalValue
        {
            get => totalValue; 
            set => totalValue = value;
        }
        /// <summary>
        /// the main caller for the VAT Value property
        /// </summary>
        public Double VATValue
        {
            get => vatValue; 
            set => vatValue = value;
        }
        #region Linked Properties
        /// <summary>
        /// the main caller for the seller ID property
        /// </summary>
        public Int64 SellerID
        {
            get => sellerID; 
            set => sellerID = value;
        }
        /// <summary>
        /// the main caller for the buyer ID property
        /// </summary>
        public Int64 BuyerID
        {
            get => buyerID; 
            set => buyerID = value;
        }
        /// <summary>
        /// the main caller for the full value of the InvoiceHeader
        /// </summary>
        public InvoiceHeader Value
        {
            get => this;
        }
        #endregion
        #endregion
    }
}
