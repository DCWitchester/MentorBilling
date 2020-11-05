using MentorBilling.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Auxilliary
{
    public class Country
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the main id property used for linking between objects
        /// </summary>
        private Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the countryCode type ISO2
        /// </summary>
        private String countryCodeISO2 { get; set; } = String.Empty;
        /// <summary>
        /// the countryCode type ISO3
        /// </summary>
        private String countryCodeISO3 { get; set; } = String.Empty;
        /// <summary>
        /// the countryCode type M49
        /// </summary>
        private String countryCodeM49 { get; set; } = String.Empty;
        /// <summary>
        /// the romanian language CountryName
        /// </summary>
        private String romanianName { get; set; } = String.Empty;
        /// <summary>
        /// the english language CountryName
        /// </summary>
        private String englishName { get; set; } = String.Empty;
#pragma warning restore IDE1006
        #endregion

        #region Callers
        /// <summary>
        /// the main caller for the ID property
        /// </summary>
        public Int64 ID
        {
            get => id;
            set => id = value;
        }
        /// <summary>
        /// the main caller for the ISO2 CountryCode
        /// </summary>
        public String CountryCodeISO2 
        { 
            get => countryCodeISO2; 
            set => countryCodeISO2 = value; 
        }
        /// <summary>
        /// the main caller for the ISO3 CountryCode
        /// </summary>
        public String CountryCodeISO3
        {
            get => countryCodeISO3;
            set => countryCodeISO3 = value;
        }
        /// <summary>
        /// the main caller for the M49 CountryCode
        /// </summary>
        public String CountryCodeM49
        {
            get => countryCodeM49;
            set => countryCodeM49 = value;
        }
        /// <summary>
        /// the romanian name for the language
        /// </summary>
        public String RomanianName
        {
            get => romanianName;
            set => romanianName = value;
        }
        /// <summary>
        /// the english name for the language
        /// </summary>
        public String EnglishName
        {
            get => englishName;
            set => englishName = value;
        }
        /// <summary>
        /// the default value for the code
        /// </summary>
        public String DefaultCode
        {
            get => countryCodeISO2;
            set => countryCodeISO2 = value;
        }
        /// <summary>
        /// the default value for the name
        /// </summary>
        public String DefaultName
        {
            get => romanianName;
            set => romanianName = value;
        }
        /// <summary>
        /// the display name based on the default value
        /// </summary>
        public String DefaultDisplayName
        {
            get => DefaultCode + ":" + DefaultDisplayName;
        }
        #endregion Callers

        #region Parameterized Callers
        /// <summary>
        /// this function will retrieve the country code based on the instance settings
        /// </summary>
        /// <param name="settings">the current instance settings</param>
        /// <returns>the country ISO2</returns>
        public String GetCountryCodeForSettings(InstanceSettings settings)
        {
            return settings.CountryISO switch
            {
                Settings.SpecialSettingsTypes.SpecialSettingsEnums.CountryISOType.ISO2      => CountryCodeISO2,
                Settings.SpecialSettingsTypes.SpecialSettingsEnums.CountryISOType.ISO3      => CountryCodeISO3,
                Settings.SpecialSettingsTypes.SpecialSettingsEnums.CountryISOType.ISOM49    => CountryCodeM49,
                _ => CountryCodeISO2
            };
        }

        /// <summary>
        /// this function will retrieve the country name based on the instance settings
        /// </summary>
        /// <param name="settings">the current instance settings</param>
        /// <returns>the country name</returns>
        public String GetCountryNameForSetting(InstanceSettings settings)
        {
            return settings.CountryName switch
            {
                Settings.SpecialSettingsTypes.SpecialSettingsEnums.CountryName.EN => EnglishName,
                Settings.SpecialSettingsTypes.SpecialSettingsEnums.CountryName.RO => RomanianName,
                _ => RomanianName
            };
        }

        /// <summary>
        /// this function will retrieve the display name based on the instance settings
        /// </summary>
        /// <param name="settings">the instance settings</param>
        /// <returns>the country </returns>
        public String GetDisplayNameForSettings(InstanceSettings settings)
        {
            return GetCountryCodeForSettings(settings) + ":" + GetCountryNameForSetting(settings);
        }

        /// <summary>
        /// this function will check if this country is Romania or not
        /// </summary>
        public Boolean IsCountryRomania => countryCodeISO2.ToUpper().Trim().Equals("RO");
        #endregion
    }
}
