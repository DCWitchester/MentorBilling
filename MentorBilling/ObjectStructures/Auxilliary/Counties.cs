using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Auxilliary
{
    public class Counties
    {
#pragma warning disable IDE1006
        private Int64 id { get; set; } = new Int64();
        private String countyCode { get; set; } = String.Empty;
        private String countyName { get; set; } = String.Empty;
#pragma warning restore IDE1006

        public Int64 ID 
        {
            get => id;
            set => id = value;
        }

        public String CountyCode
        {
            get => countyCode;
            set => countyCode = value;
        }

        public String CountyName
        {
            get => countyName;
            set => countyName = value;
        }
    }
}
