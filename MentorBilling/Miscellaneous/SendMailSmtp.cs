using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace MentorBilling.Miscellaneous
{
    public class SendMailSmtp
    {
        #region Properties
        /// <summary>
        /// the mail message to be sent
        /// </summary>
        MailMessage Mail { get; set; }
        /// <summary>
        /// the mail client that will make the connection
        /// </summary>
        SmtpClient Client { get; set; }
#pragma warning disable IDE1006
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
#pragma warning restore IDE1006
        #endregion
        #region Setters
        /// <summary>
        /// the main setter for the emails sender
        /// </summary>
        public String SetSenderAdress
        {
           set => mailSender = CheckMail(value);
        }

        /// <summary>
        /// the main setter for the emails recepient
        /// </summary>
        public String SetMailReceiver
        {
            set => mailReceiver = CheckMail(value);
        }

        /// <summary>
        /// the main setter for the emails body
        /// </summary>
        public String SetMailBody
        {
            set => mailBody = value;
        }

        /// <summary>
        /// the main setter for the emails password
        /// </summary>
        public String SetMailPassword
        {
            set => mailPassword = value;
        }

        /// <summary>
        /// the main setter for the emails subject
        /// </summary>
        public String SetMailSubject
        {
            set => mailSubject = value;
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
        /// this function will add an atachement to the email
        /// </summary>
        /// <param name="atachementPath"> the path towards the file that will be added as an atachement </param>
        public void AddAtachement(String[] atachementPath)
        {
            mailAtachements.AddRange(atachementPath);
        }

        /// <summary>
        /// this function will add an atachement to the email
        /// </summary>
        /// <param name="atachementPath"> the path towards the file that will be added as an atachement </param>
        public void AddAtachement(List<String> atachementPath)
        {
            mailAtachements.AddRange(atachementPath);
        }
        #endregion
        #region Callers
        /// <summary>
        /// the main caller for the class
        /// </summary>
        public SendMailSmtp() { }
        /// <summary>
        /// the caller for the class with a specific email
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        public SendMailSmtp(String username, String password)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        public SendMailSmtp(String username, String password, String recepient)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachementList">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, String attachement)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachementList">the email attachements array</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, String[] attachements)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the caller for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachementList">the email attachements list</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> attachementList)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
        }
        #endregion
        #region Private Functions
        /// <summary>
        /// this function will reinitialize the client
        /// </summary>
        void InitializaClient()
        {
            Client = new SmtpClient
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
            Mail = new MailMessage(sender, receiver);
        }
        /// <summary>
        /// the mail checker 
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        String CheckMail(String mail)
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
        #endregion
        #region Public Functions
        /// <summary>
        /// this function will send the email after making all needed setting
        /// </summary>
        public void SendMail()
        {
            InitializaClient();
            InitializeMail(mailSender, mailReceiver);
            Mail.Body = mailBody;
            Mail.Subject = mailSubject;
            foreach (String atachement in mailAtachements)
            {
                Mail.Attachments.Add(new Attachment(atachement));
            }
            Client.Send(Mail);
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given adress
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        public void SendMail(String username, String password)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given adress to the given recepient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        public void SendMail(String username, String password, String recepient)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given adress to the given recepient with the given subject
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        public void SendMail(String username, String password, String recepient,String mailSubject)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given adress to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given adress to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachementList">the current emails attachement</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, String attachement)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given adress to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachementList">the current emails attachements array</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, String[] attachements)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given adress to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> attachementList)
        {
            SetSenderAdress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
            SendMail();
        }
        #endregion
    }
}
