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

        /// <summary>
        /// the base initializer for the object without any property
        /// </summary>
        public Logo(){ }

        /// <summary>
        /// the base initializer for the object with the byteArray value
        /// </summary>
        /// <param name="value">the image byteArray</param>
        public Logo(Byte[] value) 
        {
            logo = value;
        }

        /// <summary>
        /// the Base Value linked to this
        /// </summary>
        public Logo Value
        {
            get => this;
            set => this.logo = value.LogoBase;
        }
    }
}
