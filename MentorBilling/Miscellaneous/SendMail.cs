using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MentorBilling.Miscellaneous
{
    public class SendMail
    {
        public static class DefaultMailAdresses
        {
            public static readonly String defaultSender = "request.mentorsoft@gmail.com";
            public static readonly String defaultSenderPassword = "10485769";
            public static readonly String defaultReceiver = "helpdesk.mentorsoft@gmail.com";
        }
        public static class MailCheck
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
        /// <summary>
        /// the mail message to be sent
        /// </summary>
        MailMessage mail { get; set; }
        /// <summary>
        /// the mail client that will make the connection
        /// </summary>
        SmtpClient client { get; set; }
        /// <summary>
        /// the mail sender
        /// </summary>
        String mailSender { get; set; } = String.Empty;
        /// <summary>
        /// the mail password
        /// </summary>
        String mailPassword { get; set; } = String.Empty;
        /// <summary>
        /// the mail adreess to receive the mail
        /// </summary>
        String mailReceiver { get; set; } = String.Empty;
        /// <summary>
        /// the mail subject 
        /// </summary>
        String mailSubject { get; set; } = String.Empty;
        /// <summary>
        /// the body of the mail
        /// </summary>
        String mailBody { get; set; } = String.Empty;
        /// <summary>
        /// the atachements list
        /// </summary>
        List<String> mailAtachements { get; set; } = new List<String>();
        /// <summary>
        /// this function will reinitialize the client
        /// </summary>
        void InitializaClient()
        {
            client = new SmtpClient
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(mailSender, mailPassword),
                Host = "smtp.gmail.com"
            };
        }
        /// <summary>
        /// this function will initialize the mail giving it a sender and a receiver
        /// </summary>
        /// <param name="sender"> FROM</param>
        /// <param name="receiver">TO</param>
        void InitializeMail(String sender, String receiver)
        {
            mail = new MailMessage(sender, receiver);
        }
        /// <summary>
        /// this funtion will set the sender mail adress for the email
        /// </summary>
        /// <param name="sender">The email adress for From</param>
        public void SetSenderAdress(String sender)
        {
            mailSender = checkMail(sender);
        }
        /// <summary>
        /// this function will set the mail receiver adress
        /// </summary>
        /// <param name="receiver">the email adress for TO</param>
        public void SetMailReceiver(String receiver)
        {
            mailReceiver = checkMail(receiver);
        }
        /// <summary>
        /// this function will set the body of the given mail
        /// </summary>
        /// <param name="body"> the mail body</param>
        public void SetMailBody(String body)
        {
            mailBody = body;
        }
        /// <summary>
        /// this function will set the mail password for the adress
        /// </summary>
        /// <param name="password">the mail password</param>
        public void SetMailPassword(String password)
        {
            mailPassword = password;
        }
        /// <summary>
        /// this function will set the subject for the mail
        /// </summary>
        /// <param name="subject"> the subject of the mail </param>
        public void SetMailSubjects(String subject)
        {
            mailSubject = subject;
        }
        /// <summary>
        /// this function will add an atachement to the email
        /// </summary>
        /// <param name="atachementPath"> the path towards the file that will be added as an atachement </param>
        public void AddAtachement(String atachementPath)
        {
            mailAtachements.Add(atachementPath);
        }
        /// <summary>
        /// this function will send the email after making all needed setting
        /// </summary>
        public void sendMail()
        {
            InitializaClient();
            InitializeMail(mailSender, mailReceiver);
            mail.Body = mailBody;
            mail.Subject = mailSubject;
            foreach (String atachement in mailAtachements)
            {
                mail.Attachments.Add(new Attachment(atachement));
            }
            client.Send(mail);
        }
        /// <summary>
        /// the mail checker 
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        private String checkMail(String mail)
        {
            try
            {
                var addr = new MailAddress(mail);
                return mail;
            }
            catch
            {
                return "";
            }
        }
    }
}
