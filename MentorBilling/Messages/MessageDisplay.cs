﻿namespace MentorBilling.Messages
{
    public class MessageDisplay
    {
        /// <summary>
        /// the main enum for the Message Display
        /// </summary>
        public enum MessageTypes
        {
            //no error to display
            None = 0,
            //database Error to dispaly
            DatabaseError = 1,
            //the invalid subscription message
            InvalidSubscription = 2,
            //the logout warning message
            Logout = 3,
            //the inactive partner error
            InactivePartner
        }

        /// <summary>
        /// this function will display the database error message
        /// </summary>
        /// <param name="messageDisplaySettings"></param>
        public static void CallDatabaseError(MessageDisplaySettings messageDisplaySettings)
        {
            messageDisplaySettings.ChangeMessageType(MessageTypes.DatabaseError);
        }

        /// <summary>
        /// this function will remove all error messages
        /// </summary>
        /// <param name="messageDisplaySettings"></param>
        public static void CallMain(MessageDisplaySettings messageDisplaySettings)
        {
            messageDisplaySettings.ChangeMessageType(MessageTypes.None);
        }

        /// <summary>
        /// this function will call the subscription error
        /// </summary>
        /// <param name="messageDisplaySettings"></param>
        public static void CallSubscriptionError(MessageDisplaySettings messageDisplaySettings)
        {
            messageDisplaySettings.ChangeMessageType(MessageTypes.InvalidSubscription);
        }

        /// <summary>
        /// this function will call the logoutWarning message
        /// </summary>
        /// <param name="messageDisplaySettings"></param>
        public static void CallLogoutWarning(MessageDisplaySettings messageDisplaySettings)
        {
            messageDisplaySettings.ChangeMessageType(MessageTypes.Logout);
        }

        public static void CallInactivePartner(MessageDisplaySettings messageDisplaySettings)
        {
            messageDisplaySettings.ChangeMessageType(MessageTypes.InactivePartner);
        }
    }
}
