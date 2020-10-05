using MentorBilling.ObjectStructures.Auxilliary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Controllers
{
    public class LogoController : Logo
    {
        /// <summary>
        /// the image Format for the Logo
        /// </summary>
        public String ImageFormat { get; set; } = "image/gif";

        /// <summary>
        /// the LogoBase Byte Array
        /// </summary>
        public new Byte[] LogoBase { get; set; }

        /// <summary>
        /// the formated Logo to be used as imageSrc
        /// </summary>
        public String Logo
        {
            get => $"data:{ImageFormat};base64,{Convert.ToBase64String(LogoBase)}";
        }

        //TODO: Settings for the aspect ratio of the image
        /// <summary>
        /// the MaintainAspectRatio Property
        /// </summary>
        public Boolean MaintainAspectRatio { get; set; } = false;
    }
}
