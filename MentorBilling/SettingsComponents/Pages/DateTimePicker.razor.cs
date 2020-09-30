using MentorBilling.SettingsComponents.Controllers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.SettingsComponents.Pages
{
    public partial class DateTimePicker
    {
        [Parameter]
        public DateTimeController PageController { get; set; }
    }
}
