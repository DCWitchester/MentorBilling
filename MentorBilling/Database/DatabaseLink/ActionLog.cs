using MentorBilling.Database.DatabaseController;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink
{
    public class ActionLog
    {
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        public static void LogAction(String Action)
        {
            String QueryCommand = "INSERT INTO log.log_utilizatori(actiune) VALUES(:p_action)";
            NpgsqlParameter QueryParameter = new NpgsqlParameter("p_action",Action);
        }
    }
}
