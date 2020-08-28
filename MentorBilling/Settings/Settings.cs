using MentorBilling.Database.DatabaseController;
using Microsoft.Extensions.Configuration;

namespace MentorBilling.Settings
{
    public class Settings
    {
        /// <summary>
        /// the global databaseConnectionSetting property
        /// </summary>
#pragma warning disable IDE1006 // Naming Styles
        private static DatabaseConnectionSettings databaseConnectionSettings { get; set; } = new DatabaseConnectionSettings();
#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// the public getter and setter for the  databaseConnectionSettings
        /// </summary>
        public static DatabaseConnectionSettings DatabaseConnectionSettings
        {
            get => databaseConnectionSettings;
            set => databaseConnectionSettings = value;
        }

        public static void ConsumeJSONSettings(IConfiguration configuration) 
        {
            
        }

    }
}
