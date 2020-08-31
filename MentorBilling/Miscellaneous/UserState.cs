using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Miscellaneous
{
    public class UserState
    {
        public enum UserStates
        {
            loggingIn = 0,
            loggedOut = 1,
            loggedIn = 2
        }
    }
}
