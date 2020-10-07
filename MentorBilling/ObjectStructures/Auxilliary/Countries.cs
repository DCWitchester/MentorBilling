using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorBilling.ObjectStructures.Auxilliary
{
    public class Countries
    {
#pragma warning disable IDE1006 
        private Int64 id { get; set; } = new Int64();
        private String countryCodeISO2 { get; set; } = String.Empty;
        private String countryCodeISO3 { get; set; } = String.Empty;
        private String countryCodeM49 { get; set; } = String.Empty;
        private String romanianName { get; set; } = String.Empty;
        private String englishName { get; set; } = String.Empty;
#pragma warning restore IDE1006

        public Int64 ID
        {
            get => id;
            set => id = value;
        }

        public String CountryCodeISO2 
        { 
            get => countryCodeISO2; 
            set => countryCodeISO2 = value; 
        }

        public String CountryCodeISO3
        {
            get => countryCodeISO3;
            set => countryCodeISO3 = value;
        }

        public String CountryCodeM49
        {
            get => countryCodeM49;
            set => countryCodeM49 = value;
        }

        public String RomanianName
        {
            get => romanianName;
            set => romanianName = value;
        }

        public String EnglishName
        {
            get => englishName;
            set => englishName = value;
        }

        public String DefaultCode
        {
            get => countryCodeISO2;
            set => countryCodeISO2 = value;
        }

        public String DefaultName
        {
            get => romanianName;
            set => romanianName = value;
        }

        public String DefaultDisplayName
        {
            get => DefaultCode + ":" + DefaultDisplayName;
        }

    }
}
