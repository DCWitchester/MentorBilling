using MentorBilling.Database.DatabaseController;
using System;

namespace MentorBilling.Database.DatabaseLink
{
    public class Miscellaneous
    {
        #region Connection Close Function
        /// <summary>
        /// the main function for closing a connection on success
        /// </summary>
        /// <returns>true</returns>
        public static Boolean NormalConnectionClose(PostgreSqlConnection DatabaseConnection)
        {
            DatabaseConnection.CloseConnection();
            return true;
        }
        /// <summary>
        /// the main function dor closing a connection on error
        /// </summary>
        /// <returns>false</returns>
        public static Boolean ErrorConnectionClose(PostgreSqlConnection DatabaseConnection)
        {
            DatabaseConnection.CloseConnection();
            return false;
        }
        #endregion
    }
}
