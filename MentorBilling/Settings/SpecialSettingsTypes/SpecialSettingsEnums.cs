﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Settings.SpecialSettingsTypes
{
    public class SpecialSettingsEnums
    {
        /// <summary>
        /// the CountryISOType bound to the Settings
        /// </summary>
        public enum CountryISOType
        {
            ISO2 = 0,
            ISO3 = 1,
            ISOM49
        }
        /// <summary>
        /// the CountryName bound to the Settings
        /// </summary>
        public enum CountryName
        {
            RO = 0,
            EN = 1
        }

        /// <summary>
        /// the database settings link
        /// </summary>
        public enum DatabaseSettingsLink 
        {
            SellerControl = 0,
            CountryISO = 1,
            CountryName = 2
        }
    }
}
