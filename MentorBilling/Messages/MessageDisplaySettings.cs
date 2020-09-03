using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Messages
{
    public class MessageDisplaySettings
    {

#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the messageWaiting property
        /// </summary>
        private static Boolean messageWaiting { get; set; } = false;


        /// <summary>
        /// the CurrentError property for the message display
        /// </summary>
        private static MessageSettings.MessageTypes currentError { get; set; } = MessageSettings.MessageTypes.None;
#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// the main caller for the messageWaiting property
        /// </summary>
        public static Boolean MessageWaiting
        {
            get => messageWaiting;
        }

        /// <summary>
        /// the main caller for the currentError property
        /// </summary>
        public static MessageSettings.MessageTypes CurrentError
        {
            get => currentError;
        }

        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on the page refresh
        /// </summary>
        public event Action OnChange;

        /// <summary>
        /// this function will call the Message for Display
        /// </summary>
        /// <param name="message">the message that should be displayed</param>
        public void ChangeMessageType(MessageSettings.MessageTypes message)
        {
            //we set the message
            currentError = message;
            //if there is a message we also call the display
            if (message == MessageSettings.MessageTypes.None) messageWaiting = false;
            else messageWaiting = true;
            //before notifying the change
            NotifyStateChanged();
        }

        /// <summary>
        /// this function will invoke the OnChange Event for the form
        /// </summary>
        private void NotifyStateChanged() => OnChange?.Invoke();

    }
}
