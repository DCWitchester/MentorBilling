using MentorBilling.Database.DatabaseController;
using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous;
using MentorBilling.MiscellaneousPages.Controllers;
using Microsoft.AspNetCore.Http;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.DatabaseLink
{
    public class UserFunctions
    {
        /// <summary>
        /// the database connection for the current class
        /// </summary>
        static readonly PostgreSqlConnection PgSqlConnection = new PostgreSqlConnection(Settings.Settings.DatabaseConnectionSettings);

        #region RegistrationFunctions
        /// <summary>
        /// this function will check if there is already an account with the current register controllers username
        /// </summary>
        /// <param name="registerController">the current register controller</param>
        /// <returns>wether another account with the same username exists or not</returns>
        public static Boolean CheckUsername(RegisterController registerController)
        {
            String sqlCommand = "SELECT COUNT(*) FROM users.utilizatori WHERE nume_utilizator = :p_username";
            NpgsqlParameter npgsqlParameter = new NpgsqlParameter(":p_username",registerController.Username);
            if (!PgSqlConnection.OpenConnection()) return false;
            Boolean result = (Int64)PgSqlConnection.ExecuteScalar(sqlCommand, npgsqlParameter ) > 0;
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            return result;
        }

        /// <summary>
        /// this function will check if there is already an account bound to the current registers email adress
        /// </summary>
        /// <param name="registerController">the current register controller</param>
        /// <returns>wether another account with the same username exists or not</returns>
        public static Boolean CheckEmail(RegisterController registerController)
        {
            String sqlCommand = "SELECT COUNT(*) FROM users.utilizatori WHERE email = :p_email";
            NpgsqlParameter npgsqlParameter = new NpgsqlParameter(":p_email", registerController.Email);
            if (!PgSqlConnection.OpenConnection()) return false;
            Boolean result = (Int64)PgSqlConnection.ExecuteScalar(sqlCommand, npgsqlParameter) > 0;
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            return result;
        }

        /// <summary>
        /// this function will register a new user in the database and then return it
        /// </summary>
        /// <param name="registerController">the register controller for the new user</param>
        /// <returns>the newly added user</returns>
        public static User RegisterUser(RegisterController registerController)
        {
            #region LogAction
            //the action for the log
            String Action = "A fost inregistrat un nou utilizator la adresa de email: " + registerController.Email;
            //First we format the command to register
            String command = String.Format("INSERT INTO users.utilizatori(nume_utilizator,email,parola,nume,prenume) " +
                                    "VALUES({0},{1},{2},{3},{4}) RETURNING *", 
                                    registerController.Username, 
                                    registerController.Email, 
                                    registerController.Password, 
                                    registerController.Surname, 
                                    registerController.Name
                                    );
            //then we will create a new ipFunctions for the httpContextAccessor
            String IP = IPFunctions.GetWANIp();
            #endregion
            //the insert returning command will return a single column based on the new insert
            String queryCommand = "INSERT INTO users.utilizatori(nume_utilizator,email,parola,nume,prenume) " +
                                    "VALUES(:p_username,:p_email,:p_password,:p_surname,:p_name) " +
                                    "RETURNING *";
            //we bind the parameters to the registerController properties
            NpgsqlParameter[] queryParameters =
            {
                new NpgsqlParameter("p_username",registerController.Username),
                new NpgsqlParameter("p_email",registerController.Email),
                new NpgsqlParameter("p_password",registerController.Password),
                new NpgsqlParameter("p_surname",registerController.Surname),
                new NpgsqlParameter("p_name",registerController.Name)
            };
            //if we are unable to connect to the database we return a null object
            //this should never happen since they will be on the same server though better safe than sorry
            if (!PgSqlConnection.OpenConnection()) return null;
            //once done we run the sqlCommand and retrieve the values to a new DataTable
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(queryCommand,queryParameters);
            //once that is done we close the fucking connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            //we will log the current action
            ActionLog.LogAction(Action, IP, command);
            //before initializing a new user from the dataTable
            if (result != null && result.Rows.Count > 0)
                //then finally return the new user
                return new User
                {
                    ID = (Int64)result.Rows[0]["ID"],
                    Username = result.Rows[0]["NUME_UTILIZATOR"].ToString(),
                    Email = result.Rows[0]["EMAIL"].ToString(),
                    Name = result.Rows[0]["PRENUME"].ToString(),
                    Surname = result.Rows[0]["NUME"].ToString()
                };
            else
                return null;
        }
        #endregion
        #region Login Functions
        /// <summary>
        /// this function will check if there is already an account with the current login controllers username or email
        /// </summary>
        /// <param name="registerController">the current login controller</param>
        /// <returns>wether another account with the controllers username or email exists or not</returns>
        public static Boolean CheckUsernameOrEmail(LoginController loginController)
        {
            String sqlCommand = "SELECT COUNT(*) FROM users.utilizatori WHERE nume_utilizator = :p_username OR email = :p_username";
            NpgsqlParameter npgsqlParameter = new NpgsqlParameter(":p_username", loginController.Username);
            if (!PgSqlConnection.OpenConnection()) return false;
            Boolean result = (Int64)PgSqlConnection.ExecuteScalar(sqlCommand, npgsqlParameter) > 0;
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            return result;
        }

        /// <summary>
        /// this function will check if there is an account linked to the email
        /// </summary>
        ///<param name="PasswordLostController">the password lost controller</param>
        /// <returns>wether a account with the controllers email exists or not</returns>
        public static Boolean CheckEmail(PasswordLostController PasswordLostController)
        {
            String sqlCommand = "SELECT COUNT(*) FROM users.utilizatori WHERE email = :p_email";
            NpgsqlParameter npgsqlParameter = new NpgsqlParameter(":p_email", PasswordLostController.Email);
            if (!PgSqlConnection.OpenConnection()) return false;
            Boolean result = (Int64)PgSqlConnection.ExecuteScalar(sqlCommand, npgsqlParameter) > 0;
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            return result;
        }

        /// <summary>
        /// this function will check if a valid account is linked to the username-password or email-password 
        /// </summary>
        /// <param name="loginController">the given login controller</param>
        /// <returns></returns>
        public static Boolean CheckAccountValidity(LoginController loginController)
        {
            String queryCommand = "SELECT COUNT(*) FROM users.utilizatori WHERE (nume_utilizator = :p_username OR email = :p_email) AND parola = :p_password AND activ";
            NpgsqlParameter[] queryParameters =
            {
                new NpgsqlParameter("p_username",loginController.Username),
                new NpgsqlParameter("p_email",loginController.Username),
                new NpgsqlParameter("p_password",loginController.Password)
            };
            if (!PgSqlConnection.OpenConnection()) return false;
            Boolean result = (Int64)PgSqlConnection.ExecuteScalar(queryCommand, queryParameters) > 0;
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            return result;
        }

        /// <summary>
        /// this function will retrieve the account linked to the username-password or email-password
        /// </summary>
        /// <param name="loginController"></param>
        /// <returns></returns>
        public static User RetrieveUser(LoginController loginController)
        {
            String queryCommand = "SELECT * FROM users.utilizatori WHERE (nume_utilizator = :p_username OR email = :p_email) AND parola = :p_password AND activ";
            NpgsqlParameter[] queryParameters =
            {
                new NpgsqlParameter("p_username",loginController.Username),
                new NpgsqlParameter("p_email",loginController.Username),
                new NpgsqlParameter("p_password",loginController.Password)
            };
            if (!PgSqlConnection.OpenConnection()) return null;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(queryCommand, queryParameters);
            //we close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            if (result != null && result.Rows.Count > 0)
                return new User
                {
                    ID = (Int64)result.Rows[0]["ID"],
                    Username = result.Rows[0]["NUME_UTILIZATOR"].ToString(),
                    Email = result.Rows[0]["EMAIL"].ToString(),
                    Name = result.Rows[0]["PRENUME"].ToString(),
                    Surname = result.Rows[0]["NUME"].ToString()
                };
            else
                return null;
        }
        #endregion
        #region Validation Functions
        /// <summary>
        /// this function will retreive a user from the database based on the ID value
        /// </summary>
        /// <param name="id">the id value</param>
        /// <returns>the user retrieved from the database</returns>
        public static User RetrieveUser(Int64 id)
        {
            String queryCommand = "SELECT * FROM users.utilizatori WHERE id = :p_user_id";
            NpgsqlParameter queryParameter = new NpgsqlParameter("p_user_id",id);
            if (!PgSqlConnection.OpenConnection()) return null;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(queryCommand, queryParameter);
            //we close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            if(result != null && result.Rows.Count > 0)
                return new User
                {
                    ID          = (Int64)result.Rows[0]["ID"],
                    Username    = result.Rows[0]["NUME_UTILIZATOR"].ToString(),
                    Email       = result.Rows[0]["EMAIL"].ToString(),
                    Name        = result.Rows[0]["PRENUME"].ToString(),
                    Surname     = result.Rows[0]["NUME"].ToString()
                };
            return null;
        }

        /// <summary>
        /// this function will retreive a user from the database based on the email value
        /// </summary>
        /// <param name="email">the email value</param>
        /// <returns>the user retrieved from the database</returns>
        public static User RetrieveUser(String email)
        {
            String queryCommand = "SELECT * FROM users.utilizatori WHERE email = :p_email";
            NpgsqlParameter queryParameter = new NpgsqlParameter("p_email", email);
            if (!PgSqlConnection.OpenConnection()) return null;
            DataTable result = PgSqlConnection.ExecuteReaderToDataTable(queryCommand, queryParameter);
            //we close the connection
            Miscellaneous.NormalConnectionClose(PgSqlConnection);
            if (result != null && result.Rows.Count > 0)
                return new User
                {
                    ID = (Int64)result.Rows[0]["ID"],
                    Username = result.Rows[0]["NUME_UTILIZATOR"].ToString(),
                    Email = result.Rows[0]["EMAIL"].ToString(),
                    Name = result.Rows[0]["PRENUME"].ToString(),
                    Surname = result.Rows[0]["NUME"].ToString()
                };
            return null;
        }

        /// <summary>
        /// this is the main function for retrieving the sysadmin rigths for a given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>the sysadmin rights</returns>
        public static Boolean CheckAdministratorRights(User user)
        {
            String queryCommand = "SELECT sysadmin FROM users.utilizatori WHERE id = :p_user_id";
            NpgsqlParameter queryParameter = new NpgsqlParameter("p_user_id", user.ID);
            if (! PgSqlConnection.OpenConnection()) return false;
            return (Boolean)PgSqlConnection.ExecuteScalar(queryCommand, queryParameter) ?
                    Miscellaneous.NormalConnectionClose(PgSqlConnection):
                    Miscellaneous.ErrorConnectionClose(PgSqlConnection);
        }
        #endregion
        #region Reset Functions
        /// <summary>
        /// this is the main function for updating the password
        /// </summary>
        /// <param name="user">the user for which we will update the password</param>
        /// <param name="resetPasswordController">the password</param>
        /// <returns>the state of the query</returns>
        public static Boolean UpdatePasswordFunctions(User user, ResetPasswordController resetPasswordController)
        {
            #region LogAction
            //the main Action for the log
            String Action = String.Format("Sa actualizat parola utilizatorului cu emailul {0}",user.Email);
            //the main command format for the log
            String Command = String.Format("UPDATE users.utilizatori SET parola = {0} WHERE id = {1}", resetPasswordController.Password,user.ID);
            //then we will create a new ipFunctions to get the WanIP
            String IP = IPFunctions.GetWANIp();
            #endregion
            //the query string
            String queryCommand = "UPDATE users.utilizatori SET parola = :p_password WHERE id = :p_user_id";
            //the query parameters
            NpgsqlParameter[] queryParamaters =
            {
                new NpgsqlParameter("p_password",resetPasswordController.Password),
                new NpgsqlParameter("p_user_id",user.ID)
            };
            //we attempt to open the connection
            if (!PgSqlConnection.OpenConnection()) return false;
            //we execute the update command
            PgSqlConnection.ExecuteNonQuery(queryCommand, queryParamaters);
            //log the action
            ActionLog.LogAction(Action, Command, IP, PgSqlConnection);
            //before closing the connection
            return Miscellaneous.NormalConnectionClose(PgSqlConnection);
        }
        #endregion
    }
}
