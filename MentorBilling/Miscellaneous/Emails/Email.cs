using MentorBilling.Login.UserControllers;

namespace MentorBilling.Miscellaneous.Emails
{
    public class Email
    {
        /// <summary>
        /// this function will send a validation email to a specific user
        /// </summary>
        /// <param name="user">the specific user</param>
        public static void SendValidationEmail(User user)
        {
            //we initialize a new smtp mail sender
            SendMailSmtp sendMailSmtp = new SendMailSmtp();
            //set the email sender
            //the sendere needs to have an active app password configured
            sendMailSmtp.SetDefaultSender();
            //we set the receiver of the email
            sendMailSmtp.SetMailReceiver = user.Email;
            //we set the subject of the mail 
            sendMailSmtp.SetMailSubject = "Validare cont Mentor";
            //and the body of the email 
            sendMailSmtp.SetMailBody = MailFormat.GetValidationEmail(user);
            //we also set the body format to true so the html compiles
            sendMailSmtp.FormatMailBody = true;
            //before sending the mail
            sendMailSmtp.SendMail();
        }

        /// <summary>
        /// this function will send a password reset email to a specific user
        /// </summary>
        /// <param name="user">the specific user</param>
        public static void SendPasswordResetEmail(User user)
        {
            //we initialize a new smtp mail sender
            SendMailSmtp sendMailSmtp = new SendMailSmtp();
            //set the email sender
            //the sendere needs to have an active app password configured
            sendMailSmtp.SetDefaultSender();
            //we set the receiver of the email
            sendMailSmtp.SetMailReceiver = user.Email;
            //we set the subject of the mail 
            sendMailSmtp.SetMailSubject = "Validare cont Mentor";
            //and the body of the email 
            sendMailSmtp.SetMailBody = MailFormat.GetResetPasswordEmail(user);
            //we also set the body format to true so the html compiles
            sendMailSmtp.FormatMailBody = true;
            //before sending the mail
            sendMailSmtp.SendMail();
        }
    }
}
