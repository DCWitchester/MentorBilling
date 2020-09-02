using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Messages
{
    public class MessageSettings
    {
        public enum MessageTypes
        {
            None = 0,
            DatabaseError = 1
        }
    }
}
