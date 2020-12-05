using MentorBilling.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Invoice.Controllers
{
    public class InvoiceDetailsController
    {
        #region Settings Link
        /// <summary>
        /// the instance settings received from the parent
        /// </summary>
        readonly InstanceSettings instanceSettings;
        #endregion

        #region Display Settings
        /// <summary>
        /// <br> the property dictating the active status of the add/alter element </br>
        /// <br> linked to the Active Element Display </br>
        /// </summary>
        private Boolean IsElementDisplayActive { get; set; } = false;

        /// <summary>
        /// <br> the property dictating the active status of the add/alter element </br>
        /// <br> linked to the Active Element Display </br>
        /// </summary>
        public String ActiveElementVisibility => IsElementDisplayActive ? "visible" : "hidden" ;
        #endregion

        #region Controller
        /// <summary>
        /// the complete list of invoice detail items
        /// </summary>
        public List<InvoiceDetailController> InvoiceDetailControllers { get; set; } = new List<InvoiceDetailController>();

        /// <summary>
        /// <br> the selected invoice detail </br>
        /// <br> used for add / alter element </br>
        /// </summary>
        public InvoiceDetailController ActiveDetailController { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// this is the main constructor for the class
        /// </summary>
        public InvoiceDetailsController() { }

        /// <summary>
        /// this constructor will initialize the controller with the instance settings
        /// </summary>
        /// <param name="settings">the instance settings</param>
        public InvoiceDetailsController(InstanceSettings settings)
        {
            instanceSettings = settings;
        }
        #endregion

        #region Functionality
        #region Public Functionality
        /// <summary>
        /// this function will initialize the detail element as needed
        /// </summary>
        public void InitializeActiveDetailElement()
        {
            ActiveDetailController = new InvoiceDetailController(instanceSettings);
            ShowActiveElement();
        }

        /// <summary>
        /// this function will initialize the ActiveDetailController with a given controller
        /// </summary>
        /// <param name="invoiceDetailController">the given controller</param>
        public void InitializeActiveDetailElement(InvoiceDetailController invoiceDetailController)
        {
            ActiveDetailController = invoiceDetailController;
            ShowActiveElement();
        }

        /// <summary>
        /// this function will save the active element to the list if it is a new element
        /// </summary>
        public void SaveNewActiveElement()
        {
            InvoiceDetailControllers.Add(ActiveDetailController);
            ActiveDetailController = new InvoiceDetailController(instanceSettings);
            HideActiveElement();
        }

        /// <summary>
        /// this function will save the active element that is already linked to the list
        /// </summary>
        public void SaveExistingElement()
        {
            ActiveDetailController = new InvoiceDetailController(instanceSettings);
            HideActiveElement();
        }
        #endregion Public Functionality

        #region Private Functionality
        /// <summary>
        /// this function will show the active element display object
        /// </summary>
        private void ShowActiveElement()
        {
            IsElementDisplayActive = true;
        }

        /// <summary>
        /// this function will hide the active element display object
        /// </summary>
        private void HideActiveElement()
        {
            IsElementDisplayActive = false;
        }
        #endregion Private Functionality
        #endregion
    }
}
