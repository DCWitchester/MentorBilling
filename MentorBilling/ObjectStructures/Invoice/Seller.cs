using System;
using MentorBilling.ObjectStructures.Auxilliary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Invoice
{
    public class Seller
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the Seller ID property
        /// </summary>
        private Int32 id { get; set; } = new Int32();
        /// <summary>
        /// the private fiscal code property
        /// </summary>
        private String fiscalCode { get; set; } = String.Empty;
        /// <summary>
        /// the private name property
        /// </summary>
        private String name { get; set; } = String.Empty;
        /// <summary>
        /// the private commercial registry number property
        /// </summary>
        private String commercialRegistryNumber { get; set; } = String.Empty;
        /// <summary>
        /// the joint stock property
        /// </summary>
        private Double jointStock { get; set; } = new Double();
        /// <summary>
        /// the headquarters property
        /// </summary>
        private String headquarters { get; set; } = String.Empty;
        /// <summary>
        /// the Website property
        /// </summary>
        private String website { get; set; } = String.Empty;
        /// <summary>
        /// the Phone property
        /// </summary>
        private String phone { get; set; } = String.Empty;
        /// <summary>
        /// the Mail property
        /// </summary>
        private String email { get; set; } = String.Empty;
        /// <summary>
        /// the work point property
        /// </summary>
        private String workPoint { get; set; } = String.Empty;
        /// <summary>
        /// the base logo property
        /// </summary>
        private Logo logo { get; set; } = new Logo();
#pragma warning restore IDE1006
        #endregion

        #region Callers
        /// <summary>
        /// the Seller ID property caller
        /// </summary>
        public Int32 ID
        {
            get => id;
            set => id = value;
        }
        /// <summary>
        /// the fiscalCode property caller
        /// </summary>
        public String FiscalCode 
        {
            get => fiscalCode;
            set => fiscalCode = value;
        }
        /// <summary>
        /// the Name property caller
        /// </summary>
        public String Name 
        {
            get => name; 
            set => name = value; 
        }
        /// <summary>
        /// the Commercial Registy Number Property Caller
        /// </summary>
        public String CommercialRegistryNumber 
        {
            get => commercialRegistryNumber ;
            set => commercialRegistryNumber = value; 
        }
        /// <summary>
        /// the Joint Stock Property Caller
        /// </summary>
        public Double JointStock 
        { 
            get => jointStock; 
            set => jointStock = value; 
        }
        /// <summary>
        /// the Headquarters property Caller
        /// </summary>
        public String Headquarters 
        { 
            get => headquarters; 
            set => headquarters = value; 
        }
        /// <summary>
        /// the Website property Caller
        /// </summary>
        public String Website
        {
            get => website;
            set => website = value;
        }
        ///<summary>
        ///the Phone property Caller
        ///</summary>
        public String Phone 
        { 
            get => phone; 
            set => phone = value; 
        }
        /// <summary>
        /// the Email property Caller
        /// </summary>
        public String Email 
        { 
            get => email; 
            set => email = value; 
        }
        /// <summary>
        /// the work point proeprty caller
        /// </summary>
        public String WorkPoint 
        { 
            get => workPoint; 
            set => workPoint = value; 
        }
        /// <summary>
        /// the value caller will return the entire object
        /// </summary>
        public Seller Value => this;
        /// <summary>
        /// the main caller for the logo property
        /// </summary>
        public Logo Logo
        {
            get => logo;
            set => logo = value;
        }
        /// <summary>
        /// the main caller for the logo that calls the byteArray
        /// </summary>
        public Byte[] LogoBytes
        {
            get => logo.LogoBase;
            set => logo.LogoBase = value;
        }
        #endregion
    }
}
