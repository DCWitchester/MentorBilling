using MentorBilling.Login.UserControllers;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace MentorBilling.MiscellaneousPages
{
    public partial class ValidateAccount
    {
        [Parameter]
        public String AccountID { get; set; }

        User User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(() => RetriveUser()).ContinueWith(t => ActivateUser());
        }

        /// <summary>
        /// this function will retrieve the parameters from the encrypted String
        /// </summary>
        /// <returns>the value of the ID</returns>
        Int64 RetrieveParameter()
        {
            Miscellaneous.Encryption encryption = new Miscellaneous.Encryption();
            return Convert.ToInt64(encryption.Decrypt(AccountID));
        }

        /// <summary>
        /// this function will retrieve the user from the database
        /// </summary>
        void RetriveUser()
        {
            User = Database.DatabaseLink.UserFunctions.RetrieveUser(RetrieveParameter());
        }

        /// <summary>
        /// this function will activate a user in the database side
        /// </summary>
        void ActivateUser()
        {
            if (User == null)
                Messages.MessageDisplay.CallDatabaseError(MessageDisplaySettings);
            else 
                Database.DatabaseLink.SubscriptionFunctions.ActivateTrialSubscription(User);
        }
    }
}
