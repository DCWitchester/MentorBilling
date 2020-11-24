using System;
using MentorBilling.ObjectStructures.Auxilliary;

namespace MentorBilling.ObjectStructures.Invoice
{
    public class Seller
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the Seller ID property
        /// </summary>
        private Int64 id { get; set; } = new Int64();
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
        public Int64 ID
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

        #region Consume Functions
        /// <summary>
        /// this function will consume a context object to set the values of the current object from it
        /// </summary>
        /// <param name="furnizor">the context object</param>
        public void ConsumeDatabaseObject(Database.EntityFramework.MentorBillingEntityFramework.Furnizori furnizor)
        {
            this.id = furnizor.Id;
            this.name = furnizor.Denumire;
            this.commercialRegistryNumber = furnizor.NrRegistruComert;
            this.fiscalCode = furnizor.CodFiscal;
            this.headquarters = furnizor.Sediul;
            this.workPoint = furnizor.PunctLucru;
            this.phone = furnizor.Telefon;
            this.email = furnizor.Email;
            this.logo = new Logo(furnizor.Sigla);
        }

        /// <summary>
        /// this function will dump the current object into a given context object
        /// </summary>
        /// <param name="furnizor">the context object</param>
        public void DumpIntoDatabaseObject(Database.EntityFramework.MentorBillingEntityFramework.Furnizori furnizor)
        {
            furnizor.Denumire = this.name;
            furnizor.NrRegistruComert = this.commercialRegistryNumber;
            furnizor.CapitalSocial = this.jointStock;
            furnizor.Sediul = this.headquarters;
            furnizor.PunctLucru = this.workPoint;
            furnizor.Telefon = this.phone;
            furnizor.Email = this.email;
            furnizor.Sigla = this.logo.LogoBase;
        }
        #endregion
    }
}
