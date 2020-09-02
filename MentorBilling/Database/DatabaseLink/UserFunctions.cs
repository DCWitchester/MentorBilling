﻿using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink
{
    public class UserFunctions
    {
        static readonly PosgreSqlConnection PgSqlConnection = new PosgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        #region RegistrationFunctions
        public static Boolean CheckUsername(RegisterController registerController)
        {
            String sqlCommand = "SELECT COUNT(*) FROM users.utilizatori WHERE nume_utilizator = :p_username";
            NpgsqlParameter npgsqlParameter = new NpgsqlParameter(":p_username",registerController.Username);
            if (!PgSqlConnection.OpenConnection()) return false;
            Boolean result = (Int64)PgSqlConnection.ExecuteScalar(sqlCommand, npgsqlParameter ) > 0;
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            return result;
        }

        public static Boolean CheckEmail(RegisterController registerController)
        {
            String sqlCommand = "SELECT COUNT(*) FROM users.utilizatori WHERE email = :p_email";
            NpgsqlParameter npgsqlParameter = new NpgsqlParameter(":p_email", registerController.Email);
            if (!PgSqlConnection.OpenConnection()) return false;
            Boolean result = (Int64)PgSqlConnection.ExecuteScalar(sqlCommand, npgsqlParameter) > 0;
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            return result;
        }

        public static Boolean RegisterUser(RegisterController registerController)
        {
            String sqlCommand = "INSERT INTO users.utilizatori(nume_utilizator,email,parola,nume,prenume) " +
                                    "VALUES(:p_username,:p_email,:p_password,:p_surname,:p_name)";
            NpgsqlParameter[] npgsqlParameter =
            {
                new NpgsqlParameter("p_username",registerController.Username),
                new NpgsqlParameter("p_email",registerController.Email),
                new NpgsqlParameter("p_password",registerController.Password),
                new NpgsqlParameter("p_surname",registerController.Surname),
                new NpgsqlParameter("p_name",registerController.Name)
            };
            return false;
        }
        #endregion
    }
}
