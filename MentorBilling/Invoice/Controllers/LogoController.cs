using MentorBilling.ObjectStructures.Auxilliary;
using System;

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
        public new Byte[] LogoBase 
        { 
            get => base.LogoBase;
            set => base.LogoBase = value; 
        }

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

        /// <summary>
        /// this function will retrieve the BaseLogo 
        /// </summary>
        public Logo BaseLogo
        {
            get => base.Value;
            set => base.Value = value;
        }

        public LogoController() { }

        public LogoController(Logo logo)
        {
            base.Value = logo;
        }

        public LogoController SetImageBytes(Byte[] imageBytes)
        {
            base.LogoBase = imageBytes;
            return this;
        }
    }
}
