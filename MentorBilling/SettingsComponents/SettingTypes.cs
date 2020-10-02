using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Settings
{
    public class SettingTypes
    {
        /// <summary>
        /// the setting dataTypes linked to the settings for casting purpouses
        /// </summary>
        public enum SettingDataTypes
        {
            type_void = 0,  //void      -- error
            type_int = 1,   //Int32     -- Numeric without decimal point
            type_double,    //Double    -- Numeric with decimal point
            type_string,    //String
            type_boolean,   //Boolean
            type_date,      //Date      -- DateTime.Date (Cast to dateTime and take the date property)
            type_time,      //Time      -- DateTime.Time (Cast to dateTime and take the time property)
            type_datetime   //DateTime
        }

        /// <summary>
        /// the setting input types linked to the user input controller type
        /// </summary>
        public enum SettingInputTypes
        {
            type_void = 0,      //void      -- error (Value)
            type_number = 1,    //number    -- linked to the Int32 or Double DataType
            type_text,          //text      -- Base structure
            type_checkbox,      //checkbox  -- the basic
            type_date,          //date      -- linked to DateTime type object ( affects both the date and the time property on input set )
            type_time,          //time      -- linked to DateTime type object ( affects both the date and the time property on input set )
            type_datetime       //datetime  -- linked to DateTime type object ( the current <input type = "datetime"> )
        }
    }
}
