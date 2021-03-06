﻿using MentorBilling.Database.DatabaseController;
using MentorBilling.Miscellaneous;
using Microsoft.Extensions.Configuration;

namespace MentorBilling.Settings
{
    public class Settings
    {

#pragma warning disable IDE1006 // Naming Styles
        /// <summary>
        /// the global databaseConnectionSetting property
        /// </summary>
        private static DatabaseConnectionSettings databaseConnectionSettings { get; set; } = new DatabaseConnectionSettings();
        /// <summary>
        /// the database connection settings for accessing the juridical Entity
        /// </summary>
        private static DatabaseConnectionSettings juridicalEntityConnectionSettings { get; set; } = new DatabaseConnectionSettings();
#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// the public getter and setter for the  databaseConnectionSettings
        /// </summary>
        public static DatabaseConnectionSettings DatabaseConnectionSettings
        {
            get => databaseConnectionSettings;
            set => databaseConnectionSettings = value;
        }

        /// <summary>
        /// the public getter and setter for the juridicalEntityConnectionSettings
        /// </summary>
        public static DatabaseConnectionSettings JuridicalEntityConnectionSettings 
        { 
            get => juridicalEntityConnectionSettings;
            set => juridicalEntityConnectionSettings = value; 
        }

        /// <summary>
        /// this function will consume the JSON IConfiguration and update the Settings Value
        /// </summary>
        /// <param name="configuration">the main configuration</param>
        public static void ConsumeJSONSettings(IConfiguration configuration) 
        {
            //we initialize the encryption to be able to decrypt the data from the Config file
            Encryption encryption = new Encryption();
            //then we retrieve the settings from the config file
            #region Database Connection
            DatabaseConnectionSettings.Database         = encryption.Decrypt(configuration["PublicSettings:DatabaseSettings:Database"]);
            DatabaseConnectionSettings.Host             = encryption.Decrypt(configuration["PublicSettings:DatabaseSettings:Host"]);
            DatabaseConnectionSettings.Password         = encryption.Decrypt(configuration["PublicSettings:DatabaseSettings:Password"]);
            DatabaseConnectionSettings.Port             = encryption.Decrypt(configuration["PublicSettings:DatabaseSettings:Port"]);
            DatabaseConnectionSettings.UserID           = encryption.Decrypt(configuration["PublicSettings:DatabaseSettings:UserID"]);
            #endregion Database Connection
            #region Juridical Entity Connection Settings
            JuridicalEntityConnectionSettings.Database  = encryption.Decrypt(configuration["PublicSettings:JuridicalEntityDatabaseSettings:Database"]);
            JuridicalEntityConnectionSettings.Host      = encryption.Decrypt(configuration["PublicSettings:JuridicalEntityDatabaseSettings:Host"]);
            JuridicalEntityConnectionSettings.Password  = encryption.Decrypt(configuration["PublicSettings:JuridicalEntityDatabaseSettings:Password"]);
            JuridicalEntityConnectionSettings.Port      = encryption.Decrypt(configuration["PublicSettings:JuridicalEntityDatabaseSettings:Port"]);
            JuridicalEntityConnectionSettings.UserID    = encryption.Decrypt(configuration["PublicSettings:JuridicalEntityDatabaseSettings:UserID"]);
            #endregion
        }

    }
}
