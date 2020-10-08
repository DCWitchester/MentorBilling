using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Auxilliary
{
    public class Counties
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the id property
        /// </summary>
        private Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the country code property
        /// </summary>
        private String countyCode { get; set; } = String.Empty;
        /// <summary>
        /// the country name property
        /// </summary>
        private String countyName { get; set; } = String.Empty;
#pragma warning restore IDE1006
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
        /// the country code property
        /// </summary>
        public String CountyCode
        {
            get => countyCode;
            set => countyCode = value;
        }
        /// <summary>
        /// the country name property
        /// </summary>
        public String CountyName
        {
            get => countyName;
            set => countyName = value;
        }
        #endregion
    }
}
