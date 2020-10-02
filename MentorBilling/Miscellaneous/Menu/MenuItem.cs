using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Miscellaneous.Menu
{
    public class MenuItem
    {
        /// <summary>
        /// the Menu Item ID <= Preparation for later
        /// </summary>
        public Int32 MenuItemID { get; set; }
        /// <summary>
        /// the Menu Display used for the interface display 
        /// </summary>
        public String MenuDisplay { get; set; }
        /// <summary>
        /// the menu function called with object list and returning an object
        /// </summary>
        public Func<List<object>,object> MenuFunction { get; set; }
        /// <summary>
        /// the menu action called with the object list and returning an object
        /// </summary>
        public Action MenuAction { get; set; }
        /// <summary>
        /// the menu Enabled Property display
        /// </summary>
        public Boolean IsActive { get; set; }
    }
}
