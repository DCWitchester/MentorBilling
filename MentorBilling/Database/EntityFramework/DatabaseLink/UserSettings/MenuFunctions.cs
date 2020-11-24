using MentorBilling.Database.EntityFramework.MentorBillingEntityFramework;
using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.EntityFramework.DatabaseLink.UserSettings
{
    public class MenuFunctions : MentorBillingContext
    {
        #region Select Functions
        /// <summary>
        /// this function will update the local menu with the settings from the database server for the specific user
        /// </summary>
        /// <param name="user">the specific user</param>
        /// <param name="menu">the instance menu</param>
        public void UpdateLocalUserMenu(User user, Menu menu)
        {
            List<MeniuUtilizator> localUserMenu = base.MeniuUtilizator.Where(element => element.UtilizatorId == user.ID).ToList();
            foreach(MenuItem menuItem in menu.UserMenu)
            {
                menuItem.IsActive = localUserMenu.Where(element => element.Id == menuItem.MenuItemID).FirstOrDefault().Activ ?? false;
            }
        }
        #endregion

        #region Insert Functions
        /// <summary>
        /// this function will create a new registry in the database for specific user settings
        /// </summary>
        /// <param name="user">the specific user</param>
        /// <param name="menuItem">the menu item</param>
        public void GenerateSpecificMenuSettingForUser(User user, MenuItem menuItem)
        {
            #region ActionLog
            //we format the log action for the element
            String logAction = String.Format("S-a generat setarea specifica pentru inregistrare {0} din meniu pentru utilizatorul {1}",
                                        menuItem.MenuDisplay,
                                        user.DisplayName);
            //we generate the log Command
            String logCommand = String.Format("INSERT INTO settings.meniu_utilizator(utilizator_id, inregistrare_meniu, activ) " +
                                    "VALUES({0},{1},{2})",
                                    user.ID,
                                    menuItem.MenuItemID,
                                    menuItem.IsActive);
            //we generate the Computer IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion

            MeniuUtilizator meniuUtilizator = new MeniuUtilizator
            {
                UtilizatorId = user.ID,
                InregistrareMeniu = menuItem.MenuItemID,
                Activ = menuItem.IsActive
            };

            base.MeniuUtilizator.Add(meniuUtilizator);

            base.LogActiuni.Add(ActionLog.LogAction(logAction, IP, logCommand));

            base.SaveChanges();
        }

        /// <summary>
        /// this function will generate the menu setting for a given user with one query
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="menuItems">the complete list of menu items</param>
        public void GenerateMenuSettingsForUser(User user, List<MenuItem> menuItems)
        {
            #region ActionLog
            //the specific log action
            String logAction = String.Format("S-au generat setarile generale din meniu pentru utilizatorul {0}",
                                        user.ID);
            //we generate the Computer IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion

            base.MeniuUtilizator.AddRange(menuItems.Select(element => new MeniuUtilizator
            {
                UtilizatorId = user.ID,
                InregistrareMeniu = element.MenuItemID,
                Activ = element.IsActive
            }
            ));

            base.LogActiuni.Add(ActionLog.LogAction(logAction, IP));

            base.SaveChanges();
        }
        #endregion

        #region Update Functions
        /// <summary>
        /// this function will update a given specific menu item into the database 
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="menuItem">the specific menu item</param>
        public void UpdateSpecificMenuSettingForUser(User user, MenuItem menuItem)
        {
            #region ActionLog
            //the main log display
            String logAction = $"S-a actualizat starea setari {menuItem.MenuDisplay} pentru utilizatorul {user.DisplayName}";
            String logCommand = $"UPDATE settings.meniu_utilizator SET activ = {menuItem.IsActive} " +
                                    $"WHERE utilizator_id = {user.ID} AND inregistrare_meniu = {menuItem.MenuItemID}";
            //the local element IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            MeniuUtilizator meniuUtilizator = base.MeniuUtilizator.Where(element => element.UtilizatorId == user.ID && element.InregistrareMeniu == menuItem.MenuItemID).FirstOrDefault();
            meniuUtilizator.Activ = menuItem.IsActive;

            base.Update(meniuUtilizator);

            base.LogActiuni.Add(ActionLog.LogAction(logAction, IP, logCommand));

            base.SaveChanges();

        }

        /// <summary>
        /// this function will update a given specific menu item into the database 
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="menuItems">the specific menu item</param>
        public void UpdateMenuSettingsForUser(User user, List<MenuItem> menuItems)
        {
            #region ActionLog
            //the main log display
            String logAction = $"S-a actualizat starea setarilor pentru utilizatorul {user.DisplayName}";
            //the local element IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion

            foreach(MenuItem menuItem in menuItems)
            {
                var element = base.MeniuUtilizator.Where(item => item.UtilizatorId == user.ID && item.InregistrareMeniu == menuItem.MenuItemID).FirstOrDefault();
                element.Activ = menuItem.IsActive;

                base.Update(element);
            }

            base.LogActiuni.Add(ActionLog.LogAction(logAction, IP));

            base.SaveChanges();
        }
        #endregion

    }
}
