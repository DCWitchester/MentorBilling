using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Auxilliary
{
    public class Logo
    {
        /// <summary>
        /// the base logo property
        /// </summary>
#pragma warning disable IDE1006 // Naming Styles
        private Byte[] logo { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// the public caller for the logo property
        /// </summary>
        public Byte[] LogoBase 
        { 
            get => logo; 
            set => logo = value; 
        }
    }
}
