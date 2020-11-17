using MentorBilling.SettingsComponents.Controllers;
using Microsoft.AspNetCore.Components;

namespace MentorBilling.SettingsComponents.Pages
{
    public partial class SettingComponent
    {
        [Parameter]
        public GeneralComponentController PageController { get; set; }
    }
}
