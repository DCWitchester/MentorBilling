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

        /// <summary>
        /// the errors for password does not match
        /// </summary>
        [Range(typeof(bool),"true","true",ErrorMessage ="Parola nu corespunde cu campul de verificare")]
        public Boolean DoPasswordsMatch { get => Password == PasswordMatch; }

        /// <summary>
        /// the error for trying to make an account on an already in use email
        /// </summary>
        [Range(typeof(bool), "false", "false", ErrorMessage = "Deja exista un utilizator legat de acesta adresa de email")]
        public Boolean EmailAlreadyExists { get; set; }

        /// <summary>
        /// the error for trying to make an account with the same username as another
        /// </summary>
        [Range(typeof(bool), "false", "false", ErrorMessage = "Deja exista un utilizator cu aceast nume")]
        public Boolean UsernameAlreadyExists { get; set; }

        /// <summary>
        /// the error for trying to make an account with an invalid email Adress
        /// </summary>
        [Range(typeof(bool),"true","true",ErrorMessage = "Adresa de email introdusa nu este valida")]
        public Boolean IsEmailValid { get => Miscellaneous.MailCheck.TestMail(Email); }
    }
}
