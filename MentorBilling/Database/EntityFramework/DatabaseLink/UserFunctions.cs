using MentorBilling.Database.EntityFramework.MentorBillingEntityFramework;
using MentorBilling.Login.UserControllers;
using MentorBilling.Miscellaneous;
using MentorBilling.MiscellaneousPages.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Database.EntityFramework.DatabaseLink
{
    public class UserFunctions : MentorBillingContext
    {
        #region Registration Functions
        /// <summary>
        /// this function will check if there is already an account with the current register controllers username
        /// </summary>
        /// <param name="registerController">the current register controller</param>
        /// <returns>wether another account with the same username exists or not</returns>
        public Boolean CheckUsername(RegisterController registerController)
        {
            return base.Utilizatori.Any(element => element.NumeUtilizator == registerController.Username);
        }

        /// <summary>
        /// this function will check if there is already an account bound to the current registers email adress
        /// </summary>
        /// <param name="registerController">the current register controller</param>
        /// <returns>wether another account with the same username exists or not</returns>
        public Boolean CheckEmail(RegisterController registerController)
        {
            return base.Utilizatori.Any(element => element.Email == registerController.Email);
        }

        /// <summary>
        /// this function will register a new user in the database and then return it
        /// </summary>
        /// <param name="registerController">the register controller for the new user</param>
        /// <returns>the newly added user</returns>
        public User RegistryUser(RegisterController registerController)
        {
            //we set the log action
            #region LogAction
            //the action for the log
            String Action = "A fost inregistrat un nou utilizator la adresa de email: " + registerController.Email;
            //First we format the command to register
            String Command = String.Format("INSERT INTO users.utilizatori(nume_utilizator,email,parola,nume,prenume) " +
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
            //and generate a new user in order to keep the link active
            Utilizatori utilizatorNou = new Utilizatori()
            {
                NumeUtilizator = registerController.Username,
                Email = registerController.Email,
                Parola = registerController.Password,
                Nume = registerController.Surname,
                Prenume = registerController.Name
            };
            //add the new user to the base controller
            base.Utilizatori.Add(utilizatorNou);
            //log the action
            base.LogActiuni.Add(ActionLog.LogAction(Action, IP, Command));
            //save the changes
            base.SaveChanges();
            //and return a new id
            return new User() { 
                ID = utilizatorNou.Id,
                Username = utilizatorNou.NumeUtilizator,
                Email = utilizatorNou.Email,
                Name = utilizatorNou.Prenume,
                Surname = utilizatorNou.Nume
            };
        }
        #endregion
        #region CheckUsernameOrPassword
        /// <summary>
        /// this function will check if there is already an account with the current login controllers username or email
        /// </summary>
        /// <param name="loginController">the current login controller</param>
        /// <returns>wether another account with the controllers username or email exists or not</returns>
        public Boolean CheckUsernameOrEmail(LoginController loginController)
        {
            return base.Utilizatori.Any(element => element.NumeUtilizator == loginController.Username || element.Email == loginController.Username);
        }

        /// <summary>
        /// this function will check if there is an account linked to the email
        /// </summary>
        ///<param name="PasswordLostController">the password lost controller</param>
        /// <returns>wether a account with the controllers email exists or not</returns>
        public Boolean CheckEmail(PasswordLostController PasswordLostController)
        {
            return base.Utilizatori.Any(element => element.Email == PasswordLostController.Email);
        }

        /// <summary>
        /// this function will check if a valid account is linked to the username-password or email-password 
        /// </summary>
        /// <param name="loginController">the given login controller</param>
        /// <returns>wether there is a user-password or email-password valid combo</returns>
        public Boolean CheckAccountValidity(LoginController loginController)
        {
            return base.Utilizatori.Any(element => (element.NumeUtilizator == loginController.Username
                                            || element.Email == loginController.Username) 
                                            && element.Parola == loginController.Password 
                                            && (element.Activ ?? false));
        }

        /// <summary>
        /// this function will retrieve the account linked to the username-password or email-password
        /// </summary>
        /// <param name="loginController">the given login controller</param>
        /// <returns></returns>
        public User RetrieveUser(LoginController loginController)
        {
            Utilizatori utilizator = base.Utilizatori.Where(element => (element.NumeUtilizator == loginController.Username
                                            || element.Email == loginController.Username)
                                            && element.Parola == loginController.Password
                                            && (element.Activ ?? false)).FirstOrDefault();
            return new User()
            {
                ID = utilizator.Id,
                Username = utilizator.NumeUtilizator,
                Email = utilizator.Email,
                Name = utilizator.Prenume,
                Surname = utilizator.Nume
            };
        }
        #endregion
        #region Validation Functions
        /// <summary>
        /// this function will retreive a user from the database based on the ID value
        /// </summary>
        /// <param name="id">the id value</param>
        /// <returns>the user retrieved from the database</returns>
        public User RetrieveUser(Int64 id)
        {
            Utilizatori utilizator = base.Utilizatori.Where(element => element.Id == id).FirstOrDefault();
            return new User
            {
                ID = utilizator.Id,
                Username = utilizator.NumeUtilizator,
                Email = utilizator.Email,
                Name = utilizator.Prenume,
                Surname = utilizator.Nume
            };
        }

        /// <summary>
        /// this function will retreive a user from the database based on the email value
        /// </summary>
        /// <param name="email">the email value</param>
        /// <returns>the user retrieved from the database</returns>
        public User RetrieveUser(String email)
        {
            Utilizatori utilizator = base.Utilizatori.Where(element => element.Email == email).FirstOrDefault();
            return new User
            {
                ID = utilizator.Id,
                Username = utilizator.NumeUtilizator,
                Email = utilizator.Email,
                Name = utilizator.Prenume,
                Surname = utilizator.Nume
            };
        }

        /// <summary>
        /// this is the main function for retrieving the sysadmin rigths for a given user
        /// </summary>
        /// <param name="user">the given user</param>
        /// <returns>the sysadmin rights</returns>
        public Boolean CheckAdministratorRights(User user)
        {
            return base.Utilizatori.Where(element => element.Id == user.ID).FirstOrDefault().Sysadmin;
        }
        #endregion
        #region Reset Functions
        /// <summary>
        /// this is the main function for updating the password
        /// </summary>
        /// <param name="user">the user for which we will update the password</param>
        /// <param name="resetPasswordController">the password</param>
        /// <returns>the state of the query</returns>
        public void UpdatePassword(User user, ResetPasswordController resetPasswordController)
        {
            #region LogAction
            //the main Action for the log
            String Action = String.Format("Sa actualizat parola utilizatorului cu emailul {0}", user.Email);
            //the main command format for the log
            String Command = String.Format("UPDATE users.utilizatori SET parola = {0} WHERE id = {1}", resetPasswordController.Password, user.ID);
            //then we will create a new ipFunctions to get the WanIP
            String IP = IPFunctions.GetWANIp();
            #endregion
            Utilizatori utilizator = base.Utilizatori.Find(user.ID);
            utilizator.Parola = resetPasswordController.Password;
            base.Update(utilizator);
            base.LogActiuni.Add(ActionLog.LogAction(Action, IP, Command));
            base.SaveChanges();
        }
        #endregion
    }
}
