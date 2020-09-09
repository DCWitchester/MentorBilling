using MentorBilling.Database.DatabaseLink;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.UserControllers
{
    public class LoginController
    {
        /// <summary>
        /// the username bound to a given Username TextBox
        /// </summary>
        [Required(ErrorMessage = "Nu ati introdus numele de utilizator.")]
        public String Username { get; set; } = String.Empty;

        /// <summary>
        /// the password bound to the givent Password TextBox
        /// </summary>
        [Required(ErrorMessage = "Nu ati introdus parola.")]
        public String Password { get; set; } = String.Empty;

        /// <summary>
        /// the main item for the password validity
        /// </summary>
        [Range(typeof(bool), "true", "true", ErrorMessage = "Combinatia utilizator\\parola nu exista.")]
        public Boolean IsPasswordValid { get => UserFunctions.CheckAccountValidity(this); }

        /// <summary>
        /// the main item for the user/email validity
        /// </summary>
        [Range(typeof(bool), "true", "true", ErrorMessage = "Numele de utilizator sau adresa de email introdusa nu are nici un cont atribuit")]
        public Boolean DoesUsernameExist { get => UserFunctions.CheckUsernameOrEmail(this); }
    }
}
