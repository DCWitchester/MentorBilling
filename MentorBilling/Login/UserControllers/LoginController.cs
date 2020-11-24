using MentorBilling.Database.EntityFramework.DatabaseLink;
using System;
using System.ComponentModel.DataAnnotations;

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
        public Boolean IsPasswordValid { get => CheckAccountValidity(); }

        /// <summary>
        /// the main item for the user/email validity
        /// </summary>
        [Range(typeof(bool), "true", "true", ErrorMessage = "Numele de utilizator sau adresa de email introdusa nu are nici un cont atribuit")]
        public Boolean DoesUsernameExist { get => CheckUsernameOrEmail(); }

        #region Database Calls
        /// <summary>
        /// this function will check the validity of the current account object
        /// </summary>
        /// <returns>the accounts validity</returns>
        Boolean CheckAccountValidity()
        {
            using UserFunctions userFunctions = new UserFunctions();
            return userFunctions.CheckAccountValidity(this);
        }
        /// <summary>
        /// this function will check that th given username or email is valid
        /// </summary>
        /// <returns>the object validity</returns>
        Boolean CheckUsernameOrEmail()
        {
            using UserFunctions userFunctions = new UserFunctions();
            return userFunctions.CheckUsernameOrEmail(this);
        }
        #endregion
    }
}
