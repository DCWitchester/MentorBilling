using MentorBilling.Database.DatabaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Settings
{
    public class Settings
    {
#pragma warning disable IDE1006 // Naming Styles
        private static DatabaseConnectionSettings databaseConnectionSettings { get; set; } = new DatabaseConnectionSettings();
#pragma warning restore IDE1006 // Naming Styles

        public static DatabaseConnectionSettings DatabaseConnectionSettings
        {
            get => databaseConnectionSettings;
            set => databaseConnectionSettings = value;
        }
    }
}
