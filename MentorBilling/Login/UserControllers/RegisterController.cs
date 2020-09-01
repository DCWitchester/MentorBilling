using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.UserControllers
{
    public class RegisterController
    {
        /// <summary>
        /// the email bound to a given Email TextBox
        /// </summary>
        [Required(ErrorMessage = "Numele de utilizator este camp obligatoriu")]
        public String Email { get; set; } = String.Empty;

        /// <summary>
        /// the username bound to a given Username TextBox
        /// </summary>
        [Required(ErrorMessage = "Numele de utilizator este camp obligatoriu")]
        public String Username { get; set; } = String.Empty;

        /// <summary>
        /// the password bound to a given Password TextBox
        /// </summary>
        [Required(ErrorMessage = "Parola este camp obligatoriu.")]
        public String Password { get; set; } = String.Empty;

        /// <summary>
        /// the name bound to a given Name TextBox
        /// </summary>
        public String Name { get; set; } = String.Empty;
        /// <summary>
        /// the name bound to a given Surname TextBox
        /// </summary>
        public String Surname { get; set; } = String.Empty;

        /// <summary>
        /// the PasswordMatch bound to a given Password TextBox
        /// </summary>
        public String PasswordMatch { get; set; } = String.Empty;

        [Range(typeof(bool),"true","true",ErrorMessage ="Parola nu corespunde cu campul de varificare")]
        public Boolean DoPasswordsMatch { get => Password == PasswordMatch; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Deja exista un utilizator legat de acesta adresa de email")]
        public Boolean EmailAlreadyExist { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "Deja exista un utilizator cu aceast nume")]
        public Boolean UsernameAlreadyExist { get; set; }
    }
}
