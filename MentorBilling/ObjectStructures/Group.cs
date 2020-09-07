using MentorBilling.Login.UserControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures
{
    public class Group
    {
        #region Properties 
        /// <summary>
        /// the id property of the group structure
        /// </summary>
        private Int64 id { get; set; } = new Int64();
        /// <summary>
        /// the name of the group structure
        /// </summary>
        private String name { get; set; } = String.Empty;
        //the administrator of the group
        private User administrator { get; set; } = new User();
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
        /// the main caller for the name property
        /// </summary>
        public String Name
        {
            get => name;
            set => name = value;
        }
        ///<summary>
        ///the main caller for the administrator property
        ///</summary>
        public User Administrator
        {
            get => administrator;
            set => administrator = value;
        }
        #endregion
    }
}
