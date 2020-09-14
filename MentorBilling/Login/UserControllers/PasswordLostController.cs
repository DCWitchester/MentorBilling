using MentorBilling.Database.DatabaseLink;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.UserControllers
{
    public class PasswordLostController
    {
        /// <summary>
        /// the username bound to a given Username TextBox
        /// </summary>
        [Required(ErrorMessage = "Nu ati introdus adresa de mail.")]
        public String Email { get; set; } = String.Empty;

        /// <summary>
        /// the main item for the user/email validity
        /// </summary>
        [Range(typeof(bool), "true", "true", ErrorMessage = "Adresa de email introdusa nu are nici un cont atribuit")]
        public Boolean DoesUsernameExist { get => UserFunctions.CheckEmail(this); }
    }
}
