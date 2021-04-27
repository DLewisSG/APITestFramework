using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;

namespace API_App
{
    public class SinglePostcodeService
    {
        #region Properties
        //RestSharp object which handles communication with the API
        public RestClient Client;
        //Restsharp response
        public IRestResponse RestResponse { get; set; }

        //NewtonSoft object representing the JSON response
        public JObject ResponseContent { get; set; }
        //the postcode used in this API request
        public string PostcodeSelected { get; set; }
        #endregion

        // constructor - creates restClient object
        public SinglePostcodeService()
        {
            Client = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }

        public void MakeRequest(string postcode)
        {
            // set up request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            PostcodeSelected = postcode;

            //define request resource path, changing to lowercase and removing whitespace
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";

            //make request
           RestResponse = Client.Execute(request);

            // parse Json into a JObject
            ResponseContent = JObject.Parse(RestResponse.Content);
        }
    }
}
