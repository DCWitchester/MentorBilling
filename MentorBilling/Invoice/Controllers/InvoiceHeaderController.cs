using MentorBilling.ObjectStructures.Invoice;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Controllers
{
    public class InvoiceHeaderController : InvoiceHeader
    {
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
    }
}
