using MentorBilling.Database.DatabaseController;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink
{
    public class UserFunctions
    {
        readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        public static Boolean CheckUser()
        {

        }
    }
}
