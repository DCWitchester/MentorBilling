using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous;
using MentorBilling.ObjectStructures;
using Microsoft.AspNetCore.Mvc.Formatters;
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
        public static Subscription ActiveSubscription { get; set; } = new Subscription();
    }
}
