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

        [Range(typeof(bool), "true", "true", ErrorMessage = "Combinatia utilizator\\parola nu exista.")]
        public Boolean IsPasswordValid { get; set; }

        public void CheckPassword(String RetrievedPassword)
        {
            IsPasswordValid = RetrievedPassword == Password;
        }

    }
}
