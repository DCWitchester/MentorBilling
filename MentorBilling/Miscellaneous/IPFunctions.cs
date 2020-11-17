using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace MentorBilling.Miscellaneous
{
    /// <summary>
    /// this class is used to retrieve the ip Adress of the client
    /// </summary>
    public class IPFunctions
    {
        private static readonly String ipURLAdress = "http://checkip.dyndns.org/";
        /// <summary>
        /// we the IHttpContext binds itselt to the browser http settings
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;
        /// <summary>
        /// the initialization of the class
        /// </summary>
        /// <param name="accessor">the newly generated IHttpContextAccessor</param>
        public IPFunctions(IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
        }
        /// <summary>
        /// the GetIP function for the class
        /// </summary>
        /// <returns>the current context ip</returns>
        public String GetIP()
        {
            return httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
        /// <summary>
        /// A secondary method to check the client ip
        /// </summary>
        /// <returns>the current ip adress</returns>
        public static String GetWANIp()
        {
            try
            {
                return (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")).Matches((new WebClient()).DownloadString(ipURLAdress))[0].ToString();
            }
            catch
            {
                return "0.0.0.0";
            }
        }

    }
}
