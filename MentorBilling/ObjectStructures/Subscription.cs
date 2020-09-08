using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures
{
    public class Subscription
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the id property for the object
        /// </summary>
        private Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the name property for the object
        /// </summary>
        private String name { get; set; } = String.Empty;
        /// <summary>
        /// the base monthly fee for the subscription
        /// </summary>
        private Double monthlyFee { get; set; } = new Double();
        /// <summary>
        /// the explanations for the Subscription
        /// </summary>
        private String explanations { get; set; } = String.Empty;
        /// <summary>
        /// the last payment made for the subscription
        /// </summary>
        private DateTime lastPayment { get; set; } = new DateTime();
        /// <summary>
        /// the base active period of the Subscription
        /// </summary>
        private Int32 activePeriod { get; set; } = new Int32();
        /// <summary>
        /// the subscriptionType property will be used for active group subscriptions
        /// </summary>
        private Int64 subscriptionType { get; set; } = new Int64();
#pragma warning restore IDE1006
        #endregion

        #region Callers
        /// <summary>
        /// the main caller for the id property
        /// </summary>
        public Int64 ID
        {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// the main caller for the name property
        /// </summary>
        public String Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// the main caller for the monthly fee property
        /// </summary>
        public Double MonthlyFee
        {
            get => monthlyFee;
            set => monthlyFee = value;
        }

        /// <summary>
        /// the main caller for the explanations property
        /// </summary>
        public String Explanations
        {
            get => explanations;
            set => explanations = value;
        }

        /// <summary>
        /// the main caller fot the lastPayment property
        /// </summary>
        public DateTime LastPayment
        {
            get => lastPayment;
            set => lastPayment = value;
        }

        /// <summary>
        /// the main caller for the active period property
        /// </summary>
        public Int32 ActivePeriod
        {
            get => activePeriod;
            set => activePeriod = value;
        }

        /// <summary>
        /// the main caller for the subscription type property
        /// </summary>
        public Int64 SubscriptionType
        {
            get => subscriptionType;
            set => subscriptionType = value;
        }

        /// <summary>
        /// the main checker for the validity of the subscription
        /// </summary>
        public Boolean IsSubscriptionValid => lastPayment.AddDays(activePeriod) > DateTime.Now;
        #endregion
    }
}
