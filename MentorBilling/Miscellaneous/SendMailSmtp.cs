using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;

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
        /// the alternative mail property <= linked to the sender
        /// </summary>
        String mailSenderAlternative { get; set; } = String.Empty;
        /// <summary>
        /// the displayName mail property <= linked to the sender
        /// </summary>
        String mailSenderDisplayName { get; set; } = String.Empty;
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
        /// the attachements list
        /// </summary>
        List<String> mailAttachements { get; set; } = new List<String>();
        /// <summary>
        /// the mail body formating
        /// </summary>
        Boolean IsMailHtml { get; set; } = false;
        /// <summary>
        /// the main header formating
        /// </summary>
        Boolean requestAnswer { get; set; } = false;
        /// <summary>
        /// the setting for the configuration of the sender and receiver as a MailAddress
        /// </summary>
        Boolean useMailAddresses { get; set; } = false;
#pragma warning restore IDE1006
        #endregion
        #region Setters
        /// <summary>
        /// the main setter for the emails sender
        /// </summary>
        public String SetSenderAddress
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
        /// the main setter for the emails alternative sender
        /// </summary>
        public String SetMailSenderAlternative
        {
            set => mailSenderAlternative = value;
        }

        /// <summary>
        /// the main setter for the emails display name
        /// </summary>
        public String SetMailDisplayName
        {
            set => mailSenderDisplayName = value;
        }

        /// <summary>
        /// the main setter for the emails subject
        /// </summary>
        public String SetMailSubject
        {
            set => mailSubject = value;
        }
        /// <summary>
        /// this function will set the email body to html formatting
        /// </summary>
        public Boolean FormatMailBody
        {
            set => IsMailHtml = value;
        }
        /// <summary>
        /// this function will convert the email header to requested an answer
        /// </summary>
        public Boolean RequestResponse
        {
            set => requestAnswer = value;
        }
        /// <summary>
        /// this function will convert the sender and receiver to be used as email address Object
        /// </summary>
        public Boolean UseMailAddresses
        {
            set => useMailAddresses = value;
        }
        #region Default Values
        /// <summary>
        /// this is the default email address for sending emails
        /// </summary>
        public String GetDefaultEmail => "helpdesk.mentorsoft@gmail.com";
        /// <summary>
        /// this is the default emai password
        /// </summary>
        public String GetAppPassword => "vpyuufezmukqmfav";
        /// <summary>
        /// this function will set the default sender and app password for the email
        /// </summary>
        public void SetDefaultSender()
        {
            mailSender = GetDefaultEmail;
            mailPassword = GetAppPassword;
        }
        #endregion Default Values
        /// <summary>
        /// this function will add an atachement to the email
        /// </summary>
        /// <param name="atachementPath"> the path towards the file that will be added as an atachement </param>
        public void AddAtachement(String atachementPath)
        {
            mailAttachements.Add(atachementPath);
        }

        /// <summary>
        /// this function will add an atachement to the email
        /// </summary>
        /// <param name="atachementPath"> the path towards the file that will be added as an atachement </param>
        public void AddAtachement(String[] atachementPath)
        {
            mailAttachements.AddRange(atachementPath);
        }

        /// <summary>
        /// this function will add an atachement to the email
        /// </summary>
        /// <param name="atachementPath"> the path towards the file that will be added as an atachement </param>
        public void AddAtachement(List<String> atachementPath)
        {
            mailAttachements.AddRange(atachementPath);
        }
        #endregion
        #region Constructors
        #region No parameters
        /// <summary>
        /// the main constructor for the class
        /// </summary>
        public SendMailSmtp() { }
        #endregion
        #region Sender
        /// <summary>
        /// the constructor for the class with a specific email
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        public SendMailSmtp(String username, String password)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
        }
        /// <summary>
        /// the constructor for the class with a specific email and alternative address
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
        }
        /// <summary>
        /// the constructor for the class with a specific email and alternative address
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
        }
        #endregion
        #region Sender - Receiver
        /// <summary>
        /// the constructor for the class with a specific email and recepient
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        public SendMailSmtp(String username, String password, String recepient)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
        }
        #endregion
        #region Sender - Receiver - MailSubject
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - requestAnswer
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - Single Attachement
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
         /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - Single Attachement
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachement);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachement);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachement);
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - requestAnswer - Single Attachement
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachement);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachement);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachement">the email attachement</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachement);
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - Attachement Array
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachements">the email attachements array</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachements">the email attachements array</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachements">the email attachements array</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - Attachement Array
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachements">the email attachements array</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachements">the email attachements array</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body amd multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachements">the email attachements array</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachements);
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - requestAnswer - Attachement Array
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachements">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachements">the email attachement</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachements">the email attachement</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - Attachement List
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachementList">the email attachements list</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachementList">the email attachements list</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="attachementList">the email attachements list</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - Attachement List
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachementList">the email attachements list</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachementList);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachementList">the email attachements list</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachementList);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and multiple attachements
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachementList">the email attachements list</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachementList);
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - requestAnswer - Attachement List
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachements">the email attachement</param>
        public SendMailSmtp(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, List<String> attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachements">the email attachement</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, List<String> attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
        }
        /// <summary>
        /// the constructor for the class with a specific email and recepient with the specific subject and body and specific attachement and request an answer on read
        /// </summary>
        /// <param name="username">the emails username</param>
        /// <param name="password">the emails password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the emails recepient</param>
        /// <param name="mailSubject">the emails subject</param>
        /// <param name="mailBody">the emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header response request formating</param>
        /// <param name="attachements">the email attachement</param>
        public SendMailSmtp(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, List<String> attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
        }
        #endregion
        #endregion
        #region Private Functions
        #region Main Functions
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
        /// this function will initialize the mail giving it a sender and receiver based on address Objects
        /// </summary>
        /// <param name="sender">FROM</param>
        /// <param name="receiver">TO</param>
        void InitializeMail(MailAddress sender, MailAddress receiver)
        {
            Mail = new MailMessage(sender, receiver);
        }
        /// <summary>
        /// the mail checker 
        /// </summary>
        /// <param name="mail"></param>
        /// <returns>wether the mail is valid or not</returns>
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
        #region AuxilliaryFunctions
        /// <summary>
        /// this function will generate a MailAddress based on a given string
        /// </summary>
        /// <param name="mailSender">the mail sender string <= will only be displayed if linked to the email account because of GDRP</param>
        /// <returns>a valid MailAddress</returns>
        MailAddress GenerateMailAddress(String mailSender)
        {
            return new MailAddress(mailSender);
        }
        /// <summary>
        /// this function will generate a MailAddress based on a given string with a specific dispaly name
        /// </summary>
        /// <param name="mailSender">the mail sender string <= will only be displayed if linked to the email account because of GDRP</param>
        /// <param name="displayName">the display name for the email sender</param>
        /// <returns>a valid MailAddress</returns>
        MailAddress GenerateMailAddress(String mailSender, String displayName)
        {
            return new MailAddress(mailSender, displayName);
        }
        /// <summary>
        /// this function will get the needed mailAddress for the receiver
        /// </summary>
        /// <returns>a valid MailAddress</returns>
        MailAddress GetReceiverMailAddress()
        {
            return GenerateMailAddress(mailReceiver);
        }
        /// <summary>
        /// this function will get the needed mail address for the sender
        /// </summary>
        /// <returns>a valid MailAddress</returns>
        MailAddress GetSenderMailAddress()
        {
            //there will be a multi value path for the sender address unlike the receiver
            if (String.IsNullOrWhiteSpace(mailSenderDisplayName))
            {
                //first we check if the second parameter has value
                //and in consequence if the mail sender has an alternative value
                if (String.IsNullOrWhiteSpace(mailSenderAlternative)) return GenerateMailAddress(mailSender);
                else return GenerateMailAddress(mailSenderAlternative);
            }
            else
            {
                //on the second path all we need to check is the alternative value on the second parameter
                if (String.IsNullOrWhiteSpace(mailSenderAlternative)) return GenerateMailAddress(mailSender,mailSenderDisplayName);
                else return GenerateMailAddress(mailSenderAlternative,mailSenderDisplayName);
            }
        }
        #endregion
        #endregion
        #region Public Functions
        #region BaseFunction
        /// <summary>
        /// this function will send the email after making all needed setting
        /// </summary>
        public void SendMail()
        {
            InitializaClient();
            if (useMailAddresses)
                InitializeMail(GetSenderMailAddress(), GetReceiverMailAddress());
            else
                InitializeMail(mailSender, mailReceiver);
            Mail.Body = mailBody;
            Mail.IsBodyHtml = IsMailHtml;
            Mail.Subject = mailSubject;
            if (requestAnswer) Mail.Headers.Add("Disposition-Notification-To", mailSender);
            foreach (String atachement in mailAttachements)
            {
                Mail.Attachments.Add(new Attachment(atachement));
            }
            Client.Send(Mail);
        }
        #endregion
        #region Sender
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        public void SendMail(String username, String password)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="useAddresses">the use of the email addresses</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            UseMailAddresses = useAddresses;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="displayName">the display name for the email</param>
        /// <param name="useAddresses">the use of the email addresses</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            UseMailAddresses = useAddresses;
            SendMail();
        }
        #endregion
        #region Sender - Receiver
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        public void SendMail(String username, String password, String recepient)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="useAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            UseMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="displayName">the display name for the email</param>
        /// <param name="useAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            UseMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        public void SendMail(String username, String password, String recepient, String mailSubject)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="useAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            UseMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="displayName">the display name for the email</param>
        /// <param name="useAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            UseMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="useAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            UseMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative email display value</param>
        /// <param name="displayName">the display name for the email</param>
        /// <param name="useAddresses">the use of the email addresses</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            UseMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody,  Boolean isBodyHtml)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - requestAnswer
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and request a response from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and request a response from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and request a response from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="mailBody">the current emails body</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - Attachement
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachement);
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - Attachement
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachement);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachement);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachement);
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - requestAnswer - Attachement
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement and request an answer from the receiver
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachement);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement and request an answer from the receiver
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachement);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachement and request an answer from the receiver
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachement">the current emails attachement</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String attachement)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachement);
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - Attachement Array
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachements);
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - Attachement Array
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachements);
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - requestAnswer - Attachement Array
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements and requests an answer from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements and requests an answer from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements and requests an answer from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, String[] attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - Attachement List
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            AddAtachement(attachementList);
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - Attachement List
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachementList);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachementList);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="attachementList">the current emails attachements list</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, List<String> attachementList)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            AddAtachement(attachementList);
            SendMail();
        }
        #endregion
        #region Sender - Receiver - MailSubject - MailBody - isBodyHtml - requestedAnswer - Attachement List
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements and requests an answer from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, List<String> attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements and requests an answer from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String alternativeEmail, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, List<String> attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            SendMail();
        }
        /// <summary>
        /// this function will set the username and password from the settings and send the current mail from the given address to the given recepient with the given subject and body and attachements and requests an answer from the recipient
        /// </summary>
        /// <param name="username">the mail username</param>
        /// <param name="password">the mail password</param>
        /// <param name="alternativeEmail">the alternative mail address</param>
        /// <param name="displayName">the display name linked to the sender Address</param>
        /// <param name="useAddresses">the setting to dictate the use of MailAddress Objects</param>
        /// <param name="recepient">the recepient of the curent email</param>
        /// <param name="mailSubject">the current emails subject</param>
        /// <param name="mailBody">the current emails body</param>
        /// <param name="isBodyHtml">the formatting of the email body</param>
        /// <param name="requestAnswer">the header formatting to request an answer from the recipient</param>
        /// <param name="attachements">the current emails attachements array</param>
        public void SendMail(String username, String password, String alternativeEmail, String displayName, Boolean useAddresses, String recepient, String mailSubject, String mailBody, Boolean isBodyHtml, Boolean requestAnswer, List<String> attachements)
        {
            SetSenderAddress = username;
            SetMailPassword = password;
            SetMailSenderAlternative = alternativeEmail;
            SetMailDisplayName = displayName;
            useMailAddresses = useAddresses;
            SetMailReceiver = recepient;
            SetMailSubject = mailSubject;
            SetMailBody = mailBody;
            FormatMailBody = isBodyHtml;
            RequestResponse = requestAnswer;
            AddAtachement(attachements);
            SendMail();
        }
        #endregion
        #endregion
    }
}