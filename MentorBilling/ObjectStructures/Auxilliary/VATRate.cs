using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Auxilliary
{
    public class VATRate
    {
        #region Properties
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the id property for the object
        /// </summary>
        private Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the char id property
        /// </summary>
        private String charID { get; set; } = String.Empty;
        /// <summary>
        /// the vat property
        /// </summary>
        private Int32 vat { get; set; } = new Int32();
        /// <summary>
        /// the registry index property
        /// </summary>
        private String registryIndex { get; set; } = String.Empty;
        /// <summary>
        /// the display code property
        /// </summary>
        private String displayCode { get; set; } = String.Empty;
#pragma warning restore IDE1006 // Naming Styles
        #endregion

        #region Callers
        /// <summary>
        /// the caller for the id propery
        /// </summary>
        public Int64 ID 
        { 
            get => id; 
            set => id = value; 
        }
        /// <summary>
        /// the caller for the char id property
        /// </summary>
        public String CharID
        {
            get => charID;
            set => charID = value;
        }
        /// <summary>
        /// the caller for the vat property
        /// </summary>
        public Int32 VAT
        {
            get => vat;
            set => vat = value;
        }
        /// <summary>
        /// the caller for the registry index property
        /// </summary>
        public String RegistryIndex
        {
            get => registryIndex;
            set => registryIndex = value;
        }
        /// <summary>
        /// the caller for the display code property
        /// </summary>
        public String DisplayCode
        {
            get => displayCode;
            set => displayCode = value;
        }

        public String DisplayName => vat == 0 ? DisplayCode : DisplayCode + ": " + VAT.ToString() + "%";

        #endregion
    }
}
