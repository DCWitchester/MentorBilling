using System;

namespace MentorBilling.Miscellaneous.ANAF
{
    /// <summary>
    /// this will contain a given company item
    /// </summary>
    public class Company
    {
        public String Cui                   { get; set; }
        public String Name                  { get; set; }
        public CompanyStatus CompanyStatus  { get; set; }
        public String Address                { get; set; }
        public String County                { get; set; }
        public String Country               { get; set; }
        public DateTime LastUpdate          { get; set; }
    }
}
