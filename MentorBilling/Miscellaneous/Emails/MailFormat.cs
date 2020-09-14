using MentorBilling.Login.UserControllers;
using MentorBilling.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Miscellaneous.Emails
{
    public class MailFormat
    {
        /// <summary>
        /// the enum contatining the email types that will be sent from this program
        /// </summary>
        enum EmailTypes 
        {
            //default value
            None = 0,
            //the validation email
            ValidationEmail = 1,
            //the reset password email
            ResetPassword = 2
        }

        /// <summary>
        /// this fucntion will retrieve the email based on the given type
        /// </summary>
        /// <param name="type">the given type</param>
        /// <returns>the email string</returns>
        static String GetEmailPath(EmailTypes type)
        {
            return type switch
            {
                EmailTypes.None => String.Empty,
                EmailTypes.ValidationEmail => "wwwroot/EmailStructures/validationEmail.txt",
                EmailTypes.ResetPassword => "wwwroot/EmailStructures/resetEmail.txt",
                _ => String.Empty,
            };
        }

#if DEBUG
        /// <summary>
        /// the given web adress for the account validation
        /// </summary>
        static String GetValidationWebAdress => "192.168.13.13:5678/validateAccount/";
        /// <summary>
        /// the given web adress for the password validation
        /// </summary>
        static String GetResetWebAdress => "192.168.13.13:5678/resetPassword/";
#else
        /// <summary>
        /// the given web adress for the account validation
        /// </summary>
        static String getValidationWebAdress => "192.168.13.13:5678/validateAccount/";
        /// <summary>
        /// the given web adress for the password validation
        /// </summary>
        static String getResetWebAdress => "192.168.13.13:5678/resetPassword/";
#endif

        /// <summary>
        /// this function will return the correctly formatted html email for the validateAccount for the given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>the correct validation email</returns>
        public static String GetValidationEmail(User user)
        {
            Encryption encryption = new Encryption();
            return System.IO.File.ReadAllText(GetEmailPath(EmailTypes.ValidationEmail)).Replace("{0}", user.DisplayName).Replace("{1}", GetValidationWebAdress + encryption.GetValidEncryption(user.ID.ToString()));            
        }

        /// <summary>
        /// this function will return the correctly formatted html email for the resetPassword for the given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>the correct validation email</returns>
        public static String GetResetPasswordEmail(User user)
        {
            Encryption encryption = new Encryption();
            return System.IO.File.ReadAllText(GetEmailPath(EmailTypes.ResetPassword)).Replace("{0}", user.DisplayName).Replace("{1}", GetResetWebAdress + encryption.GetValidEncryption(user.ID.ToString()));
        }
    }
}
