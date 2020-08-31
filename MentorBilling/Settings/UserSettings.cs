using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Settings
{
    public class UserSettings
    {
        public static User LoggedInUser { get; set; } = new User();
        public static UserState.UserStates UserState = Miscellaneous.UserState.UserStates.loggedOut;
    }
}
