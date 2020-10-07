﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorBilling.Settings.SpecialSettingsTypes;
using MentorBilling.SettingsComponents;

namespace MentorBilling.Settings
{
    public class InstanceSettings
    {
        /// <summary>
        /// the SellerControl for the instance
        /// </summary>
        public Boolean SellerControl { get; set; } = false;
        /// <summary>
        /// the countryISO for the instance
        /// </summary>
        public SpecialSettingsEnums.CountryISOType CountryISO { get; set; } = SpecialSettingsEnums.CountryISOType.ISO2;
        /// <summary>
        /// the countryName for the instance
        /// </summary>
        public SpecialSettingsEnums.CountryName CountryName { get; set; } = SpecialSettingsEnums.CountryName.RO;

        //TODO: Link the Settings to the Database
        /// <summary>
        /// this function will consume the settings list and set the settings needed values
        /// </summary>
        /// <param name="settings">the complete settings list</param>
        public void ConsumeSettings(List<Setting> settings)
        {
            foreach(Setting setting in settings)
            {
                switch (setting.ID)
                {
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.SellerControl:
                        this.SellerControl = setting.GetBooleanValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.CountryISO:
                        this.CountryISO = (SpecialSettingsEnums.CountryISOType)setting.GetIntegerValue;
                        break;
                    case (Int32)SpecialSettingsEnums.DatabaseSettingsLink.CountryName:
                        this.CountryName = (SpecialSettingsEnums.CountryName)setting.GetIntegerValue;
                        break;
                }
            }
        }

    }
}
