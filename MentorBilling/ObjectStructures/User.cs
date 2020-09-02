using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Login.UserControllers
{
    public class User
    {
        #region Properties
#pragma warning disable IDE1006
        /// <summary>
        /// the id property of the user structure
        /// </summary>
        private Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the username property of the user structure
        /// </summary>
        private String username { get; set; } = String.Empty;
        /// <summary>
        /// the email property of the user structure
        /// </summary>
        private String email { get; set; } = String.Empty;
        /// <summary>
        /// the name property of the user structure
        /// </summary>
        private String name { get; set; } = String.Empty;
        /// <summary>
        /// the surname property of the surname structure
        /// </summary>
        private String surname { get; set; } = String.Empty;
#pragma warning restore IDE1006
        #endregion

        #region Callers
        /// <summary>
        /// the main caller for the id property
        /// </summary>
        public Int64 ID
        {
            get => id;
            set => id = value;
        } 

        /// <summary>
        /// the main caller for the username property
        /// </summary>
        public String Username
        {
            get => username;
            set => username = value;
        }

        /// <summary>
        /// the main caller for the email property
        /// </summary>
        public String Email
        {
            get => email;
            set => email = value;
        }

        /// <summary>
        /// the main caller for the name property
        /// </summary>
        public String Name
        {
            get => name;
            set => name = value;
        }

        /// <summary>
        /// the main caller for the surname property
        /// </summary>
        public String Surname
        {
            get => surname;
            set => surname = value;
        }

        /// <summary>
        /// the caller for the display name
        /// </summary>
        public String DisplayName
        {
            get => String.IsNullOrWhiteSpace(surname) && String.IsNullOrWhiteSpace(name) ? username : surname + " " + name;
        }
        #endregion
    }
}
