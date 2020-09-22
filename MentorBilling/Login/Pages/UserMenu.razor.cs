using MentorBilling.ControllerService;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.Pages
{
    public partial class UserMenu
    {
        [Parameter]
        public InstanceController InstanceController { get; set; } = new InstanceController();

        Boolean IsMenuVisible { get; set; } = false;

        void DisplayMenu()
        {
            IsMenuVisible = !IsMenuVisible;
        }
    }
}
