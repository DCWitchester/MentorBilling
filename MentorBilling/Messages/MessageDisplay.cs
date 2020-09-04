using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Messages
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
            DatabaseError = 1
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
    }
}
