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
        private Int64 id { get; set; } = new Int64();
        private String username { get; set; } = String.Empty;
        private String email { get; set; } = String.Empty;
        private String name { get; set; } = String.Empty;
        private String surname { get; set; } = String.Empty;
#pragma warning restore IDE1006
        #endregion

        #region Callers
        public Int64 ID
        {
            get => id;
            set => id = value;
        } 

        public String Username
        {
            get => username;
            set => username = value;
        }

        public String Email
        {
            get => email;
            set => email = value;
        }

        public String Name
        {
            get => name;
            set => name = value;
        }

        public String Surname
        {
            get => surname;
            set => surname = value;
        }

        public String DisplayName
        {
            get => surname + " " + name;
        }
        #endregion
    }
}
