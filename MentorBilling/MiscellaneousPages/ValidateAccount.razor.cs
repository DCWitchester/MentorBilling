using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous.Menu;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace MentorBilling.MiscellaneousPages
{
    public partial class ValidateAccount
    {
        [Parameter]
        public String Account { get; set; }

        User User { get; set; } = new User();

        Boolean ErrorMessage { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(() => RetriveUser()).ContinueWith(t => ActivateUser()).ContinueWith(t=>ActivateMenu());
        }

        /// <summary>
        /// this function will retrieve the parameters from the encrypted String
        /// </summary>
        /// <returns>the value of the ID</returns>
        Int64 RetrieveParameter()
        {
            Miscellaneous.Encryption encryption = new Miscellaneous.Encryption();
            return Convert.ToInt64(encryption.Decrypt(Account.Replace("\"","")));
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
                ErrorMessage = true;
            else
                Database.DatabaseLink.SubscriptionFunctions.ActivateTrialSubscription(User);
        }

        /// <summary>
        /// this function will also enable the menu options for the currently activated account
        /// </summary>
        void ActivateMenu()
        {
            //we initialize a new menu item
            Menu menu = new Menu();
            //and we call the update of the menu settings
            menu.UpdateMenuSettings(User);
        }
    }
}
