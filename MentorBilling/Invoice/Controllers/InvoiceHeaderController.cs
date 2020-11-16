using MentorBilling.ObjectStructures.Invoice;
using static MentorBilling.Extensions.FunctionalityExtensions;
using System.ComponentModel.DataAnnotations;
using System;
using MentorBilling.Miscellaneous;
using MentorBilling.Settings;
using MentorBilling.ControllerService;

namespace MentorBilling.Invoice.Controllers
{
    public class InvoiceHeaderController : InvoiceHeader
    {
        #region Settings Link
        /// <summary>
        /// the instance settings received from the parent
        /// </summary>
        readonly InstanceSettings instanceSettings;
        /// <summary>
        /// the link to the seller controller
        /// </summary>
        readonly ControllerLink sellerLink;
        #endregion

        #region Primary Properties
        /// <summary>
        /// the document series bound to the given TextBox
        /// </summary>
        public new String DocumentSeries
        {
            get => base.DocumentSeries;
            set => base.DocumentSeries = value;
        }
        /// <summary>
        /// the document number bound to the given textbox
        /// </summary>
        [Required(ErrorMessage = "Numarul de document este obligatoriu")]
        [Range(0,Int32.MaxValue,ErrorMessage = "Numarul de document nu poate fi negativ")]
        public new Int32 DocumentNumber
        {
            get => base.DocumentNumber;
            set => base.DocumentNumber = value;
        }
        /// <summary>
        /// the document date bound to the given textbox
        /// </summary>
        [Required(ErrorMessage = "Data documentului este obligatorie")]
        public new DateTime DocumentDate
        {
            get => base.DocumentDate;
            set => base.DocumentDate = value;
        }
        /// <summary>
        /// the delivery notice number bound to the given textBox
        /// </summary>
        [Range(0, Int32.MaxValue, ErrorMessage = "Numarul de aviz nu poate fi negativ")]
        public new Int32 DeliveryNoticeNumber
        {
            get => base.DeliveryNoticeNumber;
            set => base.DeliveryNoticeNumber = value;
        }
        /// <summary>
        /// the VAT at Collection bount to the given checkBox
        /// </summary>
        public new Boolean VATatCollection
        {
            get => base.VATatCollection;
            set => base.vatAtCollection = value;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// the main constructor for the class
        /// </summary>
        public InvoiceHeaderController() { }
        /// <summary>
        /// the main contructor that will receive the instance settings from the parent
        /// </summary>
        /// <param name="settings">the instance settings will alter core functionality</param>
        public InvoiceHeaderController(InstanceSettings settings)
        {
            this.instanceSettings = settings;
        }
        /// <summary>
        /// the main contructor that will receive the instance settings and controller link from the parent
        /// </summary>
        /// <param name="settings">the instance settings will alter core functionality</param>
        public InvoiceHeaderController(InstanceSettings settings,ControllerLink controllerLink)
        {
            this.instanceSettings = settings;
            this.sellerLink = controllerLink;
            this.sellerLink.OnChange += SetVATatCollectionFromLinkController;
        }
        #endregion

        #region Aditional Checks
        /// <summary>
        /// the check for the Validity of the Date for the interface
        /// </summary>
        [Range(typeof(bool),"true","true",ErrorMessage = "Data documentului nu este valida sau nu se poate facura in acea data.")]
        public Boolean IsDocumentDateValid
        {
            get => CheckDateValidity();

        }
        #endregion

        #region Functionality
        /// <summary>
        /// this is the base validation for the document date
        /// </summary>
        /// <returns>if the date is valid for the document or not</returns>
        Boolean CheckDateValidity()
        {
            if (base.DocumentDate.Month == DateTime.Now.Month) return true;
            else if (instanceSettings.PermitInvoicesOutsideCurrentMonth)
            {
                if(base.DocumentDate < DateTimeConversions.GetFirstDayOfMonth(DateTime.Now))
                {
                    if (!instanceSettings.PermitInvoiceInMonthsPrior) return false;
                    else if (base.documentDate
                                    .IsBetween(DateTimeConversions.GetFirstDayOfMonth(DateTime.Now.AddMonths(-1 * instanceSettings.NumberOfMonthsPrior)),
                                        DateTimeConversions.GetLastDayOfMonth(DateTime.Now))) return true;
                    else return false;
                }
                else
                {
                    if (!instanceSettings.PermitInvoiceInMonthsFollowing) return false;
                    else if (base.documentDate.IsBetween(DateTimeConversions.GetFirstDayOfMonth(DateTime.Now),
                                DateTimeConversions.GetLastDayOfMonth(DateTime.Now.AddMonths(instanceSettings.NumberOfMonthsFollowing)))) return true;
                    else return false;

                }
            }
            else return false;
        }

        /// <summary>
        /// this function will set the VATatCollection property from the collection controller
        /// </summary>
        public void SetVATatCollectionFromLinkController()
        {
            this.VATatCollection = sellerLink.GetBooleanValue;
        }
        #endregion
    }
}
