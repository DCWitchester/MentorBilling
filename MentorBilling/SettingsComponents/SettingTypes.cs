﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.Settings
{
    public class SettingTypes
    {
        public enum SettingDataTypes
        {
            type_void = 0,
            type_int = 1,
            type_double,
            type_string,
            type_boolean,
            type_date,
            type_time,
            type_datetime
        }

        public enum SettingInputTypes
        {
            type_void = 0,
            type_number = 1,
            type_text,
            type_checkbox,
            type_date,
            type_time,
            type_datetime
        }
    }
}