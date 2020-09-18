using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MentorBilling.Miscellaneous.ANAF
{
    public class AnafGet
    {
        /*
        /// <summary>
        /// the webservice link to the ANAF Api
        /// </summary>
        private static String anaf_ws = "https://webservicesp.anaf.ro";
        /// <summary>
        /// the Web method parameter
        /// </summary>
        private static String anaf_ws_platitor_tva = "PlatitorTvaRest/api/v3/ws/tva";
        */

        private static String anaf_ws = "https://webservicesp.anaf.ro";
        private static String[] anaf_ws_platitor_tva = new string[]
                                                       { "PlatitorTvaRest/api/v4/ws/tva" };


        #region ERROR Codes
        private static String input_error_code = "600"; //input invalid code
        private static String notfound_error_code = "601"; //not found error code
        private static String queryfailed_error_code = "602";//query failed error code
        #endregion

        /*
        /// <summary>
        /// this function will retrieve the the details for a society based on a CUI
        /// </summary>
        /// <param name="cui">the CUI passed as a parameter</param>
        /// <returns>the state of the connection</returns>
        private static String AnafGetCui(String cui)
        {
            //we check if we were pasted a cui and if it is valid
            if (String.IsNullOrEmpty(cui) || !ElementCheck.VerifyCIF(cui))
            {
                //if it isn't we retrurn the error code
                return input_error_code + ",input_empty_cui";
            }
            //if not we initialize a new client over the the web service
            RestClient client = new RestClient(anaf_ws);
            //with the client we also need to initialize a new request over the parameter and the post
            RestRequest request = new RestRequest(anaf_ws_platitor_tva, Method.POST);
            //we set the request format to JSON
            request.RequestFormat = DataFormat.Json;
            //and preset the date
            String date = DateTime.Now.ToString("yyyy-MM-dd");
            //finally we create the request parameters
            //the parameter needs to be a JSON value containing the date of the request and the CUI
            String req = ""; 
            req += String.Format(@"{{'cui': {1}, 'data':'{0}'}}", date, cui);
            //we repair the string value
            req = req.Replace("'", "\"");
            //and finally we finish the format
            req = "[" + req + "]";
            //before placing them to the request
            request.AddParameter("application/json", req, ParameterType.RequestBody);
            //we retrieve the API response
            IRestResponse data = client.Execute(request);
            //and return the JSON content of the response
            return data.Content;
        }
        */

        public static String AnafGetCui(String cui, DateTime dateTime)
        {
            //we check if we were pasted a cui and if it is valid
            if (String.IsNullOrEmpty(cui) || !ElementCheck.VerifyCIF(cui))
            {
                return String.Empty;
            }
            //if not we initialize a new client over the the web service
            RestClient client = new RestClient(anaf_ws);
            //with the client we also need to initialize a new request over the parameter and the post
            RestRequest request = new RestRequest(anaf_ws_platitor_tva[0], Method.POST)
            {
                //we set the request format to JSON
                RequestFormat = DataFormat.Json
            };
            //and preset the date format
            String date = dateTime.ToString("yyyy-MM-dd");
            //finally we create the request parameters
            //the parameter needs to be a JSON value containing the date of the request and the CUI
            String req = "";
            req += String.Format(@"{{'cui': {1}, 'data':'{0}'}}", date, cui);
            //we repair the string value
            req = req.Replace("'", "\"");
            //and finally we finish the format
            req = "[" + req + "]";
            //before placing them to the request
            request.AddParameter("application/json", req, ParameterType.RequestBody);
            //we retrieve the API response
            IRestResponse data = client.Execute(request);
            //and return the JSON content of the response
            return data.Content;
        }

        /// <summary>
        /// this function will convert a datetime from the anaf format to normal DateTime
        /// </summary>
        /// <param name="AnafDate">the anaf date passed as sting</param>
        /// <returns>the datetime equivalent</returns>
        private static DateTime ConvertAnafDate(String AnafDate)
        {
            //we split the string into an array
            String[] stringArray = AnafDate.Split('-');
            //then convert it into a normal DateTime
            return new DateTime(Convert.ToInt32(stringArray[0]), Convert.ToInt32(stringArray[1]), Convert.ToInt32(stringArray[2]));
        }

        /// <summary>
        /// the function will calculate the maximum date from the json object list
        /// </summary>
        /// <param name="objectList">the jObject List</param>
        /// <returns>the maximum date time</returns>
        private static DateTime LastAlterationDate(List<JObject> objectList)
        {
            //we initialize a dateTime object list
            List<DateTime> dates = new List<DateTime>();
            //then one by one add all date elements to the list to get the maximum value for the element
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("data_inceput_ScpTVA")))     dates.Add(ConvertAnafDate(objectList[0].Value<String>("data_inceput_ScpTVA")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("data_sfarsit_ScpTVA")))     dates.Add(ConvertAnafDate(objectList[0].Value<String>("data_sfarsit_ScpTVA")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("data_anul_imp_ScpTVA")))    dates.Add(ConvertAnafDate(objectList[0].Value<String>("data_anul_imp_ScpTVA")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("dataInceputTvaInc")))       dates.Add(ConvertAnafDate(objectList[0].Value<String>("dataInceputTvaInc")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("dataSfarsitTvaInc")))       dates.Add(ConvertAnafDate(objectList[0].Value<String>("dataSfarsitTvaInc")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("dataActualizareTvaInc")))   dates.Add(ConvertAnafDate(objectList[0].Value<String>("dataActualizareTvaInc")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("dataPublicareTvaInc")))     dates.Add(ConvertAnafDate(objectList[0].Value<String>("dataPublicareTvaInc")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("dataInactivare")))          dates.Add(ConvertAnafDate(objectList[0].Value<String>("dataInactivare")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("dataReactivare")))          dates.Add(ConvertAnafDate(objectList[0].Value<String>("dataReactivare")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("dataPublicare")))           dates.Add(ConvertAnafDate(objectList[0].Value<String>("dataPublicare")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("dataRadiere")))             dates.Add(ConvertAnafDate(objectList[0].Value<String>("dataRadiere")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("dataInceputSplitTVA")))     dates.Add(ConvertAnafDate(objectList[0].Value<String>("dataInceputSplitTVA")));
            if (!String.IsNullOrWhiteSpace(objectList[0].Value<String>("dataAnulareSplitTVA")))     dates.Add(ConvertAnafDate(objectList[0].Value<String>("dataAnulareSplitTVA")));
            return dates.Max();
        }

        /// <summary>
        /// this procedure will return a JSON of all data from ANAF based on the firm CUI
        /// </summary>
        /// <param name="cui">the CUI of the firm passed as string</param>
        /// <returns> all the colected info </returns>
        private static String GetByCui(String cui)
        {
            JObject jObject = new JObject();
            String result = AnafGetCui(cui,DateTime.Now);
            if (result.StartsWith(input_error_code))
            {
                String[] error = result.Split(',');
                return JsonConvert.SerializeObject(new Error(error[0], error[1]), Formatting.Indented);
            }
            if (result.Contains("\"cod\":200") && result.Contains("\"message\":\"SUCCESS\""))
            {
                JObject json = JObject.Parse(result);
                List<JObject> foundObjects = json.Value<JArray>("found").ToObject<List<JObject>>();
                if (foundObjects.Count == 0)
                {
                    return JsonConvert.SerializeObject(new Error(notfound_error_code, "not_found_cui"));
                }
                return JsonConvert.SerializeObject(new Company()
                {
                    Cui = foundObjects[0].Value<String>("cui"),
                    Name = !String.IsNullOrEmpty(foundObjects[0].Value<String>("denumire")) ? foundObjects[0].Value<String>("denumire") : " ",
                    CompanyStatus = new CompanyStatus()
                    {
                        VAT_Applicable = foundObjects[0].Value<bool>("scpTVA"),
                        VAT_Buyout = foundObjects[0].Value<bool>("statusTvaIncasare"),
                        Inactiv = foundObjects[0].Value<bool>("statusInactivi"),
                        VAT_Split = foundObjects[0].Value<bool>("statusSplitTVA")
                    },
                    Adress = !String.IsNullOrEmpty(foundObjects[0].Value<String>("adresa")) ? foundObjects[0].Value<String>("adresa") : " ",
                    County = !String.IsNullOrEmpty(foundObjects[0].Value<String>("adresa")) ? foundObjects[0].Value<String>("adresa").Substring(0, foundObjects[0].Value<String>("adresa").IndexOf(',')).Split(' ')[1] : " ",
                    Country = "Romania",
                    LastUpdate = LastAlterationDate(foundObjects)
                }); ;
            }
            return JsonConvert.SerializeObject(new Error(queryfailed_error_code, "query_failed"));
        }

        /// <summary>
        /// this function will retrieve a Company object from anaf based on the given CIF
        /// </summary>
        /// <param name="CUI">the given CIF</param>
        /// <returns>A company Structure</returns>
        public static Company GetANAFCompany(String CUI)
        {
            try {
                return JsonConvert.DeserializeObject<Company>(GetByCui(CUI));
            } catch { 
                return new Company();
            }
        }

    }
}
