using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink.UserSettings
{
    public class MenuFunctions
    {
        /// <summary>
        /// the main Database connection for this class
        /// </summary>
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        public static void GetUserMenu(User user)
        {
            String QueryCommand = "SELECT * FROM settings.meniu_utilizatori";
        }
    }
}
