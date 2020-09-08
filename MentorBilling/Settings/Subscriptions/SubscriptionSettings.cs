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
            //the intial inactive subscription
            InactiveSubscription = 0,
            //the initial active subscription
            ActiveTrialSubscription = 1,
            //the subscription for a user that is part of a group
            ActiveGroupSubscription = 2
        }
    }
}
