using MentorBilling.ControllerService;
using MentorBilling.SettingsComponents.Controllers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.SettingsComponents.Pages
{
    public partial class SettingsPage
    {
        [Parameter]
        public InstanceController InstanceController { get; set; }

        List<GeneralComponentController> GeneralComponentControllers { get; set; } = new List<GeneralComponentController>();
    }
}
