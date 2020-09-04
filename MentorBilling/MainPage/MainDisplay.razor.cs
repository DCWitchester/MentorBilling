﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MentorBilling.MainPage
{
    public partial class MainDisplay
    {
        #region DisplayController
        /// <summary>
        /// the main initialization of the page
        /// </summary>
        protected override void OnInitialized()
        {
            //we add the Change Handler
            DisplaySettings.OnChange += OnMyChangeHandler;
            base.OnInitialized();
        }
        /// <summary>
        /// the dispose of the page
        /// </summary>
        public void Dispose()
        {
            DisplaySettings.OnChange -= OnMyChangeHandler;
        }
        /// <summary>
        /// the  main handler for the state change
        /// </summary>
        private async void OnMyChangeHandler()
        {
            await InvokeAsync(() => StateHasChanged());
        }
        #endregion
    }
}