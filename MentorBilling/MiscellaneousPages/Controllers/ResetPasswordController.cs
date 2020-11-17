using System;
using System.ComponentModel.DataAnnotations;

namespace MentorBilling.MiscellaneousPages.Controllers
{
    public class ResetPasswordController
    {
        /// <summary>
        /// the password bound to a given Password TextBox
        /// </summary>
        [Required(ErrorMessage = "Parola este camp obligatoriu.")]
        public String Password { get; set; } = String.Empty;

        /// <summary>
        /// the password bound to a given Password TextBox
        /// </summary>
        [Required(ErrorMessage = "Parola este camp obligatoriu.")]
        public String PasswordMatch { get; set; } = String.Empty;

        /// <summary>
        /// the errors for password does not match
        /// </summary>
        [Range(typeof(bool), "true", "true", ErrorMessage = "Parola nu corespunde cu campul de verificare")]
        public Boolean DoPasswordsMatch { get => Password == PasswordMatch; }
    }
}
