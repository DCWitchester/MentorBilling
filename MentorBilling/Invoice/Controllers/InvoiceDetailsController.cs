using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.ObjectStructures.Invoice.Details;
using MentorBilling.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Controllers
{
    public class InvoiceDetailsController : InvoiceDetails
    {
        #region Settings Link
        /// <summary>
        /// the instance settings received from the parent
        /// </summary>
        readonly InstanceSettings instanceSettings;
        #endregion

        #region Contructors
        /// <summary>
        /// the base invoice header controller
        /// </summary>
        public InvoiceDetailsController() { }
        /// <summary>
        /// the base invoice header controller
        /// </summary>
        /// <param name="settings">the instance settings</param>
        public InvoiceDetailsController(InstanceSettings settings)
        {
            instanceSettings = settings;
        }
        #endregion

        #region Primary Properties

        #region Common
        /// <summary>
        /// the caller for the ID property
        /// </summary>
        public new Int64 ID
        {
            get => base.ID;
            set => base.ID = value;
        }
        /// <summary>
        /// the caller for the ProductName property
        /// </summary>
        public new String ProductName
        {
            get => base.ProductName;
            set => base.ProductName = value;
        }
        /// <summary>
        /// the caller for the Products Unit of Measure property
        /// </summary>
        public new String ProductUnitOfMeasure
        {
            get => base.ProductUnitOfMeasure;
            set => base.ProductUnitOfMeasure = value;
        }
        /// <summary>
        /// the caller for the quantity property
        /// </summary>
        public new Double Quantity
        {
            get => base.Quantity;
            set => base.Quantity = value;
        }
        /// <summary>
        /// the caller for the price per unit
        /// </summary>
        public new Double PricePerUnit
        {
            get => base.PricePerUnit == 0  && base.ProductPricePerUnit !=0 ? base.ProductPricePerUnit : base.PricePerUnit; 
            set => base.PricePerUnit = value;
        }
        #endregion

        #region Grid Only Properties
        /// <summary>
        /// TODO once the settings needed are done
        /// </summary>
        public Double TotalValue => ( instanceSettings.VATinPrice ? (this.PricePerUnit) : this.PricePerUnit ) * this.Quantity;
        /// <summary>
        /// TODO once the settings needed are done
        /// </summary>
        public Double TotalVATValue;
        #endregion

        #region Edit Form Properties
        /// <summary>
        /// the caller for the ProductCode property
        /// </summary>
        public new String ProductCode
        {
            get => base.ProductCode;
            set => base.ProductCode = value;
        }
        /// <summary>
        /// the caller for the VATRate property
        /// </summary>
        public new Int64 VATRate
        {
            get => base.ProductVATRate;
            set => base.ProductVATRate = value; 
        }

        /// <summary>
        /// the VAT Rate Controller for the object link
        /// </summary>
        public VATRateController VATRateController { get; set; } = new VATRateController();
        #endregion

        #endregion

        #region Functionality
        /// <summary>
        /// this function will dump all controller values into the apropriate base elements
        /// </summary>
        public void SetBaseValuesFromControllers() 
        {
            SetVATRateFromController();
        }
        /// <summary>
        /// this function will dump all controller values into the apropriate base elements
        /// </summary>
        public void SetControllerValuesFromBaseObjects()
        {
            SetControllerValueFromVAT();
        }
        /// <summary>
        /// this function will set the VAT Rate value from the controller
        /// </summary>
        void SetVATRateFromController()
        {
            VATRate = VATRateController.SelectedVATRate.ID;
        }
        /// <summary>
        /// this function will set the Controller value from the VAT Rate
        /// </summary>
        void SetControllerValueFromVAT()
        {
            VATRateController.SelectedVATRate = VATRateController.VATRates.Find(element => element.ID == VATRate);
        }
        #endregion
    }
}
