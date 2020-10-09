using MentorBilling.AuxilliaryComponents.Controllers;
using MentorBilling.ControllerService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.AuxilliaryComponents.Pages
{
    public partial class CountiesPicker
    {
        #region Form Parameters
        /// <summary>
        /// the instance controller for the user instance
        /// </summary>
        [Parameter]
        public InstanceController InstanceController { get; set; }
        /// <summary>
        /// the page controller linked to the razor component
        /// </summary>
        [Parameter]
        public CountiesController PageController { get; set; }
        #endregion

        #region Form Binding
        /// <summary>
        /// the editform reference to the razor controller
        /// </summary>
        public EditForm MyForm { get; set; }

        /// <summary>
        /// the edit context bound to the page
        /// </summary>
        public EditContext EditContext { get; set; }

        /// <summary>
        /// the main initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            EditContext = new EditContext(PageController);
            base.OnInitialized();
        }
        #endregion
    }
}
