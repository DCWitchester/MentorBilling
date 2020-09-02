using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MentorBilling.Messages.MessageSettings;

namespace MentorBilling.Settings
{
    public class GlobalDisplaySettings
    {
        public static Boolean MessageWaiting { get; set; } = false;
        public static MessageTypes CurrentError { get; set; } = 0;
    }
}
