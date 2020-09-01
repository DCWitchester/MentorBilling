using System;
using System.ComponentModel.DataAnnotations;

namespace MentorBilling.Login.UserControllers
{
    public class RegisterController
    {
        /// <summary>
        /// the email bound to a given Email TextBox
        /// </summary>
        [Required(ErrorMessage = "Adresa de email este camp obligatoriu")]
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

        [Range(typeof(bool),"true","true",ErrorMessage ="Parola nu corespunde cu campul de verificare")]
        public Boolean DoPasswordsMatch { get => Password == PasswordMatch; }

        [Range(typeof(bool), "false", "false", ErrorMessage = "Deja exista un utilizator legat de acesta adresa de email")]
        public Boolean EmailAlreadyExists { get; set; }

        [Range(typeof(bool), "false", "false", ErrorMessage = "Deja exista un utilizator cu aceast nume")]
        public Boolean UsernameAlreadyExists { get; set; }
    }
}
