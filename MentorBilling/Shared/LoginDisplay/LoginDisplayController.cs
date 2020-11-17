using System;

namespace MentorBilling.Shared.LoginDisplay
{
    public class LoginDisplayController
    {
#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the user state property
        /// </summary>
        private Miscellaneous.UserState.UserStates userState { get; set; } = Miscellaneous.UserState.UserStates.loggedOut;
#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// the main caller for the user state property
        /// </summary>
        public Miscellaneous.UserState.UserStates UserState
        {
            get => userState;
        }

        /// <summary>
        /// the onChange Action Caller => will contain the invocable action on the page refresh
        /// </summary>
        public event Action OnChange;

        /// <summary>
        /// this function will call the Message for Display
        /// </summary>
        /// <param name="userStates">the current state for the controller</param>
        public void ChangeMessageType(Miscellaneous.UserState.UserStates userStates)
        {
            userState = userStates;
            NotifyStateChanged();
        }

        /// <summary>
        /// this function will invoke the OnChange Event for the form
        /// </summary>
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
