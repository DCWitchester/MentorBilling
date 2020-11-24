using MentorBilling.Database.EntityFramework.MentorBillingEntityFramework;
using MentorBilling.Login.UserControllers;
using MentorBilling.SettingsComponents;
using MentorBilling.SettingsComponents.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorBilling.Database.EntityFramework.DatabaseLink.UserSettings
{
    public class UserSettings : MentorBillingContext
    {
        #region Update Functions
        /// <summary>
        /// this function will update a solitary setting with the new setting value for a given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="setting">the setting</param>
        public void UpdateSettingValueForUser(User user, Setting setting)
        {
            #region Log Action
            //the specific log action
            String logAction = $"Actualizat valoarea setarii {setting.SettingDisplay} pentru utilizatorul {user.DisplayName}";
            //we generate the log Command
            String logCommand = "UPDATE setari_utilizatori " +
                                    $"SET valoare_setare = {setting.GetStringValue} " +
                                    $"WHERE utilizator_id = {user.ID} AND setare_id = {setting.ID}";
            //we generate the Computer IP
            String IP = MentorBilling.Miscellaneous.IPFunctions.GetWANIp();
            #endregion
            SetariUtilizatori setareUtilizator = base.SetariUtilizatori.Where(element => element.UtilizatorId == user.ID && element.SetareId == setting.ID).FirstOrDefault();
            setareUtilizator.ValoareSetare = setting.GetStringValue;
            base.Update(setareUtilizator);
            base.LogActiuni.Add(ActionLog.LogAction(logAction, IP, logCommand));
            base.SaveChanges();
        }

        /// <summary>
        /// this function will update a complete settings list for a given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <param name="settings">the complete settings list</param>
        public void UpdateSettingsValueForUser(User user, List<Setting> settings)
        {
            #region Log Action
            //the specific log action
            String logAction = $"Actualizat valoarea tuturor setarilor pentru utilizatorul {user.DisplayName}";
            //we use the string builder to make the command faster
            StringBuilder commandBuilder = new StringBuilder(250 * settings.Count);
            //we generate the Computer IP
            String IP = Miscellaneous.IPFunctions.GetWANIp();
            #endregion

            foreach(Setting setting in settings)
            {
                #region Action Log
                //we generate the log command for each inser command
                commandBuilder.Append("UPDATE setari_utilizatori " +
                                        $"SET valoare_setare = {setting.Value} " +
                                        $"WHERE utilizator_id = {user.ID} AND setare_id = {setting.ID}");
                #endregion
                SetariUtilizatori setareUtilizator = base.SetariUtilizatori.Where(element => element.UtilizatorId == user.ID && element.SetareId == setting.ID).FirstOrDefault();
                setareUtilizator.ValoareSetare = setting.GetStringValue;
                base.Update(setareUtilizator);
            }

            base.LogActiuni.Add(ActionLog.LogAction(logAction, IP, commandBuilder.ToString()));
        }
        #endregion

        #region Select Functions
        /// <summary>
        /// this function will retrieve the settings for a given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>a complete list of settings</returns>
        public List<Setting> RetrieveSettingsListForUser(User user)
        {
            return (from su in base.SetariUtilizatori
                    join s in base.Setari on su.SetareId equals s.Id
                    where su.UtilizatorId == user.ID
                    select new Setting
                    {
                        ID = s.Id,
                        DataTypes = (Settings.SettingTypes.SettingDataTypes)s.TipDateSetare,
                        SettingDisplay = s.Setare,
                        Value = (Object)su.ValoareSetare
                    }).ToList<Setting>();
        }

        /// <summary>
        /// this function will retrieve the complete list of settings from the Settings page for they also contain the dispaly info
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>the complete list of settings + display info </returns>
        public List<GeneralComponentController> RetrieveDisplayElementSettingsForUser(User user)
        {
            return (from su in base.SetariUtilizatori
                    join s in base.Setari
                    on su.SetareId equals s.Id
                    where su.UtilizatorId == user.ID
                    select new GeneralComponentController
                    {
                        ID = s.Id,
                        DataTypes = (Settings.SettingTypes.SettingDataTypes)s.TipDateSetare,
                        SettingDisplay = s.Setare,
                        Value = su.ValoareSetare,
                        InputTypes = (Settings.SettingTypes.SettingInputTypes)s.TipInputSetare,
                        Placeholder = s.Placeholder,
                        Tooltip = s.Tooltip
                    }).ToList();

        }
        #endregion

    }
}
