using MentorBilling.Database.EntityFramework.DatabaseLink;
using System;
using System.ComponentModel.DataAnnotations;

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
        public Boolean DoesUsernameExist { get => CheckEmail(); }

        #region Database Caller
        Boolean CheckEmail()
        {
            using UserFunctions userFunctions = new UserFunctions();
            return userFunctions.CheckEmail(this);
        }
        #endregion
    }
}
