using MentorBilling.SettingsComponents.Controllers;
using Microsoft.AspNetCore.Components;

namespace MentorBilling.SettingsComponents.Pages
{
    public partial class DateTimePicker
    {
        [Parameter]
        public DateTimeController PageController { get; set; }
    }
}
