using MentorBilling.Login.UserControllers;
using MentorBilling.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MentorBilling.Miscellaneous.Menu
{
    public class Menu
    {
        /// <summary>
        /// the enum containing all the possible elements of the menu
        /// </summary>
        enum MenuItems
        {
            subscriptions = 0,
            groups,
            invoices,
            settings
        }

        /// <summary>
        /// the user menu generated for the specific user
        /// </summary>
        public List<MenuItem> UserMenu = new List<MenuItem>();

        /// <summary>
        /// the main Menu Initializer without any parameters
        /// </summary>
        public  Menu()
        {
            InitializeMenu();
        }

        /// <summary>
        /// this function will initialize the UserMenu list
        /// </summary>
        void InitializeMenu()
        {
            //we will iterate through the possible values of the enum
            foreach(MenuItems menuItems in Enum.GetValues(typeof(MenuItems)))
            {
                //for each possible value of the enum
                //we add a new value
                UserMenu.Add(
                    //the newly added values are decided by the switch
                    //for each possible value we call the linked function
                    menuItems switch
                    {
                        MenuItems.subscriptions => InitializeSubscription(),
                        MenuItems.groups => InitializeGroup(),
                        MenuItems.invoices => InitializeInvoices(),
                        MenuItems.settings => InitializeSettings(),
                        //the default value is an empty item
                        _ => InitializeVoidItem()
                    }) ;
            }
        }

        #region Menu Updating
        /// <summary>
        /// this function will link the current menu settings to a specific user
        /// </summary>
        /// <param name="user">the given user</param>
        public void InitializeUserMenuSettingsForUser(User user)
        {
            //the menu settings for the generation
            Database.DatabaseLink.UserSettings.MenuFunctions.GenerateMenuSettingsForUser(user, UserMenu);
        }

        /// <summary>
        /// this function will update the given users menu settings with the current menu
        /// </summary>
        /// <param name="user">the given user</param>
        public void UpdateMenuSettings(User user)
        {
            Database.DatabaseLink.UserSettings.MenuFunctions.UpdateMenuSettingsForUser(user, UserMenu);
        }

        /// <summary>
        /// this function will disable all element items from the menu
        /// </summary>
        public void DeactivateMenu()
        {
            //foreach is an awesome linq extension
            UserMenu.ForEach(element => element.IsActive = false);
        }

        /// <summary>
        /// this function will bind the actions on the menu
        /// </summary>
        /// <param name="displaySettings">the display settings of the parent</param>
        public void SetMenuActions(DisplaySettings displaySettings)
        {
            //we initialize the settings action
            SetSettingsAction(displaySettings);
            //we initialize the subscription settings
            SetSubscriptionAction(displaySettings);
        }
        #endregion

        #region MenuActions
        /// <summary>
        /// this function will set the settingsAction for the menu
        /// </summary>
        /// <param name="displaySettings">the display settings</param>
        void SetSettingsAction(DisplaySettings displaySettings)
        {
            //the menu settings
            MenuItem settings = UserMenu.Where(x => x.MenuItemID == (Int32)MenuItems.settings).First();
            //the action for the item
            settings.MenuAction += (()=>ComponentDisplay.CallSettings(displaySettings));
        }

        /// <summary>
        /// this function will set the settingsAction for the menu
        /// </summary>
        /// <param name="displaySettings">the display settings</param>
        void SetSubscriptionAction(DisplaySettings displaySettings)
        {
            //the menu subscription
            MenuItem subscription = UserMenu.Where(x => x.MenuItemID == (Int32)MenuItems.subscriptions).First();
            //the action for the item
            subscription.MenuAction += (() => ComponentDisplay.CallSettings(displaySettings));
        }
        #endregion

        #region Item Initialization
        /// <summary>
        /// this function will return a subscription based menu item
        /// </summary>
        /// <returns>the menu item</returns>
        static MenuItem InitializeSubscription()
        {
            return new MenuItem()
            {
                //the id is set to the enum for the utmost control
                MenuItemID = (Int32)MenuItems.subscriptions,
                MenuDisplay = "Gestionare Abonamente",
                IsActive = true
            };
        }

        /// <summary>
        /// this function will generate a group based menu item
        /// </summary>
        /// <returns>the menu item</returns>
        static MenuItem InitializeGroup()
        {
            return new MenuItem()
            {
                //the id is set to the enum for the utmost control
                MenuItemID = (Int32)MenuItems.groups,
                MenuDisplay = "Gestionare Grupuri",
                IsActive = true
            };
        }

        /// <summary>
        /// this function will generate an invoice based menu item
        /// </summary>
        /// <returns>the menu item</returns>
        static MenuItem InitializeInvoices()
        {
            return new MenuItem()
            {
                //the id is set to the enum for the utmost control
                MenuItemID = (Int32)MenuItems.invoices,
                MenuDisplay = "Facturile Mele / Scadentar",
                IsActive = true
            };
        }

        /// <summary>
        /// this function will generate a settings based menu item
        /// </summary>
        /// <returns>the menu item</returns>
        static MenuItem InitializeSettings()
        {
            return new MenuItem()
            {
                //the id is set to the enum for the utmost control
                MenuItemID = (Int32)MenuItems.settings,
                MenuDisplay = "Setari Facturare",
                IsActive = true
            };
        }

        /// <summary>
        /// this function will generate an empty menu item
        /// </summary>
        /// <returns>the menu item</returns>
        static MenuItem InitializeVoidItem()
        {
            return new MenuItem();
        }

        #endregion
    }
}
