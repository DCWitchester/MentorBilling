using System;
using System.Text.RegularExpressions;

namespace MentorBilling.Miscellaneous
{
    public class MailCheck
    {
        /// <summary>
        /// this function checks weather the email is regex based valid
        /// </summary>
        /// <param name="email">the tested email</param>
        /// <returns>weather the mail is a amatch or not</returns>
        public static Boolean CheckMailStructure(String email)
        {
            return (new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,6}$")).IsMatch(email);
        }
        /// <summary>
        /// this function will check weather a mail adress is valid or not
        /// </summary>
        /// <param name="email">the email to be checked</param>
        /// <returns>wether the email is a match or not</returns>
        public static Boolean TestMail(String email)
        {
            if (!CheckMailStructure(email)) return false;
            //first we set the mail smtp client
            EASendMail.SmtpMail oMail = new EASendMail.SmtpMail("TryIt");
            EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
            EASendMail.SmtpServer oServer = new EASendMail.SmtpServer("");
            //then we set a generic sender
            oMail.From = "request.mentorsoft@gmail.com";
            //and the mail we want to check vor validity
            oMail.To = email;
            try
            {
                oSmtp.TestRecipients(oServer, oMail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
