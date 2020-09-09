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
        enum EmailTypes 
        {
            None = 0,
            ValidationEmail = 1
        }

        static String GetEmailPath(EmailTypes type)
        {
            return type switch
            {
                EmailTypes.None => String.Empty,
                EmailTypes.ValidationEmail => "wwwroot/EmailStructures/validationEmail.txt",
                _ => String.Empty,
            };
        }

#if DEBUG
        static String getValidationWebAdress => "localhost:44359/validateAccount/";
#else
        String getValidationWebAdress => "192.168.13.13:5678/validateAccount/";
#endif

        public static String GetValidationEmail(User user)
        {
            Encryption encryption = new Encryption();
            return System.IO.File.ReadAllText(GetEmailPath(EmailTypes.ValidationEmail)).Replace("{0}", user.DisplayName).Replace("{1}", getValidationWebAdress + encryption.Encrypt(user.ID.ToString()));            
        }
    }
}
