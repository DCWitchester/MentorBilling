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
    public partial class CountriesPicker
    {
        /// <summary>
        /// the instance controller for the user instance
        /// </summary>
        [Parameter]
        public InstanceController InstanceController { get; set; }
        /// <summary>
        /// the page controller linked to the razor
        /// </summary>
        [Parameter]
        public CountriesController PageController { get; set; }

        #region Form Binding
        /// <summary>
        /// the edit form reference used for page refresh
        /// </summary>
        private EditForm MyForm { get; set; }

        /// <summary>
        /// the main editContext on the Page
        /// </summary>
        private EditContext EditContext { get; set; }

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
