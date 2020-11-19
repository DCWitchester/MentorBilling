using System;

namespace MentorBilling.Database.DatabaseController
{
    public class DatabaseConnectionSettings
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the host property
        /// </summary>
        String host { get; set; } = "192.168.13.130";
        /// <summary>
        /// the port property
        /// </summary>
        String port { get; set; } = "5432";
        /// <summary>
        /// the database property
        /// </summary>
        String database { get; set; } = "MentorData";
        /// <summary>
        /// the userID property
        /// </summary>
        String userId { get; set; } = "postgres";
        /// <summary>
        /// the password property
        /// </summary>
        String password { get; set; } = "pgsql";
#pragma warning restore IDE1006
        #endregion
        #region Public Callers
        /// <summary>
        /// the caller for the host property
        /// </summary>
        public String Host
        {
            get => host;
            set => host = value;
        }
        /// <summary>
        /// the caller for the port property
        /// </summary>
        public String Port
        {
            get => port;
            set => port = value;
        }
        /// <summary>
        /// the caller for the database property
        /// </summary>
        public String Database
        {
            get => database;
            set => database = value;
        }
        /// <summary>
        /// the caller for the userID property
        /// </summary>
        public String UserID
        {
            get => userId;
            set => userId = value;
        }
        /// <summary>
        /// the caller for the password property
        /// </summary>
        public String Password
        {
            get => password;
            set => password = value;
        }
        #endregion
        /// <summary>
        /// this function will reunite the class properties into a valid npgsql ConnectionString
        /// </summary>
        public void RebuiltConnectionString()
        {
            ConnectionString = "Host = " + host + ";Port = " + port + ";Database = " + database + ";User Id = " + userId + ";Password = " + password;
        }
        /// <summary>
        /// the main connection string for the class instance
        /// </summary>
        public String ConnectionString { get; private set; } = String.Empty;
        public String CurrentConnectionString
        {
            get => "Host = " + host + ";Port = " + port + ";Database = " + database + ";User Id = " + userId + ";Password = " + password;
        }
        /// <summary>
        /// the main constructor for the class will initialize the connection string with the default preoperties
        /// </summary>
        public DatabaseConnectionSettings()
        {
            RebuiltConnectionString();
        }

        public static String DefaultConnectionString { get; set; } = "Host = 5.2.228.239; Port = 26662; Database = MentorData; User Id = postgres; Password = pgsql";
    }
}
