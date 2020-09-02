using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Settings.Subscriptions
{
    public class SubscriptionSettings
    {
        /// <summary>
        /// this enum will contain a image of some subscriptions on the server: => Mostly for default subscription
        /// </summary>
        public enum Subscriptions
        {
            InactiveSubscription = 0,
            ActiveTrialSubscription = 1
        }
    }
}
